namespace Biyahe.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing.Drawing2D;
    using System.Text;

    public class RoundedButton : Button
    {
        private int borderRadius = 20;

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.FromArgb(52, 152, 219); // Default blue
            this.ForeColor = Color.White;
            this.Size = new Size(120, 40);
        }


        [Category("Appearance")]
        [Description("Radius of rounded corners (0-50)")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; this.Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            // Create rounded rectangle path
            path.AddArc(rect.X, rect.Y, borderRadius * 2, borderRadius * 2, 180, 90);
            path.AddArc(rect.Width - borderRadius * 2, rect.Y, borderRadius * 2, borderRadius * 2, 270, 90);
            path.AddArc(rect.Width - borderRadius * 2, rect.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            path.AddArc(rect.X, rect.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            // Fill background
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }

            // Draw border
            using (Pen borderPen = new Pen(Color.FromArgb(40, Color.Black), 1))
            {
                pevent.Graphics.DrawPath(borderPen, path);
            }

            // Draw text
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font,
                new Point((this.Width - TextRenderer.MeasureText(this.Text, this.Font).Width) / 2,
                         (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2),
                this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            base.OnPaint(pevent);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.FromArgb(41, 128, 185); // Darker on hover
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 152, 219); // Original color
            base.OnMouseLeave(e);
        }
    }
}
