namespace Biyahe.UI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class RadioButton : Button
    {
        private bool isSelected = false;
        private Color selectedColor = Color.FromArgb(52, 152, 219);
        private Color unselectedColor = Color.FromArgb(230, 230, 230);
        private Color selectedTextColor = Color.White;
        private Color unselectedTextColor = Color.FromArgb(100, 100, 100);
        private int borderRadius = 15;

        public RadioButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = unselectedColor;
            this.ForeColor = unselectedTextColor;
            this.Size = new Size(120, 45);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.Cursor = Cursors.Hand;
        }

        [Browsable(true)]

        [Category("Toggle Appearance")]
        [Description("Is this button currently selected")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                UpdateAppearance();
            }
        }

        [Browsable(true)]

        [Category("Toggle Appearance")]
        [Description("Background color when selected")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; UpdateAppearance(); }
        }

        [Browsable(true)]

        [Category("Toggle Appearance")]
        [Description("Background color when unselected")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color UnselectedColor
        {
            get { return unselectedColor; }
            set { unselectedColor = value; UpdateAppearance(); }
        }

        private void UpdateAppearance()
        {
            if (isSelected)
            {
                this.BackColor = selectedColor;
                this.ForeColor = selectedTextColor;
            }
            else
            {
                this.BackColor = unselectedColor;
                this.ForeColor = unselectedTextColor;
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            // Rounded corners
            path.AddArc(rect.X, rect.Y, borderRadius * 2, borderRadius * 2, 180, 90);
            path.AddArc(rect.Width - borderRadius * 2, rect.Y, borderRadius * 2, borderRadius * 2, 270, 90);
            path.AddArc(rect.Width - borderRadius * 2, rect.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            path.AddArc(rect.X, rect.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            // Background
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }

            // Border
            using (Pen borderPen = new Pen(Color.FromArgb(200, Color.Gray), 1))
            {
                pevent.Graphics.DrawPath(borderPen, path);
            }

            // Selection indicator (top glow)
            if (isSelected)
            {
                using (SolidBrush glowBrush = new SolidBrush(Color.FromArgb(100, Color.White)))
                {
                    Rectangle glowRect = new Rectangle(2, 2, this.Width - 4, 4);
                    pevent.Graphics.FillRectangle(glowBrush, glowRect);
                }
            }

            // Text
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font,
                new Point((this.Width - TextRenderer.MeasureText(this.Text, this.Font).Width) / 2,
                         (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2),
                this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            base.OnPaint(pevent);
        }

        protected override void OnClick(EventArgs e)
        {
            // Toggle this button
            this.IsSelected = !this.IsSelected;

            // Deselect ALL other ToggleSelectButtons on the form
            foreach (Control control in this.Parent.Controls)
            {
                if (control is RadioButton && control != this)
                {
                    ((RadioButton)control).IsSelected = false;
                }
            }

            base.OnClick(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (!isSelected)
                this.BackColor = Color.FromArgb(245, 245, 245);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            UpdateAppearance();
            base.OnMouseLeave(e);
        }
    }
}
