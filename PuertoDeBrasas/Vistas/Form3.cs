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
        private const decimal PRECIO_POR_HORA = 40000.00m;

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

        // Llama esto una vez (por ejemplo en Form_Load)
        private void ConfigurarCheckedListBox()
        {
            // Evitar añadir el mismo handler varias veces
            checkedListBox1.ItemCheck -= CheckedListBox1_ItemCheck;
            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Contar explícitamente cómo quedarán los items después del cambio
            int seleccionados = 0;
            bool cabutiaSeleccionada = false;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                bool marcadoAntes = checkedListBox1.GetItemChecked(i);
                bool marcadoDespues;

                // Para el item que cambia, aplicar e.NewValue; para los demás usar el estado actual
                if (i == e.Index)
                    marcadoDespues = (e.NewValue == CheckState.Checked);
                else
                    marcadoDespues = marcadoAntes;

                if (marcadoDespues)
                {
                    seleccionados++;

                    // Comparación de texto segura (ignora mayúsculas y espacios)
                    string texto = checkedListBox1.Items[i].ToString()?.Trim() ?? string.Empty;
                    if (string.Equals(texto, "Cabutia", StringComparison.OrdinalIgnoreCase))
                    {
                        cabutiaSeleccionada = true;
                    }
                }
            }

            int maxPermitido = cabutiaSeleccionada ? 4 : 3;

            if (seleccionados > maxPermitido)
            {
                // Bloquea la acción de marcado
                e.NewValue = CheckState.Unchecked;

                MessageBox.Show(
                    cabutiaSeleccionada
                        ? "Ya seleccionaste el máximo de 4 opciones (incluyendo Cabutia)."
                        : "Solo puedes seleccionar un máximo de 3 opciones.\nSi incluyes Cabutia, podrás seleccionar 4 opciones.",
                    "Máximo alcanzado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }



        private void buttonReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form1.ClienteActual == null)
                {
                    MessageBox.Show("No hay un cliente autenticado. Por favor, inicia sesión nuevamente.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

                string direccion = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(direccion))
                {
                    MessageBox.Show("Por favor, ingresa la dirección del evento.",
                        "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                if (checkedListBox1.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Por favor, selecciona al menos 1 opción del menú.",
                        "Menú requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaSeleccionada = monthCalendar1.SelectionStart;

                string horaInicioStr = domainUpDown1.SelectedItem?.ToString() ?? "10:00";
                string horaFinStr = domainUpDown2.SelectedItem?.ToString() ?? "11:00";

                TimeSpan horaInicio = TimeSpan.Parse(horaInicioStr);
                TimeSpan horaFin = TimeSpan.Parse(horaFinStr);

                if (horaFin <= horaInicio)
                {
                    MessageBox.Show("La hora de fin debe ser posterior a la hora de inicio.",
                        "Horario inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calcular horas de duración
                double duracionHoras = (horaFin - horaInicio).TotalHours;
                if (horaFin < horaInicio) // Si termina al día siguiente
                {
                    duracionHoras = 24 - horaInicio.TotalHours + horaFin.TotalHours;
                }

                // Obtener IDs y calcular precio de platos
                var menusSeleccionados = new List<int>();
                decimal precioPlatosTotal = 0;
                var todosPlatos = platoRepo.ObtenerTodos();

                foreach (string itemNombre in checkedListBox1.CheckedItems)
                {
                    int menuId = MapearNombreAMenuID(itemNombre);
                    if (menuId > 0)
                    {
                        menusSeleccionados.Add(menuId);

                        var plato = todosPlatos.FirstOrDefault(p => p.MenuID == menuId);
                        if (plato != null)
                        {
                            precioPlatosTotal += plato.Precio;
                        }
                    }
                }

                // Calcular precio por horas
                decimal precioHoras = (decimal)duracionHoras * PRECIO_POR_HORA;

                // Precio total
                decimal precioTotal = precioPlatosTotal + precioHoras;

                string platosStr = string.Join(", ", checkedListBox1.CheckedItems.Cast<string>());
                var confirmacion = MessageBox.Show(
                    $"📋 RESUMEN DE LA RESERVA\n\n" +
                    $"📅 Fecha: {fechaSeleccionada:dd/MM/yyyy}\n" +
                    $"🕐 Horario: {horaInicioStr} - {horaFinStr} ({duracionHoras:F1} horas)\n" +
                    $"📍 Lugar: {direccion}\n" +
                    $"🍽️ Platos: {platosStr}\n\n" +
                    $"💰 DESGLOSE DE PRECIOS:\n" +
                    $"   • Platos: ${precioPlatosTotal:N2}\n" +
                    $"   • Servicio por hora ({duracionHoras:F1}h × ${PRECIO_POR_HORA:N2}): ${precioHoras:N2}\n\n" +
                    $"💵 PRECIO TOTAL: ${precioTotal:N2}\n\n" +
                    $"¿Confirmar reserva?",
                    "Confirmar Reserva",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.No)
                {
                    return;
                }

                var reserva = new Reserva
                {
                    ClienteID = Form1.ClienteActual.ClienteID,
                    Dia = fechaSeleccionada,
                    Lugar = direccion,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin
                };

                bool exito = reservaRepo.CrearReserva(reserva, menusSeleccionados);

                if (exito)
                {
                    MessageBox.Show(
                        $"¡Reserva confirmada exitosamente!\n\n" +
                        $"💰 Desglose:\n" +
                        $"   • Platos: ${precioPlatosTotal:N2}\n" +
                        $"   • Servicio ({duracionHoras:F1}h): ${precioHoras:N2}\n" +
                        $"💵 Total a pagar: ${precioTotal:N2}\n\n" +
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}