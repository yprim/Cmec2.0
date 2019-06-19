using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.pendienteMover
{
    public partial class AprobarMantenimiento : System.Web.UI.Page
    {


        #region variables globales
        MantenimientoCorrectivoServicio mantenimientoServicio = new MantenimientoCorrectivoServicio();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                String tareasRealizadas = "";
                MantenimientoCorrectivo mantenimiento = (MantenimientoCorrectivo)Session["mantenimientoAprobar"];
                List<Tarea> tareas = mantenimientoServicio.getTareasMantenimientos(mantenimiento.Id_mantenimiento);
                foreach (var item in tareas)
                {
                    tareasRealizadas +="            -> "+ item.descripcion + "\n";
                }


                txtDescripcionMantenimiento.Text = mantenimiento.Descripcion+ "\n"+ "Tareas realizadas:\n" + tareasRealizadas;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de aprobar
        /// redirecciona a la pantalla de adminstracion de lista mantenimientos pendientes
        // redireccion a la pantalla de Administracion mantenimientos pendientes
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            MantenimientoCorrectivo mantenimiento = (MantenimientoCorrectivo)Session["mantenimientoAprobar"];

            try
            {
                mantenimientoServicio.aprobarMantenimiento(mantenimiento.Id_mantenimiento);
                String url = Page.ResolveUrl("~/Catalogos/AprobacionMantenimientos/AdministrarAprobacionMantenimientos.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {
                String url = Page.ResolveUrl("~/Catalogos/AprobacionMantenimientos/AdministrarAprobacionMantenimientos.aspx");
            }
        }


        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de mantenimientos pendientes
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AprobacionMantenimientos/AdministrarAprobacionMantenimientos.aspx");
            Response.Redirect(url);
        }

        #endregion


    }
    
}