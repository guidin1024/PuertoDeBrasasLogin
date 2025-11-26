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
    public partial class FormEditarReserva : Form
    {
        public Reserva ReservaEditada { get; private set; }

        public FormEditarReserva(Reserva reserva)
        {
            InitializeComponent();
            ReservaEditada = reserva;

            // Cargar datos existentes
            dateTimePicker1.Value = reserva.Dia;
            txtLugar.Text = reserva.Lugar;

            // Configurar horas
            for (int i = 10; i <= 23; i++)
            {
                comboHoraInicio.Items.Add($"{i:D2}:00");
                comboHoraFin.Items.Add($"{i:D2}:00");
            }
            comboHoraFin.Items.Add("00:00");

            comboHoraInicio.Text = reserva.HoraInicio.ToString(@"hh\:mm");
            comboHoraFin.Text = reserva.HoraFin.ToString(@"hh\:mm");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLugar.Text))
            {
                MessageBox.Show("Ingresa el lugar del evento.");
                return;
            }

            TimeSpan inicio = TimeSpan.Parse(comboHoraInicio.Text);
            TimeSpan fin = TimeSpan.Parse(comboHoraFin.Text);

            if (fin <= inicio)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la de inicio.");
                return;
            }

            ReservaEditada.Dia = dateTimePicker1.Value;
            ReservaEditada.Lugar = txtLugar.Text.Trim();
            ReservaEditada.HoraInicio = inicio;
            ReservaEditada.HoraFin = fin;

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
