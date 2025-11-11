using PuertoDeBrasas.Data;
using PuertoDeBrasas.Modelos;
using System;
using System.Windows.Forms;

namespace PuertoDeBrasas
{
    public partial class Form2 : Form
    {
        private ClienteRepositorio clienteRepo;

        public Form2()
        {
            InitializeComponent();
            clienteRepo = new ClienteRepositorio();

            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Puerto de Brasas en Llamas.png");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;


        }


        private void buttonRegistro_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNom.Text.Trim();
            string correo = textBoxCorreo.Text.Trim();
            string clave = textBoxContraseña.Text.Trim();
            string telefono = textBoxTelefono.Text.Trim();
            string? tipo = comboTipos.SelectedItem?.ToString();

            // Campos obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(clave) || string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar nombre y apellido solo con letras
            if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar correo electrónico formato específico: algo@gmail.com
            if (!System.Text.RegularExpressions.Regex.IsMatch(correo, @"^[a-zA-Z0-9]+@gmail\.com$"))
            {
                MessageBox.Show("El correo debe tener el formato 'nombreDelMail@gmail.com'.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar teléfono solo números y 10 dígitos
            if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{10}$"))
            {
                MessageBox.Show("El teléfono debe contener exactamente 10 números.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente nuevoCliente = new Cliente
            {
                Nombre = nombre,
                CorreoElectronico = correo,
                Clave = clave,
                Telefono = telefono,
                TipoCliente = tipo
            };

            try
            {
                if (clienteRepo.Registrar(nuevoCliente))
                {
                    MessageBox.Show("Registro exitoso. ¡Ahora puedes iniciar sesión!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form1 login = new Form1();
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar al usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    }
}
