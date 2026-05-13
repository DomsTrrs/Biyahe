namespace Biyahe.UI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public class RoundComboBox : UserControl
    {
        private Label lblText;
        private Panel pnlArrow;
        private ListBox lstItems;
        private Form dropDownForm;

        private bool droppedDown = false;

        private int cornerRadius = 15;

        private Color borderColor =
            Color.FromArgb(120, 255, 255, 255);

        private Color glassTintColor =
            Color.FromArgb(40, 255, 255, 255);

        private Color glassShineColor =
            Color.FromArgb(70, 255, 255, 255);

        private Color textColor = Color.White;

        private bool useGlassmorphism = true;

        private int blurStrength = 4;

        private object dataSource;
        private string displayMember;
        private string valueMember;

        public object DataSource
        {
            get => dataSource;
            set
            {
                dataSource = value;
                RefreshData();
            }
        }

        public string DisplayMember
        {
            get => displayMember;
            set
            {
                displayMember = value;
                RefreshData();
            }
        }

        public string ValueMember
        {
            get => valueMember;
            set => valueMember = value;
        }

        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Content)]
        public ListBox.ObjectCollection Items
            => lstItems.Items;

        [Category("Appearance")]
        public override string Text
        {
            get => lblText.Text;
            set => lblText.Text = value;
        }

        [Category("Appearance")]
        [DefaultValue(15)]
        public int CornerRadius
        {
            get => cornerRadius;
            set
            {
                cornerRadius = Math.Max(1, value);
                UpdateRegion();
                Invalidate();
            }
        }

        [Category("Glass")]
        [DefaultValue(true)]
        public bool UseGlassmorphism
        {
            get => useGlassmorphism;
            set
            {
                useGlassmorphism = value;
                Invalidate();
            }
        }

        [Category("Glass")]
        public Color GlassTintColor
        {
            get => glassTintColor;
            set
            {
                glassTintColor = value;
                Invalidate();
            }
        }

        [Category("Glass")]
        public Color GlassShineColor
        {
            get => glassShineColor;
            set
            {
                glassShineColor = value;
                Invalidate();
            }
        }

        [Category("Glass")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                lblText.ForeColor = value;
                lstItems.ForeColor = value;
                Invalidate();
            }
        }

        [Category("Glass")]
        [DefaultValue(4)]
        public int BlurStrength
        {
            get => blurStrength;
            set
            {
                blurStrength = Math.Max(0,
                    Math.Min(10, value));

                Invalidate();
            }
        }

        public int SelectedIndex
        {
            get => lstItems.SelectedIndex;
            set
            {
                lstItems.SelectedIndex = value;

                if (value >= 0)
                    lblText.Text =
                        lstItems.Items[value].ToString();
            }
        }

        public object SelectedItem =>
            lstItems.SelectedItem;

        public event EventHandler SelectedIndexChanged;

        public RoundComboBox()
        {
            DoubleBuffered = true;

            Size = new Size(200, 40);

            BackColor = Color.Transparent;

            lblText = new Label();
            pnlArrow = new Panel();
            lstItems = new ListBox();

            lblText.Dock = DockStyle.Fill;
            lblText.TextAlign =
                ContentAlignment.MiddleLeft;

            lblText.Padding = new Padding(12, 0, 0, 0);

            lblText.ForeColor = textColor;

            lblText.BackColor = Color.Transparent;

            pnlArrow.Dock = DockStyle.Right;
            pnlArrow.Width = 40;
            pnlArrow.BackColor = Color.Transparent;

            lstItems.BorderStyle = BorderStyle.None;

            lstItems.BackColor =
                Color.FromArgb(35, 35, 35);

            lstItems.ForeColor = textColor;

            lstItems.Font = Font;

            Controls.Add(lblText);
            Controls.Add(pnlArrow);

            lblText.Click += ToggleDropDown;
            pnlArrow.Click += ToggleDropDown;

            lstItems.Click += ListItemClicked;

            UpdateRegion();
        }

        private bool IsInDesignMode =>
            LicenseManager.UsageMode ==
            LicenseUsageMode.Designtime ||
            DesignMode;

        private void RefreshData()
        {
            if (dataSource == null)
                return;

            lstItems.Items.Clear();

            foreach (var item in (System.Collections.IEnumerable)dataSource)
            {
                if (!string.IsNullOrEmpty(displayMember))
                {
                    var prop = item.GetType().GetProperty(displayMember);

                    if (prop != null)
                    {
                        lstItems.Items.Add(prop.GetValue(item));
                    }
                    else
                    {
                        lstItems.Items.Add(item);
                    }
                }
                else
                {
                    lstItems.Items.Add(item);
                }
            }
        }

        public object SelectedValue
        {
            get
            {
                if (lstItems.SelectedIndex < 0 || dataSource == null)
                    return null;

                var list = (System.Collections.IList)dataSource;
                var item = list[lstItems.SelectedIndex];

                if (string.IsNullOrEmpty(valueMember))
                    return item;

                var prop = item.GetType().GetProperty(valueMember);

                return prop?.GetValue(item);
            }
        }

        private void ToggleDropDown(
            object sender,
            EventArgs e)
        {
            if (droppedDown)
                CloseDropDown();
            else
                OpenDropDown();
        }

        private void OpenDropDown()
        {
            if (droppedDown)
                return;

            droppedDown = true;

            dropDownForm = new Form();

            dropDownForm.FormBorderStyle =
                FormBorderStyle.None;

            dropDownForm.ShowInTaskbar = false;

            dropDownForm.StartPosition =
                FormStartPosition.Manual;

            dropDownForm.BackColor =
                Color.FromArgb(30, 30, 30);

            dropDownForm.Size =
                new Size(Width, 150);

            Point location =
                Parent.PointToScreen(Location);

            dropDownForm.Location =
                new Point(
                    location.X,
                    location.Y + Height + 2);

            lstItems.Dock = DockStyle.Fill;

            dropDownForm.Controls.Add(lstItems);

            dropDownForm.Deactivate +=
                (s, e) => CloseDropDown();

            dropDownForm.Show();
        }

        private void CloseDropDown()
        {
            if (!droppedDown)
                return;

            droppedDown = false;

            if (dropDownForm != null)
            {
                dropDownForm.Close();
                dropDownForm.Dispose();
                dropDownForm = null;
            }
        }

        private void ListItemClicked(
            object sender,
            EventArgs e)
        {
            if (lstItems.SelectedIndex >= 0)
            {
                lblText.Text =
                    lstItems.SelectedItem.ToString();

                SelectedIndexChanged?.Invoke(
                    this,
                    EventArgs.Empty);
            }

            CloseDropDown();
        }

        protected override void OnPaint(
            PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            Rectangle rect =
                new Rectangle(
                    0,
                    0,
                    Width - 1,
                    Height - 1);

            using (GraphicsPath path = GetRoundPath(rect))
            {
                g.SetClip(path);

                bool isWebView = AcrylicRenderer.IsWebViewHost(Parent);

                // =========================
                // BACKGROUND (NEW SYSTEM)
                // =========================

                if (!IsInDesignMode && Parent != null)
                {
                    if (!isWebView && useGlassmorphism)
                    {
                        // Optional: you can still keep soft blur for normal UI
                        using (Bitmap snap = CaptureParent())
                        using (Bitmap blur = BlurBitmap(snap))
                        {
                            g.DrawImage(blur, rect);
                        }
                    }
                    else
                    {
                        // WebView-safe acrylic fallback
                        AcrylicRenderer.DrawAcrylic(
                            g,
                            rect,
                            glassTintColor,
                            glassShineColor);
                    }
                }

                g.ResetClip();

                // =========================
                // GLASS TINT
                // =========================

                using (SolidBrush tint =
                       new SolidBrush(
                           glassTintColor))
                {
                    g.FillPath(tint, path);
                }

                // =========================
                // SHINE
                // =========================

                Rectangle shineRect =
                    new Rectangle(
                        0,
                        0,
                        Width,
                        Height / 2);

                using (LinearGradientBrush shine =
                       new LinearGradientBrush(
                           shineRect,
                           glassShineColor,
                           Color.Transparent,
                           LinearGradientMode.Vertical))
                {
                    g.FillRectangle(
                        shine,
                        shineRect);
                }

                g.ResetClip();

                // =========================
                // BORDER
                // =========================

                using (Pen pen =
                       new Pen(borderColor, 1.5f))
                {
                    g.DrawPath(pen, path);
                }

                // =========================
                // ARROW
                // =========================

                Point middle =
                    new Point(
                        Width - 20,
                        Height / 2);

                Point[] arrow =
                {
                    new Point(
                        middle.X - 5,
                        middle.Y - 3),

                    new Point(
                        middle.X + 5,
                        middle.Y - 3),

                    new Point(
                        middle.X,
                        middle.Y + 4)
                };

                using (SolidBrush brush =
                       new SolidBrush(textColor))
                {
                    g.FillPolygon(
                        brush,
                        arrow);
                }
            }
        }

        private Bitmap CaptureParent()
        {
            Bitmap bmp =
                new Bitmap(Width, Height);

            using (Graphics g =
                   Graphics.FromImage(bmp))
            {
                g.TranslateTransform(
                    -Left,
                    -Top);

                PaintEventArgs pea =
                    new PaintEventArgs(
                        g,
                        new Rectangle(
                            Left,
                            Top,
                            Width,
                            Height));

                InvokePaintBackground(
                    Parent,
                    pea);

                InvokePaint(
                    Parent,
                    pea);
            }

            return bmp;
        }

        private Bitmap BlurBitmap(Bitmap src)
        {
            // lightweight "softening" instead of fake blur loop
            Bitmap result = new Bitmap(src.Width, src.Height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(src, 0, 0, src.Width, src.Height);
            }

            return result;
        }

        private GraphicsPath GetRoundPath(
            Rectangle rect)
        {
            GraphicsPath path =
                new GraphicsPath();

            int d = cornerRadius * 2;

            path.AddArc(
                rect.X,
                rect.Y,
                d,
                d,
                180,
                90);

            path.AddArc(
                rect.Right - d,
                rect.Y,
                d,
                d,
                270,
                90);

            path.AddArc(
                rect.Right - d,
                rect.Bottom - d,
                d,
                d,
                0,
                90);

            path.AddArc(
                rect.X,
                rect.Bottom - d,
                d,
                d,
                90,
                90);

            path.CloseFigure();

            return path;
        }

        private void UpdateRegion()
        {
            using (GraphicsPath path =
                   GetRoundPath(ClientRectangle))
            {
                Region = new Region(path);
            }
        }

        protected override void OnResize(
            EventArgs e)
        {
            base.OnResize(e);

            UpdateRegion();

            Invalidate();
        }
    }
}