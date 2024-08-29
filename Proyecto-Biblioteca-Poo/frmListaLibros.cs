﻿using System;
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
    public partial class frmListaLibros : Form
    {
        public frmListaLibros()
        {
            InitializeComponent();
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            new frmAgregarODetallesLibros().ShowDialog();
        }

        private void frmListaLibros_Load(object sender, EventArgs e)
        {
            string consulta = "Select isbn_lb, titulo_lb, autor_es_lb, editorial_lb, genero_lb, año_publicacion_lb, cantidad_lb, sinopsis_lb from Libros";
            csConexionSQL database = new csConexionSQL();
            dgvLibros.DataSource = database.MostrarRegistros(consulta);
            new csAjustarDataGridView().Ajustar(dgvLibros);
        }
    }
}
