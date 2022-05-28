using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades
{
    public static class JuegoDao
    {
        private static string cadenaConexion;
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static JuegoDao()
        {
            cadenaConexion = @"Data Source=.;Initial Catalog=Ejercicios_UTN;Integrated Security=True";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static void Eliminar(int codigoJuego)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = $"DELETE FROM Juegos WHERE CODIGO_JUEGO ={codigoJuego}";
                comando.Parameters.AddWithValue("@ID", codigoJuego);
                int rows = comando.ExecuteNonQuery();

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

        public static void Guardar(Juego unJuego)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = $"INSERT INTO Juegos (CODIGO_USUARIO,NOMBRE,PRECIO, GENERO) VALUES (@Codigo,@Nombre,@Precio,@Genero)";
                comando.Parameters.AddWithValue("@Codigo", unJuego.CodigoUsuario);
                comando.Parameters.AddWithValue("@Nombre", unJuego.Nombre);
                comando.Parameters.AddWithValue("@Precio", unJuego.Precio);
                comando.Parameters.AddWithValue("@Genero", unJuego.Genero);
                int rows = comando.ExecuteNonQuery();

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

        public static List<Biblioteca> Leer()
        {
            List<Biblioteca> listado = new List<Biblioteca>();

            try
            {
                conexion.Open();
                comando.CommandText = "SELECT [CODIGO_JUEGO],[NOMBRE],[GENERO], [USERNAME]FROM[EJERCICIOS_UTN].[dbo].[JUEGOS] as ju JOIN USUARIOS as usu ON ju.CODIGO_USUARIO = usu.CODIGO_USUARIO";
                //SELECT [CODIGO_JUEGO],[CODIGO_USUARIO],[NOMBRE],[PRECIO],[GENERO] FROM[EJERCICIOS_UTN].[dbo].[JUEGOS]

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        listado.Add(new Biblioteca(Convert.ToInt32(dataReader["CODIGO_JUEGO"]),
                                                   dataReader["Nombre"].ToString(),
                                                   dataReader["Genero"].ToString(),
                                                   dataReader["Username"].ToString()));
                    }
                }

                return listado;
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

        public static Juego LeerPorId(int codigoJuego)
        {
            Juego jueguito = null;
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = $"SELECT * from JUEGOS where CODIGO_JUEGO = @ID";
                comando.Parameters.AddWithValue("@ID", codigoJuego);

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        jueguito = new Juego(Convert.ToInt32(dataReader["CODIGO_JUEGO"]), Convert.ToInt32(dataReader["CODIGO_USUARIO"]),
                                             dataReader["NOMBRE"].ToString(), dataReader["GENERO"].ToString(), Convert.ToDouble(dataReader["PRECIO"]));
                    }
                }

                return jueguito;
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

        public static void Modificar(Juego juego)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = $"UPDATE Juegos SET nombre = @Nombre, precio = @Precio, genero = @Genero where CODIGO_JUEGO = @ID";
                comando.Parameters.AddWithValue("@Nombre", juego.Nombre);
                comando.Parameters.AddWithValue("@Precio", juego.Precio);
                comando.Parameters.AddWithValue("@Genero", juego.Genero);
                comando.Parameters.AddWithValue("@ID", juego.CodigoJuego);
                int rows = comando.ExecuteNonQuery();


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
