namespace Biyahe.UI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class RoundedTextBox : UserControl
    {
        // ── Inner TextBox ───────────────────────────────────────────────
        private TextBox innerTextBox;

        // ── Corner Radii ────────────────────────────────────────────────
        private int cornerRadiusTopLeft = 15;
        private int cornerRadiusTopRight = 15;
        private int cornerRadiusBottomLeft = 15;
        private int cornerRadiusBottomRight = 15;

        // ── Colors ──────────────────────────────────────────────────────
        private Color borderColor = Color.FromArgb(180, 180, 180);
        private Color focusBorderColor = Color.FromArgb(52, 152, 219);
        private Color backgroundColor = Color.White;
        private int borderThickness = 2;

        // ── State ───────────────────────────────────────────────────────
        private bool isFocused = false;

        public RoundedTextBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            innerTextBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = backgroundColor,
                Font = new Font("Segoe UI", 10F),
                Dock = DockStyle.None,
            };

            innerTextBox.GotFocus += (s, e) => { isFocused = true; Invalidate(); };
            innerTextBox.LostFocus += (s, e) => { isFocused = false; Invalidate(); };
            innerTextBox.TextChanged += (s, e) => OnTextChanged(e);

            this.Controls.Add(innerTextBox);
            this.Size = new Size(200, 40);
            this.DoubleBuffered = true;
            this.Cursor = Cursors.IBeam;
            this.Padding = new Padding(8, 0, 8, 0);

            // Clicking anywhere on the control focuses the inner textbox
            this.Click += (s, e) => innerTextBox.Focus();
        }

        // ── Corner Properties ───────────────────────────────────────────

        [Category("Appearance")]
        [Description("Radius of top-left corner (0-50)")]
        [DefaultValue(15)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusTopLeft
        {
            get { return cornerRadiusTopLeft; }
            set { cornerRadiusTopLeft = Clamp(value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Radius of top-right corner (0-50)")]
        [DefaultValue(15)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusTopRight
        {
            get { return cornerRadiusTopRight; }
            set { cornerRadiusTopRight = Clamp(value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Radius of bottom-left corner (0-50)")]
        [DefaultValue(15)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusBottomLeft
        {
            get { return cornerRadiusBottomLeft; }
            set { cornerRadiusBottomLeft = Clamp(value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Radius of bottom-right corner (0-50)")]
        [DefaultValue(15)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusBottomRight
        {
            get { return cornerRadiusBottomRight; }
            set { cornerRadiusBottomRight = Clamp(value); Invalidate(); }
        }

        // ── Style Properties ────────────────────────────────────────────

        [Category("Appearance")]
        [Description("Border color when unfocused")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Border color when focused")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color FocusBorderColor
        {
            get { return focusBorderColor; }
            set { focusBorderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Background fill color")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                innerTextBox.BackColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Thickness of the border in pixels")]
        [DefaultValue(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderThickness
        {
            get { return borderThickness; }
            set { borderThickness = Math.Max(1, value); Invalidate(); }
        }

        // ── TextBox Pass-through Properties ────────────────────────────

        [Category("Behavior")]
        [Description("Password masking character. Set to * or • to hide input")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public char PasswordChar
        {
            get { return innerTextBox.PasswordChar; }
            set { innerTextBox.PasswordChar = value; }
        }

        [Category("Behavior")]
        [Description("Maximum number of characters allowed")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int MaxLength
        {
            get { return innerTextBox.MaxLength; }
            set { innerTextBox.MaxLength = value; }
        }

        [Category("Appearance")]
        [Description("Placeholder/hint text shown when empty")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PlaceholderText
        {
            get { return innerTextBox.PlaceholderText; }
            set { innerTextBox.PlaceholderText = value; }
        }

        public override string Text
        {
            get { return innerTextBox.Text; }
            set { innerTextBox.Text = value; }
        }

        public override Font Font
        {
            get { return innerTextBox.Font; }
            set { innerTextBox.Font = value; RepositionInnerTextBox(); }
        }

        public override Color ForeColor
        {
            get { return innerTextBox.ForeColor; }
            set { innerTextBox.ForeColor = value; }
        }

        // ── Layout ──────────────────────────────────────────────────────

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RepositionInnerTextBox();
            UpdateRegion();
        }

        private void RepositionInnerTextBox()
        {
            int pad = borderThickness + 12;
            int textHeight = innerTextBox.PreferredHeight;

            innerTextBox.SetBounds(
                pad,
                (this.Height - textHeight) / 2,
                this.Width - pad * 2,
                textHeight
            );
        }

        private void UpdateRegion()
        {
            GraphicsPath path = GetRoundPath(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            try
            {
                using (path = GetRoundPath(ClientRectangle))
                {
                    if (this.Region != null)
                        this.Region.Dispose();

                    this.Region = new Region(path);
                }
            }
            catch { }
        }

        // ── Paint ───────────────────────────────────────────────────────

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(
                borderThickness / 2,
                borderThickness / 2,
                this.Width - borderThickness,
                this.Height - borderThickness
            );

            GraphicsPath path = GetRoundPath(rect);

            // Background fill
            using (SolidBrush brush = new SolidBrush(backgroundColor))
                e.Graphics.FillPath(brush, path);

            // Border — switches color on focus
            Color activeBorder = isFocused ? focusBorderColor : borderColor;
            using (Pen pen = new Pen(activeBorder, borderThickness))
                e.Graphics.DrawPath(pen, path);
        }

        private GraphicsPath GetRoundPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();

            int tl = SafeRadius(cornerRadiusTopLeft, rect);
            int tr = SafeRadius(cornerRadiusTopRight, rect);
            int br = SafeRadius(cornerRadiusBottomRight, rect);
            int bl = SafeRadius(cornerRadiusBottomLeft, rect);

            // Top-left
            if (tl > 0)
                path.AddArc(rect.X, rect.Y, tl * 2, tl * 2, 180, 90);
            else
                path.AddLine(rect.X, rect.Y, rect.X, rect.Y);

            // Top-right
            if (tr > 0)
                path.AddArc(rect.Right - tr * 2, rect.Y, tr * 2, tr * 2, 270, 90);
            else
                path.AddLine(rect.Right, rect.Y, rect.Right, rect.Y);

            // Bottom-right
            if (br > 0)
                path.AddArc(rect.Right - br * 2, rect.Bottom - br * 2, br * 2, br * 2, 0, 90);
            else
                path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom);

            // Bottom-left
            if (bl > 0)
                path.AddArc(rect.X, rect.Bottom - bl * 2, bl * 2, bl * 2, 90, 90);
            else
                path.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom);

            path.CloseFigure();
            return path;
        }

        private int SafeRadius(int radius, Rectangle rect)
        {
            int max = Math.Min(rect.Width, rect.Height) / 2;
            return Math.Min(radius, max);
        }

        private int Clamp(int value) => Math.Max(0, Math.Min(50, value));
    }
}