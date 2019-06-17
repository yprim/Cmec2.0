using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{  /// <summary>
   /// Priscilla Mena
   ///5/29/2019
   ///Clase para administrar los servicios de la entidad Responsable
   /// </summary>
    public class ResponsableServicios
    {
        #region variables

        ResponsableDatos responsableDatos = new ResponsableDatos();
        #endregion

        #region servicios

        /// <summary>
        /// Priscilla Mena
        /// 5/29/2019
        /// Efecto: devuelve un lista con todas las responsables
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de responsables
        /// </summary>
        /// <param name="Responsable"></param>
        /// <returns></returns>
        public List<Responsable> getResponsables()
        {


            return responsableDatos.getResponsables();
        }

        /// <summary>
        /// Priscilla Mena
        /// 5/29/2019
        /// Efecto: inserta en la base de datos un Responsable
        /// Requiere: Responsable
        /// Modifica: -
        /// Devuelve: id del Responsable insertado
        /// </summary>
        /// <param name="Responsable"></param>
        /// <returns></returns>
        public int insertarResponsable(Responsable Responsable)
        {


            return responsableDatos.insertarResponsable(Responsable);
        }

        /// <summary>
        /// Priscilla Mena
        /// 5/29/2019
        /// Efecto: actualiza un Responsable
        /// Requiere: Responsable a modificar
        /// Modifica: Responsable
        /// Devuelve: -
        /// </summary>
        /// <param name="Responsable"></param>
        public void actualizarResponsable(Responsable Responsable)
        {
            responsableDatos.actualizarResponsable(Responsable);

        }

        /// <summary>
        /// Priscilla Mena
        /// 5/29/2019
        /// Efecto: Elimina un Responsable de  la base de datos
        /// Requiere: Responsable
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="Responsable"></param>
        public void eliminarResponsable(Responsable Responsable)
        {
            responsableDatos.eliminarResponsable(Responsable);

        }
        #endregion
    }

}
