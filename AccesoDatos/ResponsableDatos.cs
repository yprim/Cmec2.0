using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    /// <summary>
    /// Priscilla Mena
    ///5/29/2019
    ///Clase para administrar las consultas sql para las responsables
    /// </summary>
    public class ResponsableDatos
    {
        #region variables

        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas

        /// <summary>
        /// Priscilla Mena
        /// 5/29/2019
        /// Efecto: devuelve un lista con todas las responsables
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de responsables
        /// </summary>
        /// <param name="Responsable"></param>
        /// <returns></returns>
        public List<Responsable> getResponsables()
        {
            List<Responsable> listaResponsables = new List<Responsable>();

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("select id, nombre, usuario from  Responsable;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Responsable responsable = new Responsable();

                responsable.idResponsable = Convert.ToInt32(reader["id"].ToString());
                responsable.nombre = reader["nombre"].ToString();
                responsable.usuario = reader["usuario"].ToString();

                listaResponsables.Add(responsable);
            }

            sqlConnection.Close();

            return listaResponsables;
        }
        /// <summary>
        /// Priscilla Mena
        /// 5/29/2019
        /// Efecto: inserta en la base de datos un Responsable
        /// Requiere: Responsable
        /// Modifica: -
        /// Devuelve: id del Responsable insertado
        /// </summary>
        /// <param name="responsable"></param>
        /// <returns></returns>
        public int insertarResponsable(Responsable responsable)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand(@"insert into Responsable(nombre,usuario)
                                                    values(@nombre,@usuario);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre", responsable.nombre);
            sqlCommand.Parameters.AddWithValue("@usuario", responsable.usuario);

            sqlConnection.Open();
            int id_responsable = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return id_responsable;
        }

        /// <summary>
        /// Priscilla Mena
        /// 5/29/2019
        /// Efecto: actualiza un Responsable
        /// Requiere: Responsable a modificar
        /// Modifica: Responsable
        /// Devuelve: -
        /// </summary>
        /// <param name="responsable"></param>
        public void actualizarResponsable(Responsable responsable)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Update Responsable " +
                                                    "set nombre = @nombre, usuario=@usuario " +
                                                    "where id = @id;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", responsable.idResponsable);
            sqlCommand.Parameters.AddWithValue("@nombre", responsable.nombre);
            sqlCommand.Parameters.AddWithValue("@usuario", responsable.usuario);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

        /// <summary>
        /// Priscilla Mena
        /// 5/29/2019
        /// Efecto: Elimina un Responsable de  la base de datos
        /// Requiere: Responsable
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="Responsable"></param>
        public void eliminarResponsable(Responsable Responsable)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Delete Responsable " +
                                               "output Deleted.id where id = @id;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", Responsable.idResponsable);

            sqlConnection.Open();
            int resultado= (int)sqlCommand.ExecuteScalar();

            sqlConnection.Close();

        }
        #endregion
    }
}
