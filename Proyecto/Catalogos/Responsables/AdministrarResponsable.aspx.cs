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

namespace Proyecto.Catalogos.Responsables
{
    public partial class AdministrarResponsable : System.Web.UI.Page
    {
        #region variables globales
        ResponsableServicios responsableServicios = new ResponsableServicios();

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
                Session["listaResponsables"] = null;

                ResponsableServicios responsableServicios = new ResponsableServicios();

                List<Responsable> listaResponsables = new List<Responsable>();
                listaResponsables = responsableServicios.getResponsables();

                Session["listaResponsables"] = listaResponsables;
                Session["listaResponsablesFiltrada"] = listaResponsables;

                mostrarDatosTabla();
            }

        }

        #endregion
        #region logica
    


        #region prueba

        /// <summary>
        /// Priscilla Mena
        /// 29/5/2019
        /// Efecto: carga los datos filtrados en la tabla de Responsables y realiza la paginacion correspondiente
        /// Requiere: -
        /// Modifica: los datos mostrados en pantalla
        /// Devuelve: -
        /// </summary>
        private void mostrarDatosTabla()
        {

            List<Responsable> listaSession = (List<Responsable>)Session["listaResponsables"];
            String idResponsable = "";
            String nombre = "";
            String usuario = "";
            if (ViewState["idResponsable"] != null)
                idResponsable = (String)ViewState["idResponsable"];

            if (ViewState["nombre"] != null)
                nombre = (String)ViewState["nombre"];

            if (ViewState["usuario"] != null)
                usuario = (String)ViewState["usuario"];

            List<Responsable> listaResponsables = (List<Responsable>)listaSession.Where(x => x.nombre.ToUpper().Contains(nombre.ToUpper()) && x.usuario.ToUpper().Contains(usuario.ToUpper()) && x.idResponsable.ToString().Contains(idResponsable)).ToList();
            Session["listaResponsablesFiltrada"] = listaResponsables;

            var dt = listaResponsables;
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

            rpResponsable.DataSource = pgsource;
            rpResponsable.DataBind();

            //metodo que realiza la paginacion
            Paginacion();
        }

        /// <summary>
        /// Priscilla Mena
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
        /// Priscilla Mena
        /// 29/5/2019
        /// Efecto: se devuelve a la primera pagina y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Primer pagina"
        /// Modifica: elementos mostrados en la tabla de responsables
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
        /// Priscilla Mena
        /// 29/5/2019
        /// Efecto: se devuelve a la ultima pagina y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Ultima pagina"
        /// Modifica: elementos mostrados en la tabla de responsables
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
        /// Priscilla Mena
        /// 29/5/2019
        /// Efecto: se devuelve a la pagina anterior y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Anterior pagina"
        /// Modifica: elementos mostrados en la tabla de responsables
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
        /// Priscilla Mena
        /// 29/5/2019
        /// Efecto: se devuelve a la pagina siguiente y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Siguiente pagina"
        /// Modifica: elementos mostrados en la tabla de responsables
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
        /// Priscilla Mena
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
        /// Priscilla Mena
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

        #endregion

        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        ///5/29/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo responsable,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Responsables/NuevoResponsable.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        ///5/29/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un responsable,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idResponsable = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Entidades.Responsable> listaResponsables = (List<Entidades.Responsable>)Session["listaResponsables"];

            Entidades.Responsable responsableEditar = new Entidades.Responsable();

            foreach (Entidades.Responsable responsable in listaResponsables)
            {
                if (responsable.idResponsable == idResponsable)
                {
                    responsableEditar = responsable;
                    break;
                }
            }

            Session["responsableEditar"] = responsableEditar;

            String url = Page.ResolveUrl("~/Catalogos/Responsables/EditarResponsable.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        ///5/29/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un responsable,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idResponsable = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Entidades.Responsable> listaResponsables = (List<Entidades.Responsable>)Session["listaResponsables"];

            Entidades.Responsable responsableEliminar = new Entidades.Responsable();

            foreach (Entidades.Responsable responsable in listaResponsables)
            {
                if (responsable.idResponsable == idResponsable)
                {
                    responsableEliminar = responsable;
                    break;
                }
            }

            Session["responsableEliminar"] = responsableEliminar;

            String url = Page.ResolveUrl("~/Catalogos/Responsables/EliminarResponsable.aspx");
            Response.Redirect(url);

        }


        /// <summary>
        /// Priscilla Mena
        /// 5/29/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un responsable,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idResponsable = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Entidades.Responsable> listaResponsables = (List<Entidades.Responsable>)Session["listaResponsables"];

            Entidades.Responsable responsableVer = new Entidades.Responsable();

            foreach (Entidades.Responsable responsable in listaResponsables)
            {
                if (responsable.idResponsable == idResponsable)
                {
                    responsableVer = responsable;
                    break;
                }
            }

            Session["responsableVer"] = responsableVer;

            String url = Page.ResolveUrl("~/Catalogos/Responsables/VerResponsable.aspx");
            Response.Redirect(url);

        }

   


        protected void Button4_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            ViewState["nombre"] = txtBuscarNombre.Text;
            mostrarDatosTabla();
        }

        #endregion
    }
}