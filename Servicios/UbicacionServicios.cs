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
    /// Adrián Serrano
    /// 5/9/2019
    ///Clase para administrar los servicios de la entidad Ubicacion
    /// </summary>
    public class UbicacionServicios
    {
        #region variables
        UbicacionDatos ubicacionDatos = new UbicacionDatos();
        #endregion

        #region servicios

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: devuelve una lista con todas las ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de ubicaciones
        /// </summary>
        /// <param name="Ubicacion"></param>
        /// <returns></returns>
        public List<Ubicacion> getUbicaciones()
        {
            return ubicacionDatos.getUbicaciones();
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: inserta en la base de datos una Ubicacion
        /// Requiere: Ubicacion
        /// Modifica: -
        /// Devuelve: id de la Ubicacion insertado
        /// </summary>
        /// <param name="Ubicacion"></param>
        /// <returns></returns>
        public int insertarUbicacion(Ubicacion ubicacion)
        {
            return ubicacionDatos.insertarUbicacion(ubicacion);
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: actualiza una Ubicacion
        /// Requiere: Ubicacion a modificar
        /// Modifica: Ubicacion
        /// Devuelve: -
        /// </summary>
        /// <param name="Ubicacion"></param>
        public void actualizarUbicacion(Ubicacion ubicacion)
        {
            ubicacionDatos.actualizarUbicacion(ubicacion);
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: Elimina una Ubicacion de  la base de datos
        /// Requiere: Ubicacion
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="Ubicacion"></param>
        public void eliminarUbicacion(Ubicacion ubicacion)
        {
            ubicacionDatos.eliminarUbicacion(ubicacion);

        }
        #endregion
    }
}
