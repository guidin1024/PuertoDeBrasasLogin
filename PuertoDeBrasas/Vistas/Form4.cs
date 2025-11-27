using PuertoDeBrasas.Data;
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
        private ClienteRepositorio clienteRepo;

        public Form4()
        {
            InitializeComponent();

            reservaRepo = new ReservaRepositorio();
            platoRepo = new PlatoRepositorio();
            clienteRepo = new ClienteRepositorio();

            ConfigurarFormulario();
            CargarDatos();

            this.FormClosing += Form4_FormClosing;
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
            listaReservas.RowHeadersVisible = false;
            listaReservas.AllowUserToResizeRows = false;

            // Configurar ListView de menú
            listaMenu.Columns.Clear();
            listaMenu.Columns.Add("ID", 50);
            listaMenu.Columns.Add("Nombre del Plato", 200);
            listaMenu.Columns.Add("Precio", 100);
            listaMenu.FullRowSelect = true;
            listaMenu.View = View.Details;
            listaMenu.GridLines = true;

            // Configurar ListView de clientes
            listaClientes.Columns.Clear();
            listaClientes.Columns.Add("ID", 50);
            listaClientes.Columns.Add("Tipo", 100);
            listaClientes.Columns.Add("Nombre", 150);
            listaClientes.Columns.Add("Email", 150);
            listaClientes.FullRowSelect = true;
            listaClientes.View = View.Details;
            listaClientes.GridLines = true;
        }

        private void CargarDatos()
        {
            CargarReservas();
            CargarMenu();
            CargarClientes();
        }

        // === GESTIÓN DE RESERVAS ===

        private void CargarReservas()
        {
            try
            {
                var dt = reservaRepo.ObtenerTodasReservas();
                listaReservas.DataSource = dt;

                // Mejorar la visualización
                if (listaReservas.Columns.Count > 0)
                {
                    // Ocultar columna ReservaID si existe
                    if (listaReservas.Columns.Contains("ReservaID"))
                    {
                        listaReservas.Columns["ReservaID"].Visible = false;
                    }

                    // Ajustar nombres de columnas
                    if (listaReservas.Columns.Contains("Cliente"))
                        listaReservas.Columns["Cliente"].HeaderText = "Cliente";

                    if (listaReservas.Columns.Contains("TelefonoCliente"))
                        listaReservas.Columns["TelefonoCliente"].HeaderText = "Teléfono";

                    if (listaReservas.Columns.Contains("Dia"))
                    {
                        listaReservas.Columns["Dia"].HeaderText = "Fecha";
                        listaReservas.Columns["Dia"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }

                    if (listaReservas.Columns.Contains("Estado"))
                        listaReservas.Columns["Estado"].HeaderText = "Estado";

                    if (listaReservas.Columns.Contains("Menu"))
                        listaReservas.Columns["Menu"].HeaderText = "Menú Seleccionado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (listaReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una reserva para ver sus detalles.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int reservaId = Convert.ToInt32(listaReservas.SelectedRows[0].Cells["ReservaID"].Value);
                var reserva = reservaRepo.ObtenerPorId(reservaId);
                var menus = reservaRepo.ObtenerMenusDeReserva(reservaId);

                if (reserva != null)
                {
                    string menusStr = string.Join("\n• ", menus);
                    string estado = reserva.Estado ?? "Pendiente";

                    MessageBox.Show(
                        $"🆔 ID Cliente: {reserva.ClienteID}\n" +
                        $"📍 Lugar: {reserva.Lugar}\n" +
                        $"📅 Fecha: {reserva.Dia:dd/MM/yyyy}\n" +
                        $"🕐 Hora Inicio: {reserva.HoraInicio:hh\\:mm}\n" +
                        $"🕐 Hora Fin: {reserva.HoraFin:hh\\:mm}\n" +
                        $"📋 Estado: {estado}\n\n" +
                        $"🍽️ Platos elegidos:\n• {menusStr}",
                        "Detalles de la Reserva",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (listaReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una reserva.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int reservaId = Convert.ToInt32(listaReservas.SelectedRows[0].Cells["ReservaID"].Value);

                if (reservaRepo.CambiarEstado(reservaId, "Aceptado"))
                {
                    MessageBox.Show("✅ Reserva aceptada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarReservas();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado de la reserva.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (listaReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una reserva.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                "¿Estás seguro de que deseas rechazar esta reserva?\n\n" +
                "Esta acción cambiará el estado a 'Rechazado'.",
                "Confirmar Rechazo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int reservaId = Convert.ToInt32(listaReservas.SelectedRows[0].Cells["ReservaID"].Value);

                    if (reservaRepo.CambiarEstado(reservaId, "Rechazado"))
                    {
                        MessageBox.Show("❌ Reserva rechazada.", "Estado actualizado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarReservas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado de la reserva.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditarReserva_Click(object sender, EventArgs e)
        {
            if (listaReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una reserva para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int reservaId = Convert.ToInt32(listaReservas.SelectedRows[0].Cells["ReservaID"].Value);
                var reserva = reservaRepo.ObtenerPorId(reservaId);

                if (reserva != null)
                {
                    using (var formEditar = new FormEditarReserva(reserva))
                    {
                        if (formEditar.ShowDialog() == DialogResult.OK)
                        {
                            if (reservaRepo.ActualizarReserva(formEditar.ReservaEditada))
                            {
                                MessageBox.Show("✅ Reserva actualizada exitosamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarReservas();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar la reserva.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar reserva: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            if (listaReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una reserva para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar esta reserva?\n\n" +
                "Esta acción eliminará permanentemente la reserva y no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int reservaId = Convert.ToInt32(listaReservas.SelectedRows[0].Cells["ReservaID"].Value);

                    if (reservaRepo.EliminarReserva(reservaId))
                    {
                        MessageBox.Show("✅ Reserva eliminada exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarReservas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la reserva.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la reserva: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    item.SubItems.Add($"${plato.Precio:N2}");
                    item.Tag = plato;
                    listaMenu.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar menú: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (platoRepo.AgregarPlato(form.PlatoNuevo))
                        {
                            MessageBox.Show("✅ Plato agregado exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarMenu();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el plato.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditarMenu_Click(object sender, EventArgs e)
        {
            if (listaMenu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un plato para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var plato = (Plato)listaMenu.SelectedItems[0].Tag;
            using (var form = new FormAgregarPlato(plato))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (platoRepo.ActualizarPlato(form.PlatoNuevo))
                        {
                            MessageBox.Show("✅ Plato actualizado exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarMenu();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el plato.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (listaMenu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un plato para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var plato = (Plato)listaMenu.SelectedItems[0].Tag;
            var result = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar '{plato.NombrePlato}'?\n\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (platoRepo.EliminarPlato(plato.MenuID))
                    {
                        MessageBox.Show("✅ Plato eliminado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarMenu();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el plato.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // === GESTIÓN DE CLIENTES - INLINE (SIN FormAgregarCliente) ===

        private void CargarClientes()
        {
            try
            {
                listaClientes.Items.Clear();
                var clientes = clienteRepo.ObtenerTodos();

                foreach (var cliente in clientes)
                {
                    var item = new ListViewItem(cliente.ClienteID.ToString());
                    item.SubItems.Add(cliente.TipoCliente);
                    item.SubItems.Add(cliente.Nombre);
                    item.SubItems.Add(cliente.CorreoElectronico);
                    item.Tag = cliente;
                    listaClientes.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            // Solicitar datos mediante InputBox personalizado
            string nombre = PromptInput("Ingrese el nombre completo:", "Agregar Cliente");
            if (string.IsNullOrWhiteSpace(nombre)) return;

            string email = PromptInput("Ingrese el correo electrónico (formato: usuario@gmail.com):", "Agregar Cliente");
            if (string.IsNullOrWhiteSpace(email)) return;

            string telefono = PromptInput("Ingrese el teléfono (10 dígitos):", "Agregar Cliente");
            if (string.IsNullOrWhiteSpace(telefono)) return;

            string clave = PromptInput("Ingrese la contraseña (mínimo 4 caracteres):", "Agregar Cliente");
            if (string.IsNullOrWhiteSpace(clave)) return;

            // Seleccionar tipo de cliente
            var tipoResult = MessageBox.Show(
                "Seleccione el tipo de cliente:\n\n" +
                "SÍ = Empresa\n" +
                "NO = Persona\n" +
                "CANCELAR = Administrador",
                "Tipo de Cliente",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (tipoResult == DialogResult.Cancel)
            {
                var confirmAdmin = MessageBox.Show(
                    "¿Confirma que desea crear una cuenta de Administrador?",
                    "Confirmar Administrador",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmAdmin == DialogResult.No) return;
            }

            string tipo = tipoResult == DialogResult.Yes ? "Empresa" :
                          tipoResult == DialogResult.No ? "Persona" : "Administrador";

            // Validar nombre (solo letras y espacios)
            if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.", "Nombre inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar email
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9]+@gmail\.com$"))
            {
                MessageBox.Show("El correo debe tener el formato 'usuario@gmail.com'.", "Email inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar teléfono
            if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{10}$"))
            {
                MessageBox.Show("El teléfono debe contener exactamente 10 números.", "Teléfono inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar contraseña
            if (clave.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Contraseña inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoCliente = new Cliente
            {
                Nombre = nombre,
                CorreoElectronico = email,
                Telefono = telefono,
                Clave = clave,
                TipoCliente = tipo
            };

            try
            {
                if (clienteRepo.Registrar(nuevoCliente))
                {
                    MessageBox.Show("✅ Cliente agregado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el cliente.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (listaClientes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un cliente para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cliente = (Cliente)listaClientes.SelectedItems[0].Tag;

            // Editar campos
            string nombre = PromptInput("Nombre completo:", "Editar Cliente", cliente.Nombre);
            if (string.IsNullOrWhiteSpace(nombre)) return;

            string email = PromptInput("Correo electrónico:", "Editar Cliente", cliente.CorreoElectronico);
            if (string.IsNullOrWhiteSpace(email)) return;

            string telefono = PromptInput("Teléfono (10 dígitos):", "Editar Cliente", cliente.Telefono);
            if (string.IsNullOrWhiteSpace(telefono)) return;

            // Validaciones
            if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.", "Nombre inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9]+@gmail\.com$"))
            {
                MessageBox.Show("El correo debe tener el formato 'usuario@gmail.com'.", "Email inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{10}$"))
            {
                MessageBox.Show("El teléfono debe contener exactamente 10 números.", "Teléfono inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cliente.Nombre = nombre;
            cliente.CorreoElectronico = email;
            cliente.Telefono = telefono;

            try
            {
                if (clienteRepo.Actualizar(cliente))
                {
                    MessageBox.Show("✅ Cliente actualizado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el cliente.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (listaClientes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un cliente para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cliente = (Cliente)listaClientes.SelectedItems[0].Tag;

            // No permitir eliminar administradores o el usuario actual
            if (cliente.TipoCliente == "Administrador")
            {
                MessageBox.Show("No se puede eliminar cuentas de administrador.", "Acción no permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cliente.ClienteID == Form1.ClienteActual?.ClienteID)
            {
                MessageBox.Show("No puedes eliminar tu propia cuenta mientras estás conectado.",
                    "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar al cliente '{cliente.Nombre}'?\n\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (clienteRepo.Eliminar(cliente.ClienteID))
                    {
                        MessageBox.Show("✅ Cliente eliminado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Helper para input simple (reemplazo de FormAgregarCliente)
        private string PromptInput(string prompt, string title, string defaultValue = "")
        {
            Form promptForm = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = prompt, Width = 440 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 440, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 280, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancelar", Left = 370, Width = 90, Top = 80, DialogResult = DialogResult.Cancel };

            confirmation.Click += (sender, e) => { promptForm.Close(); };
            cancel.Click += (sender, e) => { promptForm.Close(); };

            promptForm.Controls.Add(textLabel);
            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(confirmation);
            promptForm.Controls.Add(cancel);
            promptForm.AcceptButton = confirmation;
            promptForm.CancelButton = cancel;

            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}