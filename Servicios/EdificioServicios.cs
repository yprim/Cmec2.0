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
    /// 5/28/2019
    /// Clase para administrar los servicios de la entidad Edificio
    /// </summary>
    public class EdificioServicios
    {
        #region variables
        EdificioDatos edificioDatos = new EdificioDatos();
        #endregion

        #region servicios

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: devuelve una lista con todas los edificios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de edificios
        /// </summary>
        /// <param name="Edificio"></param>
        /// <returns></returns>
        public List<Edificio> getEdificios()
        {
            return edificioDatos.getEdificios();
        }

        /// <summary>
        /// Adrián Serrano
        /// 6/08/2019
        /// Efecto: devuelve un edificio
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: un edificio
        /// </summary>
        /// <param></param>
        /// <returns><code>Edificio</code></returns>
        public Edificio getEdificioPorId(int idEdificio)
        {
            return edificioDatos.getEdificioPorId(idEdificio);
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: inserta en la base de datos un Edificio
        /// Requiere: Edificio
        /// Modifica: -
        /// Devuelve: id del Edificio insertado
        /// </summary>
        /// <param name="Edificio"></param>
        /// <returns></returns>
        public int insertarEdificio(Edificio edificio)
        {
            return edificioDatos.insertarEdificio(edificio);
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: actualiza un Edificio
        /// Requiere: Edificio a modificar
        /// Modifica: Edificio
        /// Devuelve: -
        /// </summary>
        /// <param name="Edificio"></param>
        public void actualizarEdificio(Edificio edificio)
        {
            edificioDatos.actualizarEdificio(edificio);
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: Elimina un Edificio de la base de datos
        /// Requiere: Edificio
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="Edificio"></param>
        public void eliminarEdificio(Edificio edificio)
        {
            edificioDatos.eliminarEdificio(edificio);

        }
        #endregion
    }
}
