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
            throw new NotImplementedException();
        }

        public void guardarListaPlan(List<ActivoPlanPreventivo> listaPlanActivos)
        {
            throw new NotImplementedException();
        }

        public List<ActivoPlanPreventivo> obtenerListaActivoPorPrioridad()
        {
            throw new NotImplementedException();
        }

        public List<ActivoPlanPreventivo> obtenerTodo()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
