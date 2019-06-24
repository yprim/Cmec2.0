using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ActivoPlanPreventivo
    {
        int placa;
        String equipo;
        String funcionario;
        String edificio;
        String ubicacion;
        int mesPropuesto;
        String ultimoMantenimiento;
        String nombreMesPropuesto;
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        String es_correctivo;
           
        public ActivoPlanPreventivo() {}

        public int Placa { get => placa; set => placa = value; }
        public string Equipo { get => equipo; set => equipo = value; }
        public string Funcionario { get => funcionario; set => funcionario = value; }
        public string Edificio { get => edificio; set => edificio = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public int MesPropuesto { get => mesPropuesto; set => mesPropuesto = value; }
        public string NombreMesPropuesto { get => formatoFecha.GetMonthName(this.mesPropuesto); }
        public String UltimoMantenimiento { get => ultimoMantenimiento; set => ultimoMantenimiento = value; }
        public string Es_correctivo { get => es_correctivo; set => es_correctivo = value; }
    }
}
