using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    /// <summary>
    /// Priscilla Mena
    ///5/6/2019
    ///Clase para administrar los servicios de la entidad Tarea
    /// </summary>
    public class TareaServicios
    {
        #region variables
        TareaDatos tareaDatos = new TareaDatos();
        #endregion

        #region servicios

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: devuelve una lista con todas las tareas
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de tareas
        /// </summary>
        /// <param name="Tarea"></param>
        /// <returns></returns>
        public List<Tarea> getTareas()
        {


            return tareaDatos.getTareas();
        }
        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: devuelve una lista con todas las tareas
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de tareas
        /// </summary>
        /// <param name="Tarea"></param>
        /// <returns></returns>
        public List<Tarea> getTareasIncluyePreventivas()
        {


            return tareaDatos.getTareasIncluyePreventivas();
        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: inserta en la base de datos un Tarea
        /// Requiere: Tarea
        /// Modifica: -
        /// Devuelve: id del Tarea insertado
        /// </summary>
        /// <param name="Tarea"></param>
        /// <returns></returns>
        public int insertarTarea(Tarea Tarea)
        {


            return tareaDatos.insertarTarea(Tarea);
        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: actualiza una Tarea
        /// Requiere: Tarea a modificar
        /// Modifica: Tarea
        /// Devuelve: -
        /// </summary>
        /// <param name="Tarea"></param>
        public void actualizarTarea(Tarea Tarea)
        {
            tareaDatos.actualizarTarea(Tarea);

        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: Elimina una Tarea de  la base de datos
        /// Requiere: Tarea
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="Tarea"></param>
        public void eliminarTarea(Tarea Tarea)
        {
            tareaDatos.eliminarTarea(Tarea);

        }
        #endregion
    }
}
