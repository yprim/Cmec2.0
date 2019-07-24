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
    /// Priscilla Mena Monge
    /// 24/7/2019
    /// Clase para administrar los servicios de la entidad de Funcionario
    /// </summary>
    public class FuncionarioServicios
    {
        #region variables
        FuncionarioDatos funcionarioDatos = new FuncionarioDatos();
        #endregion

        #region servicios

        /// <summary>
        /// Priscilla Mena Monge
        /// 24/7/2019
        /// Efecto: devuelve una lista con todas los Funcionarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de funcionarios
        /// </summary>
        /// <param name="Funcionario"></param>
        /// <returns></returns>
        public List<Funcionario> getFuncionarios()
        {
            return funcionarioDatos.getFuncionarios();
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 24/7/2019
        /// Efecto: inserta en la base de datos un Funcionario
        /// Requiere: Funcionario
        /// Modifica: -
        /// Devuelve: id del funcionario insertado
        /// </summary>
        /// <param name="Funcionario"></param>
        /// <returns></returns>
        public int insertarFuncionario(Funcionario funcionario)
        {
            return funcionarioDatos.insertarFuncionario(funcionario);
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 24/7/2019
        /// Efecto: actualiza un Funcionario
        /// Requiere: Funcionario a modificar
        /// Modifica: Funcionario
        /// Devuelve: -
        /// </summary>
        /// <param name="Funcionario"></param>
        public void actualizarFuncionario(Funcionario funcionario)
        {
            funcionarioDatos.actualizarFuncionario(funcionario);

        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 24/7/2019
        /// Efecto: Elimina un Funcionario de  la base de datos
        /// Requiere: Funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="Funcionario"></param>
        public void eliminarFuncionario(Funcionario funcionario)
        {
            funcionarioDatos.eliminarFuncionario(funcionario);

        }
        #endregion

    }
}
