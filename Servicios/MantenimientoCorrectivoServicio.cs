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
        ResponsableServicios responsableServicios = new ResponsableServicios();
        //FuncionarioServicios funcionarioServicios = new FuncionarioServicios();
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
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

        public List<MantenimientoCorrectivo> nombreResponsable(List<MantenimientoCorrectivo> mantenimientos)
        {

            List<Responsable> responsables = responsableServicios.getResponsables();

            foreach (MantenimientoCorrectivo mantenimiento in mantenimientos)
            {
                int id_responsable = Convert.ToInt32(mantenimiento.Id_responsable);

                foreach (Responsable responsable in responsables)
                {
                    if (responsable.idResponsable == id_responsable)
                    {
                        mantenimiento.Id_responsable = responsable.nombre;

                    }
                }

            }
            return mantenimientos;
        }

        public List<MantenimientoCorrectivo> nombreUbicacion(List<MantenimientoCorrectivo> mantenimientos)
        {
            string nombreUbicacion = "";

            List<Ubicacion> ubicaciones = ubicacionServicios.getUbicaciones();

            foreach (MantenimientoCorrectivo mantenimiento in mantenimientos)
            {
                int id_ubicacion = Convert.ToInt32(mantenimiento.Id_ubicacion);

                foreach (Ubicacion ubicacion in ubicaciones)
                {
                    if (id_ubicacion == ubicacion.idUbicacion)
                    {
                        mantenimiento.Id_ubicacion = "Edificio "+ ubicacion.edificio + ",oficina " + ubicacion.numeroAula;
                    }
                }

            }

            return mantenimientos;
        }

        //    public List<MantenimientoCorrectivo> nombreFuncionario(List<MantenimientoCorrectivo> mantenimientos)
        //    {

        //        List<Funcionario> funcionarios = funcionarioServicios.getFuncionarios();

        //        foreach (MantenimientoCorrectivo mantenimiento in mantenimientos)
        //        {
        //            int id_funcionario = Convert.ToInt32(mantenimiento.Id_funcionario);

        //            foreach (Funcionario funcionario in funcionarios)
        //            {
        //                if (funcionario.Id == id_funcionario)
        //                {
        //                    mantenimiento.Id_funcionario = funcionario.Nombre+" "+funcionario.Apellidos;

        //                }
        //            }

        //        }

        //        return mantenimientos;
        //}

        public MantenimientoCorrectivo cambiarPorNombres(MantenimientoCorrectivo mantenimiento)
        {

            
            return mantenimiento;
        }


        //Devuelve mantenimientos que no se han aprobados.
        public List<MantenimientoCorrectivo> getMantenimientosNoAprobados()
        {
            return mantenimientoDatos.getMantenimientosNoAprobados();
        }
        //Devuelve mantenimientos que si han sido aprobados
        public List<MantenimientoCorrectivo> getMantenimientosAprobados()
        {
            return mantenimientoDatos.getMantenimientosAprobados();
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
        public int insertarMantenimiento(MantenimientoCorrectivo Mantenimiento, List<String> Tareas)
        {

            return mantenimientoDatos.insertarMantenimientoCorrectivo(Mantenimiento, Tareas);

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
        public void actualizarMantenimiento(MantenimientoCorrectivo Mantenimiento,List<String> listaTareas)
        {
            mantenimientoDatos.actualizarMantenimientoCorrectivo(Mantenimiento,listaTareas);

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
        /// <summary>
        /// Steven Camacho
        /// 29/05/2019
        /// Efecto: Cambia el estado del mantenimiento a aprobado
        /// Requiere: Mantenimiento
        /// Modifica: -
        /// Devuelve: Un valor entero de la id del mantenimiento en confirmación de éxito de la aprobación.
        /// </summary>
        /// <param name="MantenimientoCorrectivo"></param>
        public int aprobarMantenimiento(int id)
        {
            return mantenimientoDatos.aprobarMantenimiento(id); //TODO metodo acceso datos.
            

        }

        /// <summary>
        /// Steven Camacho
        /// 19/Junio/2019
        /// Efecto: devuelve una lista con todos las tareas de un mantenimiento en específico. 
        /// Requiere: id_mantenimiento
        /// Modifica: -
        /// Devuelve: lista de tareas
        /// </summary>
        /// <param name="id_Mantenimiento"></param>
        /// <returns></returns>
        public List<Tarea> getTareasMantenimientos(int id_mantenimiento)
        {
            return mantenimientoDatos.getTareasMantenimientos(id_mantenimiento); 
        }
            #endregion
        }
}


