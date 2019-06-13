using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ActivoPlanPreventivo
    {
        int placa;
        String serie;
        String descripcion;
        String responsable;
        String edificio;
        String ubicacion;
        String fechaPropuesta;

        public ActivoPlanPreventivo() {}

        public int Placa { get => placa; set => placa = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Responsable { get => responsable; set => responsable = value; }
        public string Edificio { get => edificio; set => edificio = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public String FechaPropuesta { get => fechaPropuesta; set => fechaPropuesta = value; }
    }
}
