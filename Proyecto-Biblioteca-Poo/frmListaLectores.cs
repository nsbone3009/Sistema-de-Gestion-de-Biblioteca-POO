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
    public partial class frmListaLectores : Form
    {
        public frmListaLectores()
        {
            InitializeComponent();
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            new frmAgregarODetallesLectores().ShowDialog();
        }

        private void frmListaLectores_Load(object sender, EventArgs e)
        {
            string consulta = "Select * from Lectores";
            csConexionSQL database = new csConexionSQL();
            dgvLectores.DataSource = database.MostrarRegistros(consulta);
            new csAjustarDataGridView().Ajustar(dgvLectores);
        }
    }
}
