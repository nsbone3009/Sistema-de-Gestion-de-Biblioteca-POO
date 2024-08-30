using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Biblioteca_Poo
{
    public partial class frmActualizarContraseña : Form
    {
        public frmActualizarContraseña()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            csConexionSQL nueva = new csConexionSQL();
            if (txtNuevaClave.Text == txtConfirmarCLave.Text)
            {
                nueva.ActualizarContraseña(txtCorreo.Text, txtNuevaClave.Text);
                this.Hide();
            }
            else
            {
                MessageBox.Show("La Claves no son iguales");
            }
        }
    }
}
