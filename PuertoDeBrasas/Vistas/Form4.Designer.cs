namespace PuertoDeBrasas.Vistas
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            groupMateria = new GroupBox();
            lblStockActual = new Label();
            btnRegistrarCompra = new Button();
            btnEditarProveedores = new Button();
            lblAlerta = new Label();
            groupConfig = new GroupBox();
            btnCambiarPrecios = new Button();
            btnDefinirHorario = new Button();
            btnCambiarContrasena = new Button();
            lblUsuario = new Label();
            groupReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listaReservas).BeginInit();
            groupMenu.SuspendLayout();
            groupMateria.SuspendLayout();
            groupConfig.SuspendLayout();
            SuspendLayout();
            // 
            // groupReservas
            // 
            groupReservas.Controls.Add(listaReservas);
            groupReservas.Controls.Add(btnAceptar);
            groupReservas.Controls.Add(btnRechazar);
            groupReservas.Controls.Add(btnEditarReserva);
            groupReservas.Controls.Add(btnVerDetalles);
            groupReservas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupReservas.Location = new Point(20, 20);
            groupReservas.Name = "groupReservas";
            groupReservas.Size = new Size(450, 260);
            groupReservas.TabIndex = 0;
            groupReservas.TabStop = false;
            groupReservas.Text = "Gestión de Reservas";
            // 
            // listaReservas
            // 
            listaReservas.AllowUserToAddRows = false;
            listaReservas.AllowUserToDeleteRows = false;
            listaReservas.ColumnHeadersHeight = 29;
            listaReservas.Location = new Point(20, 30);
            listaReservas.Name = "listaReservas";
            listaReservas.ReadOnly = true;
            listaReservas.RowHeadersWidth = 51;
            listaReservas.Size = new Size(410, 160);
            listaReservas.TabIndex = 0;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(20, 200);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(90, 30);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            // 
            // btnRechazar
            // 
            btnRechazar.Location = new Point(120, 200);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new Size(90, 30);
            btnRechazar.TabIndex = 2;
            btnRechazar.Text = "Rechazar";
            // 
            // btnEditarReserva
            // 
            btnEditarReserva.Location = new Point(220, 200);
            btnEditarReserva.Name = "btnEditarReserva";
            btnEditarReserva.Size = new Size(90, 30);
            btnEditarReserva.TabIndex = 3;
            btnEditarReserva.Text = "Editar...";
            // 
            // btnVerDetalles
            // 
            btnVerDetalles.Location = new Point(320, 200);
            btnVerDetalles.Name = "btnVerDetalles";
            btnVerDetalles.Size = new Size(110, 30);
            btnVerDetalles.TabIndex = 4;
            btnVerDetalles.Text = "Ver Detalles...";
            // 
            // groupMenu
            // 
            groupMenu.Controls.Add(listaMenu);
            groupMenu.Controls.Add(btnAgregarMenu);
            groupMenu.Controls.Add(btnEditarMenu);
            groupMenu.Controls.Add(btnActivar);
            groupMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupMenu.Location = new Point(500, 20);
            groupMenu.Name = "groupMenu";
            groupMenu.Size = new Size(520, 260);
            groupMenu.TabIndex = 1;
            groupMenu.TabStop = false;
            groupMenu.Text = "Gestión del Menú";
            // 
            // listaMenu
            // 
            listaMenu.Location = new Point(25, 35);
            listaMenu.Name = "listaMenu";
            listaMenu.Size = new Size(470, 160);
            listaMenu.TabIndex = 0;
            listaMenu.UseCompatibleStateImageBehavior = false;
            listaMenu.View = View.Details;
            // 
            // btnAgregarMenu
            // 
            btnAgregarMenu.Location = new Point(25, 205);
            btnAgregarMenu.Name = "btnAgregarMenu";
            btnAgregarMenu.Size = new Size(120, 30);
            btnAgregarMenu.TabIndex = 1;
            btnAgregarMenu.Text = "Agregar...";
            // 
            // btnEditarMenu
            // 
            btnEditarMenu.Location = new Point(155, 205);
            btnEditarMenu.Name = "btnEditarMenu";
            btnEditarMenu.Size = new Size(120, 30);
            btnEditarMenu.TabIndex = 2;
            btnEditarMenu.Text = "Editar...";
            // 
            // btnActivar
            // 
            btnActivar.Location = new Point(285, 205);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(150, 30);
            btnActivar.TabIndex = 3;
            btnActivar.Text = "Activar/Desactivar";
            // 
            // groupMateria
            // 
            groupMateria.Controls.Add(lblStockActual);
            groupMateria.Controls.Add(btnRegistrarCompra);
            groupMateria.Controls.Add(btnEditarProveedores);
            groupMateria.Controls.Add(lblAlerta);
            groupMateria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupMateria.Location = new Point(20, 300);
            groupMateria.Name = "groupMateria";
            groupMateria.Size = new Size(450, 200);
            groupMateria.TabIndex = 2;
            groupMateria.TabStop = false;
            groupMateria.Text = "Gestión de Materia Prima y Proveedores";
            // 
            // lblStockActual
            // 
            lblStockActual.Location = new Point(20, 40);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(150, 25);
            lblStockActual.TabIndex = 0;
            lblStockActual.Text = "Stock actual: 20";
            // 
            // btnRegistrarCompra
            // 
            btnRegistrarCompra.Location = new Point(20, 80);
            btnRegistrarCompra.Name = "btnRegistrarCompra";
            btnRegistrarCompra.Size = new Size(180, 30);
            btnRegistrarCompra.TabIndex = 1;
            btnRegistrarCompra.Text = "Registrar compra...";
            // 
            // btnEditarProveedores
            // 
            btnEditarProveedores.Location = new Point(20, 120);
            btnEditarProveedores.Name = "btnEditarProveedores";
            btnEditarProveedores.Size = new Size(180, 30);
            btnEditarProveedores.TabIndex = 2;
            btnEditarProveedores.Text = "Editar proveedores...";
            // 
            // lblAlerta
            // 
            lblAlerta.Location = new Point(0, 0);
            lblAlerta.Name = "lblAlerta";
            lblAlerta.Size = new Size(100, 23);
            lblAlerta.TabIndex = 3;
            // 
            // groupConfig
            // 
            groupConfig.Controls.Add(btnCambiarPrecios);
            groupConfig.Controls.Add(btnDefinirHorario);
            groupConfig.Controls.Add(btnCambiarContrasena);
            groupConfig.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupConfig.Location = new Point(500, 300);
            groupConfig.Name = "groupConfig";
            groupConfig.Size = new Size(520, 200);
            groupConfig.TabIndex = 3;
            groupConfig.TabStop = false;
            groupConfig.Text = "Configuración General";
            // 
            // btnCambiarPrecios
            // 
            btnCambiarPrecios.Location = new Point(30, 50);
            btnCambiarPrecios.Name = "btnCambiarPrecios";
            btnCambiarPrecios.Size = new Size(200, 30);
            btnCambiarPrecios.TabIndex = 0;
            btnCambiarPrecios.Text = "Cambiar precios...";
            // 
            // btnDefinirHorario
            // 
            btnDefinirHorario.Location = new Point(30, 90);
            btnDefinirHorario.Name = "btnDefinirHorario";
            btnDefinirHorario.Size = new Size(200, 30);
            btnDefinirHorario.TabIndex = 1;
            btnDefinirHorario.Text = "Definir horario eventos...";
            // 
            // btnCambiarContrasena
            // 
            btnCambiarContrasena.Location = new Point(30, 130);
            btnCambiarContrasena.Name = "btnCambiarContrasena";
            btnCambiarContrasena.Size = new Size(200, 30);
            btnCambiarContrasena.TabIndex = 2;
            btnCambiarContrasena.Text = "Cambiar contraseña...";
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new Point(850, 510);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(200, 30);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario: Administrador";
            // 
            // Form4
            // 
            ClientSize = new Size(1071, 580);
            Controls.Add(groupReservas);
            Controls.Add(groupMenu);
            Controls.Add(groupMateria);
            Controls.Add(groupConfig);
            Controls.Add(lblUsuario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form4";
            Text = "ADMINISTRADOR";
            groupReservas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listaReservas).EndInit();
            groupMenu.ResumeLayout(false);
            groupMateria.ResumeLayout(false);
            groupConfig.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupReservas;
        private System.Windows.Forms.DataGridView listaReservas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnEditarReserva;
        private System.Windows.Forms.Button btnVerDetalles;

        private System.Windows.Forms.GroupBox groupMenu;
        private System.Windows.Forms.ListView listaMenu;
        private System.Windows.Forms.Button btnAgregarMenu;
        private System.Windows.Forms.Button btnEditarMenu;
        private System.Windows.Forms.Button btnActivar;

        private System.Windows.Forms.GroupBox groupMateria;
        private System.Windows.Forms.Label lblStockActual;
        private System.Windows.Forms.Button btnRegistrarCompra;
        private System.Windows.Forms.Button btnEditarProveedores;
        private System.Windows.Forms.Label lblAlerta;

        private System.Windows.Forms.GroupBox groupConfig;
        private System.Windows.Forms.Button btnCambiarPrecios;
        private System.Windows.Forms.Button btnDefinirHorario;
        private System.Windows.Forms.Button btnCambiarContrasena;

        private System.Windows.Forms.Label lblUsuario;
    }
}