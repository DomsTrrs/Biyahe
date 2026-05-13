using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Biyahe.UI
{
    public class RoundComboBox : UserControl
    {
        private Label lblText = new Label();
        private Panel pnlArrow = new Panel();
        private Form dropDownForm;
        private ListBox dropList = new ListBox();

        private bool droppedDown = false;

        private object dataSource;
        private string displayMember;
        private string valueMember;

        private int cornerRadius = 12;

        public event EventHandler SelectedIndexChanged;

        public RoundComboBox()
        {
            Height = 40;
            Width = 200;
            BackColor = Color.White;

            lblText.Dock = DockStyle.Fill;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(10, 0, 0, 0);

            pnlArrow.Dock = DockStyle.Right;
            pnlArrow.Width = 40;

            Controls.Add(lblText);
            Controls.Add(pnlArrow);

            lblText.Click += ToggleDropDown;
            pnlArrow.Click += ToggleDropDown;

            dropList.BorderStyle = BorderStyle.None;
            dropList.Dock = DockStyle.Fill;
            dropList.Font = Font;

            dropList.Click += DropList_Click;
        }

        // =========================
        // DATA BINDING (LIKE COMBOBOX)
        // =========================

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
                dropList.DisplayMember = value ?? string.Empty;
                RefreshData();
            }
        }

        public string ValueMember
        {
            get => valueMember;
            set
            {
                valueMember = value;
                dropList.ValueMember = value ?? string.Empty;
            }
        }

        private void RefreshData()
        {
            dropList.Items.Clear();
            dropList.DisplayMember = displayMember ?? string.Empty;
            dropList.ValueMember = valueMember ?? string.Empty;

            if (dataSource is IEnumerable list)
            {
                foreach (var item in list)
                {
                    dropList.Items.Add(item);
                }
            }
        }

        // =========================
        // SELECTION (REAL OBJECT)
        // =========================

        public object SelectedItem => dropList.SelectedItem;

        public int SelectedIndex
        {
            get => dropList.SelectedIndex;
            set
            {
                dropList.SelectedIndex = value;
                UpdateText();
            }
        }

        public object SelectedValue
        {
            get
            {
                if (SelectedItem == null || string.IsNullOrEmpty(valueMember))
                    return SelectedItem;

                var prop = SelectedItem.GetType().GetProperty(valueMember);
                return prop?.GetValue(SelectedItem);
            }
        }

        private void UpdateText()
        {
            if (SelectedItem == null)
            {
                lblText.Text = "";
                return;
            }

            if (!string.IsNullOrEmpty(displayMember))
            {
                var prop = SelectedItem.GetType().GetProperty(displayMember);
                lblText.Text = prop?.GetValue(SelectedItem)?.ToString();
            }
            else
            {
                lblText.Text = SelectedItem.ToString();
            }
        }

        // =========================
        // DROPDOWN LOGIC
        // =========================

        private void ToggleDropDown(object sender, EventArgs e)
        {
            if (droppedDown)
                CloseDropDown();
            else
                OpenDropDown();
        }

        private void OpenDropDown()
        {
            if (dropDownForm != null)
            {
                if (dropDownForm.Visible)
                {
                    return;
                }
            }

            droppedDown = true;

            dropDownForm = new Form();
            dropDownForm.FormBorderStyle = FormBorderStyle.None;
            dropDownForm.StartPosition = FormStartPosition.Manual;
            dropDownForm.ShowInTaskbar = false;
            dropDownForm.Size = new Size(Width, 150);

            Point location = Parent.PointToScreen(Location);
            dropDownForm.Location = new Point(location.X, location.Y + Height);

            dropDownForm.Controls.Add(dropList);

            dropDownForm.Show();
        }

        private void CloseDropDown()
        {
            droppedDown = false;

            if (dropDownForm != null)
            {
                dropDownForm.Controls.Remove(dropList);
                dropDownForm.Close();
                dropDownForm.Dispose();
                dropDownForm = null;
            }
        }

        private void DropList_Click(object sender, EventArgs e)
        {
            UpdateText();

            CloseDropDown();

            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }


        // =========================
        // UI (ROUNDED)
        // =========================

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = GetRoundPath(rect))
            using (Pen pen = new Pen(Color.Gray, 1.5f))
            {
                g.DrawPath(pen, path);
            }

            // Arrow
            Point mid = new Point(Width - 20, Height / 2);

            Point[] arrow =
            {
                new Point(mid.X - 5, mid.Y - 3),
                new Point(mid.X + 5, mid.Y - 3),
                new Point(mid.X, mid.Y + 4)
            };

            using (SolidBrush b = new SolidBrush(Color.Black))
            {
                g.FillPolygon(b, arrow);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            int d = cornerRadius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}