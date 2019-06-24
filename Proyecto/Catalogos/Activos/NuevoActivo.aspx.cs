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
    public partial class NuevoActivo : System.Web.UI.Page
    {


        #region variables globales
        ActivoServicios activoServicios = new ActivoServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPlacaActivo.Attributes.Add("oninput", "validarTexto(this,'placa')");
                txtSerieActivo.Attributes.Add("oninput", "validarTexto(this,'serie')");
                txtModeloActivo.Attributes.Add("oninput", "validarTexto(this,'modelo')");
                ddlDescripcionActivo.Attributes.Add("oninput", "validarTexto(this,'desc')");
                txtFechaActivo.Attributes.Add("oninput", "validarTexto(this,'fecha')");
                
                //calendario.Visible = false;
            }
        }

        #endregion

        #region logica

        /// <summary>
        /// Metodo que valida los campos que debe ingresar el usuario
        /// </summary>
        /// <returns>Devuelve true si todos los campos esta con datos correctos sino devuelve false
        /// y marcar lo campos para que el usuario vea cuales son los campos que se encuentran mal</returns>
        public Boolean validarCampos()
        {
            Boolean validados = true;

            #region validacion placa activo
            String placaActivo = txtPlacaActivo.Text;

            if (placaActivo.Trim() == "")
            {
                txtPlacaActivo.CssClass = "form-control alert-danger";
                divPlacaActivoIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion serie activo
            String serieActivo = txtSerieActivo.Text;

            if (serieActivo.Trim() == "")
            {
                txtSerieActivo.CssClass = "form-control alert-danger";
                divSerieActivoIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion modelo activo
            String modeloActivo = txtModeloActivo.Text;

            if (modeloActivo.Trim() == "")
            {
                txtModeloActivo.CssClass = "form-control alert-danger";
                divModeloActivoIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion descripción activo
            String descripcionActivo = ddlDescripcionActivo.Text;

            if (descripcionActivo.Trim() == "")
            {
                ddlDescripcionActivo.CssClass = "form-control alert-danger";
                divDescripcionActivoIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion fecha compra activo
            String fechaActivo = txtFechaActivo.Text;

            if (fechaActivo.Trim() == "")
            {
                txtFechaActivo.CssClass = "form-control alert-danger";
                divFechaCompraActivoIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            return validados;
        }

        #endregion

        #region eventos

        /// <summary>
        /// Metodo que se activa cuando se cambia el nombre
        /// </summary>
        protected void txtPlacaActivo_TextChanged(object sender, EventArgs e)
        {
            txtPlacaActivo.CssClass = "form-control";
            lblPlacaActivoIncorrecto.Visible = false;
        }

        /// <summary>
        /// Metodo que se activa cuando se da click al boton de guardar
        /// valida que todos los campos se hayan ingrsado correctamente 
        /// y guarda los datos en la base de datos 
        /// redirecciona a la pantalla de administacion de activos
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de guardar los datos en la base de datos
            if (validarCampos())
            {
                Activo activo = new Activo();
                activo.Placa = Int32.Parse(txtPlacaActivo.Text);
                activo.Serie = txtSerieActivo.Text;
                activo.Modelo = txtModeloActivo.Text;
                activo.Descripcion = ddlDescripcionActivo.SelectedValue;
                activo.FechaCompra = txtFechaActivo.Text;

                activoServicios.insertar(activo);

                String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivo.aspx");
                Response.Redirect(url);
            }
        }


        /// <summary>
        /// Metodo que se activa cuando se le da click al boton cancelar
        /// redirecciona a la pantalla de adminstracion de activos
        /// </summary>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivo.aspx");
            Response.Redirect(url);
        }


        #endregion

    }
    
}