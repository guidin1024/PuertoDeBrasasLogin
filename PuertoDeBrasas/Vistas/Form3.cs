using PuertoDeBrasas.Modelos;
using PuertoDeBrasas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PuertoDeBrasas
{
    public partial class Form3 : Form
    {
        private ReservaRepositorio reservaRepo;

        public Form3()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            reservaRepo = new ReservaRepositorio();

            // Configurar componentes
            ConfigurarCalendario();
            ConfigurarDomainUpDowns();
            ConfigurarCheckedListBox();
        }

        private void ConfigurarCalendario()
        {
            // Configurar el calendario para solo fechas futuras
            monthCalendar1.MinDate = DateTime.Today;
            monthCalendar1.MaxSelectionCount = 1;
        }

        private void ConfigurarDomainUpDowns()
        {
            // Configurar horas de inicio (10:00 a 23:00)
            domainUpDown1.Items.Clear();
            for (int hora = 10; hora <= 23; hora++)
            {
                domainUpDown1.Items.Add($"{hora:D2}:00");
            }
            domainUpDown1.SelectedIndex = 0; // Por defecto 10:00
            domainUpDown1.ReadOnly = true;

            // Configurar horas de fin (11:00 a 00:00)
            domainUpDown2.Items.Clear();
            for (int hora = 11; hora <= 23; hora++)
            {
                domainUpDown2.Items.Add($"{hora:D2}:00");
            }
            domainUpDown2.Items.Add("00:00"); // Medianoche
            domainUpDown2.SelectedIndex = 0; // Por defecto 11:00
            domainUpDown2.ReadOnly = true;
        }

        private void ConfigurarCheckedListBox()
        {
            // Evitar que se seleccionen más de 3 items
            checkedListBox1.ItemCheck += (s, e) =>
            {
                if (e.NewValue == CheckState.Checked)
                {
                    int cantidadSeleccionada = checkedListBox1.CheckedItems.Count;

                    if (cantidadSeleccionada >= 3)
                    {
                        e.NewValue = CheckState.Unchecked;
                        MessageBox.Show("Solo puedes seleccionar un máximo de 3 opciones del menú.",
                            "Máximo alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            };
        }

        private void buttonReserva_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que hay un cliente logueado
                if (Form1.ClienteActual == null)
                {
                    MessageBox.Show("No hay un cliente autenticado. Por favor, inicia sesión nuevamente.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar dirección
                string direccion = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(direccion))
                {
                    MessageBox.Show("Por favor, ingresa la dirección del evento.",
                        "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                // Validar selección de platos
                if (checkedListBox1.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Por favor, selecciona al menos 1 opción del menú.",
                        "Menú requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener fecha seleccionada
                DateTime fechaSeleccionada = monthCalendar1.SelectionStart;

                // Obtener horas
                string horaInicioStr = domainUpDown1.SelectedItem?.ToString() ?? "10:00";
                string horaFinStr = domainUpDown2.SelectedItem?.ToString() ?? "11:00";

                TimeSpan horaInicio = TimeSpan.Parse(horaInicioStr);
                TimeSpan horaFin = TimeSpan.Parse(horaFinStr);

                // Validar que hora fin sea mayor que hora inicio
                if (horaFin <= horaInicio)
                {
                    MessageBox.Show("La hora de fin debe ser posterior a la hora de inicio.",
                        "Horario inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear objeto Reserva
                var reserva = new Reserva
                {
                    ClienteID = Form1.ClienteActual.ClienteID,
                    Dia = fechaSeleccionada,
                    Lugar = direccion,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin
                };

                // Obtener IDs de los menús seleccionados (MapearNombreAMenuID)
                var menusSeleccionados = new List<int>();
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    int menuId = MapearNombreAMenuID(item);
                    if (menuId > 0)
                        menusSeleccionados.Add(menuId);
                }

                // Guardar en la base de datos
                bool exito = reservaRepo.CrearReserva(reserva, menusSeleccionados);

                if (exito)
                {
                    MessageBox.Show($"¡Reserva confirmada!\n\n" +
                        $"Fecha: {fechaSeleccionada:dd/MM/yyyy}\n" +
                        $"Horario: {horaInicioStr} - {horaFinStr}\n" +
                        $"Lugar: {direccion}\n" +
                        $"Platos: {checkedListBox1.CheckedItems.Count}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la reserva:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int MapearNombreAMenuID(string nombrePlato)
        {
            // Mapear los nombres a los IDs de tu base de datos
            // Ajusta estos IDs según tu tabla 'menu'
            var mapeo = new Dictionary<string, int>
            {
                { "Sandwich de bondiola", 1 },
                { "Choripan", 2 },
                { "Empanadas", 3 },
                { "Bife de chorizo", 4 },
                { "Cabutia", 5 },
                { "Sandwich de cacío", 6 }
            };

            return mapeo.ContainsKey(nombrePlato) ? mapeo[nombrePlato] : 0;
        }

        private void LimpiarFormulario()
        {
            textBox1.Clear();
            monthCalendar1.SetDate(DateTime.Today);
            domainUpDown1.SelectedIndex = 0;
            domainUpDown2.SelectedIndex = 0;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void cerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Limpiar sesión
            Form1.ClienteActual = null;

            Form1 form1 = new Form1();
            form1.WindowState = FormWindowState.Normal;
            form1.StartPosition = FormStartPosition.CenterScreen;

            try
            {
                var textBoxCorreo = form1.Controls["Textbox_Email"] as TextBox;
                var textBoxContraseña = form1.Controls["Textbox_contraseña"] as TextBox;

                if (textBoxCorreo != null) textBoxCorreo.Text = string.Empty;
                if (textBoxContraseña != null) textBoxContraseña.Text = string.Empty;
            }
            catch { }

            form1.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Evento vacío (puedes agregar funcionalidad si quieres)
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            // Evento vacío (puedes agregar funcionalidad si quieres)
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}