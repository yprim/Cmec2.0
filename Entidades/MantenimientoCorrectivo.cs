using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Leonardo Gomez
    /// 29/may/2019
    /// Clase para administrar la entidad de Mantenimiento_Correctivo
    /// </summary>
    public class MantenimientoCorrectivo
    {
        int id;
        int id_placa;
        int responsable;
        DateTime fecha;
        int ubicacion;
        String descripcion;
        bool estado;

        public MantenimientoCorrectivo(){ }

            public int Id { get => id; set => id = value; }
        public int Id_placa { get => id_placa; set => id_placa = value; }
        public int Responsable { get => responsable; set => responsable = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }  
}
