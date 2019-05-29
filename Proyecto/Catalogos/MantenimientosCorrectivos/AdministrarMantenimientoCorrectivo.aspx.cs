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
    public partial class AdministrarMantenimientoCorrectivo : System.Web.UI.Page
    {
        #region variables globales
        MantenimientoCorrectivoServicio mantenimientoServicios = new MantenimientoCorrectivoServicio();

        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["listaMantenimiento"] = null;
            Session["mantenimientoEditar"] = null;
            Session["mantenimientoEliminar"] = null;
            cargarDatosTblMantenimiento();

        }
        #endregion

        #region logica
        /// <summary>
        /// Leonardo Gomez
        /// 29/May/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los Mantenimientos que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblMantenimiento()
        {
            List<MantenimientoCorrectivo> listaMantenimiento = new List<MantenimientoCorrectivo>();
            listaMantenimiento = mantenimientoServicios.getMantenimientos();
            rpMantenimiento.DataSource = listaMantenimiento;
            rpMantenimiento.DataBind();

            Session["listaMantenimiento"] = listaMantenimiento;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Leonado Gomez
        ///29/May/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo mantenimiento Correctivo,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/NuevoMantenimentoCorrectivo.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Leonardo Gomez
        ///29/May/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un mantenimiento,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<MantenimientoCorrectivo> listaMantenimiento = (List<MantenimientoCorrectivo>)Session["listaMantenimiento"];

            MantenimientoCorrectivo mantenimientoEditar = new MantenimientoCorrectivo();

            foreach (MantenimientoCorrectivo mantenimiento in listaMantenimiento)
            {
                if (mantenimiento.Id == id)
                {
                    mantenimientoEditar = mantenimiento;
                    break;
                }
            }

            Session["mantenimientoEditar"] = mantenimientoEditar;

            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/EditarMantenimiento.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Leonado Gomez
        ///29/May/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un mantenimiento,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<MantenimientoCorrectivo> listaMantenimiento = (List<MantenimientoCorrectivo>)Session["listaMantenimiento"];

            MantenimientoCorrectivo mantenimientoEliminar = new MantenimientoCorrectivo();

            foreach (MantenimientoCorrectivo mantenimiento in listaMantenimiento)
            {
                if (mantenimiento.Id == id)
                {
                    mantenimientoEliminar = mantenimiento;
                    break;
                }
            }

            Session["mantenimientoEliminar"] = mantenimientoEliminar;

            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/EliminarMantenimientoCorrectivo.aspx");
            Response.Redirect(url);

        }


        /// <summary>
        /// Leonado Gomez
        /// 29/May/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un mantenimiento,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<MantenimientoCorrectivo> listaMantenimiento = (List<MantenimientoCorrectivo>)Session["listaMantenimiento"];

            MantenimientoCorrectivo mantenimientoVer = new MantenimientoCorrectivo();

            foreach (MantenimientoCorrectivo mantenimiento in listaMantenimiento)
            {
                if (mantenimientoVer.Id == id)
                {
                    mantenimientoVer = mantenimiento;
                    break;
                }
            }

            Session["mantenimientoVer"] = mantenimientoVer;

            String url = Page.ResolveUrl("~/Catalogos/MantemientosCorrectivos/VerMantenimientoCorrectivo.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Leonado Gomgez
        /// 29/May/2019
        /// Efecto: habilita o desabilita los botones de editar y elminar segun el rol
        /// Requiere: -
        /// Modifica: visibilidad de botones
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpMantenimiento_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btnEditar = e.Item.FindControl("btnEditar") as LinkButton;
                LinkButton btnEliminar = e.Item.FindControl("btnEliminar") as LinkButton;


            }
        }

        #endregion
    }
}