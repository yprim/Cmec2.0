using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoDatos

{
    /// <summary>
    /// Leonardo Gomez
    ///29/May/2019
    ///Clase para administrar las consultas sql para los Mantenimientos Correctivos
    /// </summary>
    public class MantenimientoCorrectivoDatos
    {
        #region variables

        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto: devuelve una lista con todos los mantenimientos 
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de mantenimientos
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        /// <returns></returns>
        public List<MantenimientoCorrectivo> getMantenimientosCorrectivos()
        {
            List<MantenimientoCorrectivo> listaMantenimientos = new List<MantenimientoCorrectivo>();

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Select * from Mantenimiento_Correctivo;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                MantenimientoCorrectivo Mantenimiento = new MantenimientoCorrectivo();

                Mantenimiento.Id = Convert.ToInt32(reader["id"].ToString());
                Mantenimiento.Id_placa = Convert.ToInt32(reader["id_placa"].ToString());
                Mantenimiento.Responsable = Convert.ToInt32(reader["responsable"].ToString());
                Mantenimiento.Fecha = Convert.ToDateTime(reader["fecha"].ToString());
                Mantenimiento.Ubicacion = Convert.ToInt32(reader["ubicacion"].ToString());
                Mantenimiento.Descripcion = reader["descripcion"].ToString();
                Mantenimiento.Estado = false;

                listaMantenimientos.Add(Mantenimiento);
            }

            sqlConnection.Close();

            return listaMantenimientos;
        }
        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto: inserta en la base de datos un MantenimientoCorrectivo
        /// Requiere: MantenimientoCorrectivo
        /// Modifica: -
        /// Devuelve: id del Mantenimiento insertado
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        /// <returns></returns>
        public int insertarMantenimientoCorrectivo(MantenimientoCorrectivo Mantenimiento)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand(@"insert into Mantenimiento(id_placa,responsable,fecha,ubicacion,
                                                     descripcion,estado)
                                                    values(@id_placa,@responsable,@fecha,@ubicacion,@descripcion,@estado);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_placa", Mantenimiento.Id_placa);
            sqlCommand.Parameters.AddWithValue("@responsable", Mantenimiento.Responsable);
            sqlCommand.Parameters.AddWithValue("@fecha", Mantenimiento.Fecha);
            sqlCommand.Parameters.AddWithValue("@ubicacion", Mantenimiento.Ubicacion);
            sqlCommand.Parameters.AddWithValue("@descripcion", Mantenimiento.Descripcion);
            sqlCommand.Parameters.AddWithValue("@estado", Mantenimiento.Estado);

            sqlConnection.Open();
            int id_mantenimiento = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return id_mantenimiento;
        }

        /// <summary>
        /// Leonardo Gomez
        /// 19/May/2019
        /// Efecto: actualiza una Mantenimiento Correctivo
        /// Requiere: Mantenimiento a modificar
        /// Modifica: MantenimientoCorrectivo
        /// Devuelve: -
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        public void actualizarMantenimientoCorrectivo(MantenimientoCorrectivo Mantenimiento)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Update Mantenimiento " +
                                                    "set id_placa = @id_placa, " +
                                                    " responsable = @responsable, " +
                                                    " fecha = @fecha, " +
                                                    " ubicacion = @ubicacion, " +
                                                    " descripcion = @descripcion, " +
                                                    " estado = @estado, " +
                                                    "where id = @id;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_placa", Mantenimiento.Id_placa);
            sqlCommand.Parameters.AddWithValue("@responsable", Mantenimiento.Responsable);
            sqlCommand.Parameters.AddWithValue("@fecha", Mantenimiento.Fecha);
            sqlCommand.Parameters.AddWithValue("@ubicacion", Mantenimiento.Ubicacion);
            sqlCommand.Parameters.AddWithValue("@responsable", Mantenimiento.Responsable);
            sqlCommand.Parameters.AddWithValue("@estado", Mantenimiento.Estado);
            sqlCommand.Parameters.AddWithValue("@id", Mantenimiento.Id);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }

        /// <summary>
        /// Leonardo Gomez
        /// 19/May/2019
        /// Efecto: Elimina un Mantenimiento Correctivo de  la base de datos
        /// Requiere: Mantenimiento Correctivo
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        public void eliminarMantenimientoCorrectivo(MantenimientoCorrectivo Mantenimiento)
        {

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Delete MantenimientoCorrectivo " +
                                               "where id = @id;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", Mantenimiento.Id);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }
        #endregion
    }
}

    

