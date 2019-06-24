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
    public partial class VerActivo : System.Web.UI.Page
    {
        #region variables globales
        TareaServicios tareaServicios = new TareaServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Activo activo = (Activo)Session["activoVer"];
                txtDescripcionActivo.Text = activo.Descripcion;
                txtPlacaActivo.Text = activo.Placa.ToString();
                txtSerieActivo.Text = activo.Serie;
                txtModeloActivo.Text = activo.Modelo;
                txtFechaCompraActivo.Text = activo.FechaCompra;
            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
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
            Activo activo = (Activo)Session["activoVer"];
            String url;
            if (activo.IsNotDeleted)
            {
                url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivo.aspx");
            }
            else {
                url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivoEliminado.aspx");
            }
            Response.Redirect(url);
        }

        #endregion

    }
}