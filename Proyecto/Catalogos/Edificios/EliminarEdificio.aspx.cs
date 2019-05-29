using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Edificios
{
    public partial class EliminarEdificio : System.Web.UI.Page
    {
        #region variables globales
        EdificioServicios edificioServicios = new EdificioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Edificio edificio = (Edificio)Session["edificioEliminar"];
                txtNombreEdificio.Text = edificio.nombre;
            }
        }
        #endregion

        #region eventos


        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Edificios
        /// elimina el Edificio de la base de datos
        // redireccion a la pantalla de Administracion de Edificios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Edificio edificio = (Edificio)Session["edificioEliminar"];

            try
            {
                edificioServicios.eliminarEdificio(edificio);
                String url = Page.ResolveUrl("~/Catalogos/Edificios/AdministrarEdificio.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de edificios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Edificios/AdministrarEdificio.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}