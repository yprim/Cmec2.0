using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Adrián Serrano
    /// 05/09/2019
    /// clase para administrar la entidad de Ubicación
    /// </summary>
    public class Ubicacion
    {
        public int idUbicacion { get; set; }
        public string numeroAula { get; set; }
        public Edificio edificio { get; set; }
    }
}
