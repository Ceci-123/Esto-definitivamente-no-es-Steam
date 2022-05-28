using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class UsuarioDao
    {
        private static string cadenaConexion;
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static UsuarioDao()
        {
            cadenaConexion = @"Data Source=.;Initial Catalog=Ejercicios_UTN;Integrated Security=True";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static List<Usuario> Leer()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();
            try
            {
                conexion.Open();
                comando.CommandText = "SELECT [CODIGO_USUARIO],[USERNAME] FROM[EJERCICIOS_UTN].[dbo].[USUARIOS]";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listadoUsuarios.Add(new Usuario(Convert.ToInt32(dataReader["CODIGO_USUARIO"]),
                                                   dataReader["USERNAME"].ToString()));
                    }
                }

                return listadoUsuarios;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
