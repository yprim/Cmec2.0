﻿using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Activos
{
    public partial class AdministrarActivo : System.Web.UI.Page
    {
        #region variables globales
        ActivoServicios activoServicios = new ActivoServicios();
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
                Session["listaActivos"] = null;
                Session["procedencia"]=null;

                ActivoServicios activoServicios = new ActivoServicios();

                List<Activo> listaActivos = new List<Activo>();
                listaActivos = activoServicios.obtenerTodo();

                Session["listaActivos"] = listaActivos;
                Session["listaActivosFiltrada"] = listaActivos;

                mostrarDatosTabla();
            }
        }
        #endregion

        #region logica

        /// <summary>
        /// Steven Camacho
        /// 27/abr/2019
        /// Efecto: carga los datos filtrados en la tabla de activos y realiza la paginacion correspondiente
        /// Requiere: -
        /// Modifica: los datos mostrados en pantalla
        /// Devuelve: -
        /// </summary>
        private void mostrarDatosTabla()
        {

            List<Activo> listaSession = (List<Activo>)Session["listaActivos"];
            String placa = "";
            String serie = "";
            String modelo = "";
            String fechaCompra =""; 
            String descripcion = "";


            if (ViewState["placa"] != null)
                placa = ViewState["placa"].ToString();

            if (ViewState["descripcion"] != null)
                descripcion = (String)ViewState["descripcion"];

            if (ViewState["fechaCompra"] != null) { 
                fechaCompra = (String)ViewState["fechaCompra"];
             }
            if (ViewState["serie"] != null)
                serie = (String)ViewState["serie"];

            if (ViewState["modelo"] != null)
                modelo = (String)ViewState["modelo"];

            List<Activo> listaActivos = (List<Activo>)listaSession.Where(x => x.Descripcion.ToUpper().Contains(descripcion.ToUpper()) && x.Placa.ToString().Contains(placa) 
                                            &&  x.Serie.ToUpper().Contains(serie.ToUpper()) && x.Modelo.ToUpper().Contains(modelo.ToUpper()) && x.FechaCompra.Contains(fechaCompra)).ToList();
            Session["listaActivosFiltrada"] = listaActivos;

            var dt = listaActivos;
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
        /// 27/5/2019
        /// Metodo que redirecciona a la pantalla para registrar un nuevo activo
        /// Este se activa al hacer click en la botón nuevo activo
        /// </summary>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Activos/NuevoActivo.aspx");
            Response.Redirect(url);
        }

        /*
         * Steven Camacho B
         * 27/06/2019
         * Metodo que redirecciona a la pantalla donde se edita un activo
         * se activa cuando se presiona el boton de Editar
         */
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idActivo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Activo> listaActivos = (List<Activo>)Session["listaActivosFiltrada"];

            Activo activoEditar = new Activo();

            foreach (Activo activo in listaActivos)
            {
                if (activo.Placa == idActivo)
                {
                    activoEditar = activo;
                    break;
                }
            }
            
            Session["activoEditar"] = activoEditar;

            String url = Page.ResolveUrl("~/Catalogos/Activos/EditarActivo.aspx");
            Response.Redirect(url);
        }

       /// <summary>
       /// Steven Camacho B
       /// 27/05/2019
       /// Metodo que redirecciona a la pantalla donde se elimina (inhabilita) un activo
       /// se activa cuando se presiona el boton de Eliminar
        /// </summary>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idActivo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Activo> listaActivos = (List<Activo>)Session["listaActivosFiltrada"];

            Activo activoEliminar = new Activo();

            foreach (Activo activo in listaActivos)
            {
                if (activo.Placa == idActivo)
                {
                    activoEliminar = activo;
                    break;
                }
            }

            Session["activoEliminar"] = activoEliminar;

            String url = Page.ResolveUrl("~/Catalogos/Activos/EliminarActivo.aspx");
            Response.Redirect(url);
        }

        protected void btnMantenimiento_Click(object sender, EventArgs e) {
            int idActivo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Activo> listaActivos = (List<Activo>)Session["listaActivosFiltrada"];

            Activo activoMantenimiento = new Activo();

            foreach (Activo activo in listaActivos)
            {
                if (activo.Placa == idActivo)
                {
                    activoMantenimiento = activo;
                    break;
                }
            }

            Session["activoMantenimiento"] = activoMantenimiento;

            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/NuevoMantenimientoCorrectivo.aspx");
            Response.Redirect(url);
        }
        /// <summary>
        /// Steven Camacho Barboza
        /// 27/05/2019
        /// Efecto: redirrecciona a la pantalla de Ver
        /// Requiere: dar clic al boton de "Ver"
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idActivo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Activo> listaActivos = (List<Activo>)Session["listaActivosFiltrada"];

            Activo activoVer = new Activo();

            foreach (Activo activo in listaActivos)
            {
                if (activo.Placa == idActivo)
                {
                    activoVer = activo;
                    break;
                }
            }

            Session["activoVer"] = activoVer;

            String url = Page.ResolveUrl("~/Catalogos/Activos/VerActivo.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Steven Camacho Barboza
        /// 27/05/2019
        /// Efecto: redirrecciona a la pantalla de activos eliminados
        /// Requiere: dar clic al boton de "Ver activos eliminados"
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerEliminados_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivoEliminado.aspx");
            Response.Redirect(url);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            ViewState["placa"] = txtBuscarPlaca.Text;
            ViewState["descripcion"] = txtBuscarDescripcion.Text;
            ViewState["serie"] = txtBuscarSerie.Text;
            ViewState["modelo"] = txtBuscarModelo.Text;
            ViewState["fechaCompra"] = txtBuscarFecha.Text;

            mostrarDatosTabla();
        }
        #endregion
    }
}