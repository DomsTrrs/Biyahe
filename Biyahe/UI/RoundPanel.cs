namespace Biyahe.UI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public class RoundedPanel : Panel
    {
        private int cornerRadiusTopLeft = 20;
        private int cornerRadiusTopRight = 20;
        private int cornerRadiusBottomLeft = 20;
        private int cornerRadiusBottomRight = 20;
        private Color panelColor = Color.LightBlue;

        private bool useGlassmorphism = false;

        private Color glassTintColor =
            Color.FromArgb(50, 255, 255, 255);

        private Color glassBorderColor =
            Color.FromArgb(120, 255, 255, 255);

        private Color glassShineColor =
            Color.FromArgb(80, 255, 255, 255);

        private int blurStrength = 4;

        [Category("Appearance")]
        [Description("Radius of top-left corner (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusTopLeft
        {
            get { return cornerRadiusTopLeft; }
            set { cornerRadiusTopLeft = Clamp(value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Radius of top-right corner (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusTopRight
        {
            get { return cornerRadiusTopRight; }
            set { cornerRadiusTopRight = Clamp(value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Radius of bottom-left corner (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusBottomLeft
        {
            get { return cornerRadiusBottomLeft; }
            set { cornerRadiusBottomLeft = Clamp(value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Radius of bottom-right corner (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusBottomRight
        {
            get { return cornerRadiusBottomRight; }
            set { cornerRadiusBottomRight = Clamp(value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Background color of panel")]
        [DefaultValue(typeof(Color), "LightBlue")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color PanelColor
        {
            get { return panelColor; }
            set { panelColor = value; Invalidate(); }
        }

        [Category("Glass")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color GlassBorderColor
        {
            get => glassBorderColor;
            set
            {
                glassBorderColor = value;
                Invalidate();
            }
        }

        [Category("Glass")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
        [DefaultValue(4)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BlurStrength
        {
            get => blurStrength;
            set
            {
                blurStrength = Math.Max(0, Math.Min(10, value));
                Invalidate();
            }
        }

        public RoundedPanel()
        {
            DoubleBuffered = true;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer,
            true);

            UpdateStyles();

        }

        private bool IsInDesignMode =>
           LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
           DesignMode;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundPath(ClientRectangle))
            {
                if (useGlassmorphism)
                    PaintGlass(g, path);
                else
                    PaintNormal(g, path);
            }
        }

        private void PaintNormal(Graphics g, GraphicsPath path)
        {
            using (SolidBrush brush = new SolidBrush(panelColor))
                g.FillPath(brush, path);

            using (Pen pen =
                   new Pen(Color.FromArgb(120, Color.Black), 2))
            {
                g.DrawPath(pen, path);
            }
        }

        private void PaintGlass(Graphics g, GraphicsPath path)
        {
            Rectangle rect = ClientRectangle;

            g.SetClip(path);

            bool isWebView = AcrylicRenderer.IsWebViewHost(Parent);

            if (!IsInDesignMode && Parent != null)
            {
                if (!isWebView && blurStrength > 0)
                {
                    using (Bitmap snap = CaptureParent())
                    using (Bitmap blur = BlurBitmap(snap))
                    {
                        g.DrawImage(blur, rect);
                    }
                }
                else
                {
                    AcrylicRenderer.DrawAcrylic(
                        g,
                        rect,
                        glassTintColor,
                        glassShineColor);
                }
            }

            g.ResetClip();

            using (Pen pen = new Pen(glassBorderColor, 1.5f))
            {
                g.DrawPath(pen, path);
            }
        }

        private Bitmap CaptureParent()
        {
            Bitmap bmp = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TranslateTransform(-Left, -Top);

                PaintEventArgs pea =
                    new PaintEventArgs(
                        g,
                        new Rectangle(
                            Left,
                            Top,
                            Width,
                            Height));

                InvokePaintBackground(Parent, pea);
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

        private GraphicsPath GetRoundPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();

            int tl = SafeRadius(cornerRadiusTopLeft, rect);
            int tr = SafeRadius(cornerRadiusTopRight, rect);
            int bl = SafeRadius(cornerRadiusBottomLeft, rect);
            int br = SafeRadius(cornerRadiusBottomRight, rect);

            // Move to start point (top-left after arc position)
            path.StartFigure();

            // Top side line
            path.AddLine(rect.X + tl, rect.Y, rect.Right - tr, rect.Y);

            // Top-right arc
            if (tr > 0)
                path.AddArc(rect.Right - tr * 2, rect.Y, tr * 2, tr * 2, 270, 90);

            // Right side line
            path.AddLine(rect.Right, rect.Y + tr, rect.Right, rect.Bottom - br);

            // Bottom-right arc
            if (br > 0)
                path.AddArc(rect.Right - br * 2, rect.Bottom - br * 2, br * 2, br * 2, 0, 90);

            // Bottom side line
            path.AddLine(rect.Right - br, rect.Bottom, rect.X + bl, rect.Bottom);

            // Bottom-left arc
            if (bl > 0)
                path.AddArc(rect.X, rect.Bottom - bl * 2, bl * 2, bl * 2, 90, 90);

            // Left side line
            path.AddLine(rect.X, rect.Bottom - bl, rect.X, rect.Y + tl);

            // Top-left arc
            if (tl > 0)
                path.AddArc(rect.X, rect.Y, tl * 2, tl * 2, 180, 90);

            path.CloseFigure();
            return path;
        }

        // Prevents radius from being larger than half the panel size
        private int SafeRadius(int radius, Rectangle rect)
        {
            int max = Math.Min(rect.Width, rect.Height) / 2;
            return Math.Min(radius, max);
        }

        private int Clamp(int value) => Math.Max(0, Math.Min(50, value));

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (useGlassmorphism && Parent != null)
            {
                // Glass effect - paint parent background clipped to our region
               
                g.TranslateTransform(-Left, -Top);

                using (GraphicsPath path = GetRoundPath(ClientRectangle))
                {
                    g.SetClip(path, CombineMode.Intersect);
                    try
                    {
                        PaintEventArgs pea = new PaintEventArgs(g, ClientRectangle);
                        InvokePaintBackground(Parent, pea);
                        InvokePaint(Parent, pea);
                    }
                    finally
                    {
                        g.ResetClip();
                        g.ResetTransform();
                    }
                }
            }

            if (BackgroundImage != null)
            {
                DrawBackgroundImageManual(g);
            }
        }

        private void DrawBackgroundImageManual(Graphics g)
        {
            Image img = BackgroundImage;
            Rectangle rect = ClientRectangle;

            switch (BackgroundImageLayout)
            {
                case ImageLayout.None:
                    g.DrawImage(img, 0, 0, img.Width, img.Height);
                    break;

                case ImageLayout.Tile:
                    using (var tb = new TextureBrush(img, WrapMode.Tile))
                        g.FillRectangle(tb, rect);
                    break;

                case ImageLayout.Center:
                    int cx = (rect.Width - img.Width) / 2;
                    int cy = (rect.Height - img.Height) / 2;
                    g.DrawImage(img, cx, cy, img.Width, img.Height);
                    break;

                case ImageLayout.Stretch:
                    g.DrawImage(img, rect);
                    break;

                case ImageLayout.Zoom:
                    float scale = Math.Min((float)rect.Width / img.Width, (float)rect.Height / img.Height);
                    int zw = (int)(img.Width * scale);
                    int zh = (int)(img.Height * scale);
                    int zx = (rect.Width - zw) / 2;
                    int zy = (rect.Height - zh) / 2;
                    g.DrawImage(img, zx, zy, zw, zh);
                    break;
            }
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateRegion();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
            Invalidate();
        }

        private void UpdateRegion()
        {
            if (ClientRectangle.Width <= 0 || ClientRectangle.Height <= 0) return;

            using (GraphicsPath path = GetRoundPath(ClientRectangle))
            {
                Region = new Region(path);
            }
        }
    }
}