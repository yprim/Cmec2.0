using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ReporteServicios
    {
        #region variables
        ReporteDatos reporteDatos = new ReporteDatos();
        #endregion

        public LinkedList<ReporteGeneral> ReporteMantenimientos()
        {
            return this.reporteDatos.ReporteMantenimientos();
        }

        public LinkedList<int> ReporteAvance()
        {
            return this.reporteDatos.ReporteAvance();
        }
    }
}
