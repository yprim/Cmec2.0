using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ReporteAvance
    {
        #region variables
        ReporteDatos reporteDatos = new ReporteDatos();
        #endregion

        public LinkedList<int> reporteAvance()
        {
            return this.reporteDatos.ReporteAvance();
        }
    }
}
