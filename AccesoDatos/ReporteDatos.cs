using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ReporteDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        public LinkedList<ReporteGeneral> ReporteMantenimientos()
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();
            //SqlCommand sqlCommandCount = new SqlCommand("select count(esta_aprovado) from Propuesta_Mantenimiento_Preventivo group by esta_aprovado;", conexion);
            SqlCommand sqlCommand = new SqlCommand("select fecha, descripcion, estado, es_correctivo, r.usuario as responsable, placa_activo, u.numero_aula as aula, f.usuario as funcionario from Mantenimiento m  inner join Responsable r on m.id_responsable = r.id inner join Ubicacion u on m.id_ubicacion = u.id_ubicacion inner join Funcionario f on m.id_funcionario = f.id;", sqlConnection);
            
            SqlDataReader reader;
            LinkedList<ReporteGeneral> reportesGenerales = new LinkedList<ReporteGeneral>();
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReporteGeneral  reporteGeneral = new ReporteGeneral();
                reporteGeneral.fecha = Convert.ToDateTime(reader["fecha"].ToString());
                reporteGeneral.descripcion = reader["descripcion"].ToString();

                int estado = Convert.ToInt32(reader["estado"].ToString());
                reporteGeneral.estado = estado == 0 ? "En proceso" : estado == 1 ? "Aprobado" : "Borrado";

                bool esCorrectivo = Convert.ToBoolean(reader["es_correctivo"].ToString());
                reporteGeneral.es_correctivo = esCorrectivo? "Correctivo" : "Preventivo";

                reporteGeneral.responsable = reader["responsable"].ToString();
                reporteGeneral.placa = reader["placa_activo"].ToString();
                reporteGeneral.aula = reader["aula"].ToString();
                reporteGeneral.funcionario = reader["funcionario"].ToString();

                reportesGenerales.AddLast(reporteGeneral);
            }

            sqlConnection.Close();

            return reportesGenerales;
        }


        public LinkedList<int> ReporteAvance()
        {
            SqlConnection sqlConnection = conexion.conexionCMEC();
            SqlCommand sqlCommand = new SqlCommand("select count(esta_aprovado) as aprobados from Propuesta_Mantenimiento_Preventivo group by esta_aprovado;", sqlConnection);

            SqlDataReader reader;
            LinkedList<int> reporteAvance = new LinkedList<int>();
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            int linea = 1;

            while (reader.Read())
            {
                if (linea == 1)
                {
                    reporteAvance.AddLast(Convert.ToInt32(reader["aprobados"].ToString()));
                    linea = linea + 1;
                }
                else
                {
                    reporteAvance.AddLast(Convert.ToInt32(reader["aprobados"].ToString()));
                }
            }

            sqlConnection.Close();

            return reporteAvance;
        }
    }
}
