using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuertoDeBrasas.Modelos;
using PuertoDeBrasas.Repositorios;

namespace PuertoDeBrasas.Vistas
{
    public partial class FormEditarReserva : Form
    {
        public Reserva ReservaEditada { get; private set; }
        public List<int> MenusSeleccionados { get; private set; }
        private ReservaRepositorio reservaRepo;
        private PlatoRepositorio platoRepo;
        private int reservaId;

        public FormEditarReserva(Reserva reserva)
        {
            InitializeComponent();
            ReservaEditada = reserva;
            reservaId = reserva.ReservaID;
            MenusSeleccionados = new List<int>();

            reservaRepo = new ReservaRepositorio();
            platoRepo = new PlatoRepositorio();

            // Cargar datos existentes
            dateTimePicker1.Value = reserva.Dia;
            dateTimePicker1.MinDate = DateTime.Today;
            txtLugar.Text = reserva.Lugar;

            // Configurar horas
            for (int i = 10; i <= 23; i++)
            {
                comboHoraInicio.Items.Add($"{i:D2}:00");
                comboHoraFin.Items.Add($"{i:D2}:00");
            }
            comboHoraFin.Items.Add("00:00");

            comboHoraInicio.Text = reserva.HoraInicio.ToString(@"hh\:mm");
            comboHoraFin.Text = reserva.HoraFin.ToString(@"hh\:mm");

            // Cargar menú disponible
            CargarMenuDisponible();

            // Marcar los platos actuales de la reserva
            CargarMenuActual();

            // Configurar validación de selección de menú
            ConfigurarValidacionMenu();
        }

        private void CargarMenuDisponible()
        {
            try
            {
                var platos = platoRepo.ObtenerTodos();
                checkedListMenu.Items.Clear();

                foreach (var plato in platos)
                {
                    checkedListMenu.Items.Add($"{plato.NombrePlato} - ${plato.Precio:N2}", false);
                    checkedListMenu.Tag = platos; // Guardamos la lista de platos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el menú: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMenuActual()
        {
            try
            {
                var menusActuales = reservaRepo.ObtenerMenusDeReserva(reservaId);
                var todosPlatos = platoRepo.ObtenerTodos();

                for (int i = 0; i < checkedListMenu.Items.Count; i++)
                {
                    string itemTexto = checkedListMenu.Items[i].ToString() ?? "";

                    foreach (var nombreMenu in menusActuales)
                    {
                        if (itemTexto.StartsWith(nombreMenu))
                        {
                            checkedListMenu.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los platos actuales: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarValidacionMenu()
        {
            checkedListMenu.ItemCheck += (s, e) =>
            {
                if (e.NewValue == CheckState.Checked)
                {
                    int cantidadSeleccionada = checkedListMenu.CheckedItems.Count;

                    // Verificar si "Cabutia" está entre los seleccionados
                    bool cabutiaSeleccionada = false;
                    for (int i = 0; i < checkedListMenu.Items.Count; i++)
                    {
                        string item = checkedListMenu.Items[i].ToString() ?? "";
                        if ((i == e.Index && item.StartsWith("Cabutia")) ||
                            (checkedListMenu.GetItemChecked(i) && item.StartsWith("Cabutia")))
                        {
                            cabutiaSeleccionada = true;
                            break;
                        }
                    }

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLugar.Text))
            {
                MessageBox.Show("Por favor, ingresa el lugar del evento.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLugar.Focus();
                return;
            }

            if (checkedListMenu.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos 1 opción del menú.", "Menú requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan inicio = TimeSpan.Parse(comboHoraInicio.Text);
            TimeSpan fin = TimeSpan.Parse(comboHoraFin.Text);

            if (fin <= inicio)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la hora de inicio.", "Horario inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboHoraFin.Focus();
                return;
            }

            // Actualizar datos de la reserva
            ReservaEditada.Dia = dateTimePicker1.Value;
            ReservaEditada.Lugar = txtLugar.Text.Trim();
            ReservaEditada.HoraInicio = inicio;
            ReservaEditada.HoraFin = fin;

            // Obtener IDs de los platos seleccionados
            var todosPlatos = platoRepo.ObtenerTodos();
            MenusSeleccionados.Clear();

            foreach (string itemTexto in checkedListMenu.CheckedItems)
            {
                foreach (var plato in todosPlatos)
                {
                    if (itemTexto.StartsWith(plato.NombrePlato))
                    {
                        MenusSeleccionados.Add(plato.MenuID);
                        break;
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
