using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.pendienteMover
{
    public partial class AprobarMantenimiento : System.Web.UI.Page
    {/*


        #region variables globales
        MantenimientoServicio mantenimientoServicio = new MantenimientoServicio();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Mantenimiento mantenimiento = (Mantenimiento)Session["mantenimientoAprobar"];

                txtDescripcionMantenimiento.Text = mantenimiento.Descripcion+ "\n"+ mantenimiento.tareas.toString();

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de aprobar
        /// redirecciona a la pantalla de adminstracion de lista mantenimientos pendientes
        // redireccion a la pantalla de Administracion mantenimientos pendientes
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento = (Mantenimiento)Session["mantenimientoAprobar"];

            try
            {
                mantenimientoServicio.aprobarMantenimiento(mantenimiento.id);
                String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarAprobacionMantenimientos.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

                //  (this.Master as Site).Mensaje("El tarea no puede ser eliminado ya que está siendo utilizado por otra reunión", "¡Alerta!");
            }
        }


        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de mantenimientos pendientes
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarAprobacionMantenimientos.aspx");
            Response.Redirect(url);
        }

        #endregion

*/
    }
    
}