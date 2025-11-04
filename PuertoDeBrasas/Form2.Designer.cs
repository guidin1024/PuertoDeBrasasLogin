namespace PuertoDeBrasas
{
    partial class Form2
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
            label1 = new Label();
            LabelNom = new Label();
            LabelCorreo = new Label();
            LabelContraseña = new Label();
            LabelTel = new Label();
            textBoxTelefono = new TextBox();
            textBoxContraseña = new TextBox();
            textBoxCorreo = new TextBox();
            textBoxNom = new TextBox();
            buttonRegistro = new Button();
            buttonCancelar = new Button();
            comboTipos = new ComboBox();
            LabelTipoUsuario = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Peru;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(325, 20);
            label1.Name = "label1";
            label1.Size = new Size(163, 41);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO";
            // 
            // LabelNom
            // 
            LabelNom.AutoSize = true;
            LabelNom.BackColor = Color.Peru;
            LabelNom.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelNom.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            LabelNom.ImageAlign = ContentAlignment.BottomCenter;
            LabelNom.Location = new Point(56, 87);
            LabelNom.Name = "LabelNom";
            LabelNom.Size = new Size(165, 23);
            LabelNom.TabIndex = 1;
            LabelNom.Text = "Apellido y nombre:";
            // 
            // LabelCorreo
            // 
            LabelCorreo.AutoSize = true;
            LabelCorreo.BackColor = Color.Peru;
            LabelCorreo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCorreo.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            LabelCorreo.ImageAlign = ContentAlignment.BottomCenter;
            LabelCorreo.Location = new Point(56, 172);
            LabelCorreo.Name = "LabelCorreo";
            LabelCorreo.Size = new Size(162, 23);
            LabelCorreo.TabIndex = 2;
            LabelCorreo.Text = "Correo Electronico:";
            // 
            // LabelContraseña
            // 
            LabelContraseña.AutoSize = true;
            LabelContraseña.BackColor = Color.Peru;
            LabelContraseña.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelContraseña.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            LabelContraseña.ImageAlign = ContentAlignment.BottomCenter;
            LabelContraseña.Location = new Point(56, 265);
            LabelContraseña.Name = "LabelContraseña";
            LabelContraseña.Size = new Size(104, 23);
            LabelContraseña.TabIndex = 3;
            LabelContraseña.Text = "Contraseña:";
            // 
            // LabelTel
            // 
            LabelTel.AutoSize = true;
            LabelTel.BackColor = Color.Peru;
            LabelTel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTel.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            LabelTel.ImageAlign = ContentAlignment.BottomCenter;
            LabelTel.Location = new Point(56, 503);
            LabelTel.Name = "LabelTel";
            LabelTel.Size = new Size(78, 23);
            LabelTel.TabIndex = 4;
            LabelTel.Text = "Telefono";
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(56, 529);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(161, 27);
            textBoxTelefono.TabIndex = 6;
            // 
            // textBoxContraseña
            // 
            textBoxContraseña.Location = new Point(56, 291);
            textBoxContraseña.Name = "textBoxContraseña";
            textBoxContraseña.PasswordChar = '*';
            textBoxContraseña.Size = new Size(161, 27);
            textBoxContraseña.TabIndex = 7;
            // 
            // textBoxCorreo
            // 
            textBoxCorreo.Location = new Point(56, 198);
            textBoxCorreo.Name = "textBoxCorreo";
            textBoxCorreo.Size = new Size(161, 27);
            textBoxCorreo.TabIndex = 8;
            // 
            // textBoxNom
            // 
            textBoxNom.Location = new Point(56, 113);
            textBoxNom.Name = "textBoxNom";
            textBoxNom.Size = new Size(165, 27);
            textBoxNom.TabIndex = 9;
            // 
            // buttonRegistro
            // 
            buttonRegistro.BackColor = Color.Peru;
            buttonRegistro.BackgroundImage = Properties.Resources.Puerto_de_Brasas_en_Madera__1_;
            buttonRegistro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRegistro.Location = new Point(546, 511);
            buttonRegistro.Name = "buttonRegistro";
            buttonRegistro.Size = new Size(224, 55);
            buttonRegistro.TabIndex = 10;
            buttonRegistro.Text = "REGISTRARSE";
            buttonRegistro.UseVisualStyleBackColor = false;
            buttonRegistro.Click += buttonRegistro_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.Peru;
            buttonCancelar.BackgroundImage = Properties.Resources.Puerto_de_Brasas_en_Madera__1_;
            buttonCancelar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancelar.Location = new Point(373, 520);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(138, 42);
            buttonCancelar.TabIndex = 11;
            buttonCancelar.Text = "CANCELAR";
            buttonCancelar.UseVisualStyleBackColor = false;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // comboTipos
            // 
            comboTipos.FormattingEnabled = true;
            comboTipos.Items.AddRange(new object[] { "Persona", "Empresa" });
            comboTipos.Location = new Point(56, 414);
            comboTipos.Name = "comboTipos";
            comboTipos.Size = new Size(241, 28);
            comboTipos.TabIndex = 12;
            // 
            // LabelTipoUsuario
            // 
            LabelTipoUsuario.AutoSize = true;
            LabelTipoUsuario.BackColor = Color.Peru;
            LabelTipoUsuario.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTipoUsuario.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            LabelTipoUsuario.ImageAlign = ContentAlignment.BottomCenter;
            LabelTipoUsuario.Location = new Point(56, 388);
            LabelTipoUsuario.Name = "LabelTipoUsuario";
            LabelTipoUsuario.Size = new Size(139, 23);
            LabelTipoUsuario.TabIndex = 13;
            LabelTipoUsuario.Text = "Tipo de usuario:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 607);
            Controls.Add(LabelTipoUsuario);
            Controls.Add(comboTipos);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonRegistro);
            Controls.Add(textBoxNom);
            Controls.Add(textBoxCorreo);
            Controls.Add(textBoxContraseña);
            Controls.Add(textBoxTelefono);
            Controls.Add(LabelTel);
            Controls.Add(LabelContraseña);
            Controls.Add(LabelCorreo);
            Controls.Add(LabelNom);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Panel de registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label LabelNom;
        private Label LabelCorreo;
        private Label LabelContraseña;
        private Label LabelTel;
        private TextBox textBoxTelefono;
        private TextBox textBoxContraseña;
        private TextBox textBoxCorreo;
        private TextBox textBoxNom;
        private Button buttonRegistro;
        private Button buttonCancelar;
        private ComboBox comboTipos;
        private Label LabelTipoUsuario;
    }
}