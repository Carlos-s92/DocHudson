using System;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows;
using System.util;
using TestGit.Custom;

namespace CustomControls.RJControls
{
    public class RJDatePicker : DateTimePicker
    {
        private bool preventDropDown = true;

        //Fields
        //-> Appearance
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 0;

        //-> Other Values
        private bool droppedDown = false;
        private Image calendarIcon = TestGit.Properties.Resources.calendarWhite;
        private RectangleF iconButtonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;

        //Properties
        public Color SkinColor
        {
            get { return skinColor; }
            set
            {
                skinColor = value;
                if (skinColor.GetBrightness() >= 0.6F)
                    calendarIcon = TestGit.Properties.Resources.calendarDark;
                else calendarIcon = TestGit.Properties.Resources.calendarWhite;
                this.Invalidate();
            }
        }

        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                this.Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        //Constructor
        public RJDatePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new System.Drawing.Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5F);
        }

        //Overridden methods
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            using (Pen penBorder = new Pen(borderColor, borderSize))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat textFormat = new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width - 0.5F, this.Height - 0.5F);
                RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0, calendarIconWidth, clientArea.Height);
                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;

                //Draw surface
                graphics.FillRectangle(skinBrush, clientArea);
                //Draw text
                graphics.DrawString("   " + this.Text, this.Font, textBrush, clientArea, textFormat);
                //Draw open calendar icon highlight
                if (droppedDown == true) graphics.FillRectangle(openIconBrush, iconArea);
                //Draw border 
                if (borderSize >= 1) graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
                //Draw icon
                graphics.DrawImage(calendarIcon, this.Width - calendarIcon.Width - 9, (this.Height - calendarIcon.Height) / 2);

            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (iconButtonArea.Contains(e.Location))
                this.Cursor = Cursors.Hand;
            else this.Cursor = Cursors.Default;
        }

        //Private methods
        private int GetIconButtonWidth()
        {
            int textWidh = TextRenderer.MeasureText(this.Text, this.Font).Width;
            if (textWidh <= this.Width - (calendarIconWidth + 20))
                return calendarIconWidth;
            else return arrowIconWidth;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Si el clic fue sobre el icono del calendario
            if (iconButtonArea.Contains(e.Location))
            {
                ShowCustomCalendar();
            }
        }

        private void ShowCustomCalendar()
        {
            // Verificamos si ya existe un Panel calendario abierto
            Control existingPanel = this.Parent.Controls["calendarPanel"];
            if (existingPanel != null)
            {
                this.Parent.Controls.RemoveByKey("calendarPanel");
                existingPanel.Dispose();
                return;
            }

            // Crear panel que contendrá el calendario
            Panel calendarPanel = new Panel();
            calendarPanel.Name = "calendarPanel";
            calendarPanel.Size = new System.Drawing.Size(291, 191); // Tamaño fijo que vos querés
            calendarPanel.BackColor = Color.White;
            calendarPanel.BorderStyle = BorderStyle.FixedSingle;

            // Posicionarlo justo debajo del RJDatePicker
            System.Drawing.Point locationOnParent = this.Parent.PointToClient(this.PointToScreen(System.Drawing.Point.Empty));
            calendarPanel.Location = new System.Drawing.Point(locationOnParent.X, locationOnParent.Y + this.Height);

            // Crear e insertar el UserControl
            userCalendar calendarControl = new userCalendar();

            calendarControl.FechaSeleccionada += (s, fechaSeleccionada) =>
            {
                this.Text = fechaSeleccionada.ToString("dd/MM/yyyy");
                this.Value = fechaSeleccionada;
                this.Parent.Controls.RemoveByKey("calendarPanel");
            };

            calendarControl.Dock = DockStyle.Fill;
            calendarPanel.Controls.Add(calendarControl);

            // Agregar el panel al mismo contenedor del DatePicker
            this.Parent.Controls.Add(calendarPanel);
            calendarPanel.BringToFront();
        }


        private const int WM_LBUTTONDOWN = 0x0201;
        private const int DTM_FIRST = 0x1000;
        private const int DTM_CLOSEMONTHCAL = DTM_FIRST + 13;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN && preventDropDown)
            {
                if (iconButtonArea.Contains(PointToClient(Cursor.Position)))
                {
                    ShowCustomCalendar();
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private DateTime _selectedDate = DateTime.Now;
        public new DateTime Value
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                this.Text = value.ToString("dd/MM/yyyy");
            }
        }
    }
}
