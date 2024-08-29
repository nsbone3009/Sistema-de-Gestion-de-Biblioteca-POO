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
    public partial class frmListaPrestamosLibros : Form
    {
        public frmListaPrestamosLibros()
        {
            InitializeComponent();
        }

        private void btnAgregarPrestamo_Click(object sender, EventArgs e)
        {
            new frmAgregarODetallesPrestamosLibros().ShowDialog();
        }

        private void frmListaPrestamosLibros_Load(object sender, EventArgs e)
        {
            string consulta = "Select * from Prestamos";
            csConexionSQL database = new csConexionSQL();
            dgvPrestamos.DataSource = database.MostrarRegistros(consulta);
            new csAjustarDataGridView().Ajustar(dgvPrestamos);
        }
    }
}
