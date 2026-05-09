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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = GetRoundPath(ClientRectangle);

            // Clip region so child controls don't bleed outside rounded corners
            this.Region = new Region(path);

            // Solid color fill
            using (SolidBrush brush = new SolidBrush(panelColor))
                e.Graphics.FillPath(brush, path);

            // Border
            using (Pen pen = new Pen(Color.FromArgb(120, Color.Black), 2))
                e.Graphics.DrawPath(pen, path);
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
    }
}