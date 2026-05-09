using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Biyahe.UI
{
    [ToolboxItem(true)]
    public class RoundedButton : Button
    {
        private int cornerRadiusTopLeft = 20;
        private int cornerRadiusTopRight = 20;
        private int cornerRadiusBottomLeft = 20;
        private int cornerRadiusBottomRight = 20;

        private Color normalColor = Color.FromArgb(52, 152, 219);
        private Color hoverColor = Color.FromArgb(41, 128, 185);

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = normalColor;
            this.ForeColor = Color.White;
            this.Size = new Size(120, 40);
            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer,
            true);

            UpdateStyles();

        }

        [Category("Rounded Corners")]
        [Description("Radius of top-left corner (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusTopLeft
        {
            get { return cornerRadiusTopLeft; }
            set { cornerRadiusTopLeft = Clamp(value); Invalidate(); UpdateRegion(); }
        }

        [Category("Rounded Corners")]
        [Description("Radius of top-right corner (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusTopRight
        {
            get { return cornerRadiusTopRight; }
            set { cornerRadiusTopRight = Clamp(value); Invalidate(); UpdateRegion(); }
        }

        [Category("Rounded Corners")]
        [Description("Radius of bottom-left corner (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusBottomLeft
        {
            get { return cornerRadiusBottomLeft; }
            set { cornerRadiusBottomLeft = Clamp(value); Invalidate(); UpdateRegion(); }
        }

        [Category("Rounded Corners")]
        [Description("Radius of bottom-right corner (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadiusBottomRight
        {
            get { return cornerRadiusBottomRight; }
            set { cornerRadiusBottomRight = Clamp(value); Invalidate(); UpdateRegion(); }
        }

        [Category("Appearance")]
        [Description("Normal background color")]
        public Color NormalColor
        {
            get { return normalColor; }
            set { normalColor = value; if (!IsHovered) BackColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Hover background color")]
        public Color HoverColor
        {
            get { return hoverColor; }
            set { hoverColor = value; Invalidate(); }
        }

        private bool isHovered = false;
        private bool IsHovered
        {
            get { return isHovered; }
            set { isHovered = value; BackColor = value ? hoverColor : normalColor; }
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

            // Use rect (Rectangle) not Point — centering flags only work with a Rectangle
            Rectangle shadowRect = rect;
            shadowRect.Offset(1, 1);
            TextRenderer.DrawText(g, Text, Font, shadowRect,
                Color.FromArgb(80, Color.Black),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);

            TextRenderer.DrawText(g, Text, Font, rect,
                ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }

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
        {
            int max = Math.Min(rect.Width, rect.Height) / 2;
            return Math.Min(radius, max);
        }

        private int Clamp(int value) => Math.Max(0, Math.Min(50, value));

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

        protected override void OnResize(EventArgs e)
        {
            UpdateRegion();
            base.OnResize(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            IsHovered = true;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            IsHovered = false;
            base.OnMouseLeave(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            this.ForeColor = Enabled ? Color.White : Color.Gray;
            base.OnEnabledChanged(e);
        }
    }
}