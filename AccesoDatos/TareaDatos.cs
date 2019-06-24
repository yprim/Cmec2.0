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
    ///5/6/2019
    ///Clase para administrar las consultas sql para las tareas
    /// </summary>
    public class TareaDatos
    {
        #region variables

        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: devuelve una lista con todas las tareas
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de tareas
        /// </summary>
        /// <param name="Tarea"></param>
        /// <returns></returns>
        public List<Tarea> getTareas()
        {

            List<Tarea> listaTareas = new List<Tarea>();

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("select t.* from  Tarea t order by descripcion;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Tarea Tarea = new Tarea();

                Tarea.idTarea = Convert.ToInt32(reader["id_tarea"].ToString());
                Tarea.descripcion = reader["descripcion"].ToString();

                listaTareas.Add(Tarea);
            }

            sqlConnection.Close();

            return listaTareas;
        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: inserta en la base de datos un Tarea
        /// Requiere: Tarea
        /// Modifica: -
        /// Devuelve: id del Tarea insertado
        /// </summary>
        /// <param name="Tarea"></param>
        /// <returns></returns>
        public int insertarTarea(Tarea Tarea)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand(@"insert into Tarea(descripcion)
                                                    values(@descripcion);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@descripcion", Tarea.descripcion);


            sqlConnection.Open();
            int id_tarea = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return id_tarea;
        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: actualiza una Tarea
        /// Requiere: Tarea a modificar
        /// Modifica: Tarea
        /// Devuelve: -
        /// </summary>
        /// <param name="Tarea"></param>
        public void actualizarTarea(Tarea Tarea)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Update Tarea " +
                                                    "set descripcion = @descripcion " +
                                                    "where id_tarea = @id_tarea;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_tarea", Tarea.idTarea);
            sqlCommand.Parameters.AddWithValue("@descripcion", Tarea.descripcion);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: Elimina una Tarea de  la base de datos
        /// Requiere: Tarea
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="Tarea"></param>
        public void eliminarTarea(Tarea Tarea)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Delete Tarea " +
                                               "output Deleted.id_tarea where id_tarea = @id_tarea;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_tarea", Tarea.idTarea);

            sqlConnection.Open();
           int resultado=(int)sqlCommand.ExecuteScalar();

            sqlConnection.Close();

        }
        #endregion
    }
}
