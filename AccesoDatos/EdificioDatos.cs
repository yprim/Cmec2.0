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
    /// 5/28/2019
    /// Clase para administrar las consultas sql para los edificios
    /// </summary>
    public class EdificioDatos
    {
        #region variables

        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Adrián Serrano
        /// 5/28/2019
        /// Efecto: devuelve una lista con todos los edificios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de edificios
        /// </summary>
        /// <param></param>
        /// <returns><code>List<Edificio></code></returns>
        public List<Edificio> getEdificios()
        {
            List<Edificio> listaEdificios = new List<Edificio>();

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("select id_edificio, nombre from  Edificio;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Edificio edificio = new Edificio();

                edificio.idEdificio = Convert.ToInt32(reader["id_edificio"].ToString());
                edificio.nombre = reader["nombre"].ToString();

                listaEdificios.Add(edificio);
            }

            sqlConnection.Close();

            return listaEdificios;
        }

        /// <summary>
        /// Adrián Serrano
        /// 6/08/2019
        /// Efecto: devuelve un edificio
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: un edificio
        /// </summary>
        /// <param></param>
        /// <returns><code>Edificio</code></returns>
        public Edificio getEdificioPorId(int idEdificio)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("select id_edificio, nombre from Edificio where id_edificio=@id_edificio_;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_edificio_", idEdificio);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            Edificio edificio = new Edificio();

            if (reader.Read())
            {
                edificio.idEdificio = Convert.ToInt32(reader["id_edificio"].ToString());
                edificio.nombre = reader["nombre"].ToString();
            }

            sqlConnection.Close();

            return edificio;
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/28/2019
        /// Efecto: inserta en la base de datos un Edificio
        /// Requiere: Edificio
        /// Modifica: -
        /// Devuelve: id del Edificio insertado
        /// </summary>
        /// <param name="edificio"></param>
        /// <returns></returns>
        public int insertarEdificio(Edificio edificio)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("insert into Edificio(nombre) output Inserted.id_edificio " +
                "values(@nombre);"
                , sqlConnection);
            sqlCommand.Parameters.AddWithValue("@nombre", edificio.nombre);

            sqlConnection.Open();
            int idEdificio = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idEdificio;
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: actualiza un edificio
        /// Requiere: Edificio a modificar
        /// Modifica: Edificio
        /// Devuelve: -
        /// </summary>
        /// <param name="edificio"></param>
        public void actualizarEdificio(Edificio edificio)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("update Edificio set nombre=@nombre " +
                "output Inserted.id_edificio where id_edificio=@id_edificio;"
                , sqlConnection);
            sqlCommand.Parameters.AddWithValue("@nombre", edificio.nombre);
            sqlCommand.Parameters.AddWithValue("@id_edificio", edificio.idEdificio);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: Elimina un edificio de  la base de datos
        /// Requiere: Edificio
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="edificio"></param>
        public void eliminarEdificio(Edificio edificio)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("delete from Edificio output DELETED.id_edificio where id_edificio = @id_edificio;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_edificio", edificio.idEdificio);
            
            sqlConnection.Open();
            
            int resultado=(int)sqlCommand.ExecuteScalar();

            sqlConnection.Close();

        }
        #endregion
    }
}
