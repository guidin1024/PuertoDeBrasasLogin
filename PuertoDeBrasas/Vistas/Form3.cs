using System;
using System.Windows.Forms;

namespace PuertoDeBrasas
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            //this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;


        }

        private void cerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 form1 = new Form1();
            form1.WindowState = FormWindowState.Normal;
            form1.StartPosition = FormStartPosition.CenterScreen;


            try
            {
                var textBoxCorreo = form1.Controls["Textbox_Email"] as TextBox;
                var textBoxContraseña = form1.Controls["Textbox_contraseña"] as TextBox;

                if (textBoxCorreo != null) textBoxCorreo.Text = string.Empty;
                if (textBoxContraseña != null) textBoxContraseña.Text = string.Empty;
            }
            catch { }

            form1.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
