using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Biyahe.UI
{
    [ToolboxItem(true)]
    public class RadioButton : Button
    {
        private int cornerRadiusTopLeft = 15;
        private int cornerRadiusTopRight = 15;
        private int cornerRadiusBottomLeft = 15;
        private int cornerRadiusBottomRight = 15;

        private bool isSelected = false;
        private Color selectedColor = Color.FromArgb(52, 152, 219);
        private Color unselectedColor = Color.FromArgb(230, 230, 230);
        private Color hoverColor = Color.FromArgb(245, 245, 245);
        private Color selectedTextColor = Color.White;
        private Color unselectedTextColor = Color.FromArgb(100, 100, 100);
        private Color glowColor = Color.FromArgb(100, Color.White);

        private Image buttonImage = null;
        private ImageLayout buttonImageLayout = ImageLayout.Center;

        public RadioButton()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer,
            true);

            UpdateStyles();


            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = unselectedColor;
            this.ForeColor = unselectedTextColor;
            this.Size = new Size(120, 45);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            UpdateRegion();
        }

        // ── Corner Radius ────────────────────────────────────────────────────

        [Category("Rounded Corners")]
        [Description("Radius of top-left corner (0-30)")]
        [DefaultValue(15)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusTopLeft
        {
            get { return cornerRadiusTopLeft; }
            set { cornerRadiusTopLeft = Clamp(value); Invalidate(); UpdateRegion(); }
        }

        [Category("Rounded Corners")]
        [Description("Radius of top-right corner (0-30)")]
        [DefaultValue(15)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusTopRight
        {
            get { return cornerRadiusTopRight; }
            set { cornerRadiusTopRight = Clamp(value); Invalidate(); UpdateRegion(); }
        }

        [Category("Rounded Corners")]
        [Description("Radius of bottom-left corner (0-30)")]
        [DefaultValue(15)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusBottomLeft
        {
            get { return cornerRadiusBottomLeft; }
            set { cornerRadiusBottomLeft = Clamp(value); Invalidate(); UpdateRegion(); }
        }

        [Category("Rounded Corners")]
        [Description("Radius of bottom-right corner (0-30)")]
        [DefaultValue(15)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusBottomRight
        {
            get { return cornerRadiusBottomRight; }
            set { cornerRadiusBottomRight = Clamp(value); Invalidate(); UpdateRegion(); }
        }

        // ── Toggle Appearance ────────────────────────────────────────────────

        [Category("Toggle Appearance")]
        [Description("Is this radio button selected")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; UpdateAppearance(); DeselectOthers(); }
        }

        [Category("Toggle Appearance")]
        [Description("Background color when selected")]
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; UpdateAppearance(); }
        }

        [Category("Toggle Appearance")]
        [Description("Background color when unselected")]
        public Color UnselectedColor
        {
            get { return unselectedColor; }
            set { unselectedColor = value; UpdateAppearance(); }
        }

        [Category("Toggle Appearance")]
        [Description("Hover color (unselected only)")]
        public Color HoverColor
        {
            get { return hoverColor; }
            set { hoverColor = value; }
        }

        [Category("Toggle Appearance")]
        [Description("Text color when selected")]
        public Color SelectedTextColor
        {
            get { return selectedTextColor; }
            set { selectedTextColor = value; UpdateAppearance(); }
        }

        [Category("Toggle Appearance")]
        [Description("Text color when unselected")]
        public Color UnselectedTextColor
        {
            get { return unselectedTextColor; }
            set { unselectedTextColor = value; UpdateAppearance(); }
        }

        [Category("Toggle Appearance")]
        [Description("Glow color when selected")]
        public Color GlowColor
        {
            get { return glowColor; }
            set { glowColor = value; Invalidate(); }
        }

        // ── Image ────────────────────────────────────────────────────────────

        [Category("Image")]
        [Description("Image displayed on the button")]
        [DefaultValue(null)]
        public Image ButtonImage
        {
            get { return buttonImage; }
            set { buttonImage = value; Invalidate(); }
        }

        [Category("Image")]
        [Description("How the image is displayed: None, Center, Stretch, Zoom, or Tile")]
        [DefaultValue(ImageLayout.Center)]
        public ImageLayout ButtonImageLayout
        {
            get { return buttonImageLayout; }
            set { buttonImageLayout = value; Invalidate(); }
        }

        // ── Drawing ──────────────────────────────────────────────────────────

        private bool isHovered = false;

        private void UpdateAppearance()
        {
            BackColor = isSelected ? selectedColor : isHovered ? hoverColor : unselectedColor;
            ForeColor = isSelected ? selectedTextColor : unselectedTextColor;
            Invalidate();
        }

        private void DeselectOthers()
        {
            if (Parent == null) return;
            foreach (RadioButton control in Parent.Controls.OfType<RadioButton>())
            {
                if (control != this)
                {
                    control.isSelected = false;
                    control.UpdateAppearance();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = ClientRectangle;
            GraphicsPath path = GetRoundPath(rect);

            using (SolidBrush brush = new SolidBrush(BackColor))
                g.FillPath(brush, path);

            if (buttonImage != null)
                DrawImage(g, rect, buttonImage, buttonImageLayout);

            DrawTextWithShadow(g, rect);
        }

        private void DrawImage(Graphics g, Rectangle rect, Image img, ImageLayout layout)
        {
            switch (layout)
            {
                case ImageLayout.Stretch:
                    g.DrawImage(img, rect);
                    break;

                case ImageLayout.Zoom:
                    float scale = Math.Min((float)rect.Width / img.Width, (float)rect.Height / img.Height);
                    int zoomW = (int)(img.Width * scale);
                    int zoomH = (int)(img.Height * scale);
                    g.DrawImage(img, rect.X + (rect.Width - zoomW) / 2, rect.Y + (rect.Height - zoomH) / 2, zoomW, zoomH);
                    break;

                case ImageLayout.Tile:
                    for (int y = rect.Y; y < rect.Bottom; y += img.Height)
                        for (int x = rect.X; x < rect.Right; x += img.Width)
                            g.DrawImage(img, x, y, img.Width, img.Height);
                    break;

                case ImageLayout.None:
                    g.DrawImage(img, rect.X, rect.Y, img.Width, img.Height);
                    break;

                default: // Center
                    g.DrawImage(img, rect.X + (rect.Width - img.Width) / 2, rect.Y + (rect.Height - img.Height) / 2, img.Width, img.Height);
                    break;
            }
        }

        private void DrawCheckmark(Graphics g, Rectangle rect)
        {
            using (Pen pen = new Pen(Color.White, 3f))
                g.DrawLines(pen, new[] {
                    new Point(rect.Width / 3,     rect.Height / 2),
                    new Point(rect.Width / 2,     rect.Height * 2 / 3),
                    new Point(rect.Width * 3 / 4, rect.Height / 3)
                });
        }

        private void DrawTextWithShadow(Graphics g, Rectangle rect)
        {
            Size sz = TextRenderer.MeasureText(Text, Font);
            Point pt = new Point((rect.Width - sz.Width) / 2, (rect.Height - sz.Height) / 2);

            TextRenderer.DrawText(g, Text, Font, new Point(pt.X + 1, pt.Y + 1),
                Color.FromArgb(60, Color.Black),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            TextRenderer.DrawText(g, Text, Font, pt, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // ── Helpers ──────────────────────────────────────────────────────────

        private GraphicsPath GetRoundPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();

            int tl = SafeRadius(cornerRadiusTopLeft, rect);
            if (tl > 0) path.AddArc(rect.X, rect.Y, tl * 2, tl * 2, 180, 90);
            else path.AddLine(rect.X, rect.Y, rect.X, rect.Y);

            int tr = SafeRadius(cornerRadiusTopRight, rect);
            if (tr > 0) path.AddArc(rect.Right - tr * 2, rect.Y, tr * 2, tr * 2, 270, 90);
            else path.AddLine(rect.Right, rect.Y, rect.Right, rect.Y);

            int br = SafeRadius(cornerRadiusBottomRight, rect);
            if (br > 0) path.AddArc(rect.Right - br * 2, rect.Bottom - br * 2, br * 2, br * 2, 0, 90);
            else path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom);

            int bl = SafeRadius(cornerRadiusBottomLeft, rect);
            if (bl > 0) path.AddArc(rect.X, rect.Bottom - bl * 2, bl * 2, bl * 2, 90, 90);
            else path.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom);

            path.CloseFigure();
            return path;
        }

        private int SafeRadius(int radius, Rectangle rect)
            => Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2);

        private int Clamp(int value) => Math.Max(0, Math.Min(30, value));

        private void UpdateRegion()
        {
            try
            {
                using (GraphicsPath path = GetRoundPath(ClientRectangle))
                {
                    if (this.Region != null)
                        this.Region.Dispose();

                    this.Region = new Region(path);
                }
            }
            catch { }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Prevent background flicker
        }

        protected override void OnResize(EventArgs e) { UpdateRegion(); base.OnResize(e); }
        protected override void OnClick(EventArgs e) { IsSelected = true; base.OnClick(e); }
        protected override void OnMouseEnter(EventArgs e) { isHovered = true; UpdateAppearance(); }
        protected override void OnMouseLeave(EventArgs e) { isHovered = false; UpdateAppearance(); }
    }
}