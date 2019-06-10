using System;
using Servicios;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.MantenimientosCorrectivos
{
    public partial class VerMantenimientoCorrectivo : System.Web.UI.Page
    {
        #region variables globales
        MantenimientoCorrectivoServicio mantenimientoServicios = new MantenimientoCorrectivoServicio();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MantenimientoCorrectivo mantenimiento = (MantenimientoCorrectivo)Session["mantenimientoVer"];

                txtId.Text = mantenimiento.Id.ToString();
                txtId_placa.Text = mantenimiento.Id_placa.ToString();
                txtResponsable.Text = mantenimiento.Responsable.ToString();
                txtFecha.Text = mantenimiento.Fecha.ToString();
                txtUbicacion.Text = mantenimiento.Ubicacion.ToString();
                txtDescripcionMantenimiento.Text = mantenimiento.Descripcion;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de mantenimientos Correctivos
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