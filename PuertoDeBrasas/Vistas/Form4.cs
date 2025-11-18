using PuertoDeBrasas.Modelos;
using PuertoDeBrasas.Repositorios;
using System;
using System.Windows.Forms;

namespace PuertoDeBrasas.Vistas
{
    public partial class Form4 : Form
    {
        private ReservaRepositorio reservaRepo;
        private PlatoRepositorio platoRepo;
        private MateriaPrimaRepositorio materiaPrimaRepo;
        private ProveedorRepositorio proveedorRepo;

        public Form4()
        {
            InitializeComponent();

            reservaRepo = new ReservaRepositorio();
            platoRepo = new PlatoRepositorio();
            materiaPrimaRepo = new MateriaPrimaRepositorio();
            proveedorRepo = new ProveedorRepositorio();

            ConfigurarFormulario();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            // Mostrar nombre del usuario
            if (Form1.ClienteActual != null)
            {
                lblUsuario.Text = $"Usuario: {Form1.ClienteActual.Nombre}";
            }

            // Configurar DataGridView de reservas
            listaReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listaReservas.MultiSelect = false;
            listaReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar ListView de menú
            listaMenu.Columns.Add("ID", 50);
            listaMenu.Columns.Add("Nombre", 150);
            listaMenu.Columns.Add("Descripción", 200);
            listaMenu.Columns.Add("Precio", 80);
            listaMenu.FullRowSelect = true;
        }

        private void CargarDatos()
        {
            CargarReservas();
            CargarMenu();
            CargarMateriaPrima();
        }

        // === GESTIÓN DE RESERVAS ===

        private void CargarReservas()
        {
            try
            {
                var dt = reservaRepo.ObtenerTodasReservas();
                listaReservas.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas: " + ex.Message);
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (listaReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una reserva.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int reservaId = Convert.ToInt32(listaReservas.SelectedRows[0].Cells["ReservaID"].Value);
            var reserva = reservaRepo.ObtenerPorId(reservaId);
            var menus = reservaRepo.ObtenerMenusDeReserva(reservaId);

            if (reserva != null)
            {
                string menusStr = string.Join("\n• ", menus);
                MessageBox.Show(
                    $"📅 Día: {reserva.Dia:dd/MM/yyyy}\n" +
                    $"📍 Lugar: {reserva.Lugar}\n" +
                    $"🕐 Horario: {reserva.HoraInicio} - {reserva.HoraFin}\n\n" +
                    $"🍽️ Menú seleccionado:\n• {menusStr}",
                    "Detalles de Reserva",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (listaReservas.SelectedRows.Count == 0) return;

            MessageBox.Show("Reserva aceptada exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarReservas();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (listaReservas.SelectedRows.Count == 0) return;

            var result = MessageBox.Show("¿Estás seguro de rechazar esta reserva?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int reservaId = Convert.ToInt32(listaReservas.SelectedRows[0].Cells["ReservaID"].Value);
                    reservaRepo.EliminarReserva(reservaId);
                    MessageBox.Show("Reserva rechazada.", "Éxito");
                    CargarReservas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnEditarReserva_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de edición en desarrollo.", "Info");
        }

        // === GESTIÓN DEL MENÚ ===

        private void CargarMenu()
        {
            try
            {
                listaMenu.Items.Clear();
                var platos = platoRepo.ObtenerTodos();

                foreach (var plato in platos)
                {
                    var item = new ListViewItem(plato.MenuID.ToString());
                    item.SubItems.Add(plato.NombrePlato);
                    item.SubItems.Add(plato.Descripcion);
                    item.SubItems.Add($"${plato.Precio:F2}");
                    item.Tag = plato;
                    listaMenu.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar menú: " + ex.Message);
            }
        }

        private void btnAgregarMenu_Click(object sender, EventArgs e)
        {
            using (var form = new FormAgregarPlato())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        platoRepo.AgregarPlato(form.PlatoNuevo);
                        MessageBox.Show("Plato agregado exitosamente.", "Éxito");
                        CargarMenu();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnEditarMenu_Click(object sender, EventArgs e)
        {
            if (listaMenu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona un plato.", "Aviso");
                return;
            }

            var plato = (Plato)listaMenu.SelectedItems[0].Tag;
            using (var form = new FormAgregarPlato(plato))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        platoRepo.ActualizarPlato(form.PlatoNuevo);
                        MessageBox.Show("Plato actualizado.", "Éxito");
                        CargarMenu();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (listaMenu.SelectedItems.Count == 0) return;

            var plato = (Plato)listaMenu.SelectedItems[0].Tag;
            var result = MessageBox.Show($"¿Eliminar '{plato.NombrePlato}'?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    platoRepo.EliminarPlato(plato.MenuID);
                    MessageBox.Show("Plato eliminado.", "Éxito");
                    CargarMenu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // === GESTIÓN DE MATERIA PRIMA ===

        private void CargarMateriaPrima()
        {
            try
            {
                var materias = materiaPrimaRepo.ObtenerTodas();
                int stockTotal = 0;
                foreach (var m in materias)
                {
                    stockTotal += m.Stock;
                }

                lblStockActual.Text = $"Stock total: {stockTotal} unidades";

                // Alerta si stock bajo
                if (stockTotal < 50)
                {
                    lblAlerta.Text = "⚠️ Stock bajo";
                    lblAlerta.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblStockActual.Text = "Error al cargar stock";
            }
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de registro de compra en desarrollo.", "Info");
        }

        private void btnEditarProveedores_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de proveedores en desarrollo.", "Info");
        }

        // === CONFIGURACIÓN ===

        private void btnCambiarPrecios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usa 'Editar' en el menú para cambiar precios.", "Info");
        }

        private void btnDefinirHorario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de horarios en desarrollo.", "Info");
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de cambio de contraseña en desarrollo.", "Info");
        }
    }
}