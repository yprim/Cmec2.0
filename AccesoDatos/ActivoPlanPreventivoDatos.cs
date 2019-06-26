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
        /// Método verifica si se da las condiciones de ser una fecha posterior al 1 de diciembre para cerrar el plan actual
        /// Steven Camacho
        /// 23/06/2019
        /// </summary>
        /// <returns></returns>
        public bool consultaRealizarCierrePlan() {

                int diaActual = DateTime.Today.Day;
                int mesActual = DateTime.Today.Month;
                int anioActual = DateTime.Today.Year;
                int periodoActual = obtenerNuevoPeriodo();
                if (anioActual ==periodoActual) {
                    if (mesActual == 12)
                        return true;
                    else
                        return false;
                } else if (anioActual > periodoActual)
                    return true;
            
                return false;
        }//consultaRealizarCienrrePlan

        /// <summary>
        /// Metodo permite cerrar el plan automáticamente o mediante una solicitud.
        /// </summary>
        /// <param name="consulta"></param>
        public int cierrePlan(bool esAutomatico) {
            if (esAutomatico)
            {
                if (!consultaRealizarCierrePlan())//en caso de salir falso saldrá sin cerrar el plan.
                {
                    return -1;
                }
            }
            SqlCommand sqlCommand = new SqlCommand("Update [plan] set finalizado=1 where id_plan= " +
                                                    "(select top 1 id_plan from [plan] where finalizado=0 order by id_plan desc)", conexion);
            conexion.Open();
            sqlCommand.ExecuteScalar();
            conexion.Close();
                return 1;

        }


        /// <summary>
        /// Obtiene el periodo del plan anterior para verificar que el generado sea uno mayor.
        /// Steven Camacho
        /// 23/06/19
        /// </summary>
        /// <returns></returns>
        public int obtenerNuevoPeriodo() {
            SqlCommand sqlcommand = new SqlCommand("select top 1 periodo from [plan] where finalizado=1 order by id_plan desc", conexion);
            SqlDataReader reader;
            conexion.Open();
            reader = sqlcommand.ExecuteReader();
            int resultado = 0;
            if (reader.Read())
            {
                string periodo = reader.GetValue(0).ToString();
                resultado = Int32.Parse(reader.GetValue(0).ToString())+1;
            }else
                resultado = DateTime.Today.Year;
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
            SqlCommand sqlCommand = new SqlCommand("insert into [plan] (periodo, finalizado) output Inserted.id_plan VALUES (@nuevoPeriodo,0);", conexion);
            int periodo = obtenerNuevoPeriodo();
            sqlCommand.Parameters.AddWithValue("@nuevoPeriodo",periodo);
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
                                                    "where a.placa not in(select placa_activo from mantenimiento where id_ubicacion=1) " +
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
                "select p.placa_activo,a.descripcion,f.nombre,e.nombre,u.numero_aula,p.mes,m.fecha,m.es_correctivo " +
                "from Propuesta_Mantenimiento_Preventivo p " +
                "join Activo a on a.placa=p.placa_activo and p.esta_aprovado=0 " +
                "left join Mantenimiento m on m.placa_activo=p.placa_activo and m.id_mantenimiento= " +
                "(select Top 1 id_mantenimiento from Mantenimiento ma " +
                "where ma.placa_activo= p.placa_activo " +
                "order by id_mantenimiento desc ) " +
                "left join Funcionario f on f.id=m.id_funcionario " +
                "left join Ubicacion u on u.id_ubicacion=m.id_ubicacion " +
                "left join Edificio e on e.id_edificio= u.id_edificio " +
                "where p.placa_activo not in(select placa_activo from mantenimiento where es_correctivo=0 " +
                "and id_plan= (select top(1) id_plan from [plan] Order By id_plan desc)) and " +
                "p.id_plan =(select top(1) id_plan from [plan] Order By id_plan desc ) " +
                "order by p.mes asc", conexion);

            SqlDataReader reader;
            conexion.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ActivoPlanPreventivo activoNuevo = new ActivoPlanPreventivo();
                activoNuevo.Placa = Int32.Parse(reader.GetValue(0).ToString());
                activoNuevo.Equipo = reader.GetValue(1).ToString();
                activoNuevo.Funcionario = reader.GetValue(2).ToString();
                activoNuevo.Edificio = reader.GetValue(3).ToString();
                activoNuevo.Ubicacion = reader.GetValue(4).ToString();
                activoNuevo.MesPropuesto = Int32.Parse(reader.GetValue(5).ToString());
                string fechaMantenimiento= reader.GetValue(6).ToString();
                if (fechaMantenimiento == "")
                    activoNuevo.UltimoMantenimiento = "";
                else
                    activoNuevo.UltimoMantenimiento = (DateTime.Parse(fechaMantenimiento)).ToShortDateString();
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
