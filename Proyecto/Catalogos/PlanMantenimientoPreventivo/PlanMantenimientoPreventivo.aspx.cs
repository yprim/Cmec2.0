using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.PlanMantenimientoPreventivo
{
    public partial class PlanMantenimientoPreventivo : System.Web.UI.Page
    {

        #region variables globales
        ActivoPlanPreventivoServicios planServicios;
        readonly PagedDataSource pgsource = new PagedDataSource();
        int primerIndex, ultimoIndex;
        private int elmentosMostrar = 10;
        #endregion

        #region page load

        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPermitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!Page.IsPostBack)
            {
                Session["listaPlan"] = null;

                planServicios = new ActivoPlanPreventivoServicios();

                List<ActivoPlanPreventivo> listaPlan;
                listaPlan = planServicios.obtenerTodo();


                Session["listaPlan"] = listaPlan;
                Session["listaPlanFiltrada"] = listaPlan;

                comprobarEstadoPlanMantenimiento();
                mostrarDatosTabla();
            }
        }
        #endregion

        #region logica

        /// <summary>
        /// Steven Camacho
        /// 11/06/2019
        /// Efecto: carga los datos filtrados en la tabla del plan de mantenimiento y realiza la paginacion correspondiente
        /// Requiere: -
        /// Modifica: los datos mostrados en pantalla
        /// Devuelve: -
        /// </summary>
        private void mostrarDatosTabla()
        {
           

            List<ActivoPlanPreventivo> listaSession = (List<ActivoPlanPreventivo>)Session["listaPlan"];
            String placa = "";
            String serie = "";
            String descripcion = "";
            String responsable = "";
            String edificio = "";
            String ubicacion = "";
            String mesPropuesto = "";


            if (ViewState["placa"] != null)
                placa = ViewState["placa"].ToString();

            if (ViewState["equipo"] != null)
                descripcion = (String)ViewState["equipo"];

            if (ViewState["mesPropuesto"] != null)
            {
                mesPropuesto = (String)ViewState["mesPropuesto"];
            }
            if (ViewState["responsable"] != null)
                responsable = (String)ViewState["responsable"];

            if (ViewState["edificio"] != null)
                edificio = (String)ViewState["edificio"];

            if (ViewState["ubicacion"] != null)
                ubicacion = (String)ViewState["ubicacion"];

            DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
            List<ActivoPlanPreventivo> listaPlan = (List<ActivoPlanPreventivo>)listaSession.Where(x => x.Equipo.ToUpper().Contains(descripcion.ToUpper()) && x.Placa.ToString().Contains(placa)
                                            && x.Responsable.ToUpper().Contains(responsable.ToUpper()) && formatoFecha.GetMonthName(x.MesPropuesto).Contains(mesPropuesto)
                                            && x.Edificio.Contains(edificio) && x.Ubicacion.Contains(ubicacion)).ToList();
            Session["listaPlanFiltrada"] = listaPlan;

            var dt = listaPlan;
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

            rpActivo.DataSource = pgsource;
            rpActivo.DataBind();

            //metodo que realiza la paginacion
            Paginacion();
            
        }//mostrarDatosTabla



        /// <summary>
        /// Steven Camacho
        /// 11/06/2019
        /// Efecto: realiza una comprobación, para determinar si existe algún plan de mantenimiento vigente.
        /// Requiere: -
        /// Modifica: hace visible un mensaje en el interfaz que indica que no hay un plan de manteniento activo.
        /// Devuelve: -
        /// </summary>
        private void comprobarEstadoPlanMantenimiento() {
            
            if (!planServicios.existePlanVigente()) { 
                divMensajeSinPlan.Style.Add("display", "block");
                ButtonGenerarPlan.Style.Add("display", "block");
            }
            else{
                divMensajeSinPlan.Style.Add("display", "none");
                ButtonGenerarPlan.Style.Add("display", "none");
            }
        }

        /// <summary>
        /// Leonardo Carrion
        /// 10/abr/2019
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

        /// <summary>
        /// Steven Camacho B
        /// 27/05/2019
        /// Efecto: se devuelve a la primera pagina y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Primer pagina"
        /// Modifica: elementos mostrados en la tabla de contactos
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
        /// Steven Camacho B
        /// 27/05/2019
        /// Efecto: se devuelve a la ultima pagina y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Ultima pagina"
        /// Modifica: elementos mostrados en la tabla de contactos
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
        /// Steven Camacho B
        /// 27/05/2019
        /// Efecto: se devuelve a la pagina anterior y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Anterior pagina"
        /// Modifica: elementos mostrados en la tabla de contactos
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
        /// Steven Camacho B
        /// 27/05/2019
        /// Efecto: se devuelve a la pagina siguiente y muestra los datos de la misma
        /// Requiere: dar clic al boton de "Siguiente pagina"
        /// Modifica: elementos mostrados en la tabla de contactos
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
        /// Steven Camacho B
        /// 27/05/2019
        /// Efecto: actualiza la pagina actual y muestra los datos de la misma
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
        /// Steven Camacho
        /// 27/05/2019
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

        #region eventos

        /*
         * Steven Camacho B
         * 27/06/2019
         * Metodo que redirecciona a la pantalla donde se realiza el mantenimiento preventivo de un activo
         * se activa cuando se presiona el boton de mantenimiento
         */
        protected void btnMantenimiento_Click(object sender, EventArgs e)
        {
            int idActivo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<ActivoPlanPreventivo> listaPlan = (List<ActivoPlanPreventivo>)Session["listaPlanFiltrada"];

            ActivoPlanPreventivo activoPlan = new ActivoPlanPreventivo();

            foreach (ActivoPlanPreventivo activo in listaPlan)
            {
                if (activo.Placa == idActivo)
                {
                    activoPlan = activo;
                    break;
                }
            }

            Session["activoMantenimiento"] = activoPlan;

            String url = Page.ResolveUrl("~/Catalogos/PlanMantenimientoPreventivo/MantenimientoPreventivoActivo.aspx");
            Response.Redirect(url);
        }
        /*
         * Steven Camacho B
         * 11/06/2019
         * Metodo que redirecciona a la pantalla donde se consulta el período a generar del plan de mantenimiento preventivo
         * se activa cuando se presiona el boton de generar plan
         */
        protected void btnGenerarPlan_Click(object sender, EventArgs e)
        {
            planServicios= new ActivoPlanPreventivoServicios();
            planServicios.generarPlanPreventivo();
            mostrarDatosTabla();
            Response.Redirect("~/Catalogos/PlanMantenimientoPreventivo/PlanMantenimientoPreventivo.aspx");
        }


            protected void Button4_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            ViewState["placa"] = txtBuscarPlaca.Text;
            ViewState["equipo"] = txtBuscarDescripcion.Text;
            ViewState["mesPropuesto"] = txtBuscarFecha.Text;
            ViewState["responsable"] = txtBuscarResponsable.Text;
            ViewState["edificio"] = txtBuscarEdificio.Text;
            ViewState["ubicacion"] = txtBuscarUbicacion.Text;


            mostrarDatosTabla();
        }
        #endregion

    }
}