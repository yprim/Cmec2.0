using System;
using Entidades;
using AccesoDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Servicios
{
    /// <summary>
    /// Steven Camacho B.
    /// 17/6/2019
    /// Clase para administrar servicios respecto al plan de mantenimiento.
    /// </summary>
    public class ActivoPlanPreventivoServicios
    {
        ActivoPlanPreventivoDatos planPreventivoDatos;
        public ActivoPlanPreventivoServicios() {
            planPreventivoDatos = new ActivoPlanPreventivoDatos();
        }

        /// <summary>
        /// Steven Camacho
        /// 16/06/1019
        /// Clase que genera la información que se incluirá respecto al plan preventivo anual de activos
        /// Modifica la tabla del plan preventivo, asociando activos con meses determinados en base a último mantenimiento, edificio y mes.
        /// </summary>
        public bool generarPlanPreventivo() {
            if (!planPreventivoDatos.existePlanVigente())
            {
                List<ActivoPlanPreventivo> listaActivos = planPreventivoDatos.obtenerListaActivoPorPrioridad();
                double totalActivos = listaActivos.Count();//determina la cantidad total de activos que entrarán en el plan de mantenimeinto.
                double activosPorMes =  Math.Ceiling(totalActivos/ 10);//determina la cantidad de activos a revisar por mes.
                int contador = 0;
                int numMes = 2;//empieza en el mes de febrero la asignación.
                List<ActivoPlanPreventivo> listaPlanActivos = new List<ActivoPlanPreventivo>();
                foreach (var activo in listaActivos)
                {
                    if (contador==activosPorMes) {
                        numMes += 1;
                        contador = 0;
                    }
                    ActivoPlanPreventivo nuevoActivoPlan = new ActivoPlanPreventivo();
                    nuevoActivoPlan.Placa = activo.Placa;
                    nuevoActivoPlan.MesPropuesto = numMes;
                    listaPlanActivos.Add(nuevoActivoPlan);
                    contador++;
                }
                planPreventivoDatos.guardarListaPlan(listaPlanActivos);
                return true;
            }
            return false;
        }//Metodo Generar Plan

        public bool existePlanVigente() {
            return planPreventivoDatos.existePlanVigente();
        }

        public List<ActivoPlanPreventivo> obtenerTodo()
        {
            if (existePlanVigente())
                return planPreventivoDatos.obtenerTodo();
            else
                return new List<ActivoPlanPreventivo>();

        }
    }
}
