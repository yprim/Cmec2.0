using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    /// <summary>
    /// Steven Camacho B.
    /// 17/6/2019
    /// Clase para administrar servicios respecto al plan de mantenimiento.
    /// </summary>
    public class ActivoPlanPreventivoDatos
    {
        #region variables
        private SqlConnection conexion;
        private ConexionDatos conexionDatos;
        #endregion

        #region constructor
        public ActivoPlanPreventivoDatos() {
            this.conexionDatos = new ConexionDatos();
            this.conexion = this.conexionDatos.conexionCMEC();
        }
        #endregion

        #region consultas
        public bool existePlanVigente()
        {
            SqlCommand sqlcommand = new SqlCommand("select top 1 finalizado from [plan] order by id_plan desc", conexion);
            SqlDataReader reader;
            conexion.Open();
            reader = sqlcommand.ExecuteReader();
            bool resultado = false;
            if (reader.Read()) {
                resultado = !Boolean.Parse(reader.GetValue(0).ToString());
            }
            conexion.Close();
            return resultado;
        }

        /// <summary>
        /// Steven Camacho
        /// 17/06/2019
        /// Efecto: almacena en la base de datos la relación existente del plan preventivo generado junto con los activos y las fechas correspondientes.
        /// </summary>
        public void guardarListaPlan(List<ActivoPlanPreventivo> listaPlanActivos)
        {
            SqlCommand sqlCommand = new SqlCommand("insert into [plan] (fecha_inicio, finalizado) output Inserted.id_plan VALUES (getdate(),0);", conexion);
            conexion.Open();
            int idPlan = (int)sqlCommand.ExecuteScalar();

            foreach (var activoPlan in listaPlanActivos)
            {
                sqlCommand = new SqlCommand("insert into Propuesta_Mantenimiento_Preventivo (id_plan,placa_activo,mes,esta_aprovado) " +
                                            "values(@id_plan,@placa,@mes,0)",conexion);
                sqlCommand.Parameters.AddWithValue("@id_plan",idPlan);
                sqlCommand.Parameters.AddWithValue("@placa",activoPlan.Placa);
                sqlCommand.Parameters.AddWithValue("@mes",activoPlan.MesPropuesto);
                sqlCommand.ExecuteScalar();  
            }
            conexion.Close();
        }//guardarListaPlan

        /// <summary>
        /// Steven Camacho
        /// 17/06/2019
        /// Efecto: devuelve una lista con todos los activos en orden de prioridad, tomando en cuenta solo último mantenimiento en caso de tenerlo.
        /// Devuelve: lista de activos procesados para realizar mantenimiento.
        /// </summary>
        public List<ActivoPlanPreventivo> obtenerListaActivoPorPrioridad()
        {
            conexion.Close();
            List<ActivoPlanPreventivo> listaActivos = new List<ActivoPlanPreventivo>();
            SqlCommand sqlCommand = new SqlCommand("select a.placa,m.fecha,e.id_edificio,u.numero_aula  from activo a " +
                                                    "left join mantenimiento m " +
                                                    "on a.placa = m.placa_activo and year(m.fecha)>= year(getdate())-2 and m.es_correctivo=0 " +
                                                    "left join  ubicacion u " +
                                                    "on m.id_ubicacion = u.id_ubicacion " +
                                                    "left join edificio e " +
                                                    "on e.id_edificio = u.id_edificio " +
                                                    "order by m.fecha ,e.id_edificio,u.numero_aula", conexion);
            SqlDataReader reader;
            conexion.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ActivoPlanPreventivo activoNuevo = new ActivoPlanPreventivo();
                activoNuevo.Placa = Int32.Parse(reader.GetValue(0).ToString());
                foreach (var activo in listaActivos)
                {
                    if (activoNuevo.Placa == activo.Placa) {
                        listaActivos.Remove(activo);
                        break;
                    }
                }
                listaActivos.Add(activoNuevo);

            }
            conexion.Close();
            return listaActivos;
        }//obtenerListaActivoPorPrioridad

        /// <summary>
        /// Steven Camacho
        /// 17/06/2019
        /// Efecto: devuelve una lista con todos los elementos del plan de mantenimiento preventivo, tomando los diferentes datos de una consulta de varias tablas
        /// Devuelve: lista de activos plan preventivo.
        /// </summary>
        public List<ActivoPlanPreventivo> obtenerTodo()
        {
            List<ActivoPlanPreventivo> listaActivos = new List<ActivoPlanPreventivo>();
            SqlCommand sqlCommand = new SqlCommand("" +
                "select p.placa_activo,a.descripcion,r.nombre,e.nombre,u.numero_aula,p.mes,m.fecha,m.es_correctivo " +
                "from Propuesta_Mantenimiento_Preventivo p " +
                "join Activo a on a.placa=p.placa_activo and p.esta_aprovado=0 " +
                "left join Mantenimiento m on m.placa_activo=p.placa_activo and m.id_mantenimiento= " +
                "(select Top 1 id_mantenimiento from Mantenimiento ma " +
                "where ma.placa_activo= p.placa_activo " +
                "order by id_mantenimiento desc ) " +
                "left join Responsable r on r.id=m.id_responsable " +
                "left join Ubicacion u on u.id_ubicacion=m.id_ubicacion " +
                "left join Edificio e on e.id_edificio= u.id_edificio " +
                "order by p.mes asc", conexion);

            SqlDataReader reader;
            conexion.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ActivoPlanPreventivo activoNuevo = new ActivoPlanPreventivo();
                activoNuevo.Placa = Int32.Parse(reader.GetValue(0).ToString());
                activoNuevo.Equipo = reader.GetValue(1).ToString();
                activoNuevo.Responsable = reader.GetValue(2).ToString();
                activoNuevo.Edificio = reader.GetValue(3).ToString();
                activoNuevo.Ubicacion = reader.GetValue(4).ToString();
                activoNuevo.MesPropuesto = Int32.Parse(reader.GetValue(5).ToString());
                string fechaMantenimiento= reader.GetValue(6).ToString();
                if (fechaMantenimiento == "")
                    activoNuevo.UltimoMantenimiento = "01/01/0001";
                else
                    activoNuevo.UltimoMantenimiento = fechaMantenimiento;
                String es_correctivo = reader.GetValue(7).ToString();
                if (es_correctivo == "True")
                    es_correctivo = "Correctivo";
                else if (es_correctivo == "False")
                    es_correctivo = "Preventivo";
                else
                    es_correctivo = "Sin Mantenimiento";
                activoNuevo.Es_correctivo = es_correctivo;
                listaActivos.Add(activoNuevo);
            }
            conexion.Close();
            return listaActivos;
        }

        #endregion
    }
}
