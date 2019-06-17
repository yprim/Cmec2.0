using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ResponsableDatos2
    {

        #region variables

        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Adrián Serrano
        /// 5/28/2019
        /// Efecto: devuelve una lista con todos los responsables
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de responsables
        /// </summary>
        /// <param></param>
        /// <returns><code>List<Responsable></code></returns>
        public List<Responsable> getResponsables()
        {
            List<Responsable> listaResponsables = new List<Responsable>();

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("select id_responsable, nombre, usuario from  UsuarioResponsable;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Responsable responsable = new Responsable();

                responsable.idResponsable = Convert.ToInt32(reader["id_responsable"].ToString());
                responsable.nombre = reader["nombre"].ToString();
                responsable.usuario = reader["usuario"].ToString();

                listaResponsables.Add(responsable);
            }

            sqlConnection.Close();

            return listaResponsables;
        }
    }

    #endregion
}
