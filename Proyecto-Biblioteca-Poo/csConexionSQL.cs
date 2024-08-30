using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Biblioteca_Poo
{
    class csConexionSQL
    {
        private string cadenaConexion = "Password=111;Persist Security Info=False;User ID=yair;Initial Catalog=Biblioteca;Data Source=DESKTOP-GV7UK1D\\SQLEXPRESS";
        private SqlConnection conexion;
        private string cedula;

        public SqlConnection Conexion { get { return conexion; } }
        public string Cedula { get { return cedula; } }

        public csConexionSQL()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public DataTable MostrarRegistros(string consulta)
        {
            DataTable tabla = new DataTable();
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                using (SqlDataAdapter datos = new SqlDataAdapter(comando))
                {
                    datos.Fill(tabla);
                }
            }
            return tabla;
        }

        public void Update(string consulta)
        {
            try
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conexion.Close();
            }
        }

        public SqlDataAdapter Select(string consulta)
        {
            SqlDataAdapter datos;
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                datos = new SqlDataAdapter(comando);
            }
            return datos;
        }

        public SqlDataReader SelectLeer(string consulta)
        {
            SqlDataReader leer;
            try
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    leer = comando.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                throw;

            }
            return leer;
        }

        public void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public void AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection conexion = new SqlConnection("Password=111;Persist Security Info=False;User ID=yair;Initial Catalog=Biblioteca;Data Source=DESKTOP-GV7UK1D\\SQLEXPRESS");
            conexion.Open();
            return conexion;
        }

        public class ResultadoLogin
        {
            public bool EsValido { get; set; }
            public string Rol { get; set; }
        }

        public bool VerificarLogin(string usuario, string contraseña)
        {
            using (SqlConnection conexio = GetConnection())
            {
                string consulta = @"
                    SELECT usuario_crd, contraseña_crd, cedula_usr 
                    FROM Credenciales 
                    WHERE usuario_crd = @usuario AND contraseña_crd = @contraseña;";

                using (SqlCommand comando = new SqlCommand(consulta, conexio))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);

                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        if (leer.Read())
                        {
                            cedula = leer["cedula_usr"].ToString();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public string ObtenerRolUsuario(string cedula)
        {
            string rol = string.Empty;
            using (SqlConnection conexio = GetConnection())
            {
                string consulta = @"
                    SELECT correo_usr, rol_usr 
                    FROM Credenciales AS C 
                    INNER JOIN [Usuarios] AS U ON C.cedula_usr = U.cedula_usr 
                    WHERE C.cedula_usr = @cedula";

                using (SqlCommand comando = new SqlCommand(consulta, conexio))
                {
                    comando.Parameters.AddWithValue("@cedula", cedula.Trim());
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        if (leer.Read())
                        {
                            rol = leer["rol_usr"].ToString();
                        }
                    }
                }
            }
            return rol.Trim();
        }
        public void ActualizarContraseña(string correo, string NuevaClave)
        {
            string consulta = " select cedula_usr from Usuarios where correo_usr='" + correo + "'";
            conexion.Open();
            SqlCommand comandos = new SqlCommand(consulta, conexion);

            SqlDataReader lector = comandos.ExecuteReader();

            if (lector.Read())
            {
                cedula = lector["cedula_usr"].ToString();
            }
            lector.Close();
            string consulta01 = "update Credenciales set contraseña_crd='" + NuevaClave + "'where cedula_usr='" + cedula + "'";
            SqlCommand comandos01 = new SqlCommand(consulta01, conexion);
            comandos01.ExecuteReader();
            MessageBox.Show("Datos Actualizados");
            conexion.Close();
        }
    }
}


