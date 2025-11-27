namespace PuertoDeBrasas.Vistas
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupReservas = new GroupBox();
            listaReservas = new DataGridView();
            btnAceptar = new Button();
            btnRechazar = new Button();
            btnEditarReserva = new Button();
            btnVerDetalles = new Button();
            groupMenu = new GroupBox();
            listaMenu = new ListView();
            btnAgregarMenu = new Button();
            btnEditarMenu = new Button();
            btnActivar = new Button();
            lblUsuario = new Label();
            groupReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listaReservas).BeginInit();
            groupMenu.SuspendLayout();
            SuspendLayout();

            // groupReservas
            groupReservas.Controls.Add(listaReservas);
            groupReservas.Controls.Add(btnAceptar);
            groupReservas.Controls.Add(btnRechazar);
            groupReservas.Controls.Add(btnEditarReserva);
            groupReservas.Controls.Add(btnVerDetalles);
            groupReservas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupReservas.Location = new Point(20, 20);
            groupReservas.Name = "groupReservas";
            groupReservas.Size = new Size(980, 400);
            groupReservas.TabIndex = 0;
            groupReservas.TabStop = false;
            groupReservas.Text = "Gestión de Reservas";

            // listaReservas
            listaReservas.AllowUserToAddRows = false;
            listaReservas.AllowUserToDeleteRows = false;
            listaReservas.ColumnHeadersHeight = 29;
            listaReservas.Location = new Point(20, 30);
            listaReservas.Name = "listaReservas";
            listaReservas.ReadOnly = true;
            listaReservas.RowHeadersWidth = 51;
            listaReservas.Size = new Size(940, 300);
            listaReservas.TabIndex = 0;

            // btnAceptar
            btnAceptar.BackColor = Color.FromArgb(46, 125, 50);
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(20, 345);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(120, 35);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "✓ Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += new EventHandler(this.btnAceptar_Click);

            // btnRechazar
            btnRechazar.BackColor = Color.FromArgb(211, 47, 47);
            btnRechazar.FlatStyle = FlatStyle.Flat;
            btnRechazar.ForeColor = Color.White;
            btnRechazar.Location = new Point(150, 345);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new Size(120, 35);
            btnRechazar.TabIndex = 2;
            btnRechazar.Text = "✗ Rechazar";
            btnRechazar.UseVisualStyleBackColor = false;
            btnRechazar.Click += new EventHandler(this.btnRechazar_Click);

            // btnEditarReserva
            btnEditarReserva.BackColor = Color.FromArgb(255, 152, 0);
            btnEditarReserva.FlatStyle = FlatStyle.Flat;
            btnEditarReserva.ForeColor = Color.White;
            btnEditarReserva.Location = new Point(280, 345);
            btnEditarReserva.Name = "btnEditarReserva";
            btnEditarReserva.Size = new Size(120, 35);
            btnEditarReserva.TabIndex = 3;
            btnEditarReserva.Text = "✎ Editar";
            btnEditarReserva.UseVisualStyleBackColor = false;
            btnEditarReserva.Click += new EventHandler(this.btnEditarReserva_Click);

            // btnVerDetalles
            btnVerDetalles.BackColor = Color.FromArgb(33, 150, 243);
            btnVerDetalles.FlatStyle = FlatStyle.Flat;
            btnVerDetalles.ForeColor = Color.White;
            btnVerDetalles.Location = new Point(410, 345);
            btnVerDetalles.Name = "btnVerDetalles";
            btnVerDetalles.Size = new Size(140, 35);
            btnVerDetalles.TabIndex = 4;
            btnVerDetalles.Text = "🔍 Ver Detalles";
            btnVerDetalles.UseVisualStyleBackColor = false;
            btnVerDetalles.Click += new EventHandler(this.btnVerDetalles_Click);

            // groupMenu
            groupMenu.Controls.Add(listaMenu);
            groupMenu.Controls.Add(btnAgregarMenu);
            groupMenu.Controls.Add(btnEditarMenu);
            groupMenu.Controls.Add(btnActivar);
            groupMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupMenu.Location = new Point(20, 440);
            groupMenu.Name = "groupMenu";
            groupMenu.Size = new Size(480, 300);
            groupMenu.TabIndex = 1;
            groupMenu.TabStop = false;
            groupMenu.Text = "Gestión del Menú";

            // listaMenu
            listaMenu.FullRowSelect = true;
            listaMenu.GridLines = true;
            listaMenu.Location = new Point(15, 35);
            listaMenu.Name = "listaMenu";
            listaMenu.Size = new Size(450, 200);
            listaMenu.TabIndex = 0;
            listaMenu.UseCompatibleStateImageBehavior = false;
            listaMenu.View = View.Details;

            // btnAgregarMenu
            btnAgregarMenu.BackColor = Color.FromArgb(46, 125, 50);
            btnAgregarMenu.FlatStyle = FlatStyle.Flat;
            btnAgregarMenu.ForeColor = Color.White;
            btnAgregarMenu.Location = new Point(15, 245);
            btnAgregarMenu.Name = "btnAgregarMenu";
            btnAgregarMenu.Size = new Size(135, 35);
            btnAgregarMenu.TabIndex = 1;
            btnAgregarMenu.Text = "+ Agregar";
            btnAgregarMenu.UseVisualStyleBackColor = false;
            btnAgregarMenu.Click += new EventHandler(this.btnAgregarMenu_Click);

            // btnEditarMenu
            btnEditarMenu.BackColor = Color.FromArgb(255, 152, 0);
            btnEditarMenu.FlatStyle = FlatStyle.Flat;
            btnEditarMenu.ForeColor = Color.White;
            btnEditarMenu.Location = new Point(160, 245);
            btnEditarMenu.Name = "btnEditarMenu";
            btnEditarMenu.Size = new Size(135, 35);
            btnEditarMenu.TabIndex = 2;
            btnEditarMenu.Text = "✎ Editar";
            btnEditarMenu.UseVisualStyleBackColor = false;
            btnEditarMenu.Click += new EventHandler(this.btnEditarMenu_Click);

            // btnActivar
            btnActivar.BackColor = Color.FromArgb(211, 47, 47);
            btnActivar.FlatStyle = FlatStyle.Flat;
            btnActivar.ForeColor = Color.White;
            btnActivar.Location = new Point(305, 245);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(135, 35);
            btnActivar.TabIndex = 3;
            btnActivar.Text = "🗑 Eliminar";
            btnActivar.UseVisualStyleBackColor = false;
            btnActivar.Click += new EventHandler(this.btnActivar_Click);

            // groupClientes
            groupClientes = new GroupBox();
            groupClientes.Controls.Add(listaClientes);
            groupClientes.Controls.Add(btnAgregarCliente);
            groupClientes.Controls.Add(btnEditarCliente);
            groupClientes.Controls.Add(btnEliminarCliente);
            groupClientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupClientes.Location = new Point(520, 440);
            groupClientes.Name = "groupClientes";
            groupClientes.Size = new Size(480, 300);
            groupClientes.TabIndex = 2;
            groupClientes.TabStop = false;
            groupClientes.Text = "Gestión de Clientes y Administradores";

            // listaClientes
            listaClientes.FullRowSelect = true;
            listaClientes.GridLines = true;
            listaClientes.Location = new Point(15, 35);
            listaClientes.Name = "listaClientes";
            listaClientes.Size = new Size(450, 200);
            listaClientes.TabIndex = 0;
            listaClientes.UseCompatibleStateImageBehavior = false;
            listaClientes.View = View.Details;

            // btnAgregarCliente
            btnAgregarCliente.BackColor = Color.FromArgb(46, 125, 50);
            btnAgregarCliente.FlatStyle = FlatStyle.Flat;
            btnAgregarCliente.ForeColor = Color.White;
            btnAgregarCliente.Location = new Point(15, 245);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(135, 35);
            btnAgregarCliente.TabIndex = 1;
            btnAgregarCliente.Text = "+ Agregar";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            btnAgregarCliente.Click += new EventHandler(this.btnAgregarCliente_Click);

            // btnEditarCliente
            btnEditarCliente.BackColor = Color.FromArgb(255, 152, 0);
            btnEditarCliente.FlatStyle = FlatStyle.Flat;
            btnEditarCliente.ForeColor = Color.White;
            btnEditarCliente.Location = new Point(160, 245);
            btnEditarCliente.Name = "btnEditarCliente";
            btnEditarCliente.Size = new Size(135, 35);
            btnEditarCliente.TabIndex = 2;
            btnEditarCliente.Text = "✎ Editar";
            btnEditarCliente.UseVisualStyleBackColor = false;
            btnEditarCliente.Click += new EventHandler(this.btnEditarCliente_Click);

            // btnEliminarCliente
            btnEliminarCliente.BackColor = Color.FromArgb(211, 47, 47);
            btnEliminarCliente.FlatStyle = FlatStyle.Flat;
            btnEliminarCliente.ForeColor = Color.White;
            btnEliminarCliente.Location = new Point(305, 245);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(135, 35);
            btnEliminarCliente.TabIndex = 3;
            btnEliminarCliente.Text = "🗑 Eliminar";
            btnEliminarCliente.UseVisualStyleBackColor = false;
            btnEliminarCliente.Click += new EventHandler(this.btnEliminarCliente_Click);

            // lblUsuario
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.Location = new Point(780, 750);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(200, 23);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario: Cargando...";

            // Form4
            this.ClientSize = new Size(1030, 790);
            this.Controls.Add(lblUsuario);
            this.Controls.Add(groupClientes);
            this.Controls.Add(groupMenu);
            this.Controls.Add(groupReservas);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form4";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Panel de Administrador - Puerto de Brasas";
            groupReservas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listaReservas).EndInit();
            groupMenu.ResumeLayout(false);
            groupClientes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private GroupBox groupReservas;
        private DataGridView listaReservas;
        private Button btnAceptar;
        private Button btnRechazar;
        private Button btnEditarReserva;
        private Button btnVerDetalles;
        private GroupBox groupMenu;
        private ListView listaMenu;
        private Button btnAgregarMenu;
        private Button btnEditarMenu;
        private Button btnActivar;
        private GroupBox groupClientes;
        private ListView listaClientes;
        private Button btnAgregarCliente;
        private Button btnEditarCliente;
        private Button btnEliminarCliente;
        private Label lblUsuario;
    }
}