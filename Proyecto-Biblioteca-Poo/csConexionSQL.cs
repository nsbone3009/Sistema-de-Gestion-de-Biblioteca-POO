using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Proyecto_Biblioteca_Poo
{
    class csConexionSQL
    {
        private string cadenaConexion = @"Server = DESKTOP-T767FTN\KHRIZ; Database = Biblioteca; Integrated Security = True";
            private SqlConnection conexion;

            public SqlConnection Conexion { get { return conexion; } }

            public csConexionSQL()
            {
                conexion = new SqlConnection(cadenaConexion);
            }

            public DataTable MostrarRegistros(string consulta)
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataAdapter datos = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }

            public void Update(string consulta)
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }

            public SqlDataAdapter Select(string consulta)
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataAdapter datos = new SqlDataAdapter(comando);
                return datos;
            }

            public SqlDataReader SelectLeer(string consulta)
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader leer = comando.ExecuteReader();
                return leer;
            }

            public void CerrarConexion()
            {
                conexion.Close();
            }

            public void AbrirConexion()
            {
                conexion.Open();
            }
    }
}
