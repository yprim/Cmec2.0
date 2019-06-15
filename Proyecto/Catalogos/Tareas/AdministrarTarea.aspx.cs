using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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


        readonly PagedDataSource pgsource = new PagedDataSource();
        int primerIndex, ultimoIndex;
        private int elmentosMostrar = 10;
        private int paginaActual
        {
            get
            {
                if (ViewState["paginaActual"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["paginaActual"]);
            }
            set
            {
                ViewState["paginaActual"] = value;
            }
        }

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {

            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPermitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!Page.IsPostBack)
            {
                Session["listaTareas"] = null;

                TareaServicios edificioServicios = new TareaServicios();

                List<Tarea> listaTareas = new List<Tarea>();
                listaTareas = edificioServicios.getTareas();

                Session["listaTareas"] = listaTareas;
                Session["listaTareasFiltrada"] = listaTareas;

                mostrarDatosTabla();
            }

        }
        #endregion

        #region logica

        /// <summary>
        /// Adrian Serrano
        /// 29/5/2019
        /// Efecto: carga los datos filtrados en la tabla de Tareas y realiza la paginacion correspondiente
        /// Requiere: -
        /// Modifica: los datos mostrados en pantalla
        /// Devuelve: -
        /// </summary>
        private void mostrarDatosTabla()
        {

            List<Tarea> listaSession = (List<Tarea>)Session["listaTareas"];
            String idTarea = "";
            String descripcion = "";
            if (ViewState["idTarea"] != null)
                idTarea = (String)ViewState["idTarea"];

            if (ViewState["descripcion"] != null)
                descripcion = (String)ViewState["descripcion"];

            List<Tarea> listaTareas = (List<Tarea>)listaSession.Where(x => x.descripcion.ToUpper().Contains(descripcion.ToUpper()) && x.idTarea.ToString().Contains(idTarea)).ToList();
            Session["listaTareasFiltrada"] = listaTareas;

            var dt = listaTareas;
            pgsource.DataSource = dt;
            pgsource.AllowPaging = true;
            //numero de items que se muestran en el Repeater
            pgsource.PageSize = elmentosMostrar;
            pgsource.CurrentPageIndex = paginaActual;
            //mantiene el total de paginas en View State
            ViewState["TotalPaginas"] = pgsource.PageCount;
            //Ejemplo: "Página 1 al 10"
            lblpagina.Text = "Página " + (paginaActual + 1) + " de " + pgsource.PageCount + " (" + dt.Count + " - elementos)";
            //Habilitar los botones primero, último, anterior y siguiente
            lbAnterior.Enabled = !pgsource.IsFirstPage;
            lbSiguiente.Enabled = !pgsource.IsLastPage;
            lbPrimero.Enabled = !pgsource.IsFirstPage;
            lbUltimo.Enabled = !pgsource.IsLastPage;

            rpTarea.DataSource = pgsource;
            rpTarea.DataBind();

            //metodo que realiza la paginacion
            Paginacion();
        }

        /// <summary>
        /// Adrian Serrano
        /// 29/5/2019
        /// Efecto: realiza la paginacion
        /// Requiere: -
        /// Modifica: paginacion mostrada en pantalla
        /// Devuelve: -
        /// </summary>
        private void Paginacion()
        {
            var dt = new DataTable();
            dt.Columns.Add("IndexPagina"); //Inicia en 0
            dt.Columns.Add("PaginaText"); //Inicia en 1

            primerIndex = paginaActual - 2;
            if (paginaActual > 2)
                ultimoIndex = paginaActual + 2;
            else
                ultimoIndex = 4;

            //se revisa que la ultima pagina sea menor que el total de paginas a mostrar, sino se resta para que muestre bien la paginacion
            if (ultimoIndex > Convert.ToInt32(ViewState["TotalPaginas"]))
            {
                ultimoIndex = Convert.ToInt32(ViewState["TotalPaginas"]);
                primerIndex = ultimoIndex - 4;
            }

            if (primerIndex < 0)
                primerIndex = 0;

            //se crea el numero de paginas basado en la primera y ultima pagina
            for (var i = primerIndex; i < ultimoIndex; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }

            rptPaginacion.DataSource = dt;
            rptPaginacion.DataBind();
        }

        /// <summary>
        /// Adrian Serrano
        /// 29/5/2019
        /// Efecto: se devuelve a la primera pagina y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Primer pagina"
        /// Modifica: elementos mostrados en la tabla de edificios
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            mostrarDatosTabla();
        }

        /// <summary>
        /// Adrian Serrano
        /// 29/5/2019
        /// Efecto: se devuelve a la ultima pagina y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Ultima pagina"
        /// Modifica: elementos mostrados en la tabla de edificios
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbUltimo_Click(object sender, EventArgs e)
        {
            paginaActual = (Convert.ToInt32(ViewState["TotalPaginas"]) - 1);
            mostrarDatosTabla();
        }

        /// <summary>
        /// Adrian Serrano
        /// 29/5/2019
        /// Efecto: se devuelve a la pagina anterior y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Anterior pagina"
        /// Modifica: elementos mostrados en la tabla de edificios
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbAnterior_Click(object sender, EventArgs e)
        {
            paginaActual -= 1;
            mostrarDatosTabla();
        }

        /// <summary>
        /// Adrian Serrano
        /// 29/5/2019
        /// Efecto: se devuelve a la pagina siguiente y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Siguiente pagina"
        /// Modifica: elementos mostrados en la tabla de edificios
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbSiguiente_Click(object sender, EventArgs e)
        {
            paginaActual += 1;
            mostrarDatosTabla();
        }

        /// <summary>
        /// Adrian Serrano
        /// 29/5/2019
        /// Efecto: actualiza la la pagina actual y muestra los datos de la misma
        /// Requiere: -
        /// Modifica: elementos de la tabla
        /// Devuelve: -
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("nuevaPagina")) return;
            paginaActual = Convert.ToInt32(e.CommandArgument.ToString());
            mostrarDatosTabla();
        }

        /// <summary>
        /// Adrian Serrano
        /// 29/5/2019
        /// Efecto: marca el boton de la pagina seleccionada
        /// Requiere: dar clic al boton de paginacion
        /// Modifica: color del boton seleccionado
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPagina = (LinkButton)e.Item.FindControl("lbPaginacion");
            if (lnkPagina.CommandArgument != paginaActual.ToString()) return;
            lnkPagina.Enabled = false;
            lnkPagina.BackColor = Color.FromName("#005da4");
            lnkPagina.ForeColor = Color.FromName("#FFFFFF");
        }


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
            String url = Page.ResolveUrl("~/Catalogos/Tareas/NuevaTarea.aspx");
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

            String url = Page.ResolveUrl("~/Catalogos/Tareas/EditarTarea.aspx");
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

            String url = Page.ResolveUrl("~/Catalogos/Tareas/EliminarTarea.aspx");
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

            String url = Page.ResolveUrl("~/Catalogos/Tareas/VerTarea.aspx");
            Response.Redirect(url);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            ViewState["descripcion"] = txtBuscarNombre.Text;
            mostrarDatosTabla();
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