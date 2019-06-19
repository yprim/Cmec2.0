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

            SqlCommand sqlCommand = new SqlCommand("Select id_mantenimiento,fecha,descripcion,estado,es_correctivo,"+
             "id_responsable, placa_activo, id_ubicacion From Mantenimiento where estado = 0", sqlConnection);

            SqlDataReader reader;


            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                MantenimientoCorrectivo Mantenimiento = new MantenimientoCorrectivo();

                Mantenimiento.Id_mantenimiento = Convert.ToInt32(reader["id_mantenimiento"].ToString());
                Mantenimiento.Fecha = reader["fecha"].ToString();
                Mantenimiento.Descripcion = reader["descripcion"].ToString();
                Mantenimiento.Estado = reader["estado"].ToString();
                Mantenimiento.Es_correctivo = true;
                Mantenimiento.Id_responsable = Convert.ToInt32(reader["id_responsable"].ToString());
                Mantenimiento.Placa_activo = Convert.ToInt32(reader["placa_activo"].ToString());
                Mantenimiento.Id_ubicacion = Convert.ToInt32(reader["id_ubicacion"].ToString());

                
                if (Mantenimiento.Estado.Equals("False"))
                {
                    Mantenimiento.Estado = "En Proceso";
                }
                else
                {
                    Mantenimiento.Estado = "Aprobado";
                }

                listaMantenimientos.Add(Mantenimiento);
            }

            sqlConnection.Close();

            return listaMantenimientos;
        }

        /// <summary>
        /// Leonardo Gomez
        /// 19/06/2019
        /// Efecto: devuelve una lista con todos los mantenimientos no aprobados, precisamente esto se determina con el atributo estado cuando es 0;
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de mantenimientos no aprobados
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        /// <returns></returns>
        public List<MantenimientoCorrectivo> getMantenimientosNoAprobados()
        {
            List<MantenimientoCorrectivo> listaMantenimientos = new List<MantenimientoCorrectivo>();

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Select * from Mantenimiento where estado=0;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                MantenimientoCorrectivo Mantenimiento = new MantenimientoCorrectivo();

                Mantenimiento.Id_mantenimiento = Convert.ToInt32(reader["id_mantenimiento"].ToString());
                Mantenimiento.Placa_activo = Convert.ToInt32(reader["placa_activo"].ToString());
                Mantenimiento.Id_responsable = Convert.ToInt32(reader["id_responsable"].ToString());
                Mantenimiento.Fecha = reader["fecha"].ToString();
                Mantenimiento.Id_ubicacion = Convert.ToInt32(reader["id_ubicacion"].ToString());
                Mantenimiento.Descripcion = reader["descripcion"].ToString();
                Mantenimiento.Estado = reader["estado"].ToString(); ;

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
        public int insertarMantenimientoCorrectivo(MantenimientoCorrectivo Mantenimiento, List<String> Tareas)
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand(@"insert into Mantenimiento(fecha,descripcion,estado,es_correctivo,
                                                     id_responsable,placa_activo,id_ubicacion)
                                                    values(@fecha,@descripcion,@estado,@es_correctivo,@responsable,@id_placa,@ubicacion);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@fecha", Mantenimiento.Fecha);
            sqlCommand.Parameters.AddWithValue("@descripcion", Mantenimiento.Descripcion);
            sqlCommand.Parameters.AddWithValue("@estado", 0);
            sqlCommand.Parameters.AddWithValue("@es_correctivo", 1);
            sqlCommand.Parameters.AddWithValue("@responsable", Mantenimiento.Id_responsable);
            sqlCommand.Parameters.AddWithValue("@id_placa", Mantenimiento.Placa_activo);
            sqlCommand.Parameters.AddWithValue("@ubicacion", Mantenimiento.Id_ubicacion);

            sqlConnection.Open();
            int id_mantenimiento = Convert.ToInt32(sqlCommand.ExecuteScalar());
            
            foreach (String tarea in Tareas)
            {

                SqlCommand sqlCommandInsertTareas = new SqlCommand("insert into Tarea_Mantenimiento(id_tarea,id_mantenimiento) " +
                "values(@id_tarea,@id_mantenimiento); ", sqlConnection);

                sqlCommandInsertTareas.Parameters.AddWithValue("@id_mantenimiento", id_mantenimiento);

                String idTarea = tarea.ToString();

                sqlCommandInsertTareas.Parameters.AddWithValue("@id_tarea", idTarea);

                sqlCommandInsertTareas.ExecuteScalar();
            }

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
                                                    "set placa_activo = @id_placa, " +
                                                    " id_responsable = @responsable, " +
                                                    " fecha = @fecha, " +
                                                    " id_ubicacion = @ubicacion, " +
                                                    " descripcion = @descripcion, " +
                                                    " estado = @estado, " +
                                                    " es_correctivo = @correctivo, " +
                                                    "where id_mantenimiento = @id;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_placa", Mantenimiento.Placa_activo);
            sqlCommand.Parameters.AddWithValue("@responsable", Mantenimiento.Id_responsable);
            sqlCommand.Parameters.AddWithValue("@fecha", Mantenimiento.Fecha);
            sqlCommand.Parameters.AddWithValue("@ubicacion", Mantenimiento.Id_ubicacion);
            sqlCommand.Parameters.AddWithValue("@descripcion", Mantenimiento.Descripcion);
            sqlCommand.Parameters.AddWithValue("@estado", Mantenimiento.Estado);
            sqlCommand.Parameters.AddWithValue("@correctivo", Mantenimiento.Es_correctivo);
            sqlCommand.Parameters.AddWithValue("@id", Mantenimiento.Id_mantenimiento);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }
        public int aprobarMantenimiento(int id) {

            SqlConnection sqlConnection = conexion.conexionCMEC();

            SqlCommand sqlCommand = new SqlCommand("Update Mantenimiento " +
                                                    "set estado = 1 where id_mantenimiento = @id", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

            return 1;
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

            SqlCommand sqlCommand = new SqlCommand("Update Mantenimiento set estado=2" +
                                               "where id_mantenimiento = @id_mantenimiento;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id", Mantenimiento.Id_mantenimiento);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }
        #endregion
    }
}

    

