using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Ubicaciones
{
    public partial class EliminarUbicacion : System.Web.UI.Page
    {
        #region variables globales
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ubicacion ubicacion = (Ubicacion)Session["ubicacionEliminar"];
                //txtEdificioUbicacion.Text = ubicacion.edificio;
                //txtDescripcionUbicacion.Text = ubicacion.descripcion;
            }
        }
        #endregion

        #region eventos


        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Ubicaciones
        /// elimina la ubicacion de la base de datos
        // redireccion a la pantalla de Administracion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Ubicacion ubicacion = (Ubicacion)Session["ubicacionEliminar"];

            try
            {
                ubicacionServicios.eliminarUbicacion(ubicacion);
                String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/AdministrarUbicacion.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/AdministrarUbicacion.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}