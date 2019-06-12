using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Funcionario
    {
        int id;
        string usuario;
        string nombre;
        string apellidos;
        DateTime fecha_nacimiento;
        string correo;
        string numero_telefono1;
        string numero_telefono2;
        string ocupacion;
        int habilitado;

        public Funcionario()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime Fecha_Nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Numero_Telefono1 { get => numero_telefono1; set => numero_telefono1 = value; }
        public string Numero_Telefono2 { get => numero_telefono2; set => numero_telefono2 = value; }
        public string Ocupacion { get => ocupacion; set => ocupacion = value; }
        public int Habilitado { get; set; }

    }

}

