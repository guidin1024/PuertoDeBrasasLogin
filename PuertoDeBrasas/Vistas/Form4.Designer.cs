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
            btnEliminarReserva = new Button();
            groupMenu = new GroupBox();
            listaMenu = new ListView();
            btnAgregarMenu = new Button();
            btnEditarMenu = new Button();
            btnActivar = new Button();
            groupClientes = new GroupBox();
            listaClientes = new ListView();
            btnAgregarCliente = new Button();
            btnEditarCliente = new Button();
            btnEliminarCliente = new Button();
            lblUsuario = new Label();
            btnCerrarSesion = new Button();
            groupReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listaReservas).BeginInit();
            groupMenu.SuspendLayout();
            groupClientes.SuspendLayout();
            SuspendLayout();

            // groupReservas
            groupReservas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupReservas.Controls.Add(listaReservas);
            groupReservas.Controls.Add(btnAceptar);
            groupReservas.Controls.Add(btnRechazar);
            groupReservas.Controls.Add(btnEditarReserva);
            groupReservas.Controls.Add(btnVerDetalles);
            groupReservas.Controls.Add(btnEliminarReserva);
            groupReservas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupReservas.Location = new Point(20, 20);
            groupReservas.Name = "groupReservas";
            groupReservas.Size = new Size(1240, 450);
            groupReservas.TabIndex = 0;
            groupReservas.TabStop = false;
            groupReservas.Text = "Gestión de Reservas";

            // listaReservas
            listaReservas.AllowUserToAddRows = false;
            listaReservas.AllowUserToDeleteRows = false;
            listaReservas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listaReservas.ColumnHeadersHeight = 29;
            listaReservas.Location = new Point(20, 30);
            listaReservas.Name = "listaReservas";
            listaReservas.ReadOnly = true;
            listaReservas.RowHeadersWidth = 51;
            listaReservas.Size = new Size(1200, 350);
            listaReservas.TabIndex = 0;

            // btnAceptar
            btnAceptar.BackColor = Color.FromArgb(46, 125, 50);
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(20, 395);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(140, 40);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "✓ Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += new EventHandler(this.btnAceptar_Click);

            // btnRechazar
            btnRechazar.BackColor = Color.FromArgb(211, 47, 47);
            btnRechazar.FlatStyle = FlatStyle.Flat;
            btnRechazar.ForeColor = Color.White;
            btnRechazar.Location = new Point(170, 395);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new Size(140, 40);
            btnRechazar.TabIndex = 2;
            btnRechazar.Text = "✗ Rechazar";
            btnRechazar.UseVisualStyleBackColor = false;
            btnRechazar.Click += new EventHandler(this.btnRechazar_Click);

            // btnEditarReserva
            btnEditarReserva.BackColor = Color.FromArgb(255, 152, 0);
            btnEditarReserva.FlatStyle = FlatStyle.Flat;
            btnEditarReserva.ForeColor = Color.White;
            btnEditarReserva.Location = new Point(320, 395);
            btnEditarReserva.Name = "btnEditarReserva";
            btnEditarReserva.Size = new Size(140, 40);
            btnEditarReserva.TabIndex = 3;
            btnEditarReserva.Text = "✎ Editar";
            btnEditarReserva.UseVisualStyleBackColor = false;
            btnEditarReserva.Click += new EventHandler(this.btnEditarReserva_Click);

            // btnVerDetalles
            btnVerDetalles.BackColor = Color.FromArgb(33, 150, 243);
            btnVerDetalles.FlatStyle = FlatStyle.Flat;
            btnVerDetalles.ForeColor = Color.White;
            btnVerDetalles.Location = new Point(470, 395);
            btnVerDetalles.Name = "btnVerDetalles";
            btnVerDetalles.Size = new Size(160, 40);
            btnVerDetalles.TabIndex = 4;
            btnVerDetalles.Text = "🔍 Ver Detalles";
            btnVerDetalles.UseVisualStyleBackColor = false;
            btnVerDetalles.Click += new EventHandler(this.btnVerDetalles_Click);

            // btnEliminarReserva
            btnEliminarReserva.BackColor = Color.FromArgb(244, 67, 54);
            btnEliminarReserva.FlatStyle = FlatStyle.Flat;
            btnEliminarReserva.ForeColor = Color.White;
            btnEliminarReserva.Location = new Point(640, 395);
            btnEliminarReserva.Name = "btnEliminarReserva";
            btnEliminarReserva.Size = new Size(160, 40);
            btnEliminarReserva.TabIndex = 5;
            btnEliminarReserva.Text = "🗑 Eliminar";
            btnEliminarReserva.UseVisualStyleBackColor = false;
            btnEliminarReserva.Click += new EventHandler(this.btnEliminarReserva_Click);

            // groupMenu
            groupMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupMenu.Controls.Add(listaMenu);
            groupMenu.Controls.Add(btnAgregarMenu);
            groupMenu.Controls.Add(btnEditarMenu);
            groupMenu.Controls.Add(btnActivar);
            groupMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupMenu.Location = new Point(20, 490);
            groupMenu.Name = "groupMenu";
            groupMenu.Size = new Size(610, 320);
            groupMenu.TabIndex = 1;
            groupMenu.TabStop = false;
            groupMenu.Text = "Gestión del Menú";

            // listaMenu
            listaMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listaMenu.FullRowSelect = true;
            listaMenu.GridLines = true;
            listaMenu.Location = new Point(15, 35);
            listaMenu.Name = "listaMenu";
            listaMenu.Size = new Size(580, 220);
            listaMenu.TabIndex = 0;
            listaMenu.UseCompatibleStateImageBehavior = false;
            listaMenu.View = View.Details;

            // btnAgregarMenu
            btnAgregarMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregarMenu.BackColor = Color.FromArgb(46, 125, 50);
            btnAgregarMenu.FlatStyle = FlatStyle.Flat;
            btnAgregarMenu.ForeColor = Color.White;
            btnAgregarMenu.Location = new Point(15, 270);
            btnAgregarMenu.Name = "btnAgregarMenu";
            btnAgregarMenu.Size = new Size(155, 35);
            btnAgregarMenu.TabIndex = 1;
            btnAgregarMenu.Text = "+ Agregar";
            btnAgregarMenu.UseVisualStyleBackColor = false;
            btnAgregarMenu.Click += new EventHandler(this.btnAgregarMenu_Click);

            // btnEditarMenu
            btnEditarMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditarMenu.BackColor = Color.FromArgb(255, 152, 0);
            btnEditarMenu.FlatStyle = FlatStyle.Flat;
            btnEditarMenu.ForeColor = Color.White;
            btnEditarMenu.Location = new Point(180, 270);
            btnEditarMenu.Name = "btnEditarMenu";
            btnEditarMenu.Size = new Size(155, 35);
            btnEditarMenu.TabIndex = 2;
            btnEditarMenu.Text = "✎ Editar";
            btnEditarMenu.UseVisualStyleBackColor = false;
            btnEditarMenu.Click += new EventHandler(this.btnEditarMenu_Click);

            // btnActivar
            btnActivar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnActivar.BackColor = Color.FromArgb(211, 47, 47);
            btnActivar.FlatStyle = FlatStyle.Flat;
            btnActivar.ForeColor = Color.White;
            btnActivar.Location = new Point(345, 270);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(155, 35);
            btnActivar.TabIndex = 3;
            btnActivar.Text = "🗑 Eliminar";
            btnActivar.UseVisualStyleBackColor = false;
            btnActivar.Click += new EventHandler(this.btnActivar_Click);

            // groupClientes
            groupClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupClientes.Controls.Add(listaClientes);
            groupClientes.Controls.Add(btnAgregarCliente);
            groupClientes.Controls.Add(btnEditarCliente);
            groupClientes.Controls.Add(btnEliminarCliente);
            groupClientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupClientes.Location = new Point(650, 490);
            groupClientes.Name = "groupClientes";
            groupClientes.Size = new Size(610, 320);
            groupClientes.TabIndex = 2;
            groupClientes.TabStop = false;
            groupClientes.Text = "Gestión de Clientes y Administradores";

            // listaClientes
            listaClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listaClientes.FullRowSelect = true;
            listaClientes.GridLines = true;
            listaClientes.Location = new Point(15, 35);
            listaClientes.Name = "listaClientes";
            listaClientes.Size = new Size(580, 220);
            listaClientes.TabIndex = 0;
            listaClientes.UseCompatibleStateImageBehavior = false;
            listaClientes.View = View.Details;

            // btnAgregarCliente
            btnAgregarCliente.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregarCliente.BackColor = Color.FromArgb(46, 125, 50);
            btnAgregarCliente.FlatStyle = FlatStyle.Flat;
            btnAgregarCliente.ForeColor = Color.White;
            btnAgregarCliente.Location = new Point(15, 270);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(155, 35);
            btnAgregarCliente.TabIndex = 1;
            btnAgregarCliente.Text = "+ Agregar";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            btnAgregarCliente.Click += new EventHandler(this.btnAgregarCliente_Click);

            // btnEditarCliente
            btnEditarCliente.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditarCliente.BackColor = Color.FromArgb(255, 152, 0);
            btnEditarCliente.FlatStyle = FlatStyle.Flat;
            btnEditarCliente.ForeColor = Color.White;
            btnEditarCliente.Location = new Point(180, 270);
            btnEditarCliente.Name = "btnEditarCliente";
            btnEditarCliente.Size = new Size(155, 35);
            btnEditarCliente.TabIndex = 2;
            btnEditarCliente.Text = "✎ Editar";
            btnEditarCliente.UseVisualStyleBackColor = false;
            btnEditarCliente.Click += new EventHandler(this.btnEditarCliente_Click);

            // btnEliminarCliente
            btnEliminarCliente.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminarCliente.BackColor = Color.FromArgb(211, 47, 47);
            btnEliminarCliente.FlatStyle = FlatStyle.Flat;
            btnEliminarCliente.ForeColor = Color.White;
            btnEliminarCliente.Location = new Point(345, 270);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(155, 35);
            btnEliminarCliente.TabIndex = 3;
            btnEliminarCliente.Text = "🗑 Eliminar";
            btnEliminarCliente.UseVisualStyleBackColor = false;
            btnEliminarCliente.Click += new EventHandler(this.btnEliminarCliente_Click);

            // lblUsuario
            lblUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.Location = new Point(900, 825);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(200, 23);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario: Cargando...";

            // btnCerrarSesion
            btnCerrarSesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.FromArgb(211, 47, 47);
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(1110, 820);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(150, 35);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += new EventHandler(this.btnCerrarSesion_Click);

            // Form4
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1280, 870);
            this.Controls.Add(btnCerrarSesion);
            this.Controls.Add(lblUsuario);
            this.Controls.Add(groupClientes);
            this.Controls.Add(groupMenu);
            this.Controls.Add(groupReservas);
            this.MinimumSize = new Size(1280, 870);
            this.Name = "Form4";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Panel de Administrador - Puerto de Brasas";
            this.WindowState = FormWindowState.Maximized;
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
        private Button btnEliminarReserva;
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
        private Button btnCerrarSesion;
    }
}