using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Activos
{
    public partial class EliminarActivo : System.Web.UI.Page
    {

        #region variables globales
        ActivoServicios activoServicios = new ActivoServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Activo activo = (Activo)Session["activoEliminar"];
                txtDescripcionActivo.Text = activo.Descripcion;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de activos 
        /// elimina el activo de la base de datos
        // redireccion a la pantalla de Administracion de activos 
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Activo activo = (Activo)Session["activoEliminar"];

            try
            {
                activoServicios.inhabilitar(activo.Placa);
                String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivo.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Steven Camacho
        /// 5/6/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de activos 
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivo.aspx");
            Response.Redirect(url);
        }

        #endregion

    }
}