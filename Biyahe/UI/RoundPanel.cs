namespace Biyahe.UI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class RoundedPanel : Panel
    {
        private int cornerRadiusTopLeft = 20;
        private int cornerRadiusTopRight = 20;
        private int cornerRadiusBottomLeft = 20;
        private int cornerRadiusBottomRight = 20;
        private Color panelColor = Color.LightBlue;

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

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundPath(ClientRectangle))
            using (Pen pen = new Pen(Color.FromArgb(120, Color.Black), 2))
            {
                // Only fill if not transparent
                if (panelColor.A > 0)
                {
                    using (SolidBrush brush = new SolidBrush(panelColor))
                        e.Graphics.FillPath(brush, path);
                }

                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();

            // Top-left
            int tl = SafeRadius(cornerRadiusTopLeft, rect);
            if (tl > 0)
                path.AddArc(rect.X, rect.Y, tl * 2, tl * 2, 180, 90);
            else
                path.AddLine(rect.X, rect.Y, rect.X, rect.Y);

            // Top-right
            int tr = SafeRadius(cornerRadiusTopRight, rect);
            if (tr > 0)
                path.AddArc(rect.Right - tr * 2, rect.Y, tr * 2, tr * 2, 270, 90);
            else
                path.AddLine(rect.Right, rect.Y, rect.Right, rect.Y);

            // Bottom-right
            int br = SafeRadius(cornerRadiusBottomRight, rect);
            if (br > 0)
                path.AddArc(rect.Right - br * 2, rect.Bottom - br * 2, br * 2, br * 2, 0, 90);
            else
                path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom);

            // Bottom-left
            int bl = SafeRadius(cornerRadiusBottomLeft, rect);
            if (bl > 0)
                path.AddArc(rect.X, rect.Bottom - bl * 2, bl * 2, bl * 2, 90, 90);
            else
                path.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom);

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
            if (panelColor.A == 0 && Parent != null)
            {
                var g = e.Graphics;
                g.TranslateTransform(-Left, -Top);
                try
                {
                    using (var args = new PaintEventArgs(g, new Rectangle(Left, Top, Width, Height)))
                    {
                        InvokePaintBackground(Parent, args);
                        InvokePaint(Parent, args);
                    }
                }
                finally { g.ResetTransform(); }
            }
            else
            {
                using (var brush = new SolidBrush(panelColor))
                    e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            if (BackgroundImage != null)
                DrawBackgroundImageManual(e.Graphics);
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
                this.Region?.Dispose();
                this.Region = new Region(path);
            }
        }
    }
}