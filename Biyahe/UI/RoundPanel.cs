namespace Biyahe.UI
{

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

    public class RoundedPanel : Panel
    {
        private int cornerRadius = 20;
        private Color panelColor = Color.LightBlue;

        [Category("Appearance")]
        [Description("Radius of rounded corners (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get { return cornerRadius; }
            set { cornerRadius = Math.Max(0, Math.Min(50, value)); Invalidate(); }
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
            // Solid color fill
            using (SolidBrush brush = new SolidBrush(panelColor))
            {
                GraphicsPath path = GetRoundPath(ClientRectangle, cornerRadius);
                e.Graphics.FillPath(brush, path);
            }

            // Border
            using (Pen pen = new Pen(Color.FromArgb(120, Color.Black), 2))
            {
                GraphicsPath path = GetRoundPath(ClientRectangle, cornerRadius);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            int r2 = radius * 2;
            if (r2 > Math.Min(rect.Width, rect.Height))
                r2 = Math.Min(rect.Width, rect.Height);

            GraphicsPath path = new GraphicsPath();
            Rectangle arc = new Rectangle(rect.X, rect.Y, r2, r2);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - r2;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - r2;
            path.AddArc(arc, 0, 90);
            arc.X = rect.X;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}