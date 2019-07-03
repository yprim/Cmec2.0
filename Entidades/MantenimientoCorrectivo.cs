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
        int id_mantenimiento;
        DateTime fecha;
        string descripcion;
        string estado;
        bool es_correctivo;
        string tipo_Mantenimiento;
        string id_responsable;
        string id_funcionario;
        int placa_activo;
        string id_ubicacion;
        int plan_activo;
        string usuario_uti;


        public MantenimientoCorrectivo() {
            
        }
       
        public int Id_mantenimiento { get => id_mantenimiento; set => id_mantenimiento = value; }
        public String Fecha { get => fecha.ToShortDateString(); set => fecha = DateTime.Parse(value); }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado;  set => estado = value; }         
        public bool Es_correctivo { get { return es_correctivo; } set { es_correctivo = value; } }
        public string Id_responsable { get => id_responsable; set => id_responsable = value; }
        public string Id_funcionario { get => id_funcionario; set => id_funcionario = value; }
        public int Placa_activo { get => placa_activo; set => placa_activo = value; }
        public string Id_ubicacion { get => id_ubicacion; set => id_ubicacion = value; }
        public int Plan_activo { get => plan_activo; set => plan_activo = value; }
        public string Tipo_Mantenimiento { get => tipo_Mantenimiento; set => tipo_Mantenimiento = value; }
        public string Usuario_uti { get => usuario_uti; set => usuario_uti = value; }
    }
}
