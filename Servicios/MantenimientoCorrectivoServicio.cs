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
    /// Leonardo Gomez
    ///29/May/2019
    ///Clase para administrar los servicios de la entidad MantenimientoCorrectivo
    /// </summary>
    public class MantenimientoCorrectivoServicio
    {
        #region variables
        MantenimientoCorrectivoDatos mantenimientoDatos = new MantenimientoCorrectivoDatos();
        #endregion

        #region servicios

        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto: devuelve una lista con todas los mantenimientoCorrectivos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de mantenimientosCorrectivos
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        /// <returns></returns>
        public List<MantenimientoCorrectivo> getMantenimientos()
        {

            return mantenimientoDatos.getMantenimientosCorrectivos();

        }

        /// <summary>
        /// Leonado Gomez
        /// 29/May/2019
        /// Efecto: inserta en la base de datos un MantenimientoCorrectivo
        /// Requiere: MantenimientoCorrectivo
        /// Modifica: -
        /// Devuelve: id del Mantenimiento insertado
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        /// <returns></returns>
        public int insertarMantenimiento(MantenimientoCorrectivo Mantenimiento)
        {

            return mantenimientoDatos.insertarMantenimientoCorrectivo(Mantenimiento);

        }

        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto: actualiza un Mantenimiento
        /// Requiere: MantenimientoCorrectivo a modificar
        /// Modifica: MantenimientoCorrectivo
        /// Devuelve: -
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        public void actualizarMantenimiento(MantenimientoCorrectivo Mantenimiento)
        {
            mantenimientoDatos.actualizarMantenimientoCorrectivo(Mantenimiento);

        }

        /// <summary>
        /// Leonado Gomez
        /// 29/May/2019
        /// Efecto: Elimina un Mantenimiento de  la base de datos
        /// Requiere: Mantenimiento
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        public void eliminarMantenimiento(MantenimientoCorrectivo Mantenimiento)
        {
            mantenimientoDatos.eliminarMantenimientoCorrectivo(Mantenimiento);

        }
        #endregion
    }
}


