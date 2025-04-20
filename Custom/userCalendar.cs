using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGit.Custom
{
    public partial class userCalendar : UserControl
    {
        private DateTime currentDate = DateTime.Today;

        private enum SelectorActivo { Ninguno, Mes, Año }
        private SelectorActivo selectorActivo = SelectorActivo.Ninguno;

        Boolean isOpen = false;

        public userCalendar()
        {
            InitializeComponent();
            establecerFecha();
        }

        private void establecerFecha()
        {
            LMonthYear.Text = currentDate.ToString("MMMM yyyy", new CultureInfo("es-ES"));
            CargarDias();
        }

        private void BArrowLeft_Click(object sender, EventArgs e)
        {
            switch (selectorActivo)
            {
                case SelectorActivo.Mes:
                    currentDate = currentDate.AddYears(-1);

                    LMonthYear.Text = currentDate.Year.ToString();

                    foreach (Control ctrl in PFontCalendar.Controls)
                    {
                        if (ctrl is userMonthSelector mesSelector)
                        {
                            break;
                        }
                    }
                    break;

                case SelectorActivo.Año:
                    currentDate = currentDate.AddYears(-12);
                    ActualizarSelectorAnios();
                    break;

                default:
                    currentDate = currentDate.AddMonths(-1);
                    establecerFecha();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (selectorActivo)
            {
                case SelectorActivo.Mes:
                    currentDate = currentDate.AddYears(1);

                    LMonthYear.Text = currentDate.Year.ToString();

                    foreach (Control ctrl in PFontCalendar.Controls)
                    {
                        if (ctrl is userMonthSelector mesSelector)
                        {
                            break;
                        }
                    }
                    break;

                case SelectorActivo.Año:
                    currentDate = currentDate.AddYears(12);
                    ActualizarSelectorAnios();
                    break;

                default:
                    currentDate = currentDate.AddMonths(1);
                    establecerFecha();
                    break;
            }
        }

        private void ActualizarSelectorAnios()
        {
            int anioBase = currentDate.Year - (currentDate.Year % 12);

            foreach (Control ctrl in PFontCalendar.Controls)
            {
                if (ctrl is userYearSelector selector)
                {
                    selector.MostrarAnios(anioBase);
                    LMonthYear.Text = $"{anioBase} - {anioBase + 11}";
                    break;
                }
            }
        }

        private void CargarDias()
        {
            DateTime primerDiaMes = new DateTime(currentDate.Year, currentDate.Month, 1);
            int diaInicio = (int)primerDiaMes.DayOfWeek;

            int diasMesActual = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            DateTime mesAnterior = currentDate.AddMonths(-1);
            int diasMesAnterior = DateTime.DaysInMonth(mesAnterior.Year, mesAnterior.Month);

            int dia = 1;
            int diaSiguiente = 1;
            int diaAnterior = diasMesAnterior - diaInicio + 1;

            for (int fila = 1; fila <= 6; fila++)
            {
                for (int col = 0; col < 7; col++)
                {
                    string[] dias = { "Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab" };
                    string nombreBoton = $"BDay{dias[col]}{fila}";

                    Button btn = this.Controls.Find(nombreBoton, true).FirstOrDefault() as Button;

                    if (btn != null)
                    {
                        btn.Enabled = true;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 7, FontStyle.Regular);

                        int indice = (fila - 1) * 7 + col;

                        if (indice < diaInicio)
                        {
                            btn.Text = diaAnterior.ToString();
                            btn.ForeColor = Color.Gray;
                            btn.Enabled = false;
                            diaAnterior++;
                        }
                        else if (dia <= diasMesActual)
                        {
                            btn.Text = dia.ToString();

                            if (new DateTime(currentDate.Year, currentDate.Month, dia) == DateTime.Today)
                            {
                                btn.Font = new Font("Segoe UI", 7, FontStyle.Bold);
                                btn.ForeColor = Color.Cyan;
                            }

                            dia++;
                        }
                        else
                        {
                            btn.Text = diaSiguiente.ToString();
                            btn.ForeColor = Color.Gray;
                            btn.Enabled = false;
                            diaSiguiente++;
                        }

                        btn.Click -= SeleccionarDia_Click;
                        btn.Click += SeleccionarDia_Click;
                    }
                }
            }
        }

        public event EventHandler<DateTime> FechaSeleccionada;
        private void SeleccionarDia_Click(object sender, EventArgs e)
        {
            foreach (Control control in TLPDiasCalendar.Controls)
            {
                if (control is Button btn && btn.Enabled)
                {
                    btn.Font = new Font("Segoe UI", 7, FontStyle.Regular);
                    btn.ForeColor = Color.White;
                }
            }

            if (sender is Button clickedBtn)
            {
                clickedBtn.Font = new Font("Segoe UI", 7, FontStyle.Bold);
                clickedBtn.ForeColor = Color.Cyan;

                int diaSeleccionado = int.Parse(clickedBtn.Text);
                DateTime fechaSeleccionada = new DateTime(currentDate.Year, currentDate.Month, diaSeleccionado);

                // Lanzar el evento para rjDataPicker
                FechaSeleccionada?.Invoke(this, fechaSeleccionada);
            }
        }

        private void LMonthYear_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                selectorActivo = SelectorActivo.Mes;

                userMonthSelector UMS = new userMonthSelector();
                selectorMes(UMS);

                PFontCalendar.Controls.Add(UMS);
                PFontCalendar.BringToFront();
                isOpen = true;
            }
            else
            {
                selectorActivo = SelectorActivo.Año;

                PFontCalendar.Controls.Clear();

                userYearSelector UYS = new userYearSelector();
                int anioBase = currentDate.Year - (currentDate.Year % 12);
                UYS.MostrarAnios(anioBase);

                LMonthYear.Text = $"{anioBase} - {anioBase + 11}";

                UYS.AnioSeleccionado += (s, anioSeleccionado) =>
                {
                    currentDate = new DateTime(anioSeleccionado, currentDate.Month, 1);

                    selectorActivo = SelectorActivo.Mes;

                    PFontCalendar.Controls.Clear();

                    userMonthSelector UMS = new userMonthSelector();
                    selectorMes(UMS);
                };

                PFontCalendar.Controls.Add(UYS);
                UYS.BringToFront();
            }
        }

        private void selectorMes(userMonthSelector UMS)
        {
            UMS.MesSeleccionado += (s2, mesSeleccionado) =>
            {
                currentDate = new DateTime(currentDate.Year, mesSeleccionado, 1);
                CargarDias();
                LMonthYear.Text = currentDate.ToString("MMMM yyyy", new CultureInfo("es-ES"));
                PFontCalendar.Controls.Clear();
                PFontCalendar.SendToBack();
                isOpen = false;
                selectorActivo = SelectorActivo.Ninguno;
            };

            PFontCalendar.Controls.Add(UMS);
            LMonthYear.Text = currentDate.Year.ToString();
        }

        private void BRestartDT_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Today;

            PFontCalendar.Controls.Clear();
            PFontCalendar.SendToBack();
            isOpen = false;

            selectorActivo = SelectorActivo.Ninguno;
            establecerFecha();
            CargarDias();
        }
    }
}
