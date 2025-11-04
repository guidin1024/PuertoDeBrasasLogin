namespace PuertoDeBrasas
{
    partial class Form1 : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LabelTitulo = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Button1 = new Button();
            Textbox_Email = new TextBox();
            Textbox_contraseña = new TextBox();
            Button2 = new Button();
            SuspendLayout();
            // 
            // LabelTitulo
            // 
            LabelTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelTitulo.BackColor = Color.Peru;
            LabelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTitulo.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            LabelTitulo.ImageAlign = ContentAlignment.BottomCenter;
            LabelTitulo.Location = new Point(42, 19);
            LabelTitulo.Name = "LabelTitulo";
            LabelTitulo.Size = new Size(314, 61);
            LabelTitulo.TabIndex = 0;
            LabelTitulo.Text = "INICIO DE SESIÓN";
            // 
            // label2
            // 
            label2.BackColor = Color.Peru;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            label2.ImageAlign = ContentAlignment.BottomCenter;
            label2.Location = new Point(42, 132);
            label2.Name = "label2";
            label2.Size = new Size(170, 25);
            label2.TabIndex = 1;
            label2.Text = "Correo Electronico:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Peru;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            label3.ImageAlign = ContentAlignment.BottomCenter;
            label3.Location = new Point(42, 261);
            label3.Name = "label3";
            label3.Size = new Size(109, 23);
            label3.TabIndex = 2;
            label3.Text = "Contraseña: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Peru;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(42, 497);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 3;
            label4.Text = "¿No tienes cuenta?";
            // 
            // Button1
            // 
            Button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Button1.Location = new Point(42, 390);
            Button1.Name = "Button1";
            Button1.Size = new Size(212, 49);
            Button1.TabIndex = 4;
            Button1.Text = "Ingresar";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // Textbox_Email
            // 
            Textbox_Email.Location = new Point(42, 177);
            Textbox_Email.Name = "Textbox_Email";
            Textbox_Email.Size = new Size(212, 27);
            Textbox_Email.TabIndex = 5;
            // 
            // Textbox_contraseña
            // 
            Textbox_contraseña.Location = new Point(42, 307);
            Textbox_contraseña.Name = "Textbox_contraseña";
            Textbox_contraseña.PasswordChar = '*';
            Textbox_contraseña.Size = new Size(212, 27);
            Textbox_contraseña.TabIndex = 6;
            // 
            // Button2
            // 
            Button2.BackColor = Color.Peru;
            Button2.FlatStyle = FlatStyle.Popup;
            Button2.ForeColor = Color.Blue;
            Button2.Image = Properties.Resources.Puerto_de_Brasas_en_Llamas;
            Button2.ImageAlign = ContentAlignment.BottomCenter;
            Button2.Location = new Point(177, 493);
            Button2.Name = "Button2";
            Button2.Size = new Size(94, 28);
            Button2.TabIndex = 7;
            Button2.Text = "Registrate";
            Button2.UseVisualStyleBackColor = false;
            Button2.Click += Button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 565);
            Controls.Add(Button2);
            Controls.Add(Textbox_contraseña);
            Controls.Add(Textbox_Email);
            Controls.Add(Button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(LabelTitulo);
            Name = "Form1";
            Text = "Panel de inicio de sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTitulo;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button Button1;
        private TextBox Textbox_Email;
        private TextBox Textbox_contraseña;
        private Button Button2;
    }
}
