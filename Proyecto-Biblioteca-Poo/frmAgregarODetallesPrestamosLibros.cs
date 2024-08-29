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
    public partial class frmAgregarODetallesPrestamosLibros : Form
    {
        public frmAgregarODetallesPrestamosLibros()
        {
            InitializeComponent();
        }

        private void DetallesOAgregarPrestamos_Load(object sender, EventArgs e)
        {
            txtFechaPrestamo.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
