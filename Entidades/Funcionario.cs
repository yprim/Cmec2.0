using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Funcionario
    {
        public int id { get; set; }
        public String usuario { get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public String correo { get; set; }
        public String numero_telefono1 { get; set; }
        public String numero_telefono2 { get; set; }
        public String ocupacion { get; set; }
        public int habilitado { get; set; }


    }
}
