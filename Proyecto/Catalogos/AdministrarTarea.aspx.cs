using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos
{
    public partial class AdministrarTarea : System.Web.UI.Page
    {
        #region variables globales
        TareaServicios tareaServicios = new TareaServicios();

        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {


            Session["listaTareas"] = null;
            Session["tareaEditar"] = null;
            Session["tareaEliminar"] = null;
            cargarDatosTblTareas();


        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena
        /// 5/06/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los tareas que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblTareas()
        {
            List<Tarea> listaTareas = new List<Tarea>();
            listaTareas = tareaServicios.getTareas();
            rpTarea.DataSource = listaTareas;
            rpTarea.DataBind();

            Session["listaTareas"] = listaTareas;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        ///5/06/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo tarea,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevaTarea.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        ///5/06/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un tarea,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idTarea = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Tarea> listaTareas = (List<Tarea>)Session["listaTareas"];

            Tarea tareaEditar = new Tarea();

            foreach (Tarea tarea in listaTareas)
            {
                if (tarea.idTarea == idTarea)
                {
                    tareaEditar = tarea;
                    break;
                }
            }

            Session["tareaEditar"] = tareaEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarTarea.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        ///5/06/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un tarea,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idTarea = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Tarea> listaTareas = (List<Tarea>)Session["listaTareas"];

            Tarea tareaEliminar = new Tarea();

            foreach (Tarea tarea in listaTareas)
            {
                if (tarea.idTarea == idTarea)
                {
                    tareaEliminar = tarea;
                    break;
                }
            }

            Session["tareaEliminar"] = tareaEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarTarea.aspx");
            Response.Redirect(url);

        }


        /// <summary>
        /// Priscilla Mena
        /// 5/06/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un tarea,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idTarea = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Tarea> listaTareas = (List<Tarea>)Session["listaTareas"];

            Tarea tareaVer = new Tarea();

            foreach (Tarea tarea in listaTareas)
            {
                if (tarea.idTarea == idTarea)
                {
                    tareaVer = tarea;
                    break;
                }
            }

            Session["tareaVer"] = tareaVer;

            String url = Page.ResolveUrl("~/Catalogos/VerTarea.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Priscilla Mena    
        /// 5/06/2019
        /// Efecto: habilita o desabilita los botones de editar y elminar segun el rol
        /// Requiere: -
        /// Modifica: visibilidad de botones
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpTarea_ItemDataBound(object sender, RepeaterItemEventArgs e)
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