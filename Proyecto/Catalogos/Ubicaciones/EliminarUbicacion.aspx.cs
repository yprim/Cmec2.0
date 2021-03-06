﻿using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Ubicaciones
{
    public partial class EliminarUbicacion : System.Web.UI.Page
    {
        #region variables globales
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ubicacion ubicacion = (Ubicacion)Session["ubicacionEliminar"];
                txtNumeroUbicacion.Text = ubicacion.numeroAula;
                txtEdificioUbicacion.Text = ubicacion.edificio.nombre;
            }
        }
        #endregion

        #region eventos


        /// <summary>
        /// Adrian Serrano
        /// 5/29/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Ubicaciones
        /// elimina la ubicacion de la base de datos
        // redireccion a la pantalla de Administracion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Ubicacion ubicacion = (Ubicacion)Session["ubicacionEliminar"];

            try
            {
                int idUbicacion = ubicacionServicios.eliminarUbicacion(ubicacion);
                String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/AdministrarUbicacion.aspx");
                 Response.Redirect(url);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No se puede eliminar!. Está siendo referenciado esta ubicación con alguna mantenimiento. PROCEDA A CANCELAR!');", true);
            }
        }


        /// <summary>
        /// Adrian Serrano
        /// 5/29/2019
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