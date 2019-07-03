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

            SqlCommand sqlCommand = new SqlCommand("select id_ubicacion, numero_aula, id_edificio from Ubicacion Order by id_ubicacion desc;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Ubicacion ubicacion = new Ubicacion();
                ubicacion.idUbicacion = Convert.ToInt32(reader["id_ubicacion"].ToString());
                ubicacion.numeroAula = reader["numero_aula"].ToString();
                ubicacion.edificio = new Edificio();
                ubicacion.edificio.idEdificio = Convert.ToInt32(reader["id_edificio"].ToString());

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

            SqlCommand sqlCommand = new SqlCommand("insert into Ubicacion(numero_aula, id_edificio) output Inserted.id_ubicacion " +
                "values(@numero_aula, @id_edificio);"
                , sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numero_aula", ubicacion.numeroAula);
            sqlCommand.Parameters.AddWithValue("@id_edificio", ubicacion.edificio.idEdificio);

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

            SqlCommand sqlCommand = new SqlCommand("update Ubicacion set numero_aula=@numero_aula, id_edificio=@id_edificio " +
                "output Inserted.id_ubicacion where id_ubicacion=@id_ubicacion;"
                , sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numero_aula", ubicacion.numeroAula);
            sqlCommand.Parameters.AddWithValue("@id_edificio", ubicacion.edificio.idEdificio);
            sqlCommand.Parameters.AddWithValue("@id_ubicacion", ubicacion.idUbicacion);

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
        public int eliminarUbicacion(Ubicacion ubicacion)
        {
        
                SqlConnection sqlConnection = conexion.conexionCMEC();

                SqlCommand sqlCommand = new SqlCommand("delete from Ubicacion  where id_ubicacion = @id_ubicacion;", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id_ubicacion", ubicacion.idUbicacion);

                sqlConnection.Open();
                sqlCommand.ExecuteScalar();

                sqlConnection.Close();

                return 999;
        }
        #endregion
    }
}
