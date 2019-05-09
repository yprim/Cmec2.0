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
    public partial class EditarUbicacion : System.Web.UI.Page
    {
        #region variables globales
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Ubicacion ubicacion = (Ubicacion)Session["ubicacionEditar"];
                txtDescripcionUbicacion.Text = ubicacion.descripcion;
                txtDescripcionUbicacion.Attributes.Add("oninput", "validarTexto(this)");
            }
        }

        #endregion

        #region logica


        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto:Metodo que valida los campos que debe ingresar el usuario
        /// devuelve true si todos los campos esta con datos correctos
        /// sino devuelve false y marcar lo campos para que el usuario vea cuales son los campos que se encuntran mal
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean validarCampos()
        {
            Boolean validados = true;

            #region validacion descripcion ubicacion

            String DescripcionUbicacion = txtDescripcionUbicacion.Text;

            if (DescripcionUbicacion.Trim() == "")
            {
                txtDescripcionUbicacion.CssClass = "form-control alert-danger";
                divDescripcionUbicacionIncorrecto.Style.Add("display", "block");
                lblDescripcionUbicacionIncorrecto.Visible = true;

                validados = false;
            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtDescripcionUbicacion_Changed(object sender, EventArgs e)
        {
            txtDescripcionUbicacion.CssClass = "form-control";
            lblDescripcionUbicacion.Visible = false;
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de actualizar
        ///valida que todos los campos se hayan ingresado correctamente y guarda los datos en la base de datos
        ///redireccion a la pantalla de Administracion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnActualiza_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de actualizar los datos en la base de datos
            if (validarCampos())
            {
                Ubicacion ubicacion = (Ubicacion)Session["ubicacionEditar"];
                ubicacion.descripcion = txtDescripcionUbicacion.Text;

                ubicacionServicios.actualizarUbicacion(ubicacion);

                String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/AdministrarUbicacion.aspx");
                Response.Redirect(url);
            }


        }

        /// <summary>
        /// Adrián Serrano
        /// 5/9/2019
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