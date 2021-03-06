﻿using System;
using Entidades;
using Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;

namespace Proyecto.Catalogos.MantenimientosCorrectivos
{
    public partial class EliminarMantenimientoCorrectivo : System.Web.UI.Page
    {
        #region variables globales
        MantenimientoCorrectivoServicio mantenimientoServicios = new MantenimientoCorrectivoServicio();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                MantenimientoCorrectivo mantenimiento = (MantenimientoCorrectivo)Session["mantenimientoCorrectivoEliminar"];
                txtIdMantenimiento.Text = mantenimiento.Id_mantenimiento.ToString();
                txtIdPlaca.Text = mantenimiento.Placa_activo.ToString();
                txtDescripcion.Text = mantenimiento.Descripcion.ToString();
            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Mantenimientos
        /// elimina el Mantenimiento de la base de datos
        // redireccion a la pantalla de Administracion de Mantenimientos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            MantenimientoCorrectivo mantenimiento = (MantenimientoCorrectivo)Session["mantenimientoCorrectivoEliminar"];

            try
            {
                mantenimientoServicios.eliminarMantenimiento(mantenimiento);
                String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

             }
        }


        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Mantenimiento
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