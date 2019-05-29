using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicios;
using Entidades;

namespace Proyecto.Catalogos.Edificios
{
    /// <summary>
    /// Adrián Serrano
    /// 29/may/2019
    /// Clase para crear un nuevo edificio
    /// </summary>
    public partial class NuevoEdificio : System.Web.UI.Page
    {
        #region variables globales
        EdificioServicios edificioServicios = new EdificioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNombreEdificio.Attributes.Add("oninput", "validarTexto(this)");
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

            #region validacion nombre edificio
            String nombreEdificio = txtNombreEdificio.Text;

            if (nombreEdificio.Trim() == "")
            {
                txtNombreEdificio.CssClass = "form-control alert-danger";
                divNombreEdificioIncorrecto.Style.Add("display", "block");

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
        protected void txtxNombreEdificio_TextChanged(object sender, EventArgs e)
        {
            txtNombreEdificio.CssClass = "form-control";
            lblNombreEdificioIncorrecto.Visible = false;
        }

        /// <summary>
        /// Metodo que se activa cuando se da click al boton de guardar
        /// valida que todos los campos se hayan ingrsado correctamente 
        /// y guarda los datos en la base de datos 
        /// redirecciona a la pantalla de administacion de periodos
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de guardar los datos en la base de datos
            if (validarCampos())
            {
                Edificio edificio = new Edificio();
                edificio.nombre = txtNombreEdificio.Text;
                
                edificioServicios.insertarEdificio(edificio);

                String url = Page.ResolveUrl("~/Catalogos/Edificios/AdministrarEdificio.aspx");
                Response.Redirect(url);
            }
        }


        /// <summary>
        /// Metodo que se activa cuando se le da click al boton cancelar
        /// redirecciona a la pantalla de adminstracion de periodos
        /// </summary>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Edificios/AdministrarEdificio.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}