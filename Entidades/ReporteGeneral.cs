using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ReporteGeneral
    {
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public string es_correctivo { get; set; }
        public string responsable { get; set; }
        public string placa { get; set; }
        public string aula { get; set; }
        public string funcionario { get; set; }
    }
}
