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
    public partial class VerEdificio : System.Web.UI.Page
    {
        #region variables globales
        EdificioServicios edificioServicios = new EdificioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Edificio edificio = (Edificio)Session["edificioVer"];
                txtNombreEdificio.Text = edificio.nombre;
            }

        }
        #endregion

        #region eventos

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Edificios
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