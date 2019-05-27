using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ActivoServicios
    {
        /// <summary>
        /// Steven Camacho B.
        /// 27/5/2019
        /// Clase para administrar servicios de activos
        /// </summary>
        ActivoDatos datos;
        public ActivoServicios()
        {
            datos = new ActivoDatos();
        }

        public LinkedList<Activo> obtenerTodo()
        {
            return datos.obtenerTodos();
        }

        public int insertar(Activo activo)
        {
            return datos.insertar(activo);
        }

        public int actualizar(Activo activo)
        {
            return datos.actualizar(activo);
        }

        public int inhabilitar(int placa)
        {
            return datos.inhabilitar(placa);
        }

        public LinkedList<Activo> search(string search)
        {
            return datos.search(search);
        }
    }
}
