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
        private PlatoRepositorio platoRepo;

        public Form3()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            reservaRepo = new ReservaRepositorio();
            platoRepo = new PlatoRepositorio();

            ConfigurarCalendario();
            ConfigurarDomainUpDowns();
            ConfigurarCheckedListBox();
        }

        private void ConfigurarCalendario()
        {
            monthCalendar1.MinDate = DateTime.Today;
            monthCalendar1.MaxSelectionCount = 1;
        }

        private void ConfigurarDomainUpDowns()
        {
            domainUpDown1.Items.Clear();
            for (int hora = 10; hora <= 23; hora++)
            {
                domainUpDown1.Items.Add($"{hora:D2}:00");
            }
            domainUpDown1.SelectedIndex = 0;
            domainUpDown1.ReadOnly = true;

            domainUpDown2.Items.Clear();
            for (int hora = 11; hora <= 23; hora++)
            {
                domainUpDown2.Items.Add($"{hora:D2}:00");
            }
            domainUpDown2.Items.Add("00:00");
            domainUpDown2.SelectedIndex = 0;
            domainUpDown2.ReadOnly = true;
        }

        private void ConfigurarCheckedListBox()
        {
            // Control dinámico según si "Cabutia" está seleccionada
            checkedListBox1.ItemCheck += (s, e) =>
            {
                if (e.NewValue == CheckState.Checked)
                {
                    // Contar cuántos items están checked actualmente (sin incluir el que se está checkeando)
                    int cantidadSeleccionada = checkedListBox1.CheckedItems.Count;

                    // Verificar si "Cabutia" está entre los seleccionados o si es el item que se está seleccionando
                    bool cabutiaSeleccionada = false;
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (i == e.Index && checkedListBox1.Items[i].ToString() == "Cabutia")
                        {
                            cabutiaSeleccionada = true;
                            break;
                        }
                        else if (checkedListBox1.GetItemChecked(i) && checkedListBox1.Items[i].ToString() == "Cabutia")
                        {
                            cabutiaSeleccionada = true;
                            break;
                        }
                    }

                    // Máximo permitido: 3 normal, 4 si incluye Cabutia
                    int maximoPermitido = cabutiaSeleccionada ? 4 : 3;

                    if (cantidadSeleccionada >= maximoPermitido)
                    {
                        e.NewValue = CheckState.Unchecked;
                        string mensaje = cabutiaSeleccionada
                            ? "Ya seleccionaste el máximo de 4 opciones (incluyendo Cabutia)."
                            : "Solo puedes seleccionar un máximo de 3 opciones.\n\nSi incluyes Cabutia, podrás seleccionar 4 opciones.";

                        MessageBox.Show(mensaje, "Máximo alcanzado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Verificar si el cliente ya tiene una reserva pendiente o aceptada
                if (reservaRepo.TieneReservaPendiente(Form1.ClienteActual.ClienteID))
                {
                    MessageBox.Show(
                        "Ya tienes una reserva pendiente o aceptada.\n\n" +
                        "Solo puedes hacer una nueva reserva si tu reserva anterior ha sido rechazada o completada.",
                        "Reserva Existente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
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

                // Obtener IDs y calcular precio total
                var menusSeleccionados = new List<int>();
                decimal precioTotal = 0;
                var todosPlatos = platoRepo.ObtenerTodos();

                foreach (string itemNombre in checkedListBox1.CheckedItems)
                {
                    int menuId = MapearNombreAMenuID(itemNombre);
                    if (menuId > 0)
                    {
                        menusSeleccionados.Add(menuId);

                        // Buscar el precio del plato
                        var plato = todosPlatos.FirstOrDefault(p => p.MenuID == menuId);
                        if (plato != null)
                        {
                            precioTotal += plato.Precio;
                        }
                    }
                }

                // Mostrar confirmación con precio total
                string platosStr = string.Join(", ", checkedListBox1.CheckedItems.Cast<string>());
                var confirmacion = MessageBox.Show(
                    $"📋 RESUMEN DE LA RESERVA\n\n" +
                    $"📅 Fecha: {fechaSeleccionada:dd/MM/yyyy}\n" +
                    $"🕐 Horario: {horaInicioStr} - {horaFinStr}\n" +
                    $"📍 Lugar: {direccion}\n" +
                    $"🍽️ Platos: {platosStr}\n\n" +
                    $"💰 PRECIO TOTAL: ${precioTotal:N2}\n\n" +
                    $"¿Confirmar reserva?",
                    "Confirmar Reserva",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.No)
                {
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

                // Guardar en la base de datos
                bool exito = reservaRepo.CrearReserva(reserva, menusSeleccionados);

                if (exito)
                {
                    MessageBox.Show(
                        $"¡Reserva confirmada exitosamente!\n\n" +
                        $"Precio total: ${precioTotal:N2}\n\n" +
                        $"Tu reserva está en estado PENDIENTE y será revisada por el administrador.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

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
            var mapeo = new Dictionary<string, int>
            {
                { "Sandwich de bondiola", 1 },
                { "Choripan", 2 },
                { "Empanadas", 3 },
                { "Bife de chorizo", 4 },
                { "Cabutia", 5 },
                { "Sandwich de vacío", 6 }
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
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}