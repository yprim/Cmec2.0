using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Responsables
{
    public partial class EliminarResponsable : System.Web.UI.Page
    {
        #region variables globales
        ResponsableServicios responsableServicios = new ResponsableServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Responsable responsable = (Responsable)Session["responsableEliminar"];
                txtNombreResponsable.Text = responsable.nombre;
                txtUsuario.Text = responsable.usuario;

            }


        }
        #endregion

        #region eventos


        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de responsables
        /// elimina el responsable de la base de datos
        // redireccion a la pantalla de Administracion de responsables
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Responsable responsable = (Responsable)Session["responsableEliminar"];

            try
            {
                responsableServicios.eliminarResponsable(responsable);
                String url = Page.ResolveUrl("~/Catalogos/Responsables/AdministrarResponsable.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No se puede eliminar!. Está siendo referenciado este responsable con alguna mantenimiento. PROCEDA A CANCELAR!');", true);
            }
        }


        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de responsables
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Responsables/AdministrarResponsable.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}