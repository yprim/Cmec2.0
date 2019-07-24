using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.PlanMantenimientoPreventivo
{
    public partial class MantenimietosAprobados : System.Web.UI.Page
    {


        #region variables globales
        MantenimientoCorrectivoServicio mantenimientoServicios;
        readonly PagedDataSource pgsource = new PagedDataSource();
        int primerIndex, ultimoIndex;
        private int elmentosMostrar = 10;
        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPermitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!Page.IsPostBack)
            {
                Session["listaAprobarMantenimientos"] = null;

                mantenimientoServicios = new MantenimientoCorrectivoServicio();

                List<MantenimientoCorrectivo> listaMantenimientos = new List<MantenimientoCorrectivo>();
                listaMantenimientos = mantenimientoServicios.getMantenimientosAprobados();

                Session["listaAprobarMantenimientos"] = listaMantenimientos;
                Session["listaAprobarMantenimientosFiltrada"] = listaMantenimientos;

                mostrarDatosTabla();
            }

        }
        #endregion

        #region logica
        /// <summary>
        /// Steven Camacho
        /// 29/05/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los Mantenimientos que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void mostrarDatosTabla()
        {
            List<MantenimientoCorrectivo> listaSession = (List<MantenimientoCorrectivo>)Session["listaAprobarMantenimientos"];
            String placa = "";
            String funcionario = "";
            String ubicacion = "";
            String fecha = "";
            String descripcion = "";

            if (ViewState["placa"] != null)
                placa = ViewState["placa"].ToString();

            if (ViewState["descripcion"] != null)
                descripcion = (String)ViewState["descripcion"];

            if (ViewState["fecha"] != null)
                fecha = (String)ViewState["fecha"];

            if (ViewState["ubicacion"] != null)
                ubicacion = (String)ViewState["ubicacion"];

            if (ViewState["responsable"] != null)
                funcionario = (String)ViewState["responsable"];

            List<MantenimientoCorrectivo> listaAprobarMantenimientos = (List<MantenimientoCorrectivo>)listaSession.Where(x => x.Descripcion.ToUpper().Contains(descripcion.ToUpper()) && x.Placa_activo.ToString().Contains(placa)
                                            && x.Id_ubicacion.ToString().ToUpper().Contains(ubicacion.ToUpper()) && x.Id_responsable.ToString().ToUpper().Contains(funcionario.ToUpper()) && x.Fecha.Contains(fecha)).ToList();

            Session["listaAprobarMantenimientosFiltrada"] = listaAprobarMantenimientos;


            //metodos que cambian los valores id(fk) por el correspondiente nombre de la tabla que pertenece ese id.
            //Estos cambios solo son para mostrar los valores en la tabla de la vista.
            //Reciben una lista y le cambian sus datos según corresponda.
            //devuelven la lista modificada, no obstante se sigue usando la lista por referencia de memoria.

            mantenimientoServicios.nombreResponsable(listaAprobarMantenimientos);
          //  mantenimientoServicios.nombreFuncionario(listaAprobarMantenimientos);
            mantenimientoServicios.nombreUbicacion(listaAprobarMantenimientos);


            var dt = listaAprobarMantenimientos;

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

            rpMantenimiento.DataSource = pgsource;
            rpMantenimiento.DataBind();

            //metodo que realiza la paginacion
            Paginacion();

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

        /// <summary>
        /// Steven Camacho
        /// 29/5/2019
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

            List<MantenimientoCorrectivo> listaMantenimiento = (List<MantenimientoCorrectivo>)Session["listaAprobarMantenimientosFiltrada"];

            MantenimientoCorrectivo mantenimientoVer = new MantenimientoCorrectivo();

            foreach (MantenimientoCorrectivo mantenimiento in listaMantenimiento)
            {
                if (mantenimiento.Id_mantenimiento == id)
                {
                    mantenimientoVer = mantenimiento;
                    break;
                }
            }

            Session["mantenimientoVer"] = mantenimientoVer;
            Session["procedencia"] = "aprobados";

            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/VerMantenimientoCorrectivo.aspx");
            Response.Redirect(url);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            ViewState["placa"] = txtBuscarPlaca.Text;
            ViewState["descripcion"] = txtBuscarDescripcion.Text;
            ViewState["responsable"] = txtBuscarFuncionario.Text;
            ViewState["ubicacion"] = txtBuscarUbicacion.Text;
            ViewState["fecha"] = txtBuscarFecha.Text;

            mostrarDatosTabla();
        }
        #endregion

    }
}