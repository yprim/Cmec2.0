﻿using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Responsables
{
    public partial class EditarResponsable : System.Web.UI.Page
    {
        #region variables globales
        ResponsableServicios responsableServicios = new ResponsableServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Responsable responsable = (Responsable)Session["responsableEditar"];
                txtNombreResponsable.Text = responsable.nombre;
                txtNombreResponsable.Attributes.Add("oninput", "validarTexto(this)");
                txtUsuarioResponsable.Text = responsable.usuario;
                txtUsuarioResponsable.Attributes.Add("oninput", "validarTexto(this)");
            }
        }

        #endregion

        #region logica


        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
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

            #region validacion nombre responsable

            String nombreResponsable = txtNombreResponsable.Text;
            String usuarioResponsable = txtUsuarioResponsable.Text;

            if (nombreResponsable.Trim() == "")
            {
                txtNombreResponsable.CssClass = "form-control alert-danger";
                divNombreResponsableIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            else if (usuarioResponsable.Trim() == "")
            {
                txtUsuarioResponsable.CssClass = "form-control alert-danger";
                divUsuarioResponsableIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtNombreResponsable_Changed(object sender, EventArgs e)
        {
            txtNombreResponsable.CssClass = "form-control";
            lblNombreResponsable.Visible = false;
        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de actualizar
        ///valida que todos los campos se hayan ingresado correctamente y guarda los datos en la base de datos
        ///redireccion a la pantalla de Administracion de responsables
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
                Responsable responsable = (Responsable)Session["responsableEditar"];
                responsable.nombre = txtNombreResponsable.Text;
                responsable.usuario = txtUsuarioResponsable.Text;

                responsableServicios.actualizarResponsable(responsable);

                String url = Page.ResolveUrl("~/Catalogos/Responsables/AdministrarResponsable.aspx");
                Response.Redirect(url);
            }


        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de responsables
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Responsables/AdministrarResponsable.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}