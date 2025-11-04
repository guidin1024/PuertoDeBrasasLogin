using PuertoDeBrasas.Data;
using PuertoDeBrasas.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PuertoDeBrasas
{
    public partial class Form1 : Form
    {
        private ClienteRepository clienteRepo;

        public Form1()
        {
            InitializeComponent();
            clienteRepo = new ClienteRepository();

            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Puerto de Brasas en Llamas.png");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string correo = Textbox_Email.Text.Trim();
            string clave = Textbox_contraseña.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cliente = clienteRepo.Autenticar(correo, clave);

                if (cliente != null)
                {
                    MessageBox.Show($"Inicio de sesión exitoso. ¡Bienvenido {cliente.Nombre}!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }


    }
}

