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
                String tareasRealizadas = "";
                MantenimientoCorrectivo mantenimiento = (MantenimientoCorrectivo)Session["mantenimientoVer"];
                List<Tarea> tareas = mantenimientoServicios.getTareasMantenimientos(mantenimiento.Id_mantenimiento);
                foreach (var item in tareas)
                {
                    tareasRealizadas += "            -> " + item.descripcion + "\n";
                }
                
                txtId.Text = mantenimiento.Id_mantenimiento.ToString();
                txtId_placa.Text = mantenimiento.Placa_activo.ToString();
                txtResponsable.Text = mantenimiento.Id_responsable.ToString();
                txtFecha.Text = mantenimiento.Fecha.ToString();
                txtUbicacion.Text = mantenimiento.Id_ubicacion.ToString();
                txtDescripcionMantenimiento.Text = mantenimiento.Descripcion + "\n" + "Tareas realizadas:\n" + tareasRealizadas;

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
            String procedencia = (String)Session["procedencia"] ;
            String url = "";
            if(procedencia!="aprobaciones")
            url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
            else
            url = Page.ResolveUrl("~/Catalogos/AprobacionMantenimientos/AdministrarAprobacionMantenimientos.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}