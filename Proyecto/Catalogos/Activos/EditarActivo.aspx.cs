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
    public partial class EditarActivo : System.Web.UI.Page
    {


        #region variables globales
        ActivoServicios activoServicios = new ActivoServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSerieActivo.Attributes.Add("oninput", "validarTexto(this,'serie')");
                txtModeloActivo.Attributes.Add("oninput", "validarTexto(this,'modelo')");
                ddlDescripcionActivo.Attributes.Add("oninput", "validarTexto(this,'desc')");
                txtFechaActivo.Attributes.Add("oninput", "validarTexto(this,'fecha')");

                //cargar campos
                Activo activo = (Activo)Session["activoEditar"];
                textPlacaActivo.Text = activo.Placa.ToString();
                txtSerieActivo.Text = activo.Serie;
                txtModeloActivo.Text = activo.Modelo;
                ddlDescripcionActivo.Text = activo.Descripcion;
                txtFechaActivo.Text = DateTime.Parse(activo.FechaCompra).ToString("yyyy-MM-dd");

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
                activo.Placa = Int32.Parse(textPlacaActivo.Text);
                activo.Serie = txtSerieActivo.Text;
                activo.Modelo = txtModeloActivo.Text;
                activo.Descripcion = ddlDescripcionActivo.Text;
                activo.FechaCompra = txtFechaActivo.Text;

                activoServicios.actualizar(activo);

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