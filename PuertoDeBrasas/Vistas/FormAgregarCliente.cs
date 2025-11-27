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

namespace PuertoDeBrasas.Vistas
{
    public partial class FormAgregarCliente : Form
    {
        public Cliente ClienteNuevo { get; private set; }
        private bool esEdicion;

        public FormAgregarCliente(Cliente? clienteExistente = null)
        {
            InitializeComponent();

            if (clienteExistente != null)
            {
                esEdicion = true;
                txtNombre.Text = clienteExistente.Nombre;
                txtEmail.Text = clienteExistente.CorreoElectronico;
                txtTelefono.Text = clienteExistente.Telefono;
                txtClave.Text = clienteExistente.Clave;
                comboTipo.SelectedItem = clienteExistente.TipoCliente;
                this.Text = "Editar Cliente";
                ClienteNuevo = clienteExistente;
            }
            else
            {
                esEdicion = false;
                ClienteNuevo = new Cliente();
                this.Text = "Agregar Cliente";
                comboTipo.SelectedIndex = 0; // Por defecto "Persona"
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresa el nombre completo.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // Validar que el nombre solo contenga letras y espacios
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.", "Nombre inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // Validar email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Ingresa el correo electrónico.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Validar formato de email
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9]+@gmail\.com$"))
            {
                MessageBox.Show("El correo debe tener el formato 'usuario@gmail.com'.", "Email inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Validar teléfono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingresa el número de teléfono.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            // Validar que el teléfono tenga 10 dígitos
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^\d{10}$"))
            {
                MessageBox.Show("El teléfono debe contener exactamente 10 números.", "Teléfono inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Ingresa la contraseña.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            if (txtClave.Text.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Contraseña inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            // Validar tipo de cliente
            if (comboTipo.SelectedItem == null)
            {
                MessageBox.Show("Selecciona el tipo de cliente.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboTipo.Focus();
                return;
            }

            // Asignar valores
            ClienteNuevo.Nombre = txtNombre.Text.Trim();
            ClienteNuevo.CorreoElectronico = txtEmail.Text.Trim();
            ClienteNuevo.Telefono = txtTelefono.Text.Trim();
            ClienteNuevo.Clave = txtClave.Text.Trim();
            ClienteNuevo.TipoCliente = comboTipo.SelectedItem.ToString() ?? "Persona";

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
