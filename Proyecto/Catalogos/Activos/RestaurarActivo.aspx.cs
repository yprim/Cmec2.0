using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Activos
{
    public partial class RestaurarActivo : System.Web.UI.Page
    {
        #region variables globales
        ActivoServicios activoServicios = new ActivoServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Activo activo = (Activo)Session["activoRestaurar"];
                txtDescripcionActivo.Text = activo.Descripcion;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de restaurar
        /// redirecciona a la pantalla de adminstracion de activos eliminados
        /// restaura el tarea de la base de datos
        // redireccion a la pantalla de Administracion de activos eliminados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnRestaurar_Click(object sender, EventArgs e)
        {
            Activo activo = (Activo)Session["activoRestaurar"];

            try
            {
                activoServicios.restaurarActivo(activo.Placa);
                String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivoEliminado.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

                //  (this.Master as Site).Mensaje("El tarea no puede ser eliminado ya que está siendo utilizado por otra reunión", "¡Alerta!");
            }
        }


        /// <summary>
        /// Steven Camacho
        /// 5/6/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de activos eliminados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivoEliminado.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}