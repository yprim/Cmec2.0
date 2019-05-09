using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Ubicaciones
{
    public partial class AdministrarUbicacion : System.Web.UI.Page
    {
        #region variables globales
        UbicacionServicios ubicacionServicios = new UbicacionServicios();

        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {


            Session["listaUbicaciones"] = null;
            Session["ubicacionEditar"] = null;
            Session["ubicacionEliminar"] = null;
            cargarDatosTblUbicaciones();


        }
        #endregion

        #region logica
        /// <summary>
        /// Adriá Serrano
        /// 5/09/2019
        /// Efecto: Metodo para llenar los datos de la tabla con las ubicaciones que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblUbicaciones()
        {
            List<Ubicacion> listaUbicaciones = new List<Ubicacion>();
            listaUbicaciones = ubicacionServicios.getUbicaciones();
            rpUbicacion.DataSource = listaUbicaciones;
            rpUbicacion.DataBind();

            Session["listaUbicaciones"] = listaUbicaciones;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Adrián Serrano
        /// 5/09/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa una nueva ubicación,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/NuevaUbicacion.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/09/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un ubicación,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idUbicacion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Ubicacion> listaUbicaciones = (List<Ubicacion>)Session["listaUbicaciones"];

            Ubicacion ubicacionEditar = new Ubicacion();

            foreach (Ubicacion ubicacion in listaUbicaciones)
            {
                if (ubicacion.idUbicacion == idUbicacion)
                {
                    ubicacionEditar = ubicacion;
                    break;
                }
            }

            Session["ubicacionEditar"] = ubicacionEditar;

            String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/EditarUbicacion.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Adrián Serrano
        /// 5/09/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina una ubicación,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idUbicacion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Ubicacion> listaUbicaciones = (List<Ubicacion>)Session["listaUbicaciones"];

            Ubicacion ubicacionEliminar = new Ubicacion();

            foreach (Ubicacion ubicacion in listaUbicaciones)
            {
                if (ubicacion.idUbicacion == idUbicacion)
                {
                    ubicacionEliminar = ubicacion;
                    break;
                }
            }

            Session["ubicacionEliminar"] = ubicacionEliminar;

            String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/EliminarUbicacion.aspx");
            Response.Redirect(url);

        }


        /// <summary>
        /// Adrián Serrano
        /// 5/09/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve una ubicacion,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idUbicacion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Ubicacion> listaUbicaciones = (List<Ubicacion>)Session["listaUbicaciones"];

            Ubicacion ubicacionVer = new Ubicacion();

            foreach (Ubicacion ubicacion in listaUbicaciones)
            {
                if (ubicacion.idUbicacion == idUbicacion)
                {
                    ubicacionVer = ubicacion;
                    break;
                }
            }

            Session["ubicacionVer"] = ubicacionVer;

            String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/VerUbicacion.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Adrián Serrano
        /// 5/09/2019
        /// Efecto: habilita o desabilita los botones de editar y elminar segun el rol
        /// Requiere: -
        /// Modifica: visibilidad de botones
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpUbicacion_ItemDataBound(object sender, RepeaterItemEventArgs e)
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