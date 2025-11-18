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
    public partial class FormAgregarPlato : Form
    {
        public Plato PlatoNuevo { get; private set; }

        public FormAgregarPlato(Plato? platoExistente = null)
        {
            InitializeComponent();

            if (platoExistente != null)
            {
                txtNombre.Text = platoExistente.NombrePlato;
                txtDescripcion.Text = platoExistente.Descripcion;
                txtPrecio.Text = platoExistente.Precio.ToString();
                this.Text = "Editar Plato";
                PlatoNuevo = platoExistente;
            }
            else
            {
                PlatoNuevo = new Plato();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresa el nombre del plato.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido.");
                return;
            }

            PlatoNuevo.NombrePlato = txtNombre.Text.Trim();
            PlatoNuevo.Descripcion = txtDescripcion.Text.Trim();
            PlatoNuevo.Precio = precio;

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