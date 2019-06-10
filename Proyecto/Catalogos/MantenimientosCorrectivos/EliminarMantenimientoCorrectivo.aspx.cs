using System;
using Entidades;
using Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.MantenimientosCorrectivos
{
    public partial class EliminarMantenimientoCorrectivo : System.Web.UI.Page
    {
        #region variables globales
        MantenimientoCorrectivoServicio mantenimientoServicios = new MantenimientoCorrectivoServicio();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                MantenimientoCorrectivo mantenimiento = (MantenimientoCorrectivo)Session["mantenimientoEliminar"];
                txtIdMantenimiento.Text = mantenimiento.Id.ToString();
                txtIdPlaca.Text = mantenimiento.Id_placa.ToString();
                txtDescripcion.Text = mantenimiento.Descripcion.ToString();
            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Mantenimientos
        /// elimina el Mantenimiento de la base de datos
        // redireccion a la pantalla de Administracion de Mantenimientos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            MantenimientoCorrectivo mantenimiento = (MantenimientoCorrectivo)Session["mantenimientoEliminar"];

            try
            {
                mantenimientoServicios.eliminarMantenimiento(mantenimiento);
                String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

                //  (this.Master as Site).Mensaje("El tarea no puede ser eliminado ya que está siendo utilizado por otra reunión", "¡Alerta!");
            }
        }


        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Mantenimiento
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}