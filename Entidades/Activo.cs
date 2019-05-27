using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Steven Camacho
    /// 10/may/2019
    /// Clase para administrar la entidad de Activo
    /// </summary>
    public class Activo
    {
        int placa;
        string serie;
        string modelo;
        DateTime fechaCompra;
        string descripcion;
        int responsable;
        int ubicacion;

        public Activo() { }

        public int Placa { get => placa; set => placa = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public DateTime FechaCompra { get => fechaCompra; set => fechaCompra = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Responsable { get => responsable; set => responsable = value; }
        public int Ubicacion { get => ubicacion; set => ubicacion = value; }
    }
}
