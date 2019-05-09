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
    /// Adrián Serrano
    /// 5/9/2019
    /// Clase para administrar las consultas sql para las ubicaciones
    /// </summary>
    public class UbicacionDatos
    {
        #region variables

        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: devuelve una lista con todas las ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de ubicaciones
        /// </summary>
        /// <param></param>
        /// <returns><code>List<Ubicacion></code></returns>
        public List<Ubicacion> getUbicaciones()
        {

            List<Ubicacion> listaUbicaciones = new List<Ubicacion>();

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("select id, edificio, descripcion from  Ubicacion;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Ubicacion ubicacion = new Ubicacion();

                ubicacion.idUbicacion = Convert.ToInt32(reader["id"].ToString());
                ubicacion.edificio = reader["edificio"].ToString();
                ubicacion.descripcion = reader["descripcion"].ToString();

                listaUbicaciones.Add(ubicacion);
            }

            sqlConnection.Close();

            return listaUbicaciones;
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: inserta en la base de datos una Ubicacion
        /// Requiere: Ubicacion
        /// Modifica: -
        /// Devuelve: id de la Ubicacion insertada
        /// </summary>
        /// <param name="Ubicacion"></param>
        /// <returns></returns>
        public int insertarUbicacion(Ubicacion ubicacion)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("insert into Ubicacion(edificio, descripcion) output Inserted.id " +
                "values(@edificio, @descripcion);"
                , sqlConnection);
            sqlCommand.Parameters.AddWithValue("@edificio", ubicacion.edificio);
            sqlCommand.Parameters.AddWithValue("@descripcion", ubicacion.descripcion);

            sqlConnection.Open();
            int id_ubicacion = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return id_ubicacion;
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: actualiza una ubicación
        /// Requiere: Ubicación a modificar
        /// Modifica: Ubicación
        /// Devuelve: -
        /// </summary>
        /// <param name="Ubicacion"></param>
        public void actualizarUbicacion(Ubicacion ubicacion)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("update Ubicacion set edificio=@edificio, descripcion=@descripcion " +
                "output Inserted.id where id=@id;"
                , sqlConnection);
            sqlCommand.Parameters.AddWithValue("@edificio", ubicacion.edificio);
            sqlCommand.Parameters.AddWithValue("@descripcion", ubicacion.descripcion);
            sqlCommand.Parameters.AddWithValue("@id", ubicacion.idUbicacion);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: Elimina una ubicación de  la base de datos
        /// Requiere: Ubicación
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="Ubicacion"></param>
        public void eliminarUbicacion(Ubicacion ubicacion)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("delete from Ubicacion output DELETED.id where id = @id;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", ubicacion.idUbicacion);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }
        #endregion
    }
}
