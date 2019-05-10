using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos
{
    public partial class EliminarTarea : System.Web.UI.Page
    {
        #region variables globales
        TareaServicios tareaServicios = new TareaServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Tarea tarea = (Tarea)Session["tareaEliminar"];
                txtDescripcionTarea.Text = tarea.descripcion;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de tareas
        /// elimina el tarea de la base de datos
        // redireccion a la pantalla de Administracion de tareas
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Tarea tarea = (Tarea)Session["tareaEliminar"];

            try
            {
                tareaServicios.eliminarTarea(tarea);
                String url = Page.ResolveUrl("~/Catalogos/Tareas/AdministrarTarea.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

            //  (this.Master as Site).Mensaje("El tarea no puede ser eliminado ya que está siendo utilizado por otra reunión", "¡Alerta!");
            }
        }


        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de tareas
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Tareas/AdministrarTarea.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}