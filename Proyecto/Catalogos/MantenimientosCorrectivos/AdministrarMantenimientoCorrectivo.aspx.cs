using System;
using Servicios;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace Proyecto.Catalogos.MantenimientosCorrectivos
{
    public partial class AdministrarMantenimientoCorrectivo : System.Web.UI.Page
    {
        #region variables globales
        MantenimientoCorrectivoServicio mantenimientoServicios = new MantenimientoCorrectivoServicio();
        ResponsableServicios responsableServicios = new ResponsableServicios();
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
                Session["listaMantenimientosCorrectivos"] = null;
                Session["procedencia"] = null;

                MantenimientoCorrectivoServicio mantenimientoServicios = new MantenimientoCorrectivoServicio();

                List<MantenimientoCorrectivo> listaMantenimientoCorrectivos = new List<MantenimientoCorrectivo>();
                listaMantenimientoCorrectivos = mantenimientoServicios.getMantenimientos();

                Session["listaMantenimientosCorrectivos"] = listaMantenimientoCorrectivos;
                Session["listaMantenimientosCorrectivosFiltrada"] = listaMantenimientoCorrectivos;

                mostrarDatosTabla();
            }
        }
        #endregion

        #region logica

        /// <summary>
        /// Leonardo Gomez
        /// 13/06/2019
        /// Efecto: carga los datos filtrados en la tabla de activos y realiza la paginacion correspondiente
        /// Requiere: -
        /// Modifica: los datos mostrados en pantalla
        /// Devuelve: -
        /// </summary>
        private void mostrarDatosTabla()
        {

            List<MantenimientoCorrectivo> listaSession = (List<MantenimientoCorrectivo>)Session["listaMantenimientosCorrectivos"];
            String id_mantenimiento = "";
            String fecha = "";
            String descripcion = "";
            String estado = "";
            String es_correctivo = "";
            String id_responsable = "";
            String placa_activo = "";
            String id_ubicacion = "";
            String id_funcionario = "";


            if (ViewState["id_mantenimiento"] != null)
                id_mantenimiento = ViewState["id_mantenimiento"].ToString();

            if (ViewState["fecha"] != null)
                fecha = (String)ViewState["fecha"];

            if (ViewState["descripcion"] != null)
                descripcion = (String)ViewState["descripcion"].ToString();

            if (ViewState["estado"] != null)
                 estado = (String)ViewState["estado"];

            if (ViewState["id_responsable"] != null) 
                id_responsable = (String)ViewState["id_responsable"].ToString();
            
            if (ViewState["es_correctivo"] != null)
            
            if (ViewState["placa_activo"] != null)
                placa_activo = (String)ViewState["placa_activo"];

            if (ViewState["id_ubicacion"] != null)
                id_ubicacion = (String)ViewState["id_ubicacion"];

            if (ViewState["id_funcionario"] != null)
                id_funcionario = (String)ViewState["id_funcionario"].ToString();

            List<MantenimientoCorrectivo> listaMantenimientosCorrectivos = (List<MantenimientoCorrectivo>)listaSession.Where( 
               x => x.Id_mantenimiento.ToString().Contains(id_mantenimiento) 
            && x.Fecha.ToString().Contains(fecha) 
            && x.Descripcion.ToString().Contains(descripcion) 
            && x.Estado.ToString().Contains(estado) 
            && x.Id_responsable.ToString().Contains(id_responsable) 
            && x.Es_correctivo.ToString().Contains(es_correctivo) 
            && x.Placa_activo.ToString().Contains(placa_activo)
            && x.Id_ubicacion.ToString().Contains(id_ubicacion)
            && x.Id_funcionario.ToString().Contains(id_funcionario)).ToList();

            Session["listaMantenimientosCorrectivosFiltrada"] = listaMantenimientosCorrectivos;

            //metodos que cambian los valores id(fk) por el correspondiente nombre de la tabla que pertenece ese id.
            //Estos cambios solo son para mostrar los valores en la tabla de la vista.
            //Reciben una lista y le cambian sus datos según corresponda.
            //devuelven la lista modificada, no obstante se sigue usando la lista por referencia de memoria.

            mantenimientoServicios.nombreResponsable(listaMantenimientosCorrectivos);
//mantenimientoServicios.nombreFuncionario(listaMantenimientosCorrectivos);
            mantenimientoServicios.nombreUbicacion(listaMantenimientosCorrectivos);

            var dt = listaMantenimientosCorrectivos;
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

            rpMantenimientoCorrectivo.DataSource = pgsource;
            rpMantenimientoCorrectivo.DataBind();

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
        /// Leonardo Gomez
        /// 13/06/2019
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
        /// Leonardo Gomez
        /// 13/06/2019
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
        /// Leonardo Gomez
        /// 13/06/2019
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
        /// Leonardo Gomez
        /// 13/06/2019
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
        /// Leonardo Gomez
        /// 13/06/2019
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
        /// Leonardo Gomez
        /// 13/06/2019
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
        /// 13/06/2019
        /// Metodo que redirecciona a la pantalla para registrar un nuevo mantenimiento correctivo
        /// Este se activa al hacer click en la botón nuevo activo
        /// </summary>
        protected void btn_Nuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Activos/AdministrarActivo.aspx");
            Response.Redirect(url);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idMantenimiento = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<MantenimientoCorrectivo> listaMantenimientosCorrectivos = (List<MantenimientoCorrectivo>)Session["listaMantenimientosCorrectivosFiltrada"];

            MantenimientoCorrectivo mantenimientoEditar = new MantenimientoCorrectivo();

            foreach (MantenimientoCorrectivo mantenimiento in listaMantenimientosCorrectivos)
            {
                if (mantenimiento.Id_mantenimiento == idMantenimiento)
                {
                    mantenimientoEditar = mantenimiento;
                    break;
                }
            }

            Session["mantenimientoEditar"] = mantenimientoEditar;

            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/EditarMantenimientoCorrectivo.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Leonardo Gomez
        /// 13/06/2019
        /// Metodo que redirecciona a la pantalla donde se elimina (inhabilita) un mantenimiento Correctivo
        /// se activa cuando se presiona el boton de Eliminar
        /// </summary>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMantenimiento = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<MantenimientoCorrectivo> listaMantenimientosCorrectivos = (List<MantenimientoCorrectivo>)Session["listaMantenimientosCorrectivosFiltrada"];

            MantenimientoCorrectivo mantenimientoCorrectivoEliminar = new MantenimientoCorrectivo();

            foreach (MantenimientoCorrectivo mantenimiento in listaMantenimientosCorrectivos)
            {
                if (mantenimiento.Id_mantenimiento == idMantenimiento)
                {
                    mantenimientoCorrectivoEliminar = mantenimiento;
                    break;
                }
            }

            Session["mantenimientoCorrectivoEliminar"] = mantenimientoCorrectivoEliminar;

            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/EliminarMantenimientoCorrectivo.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Leonardo Gomez
        /// 13/06/2019
        /// Efecto: redirrecciona a la pantalla de Ver
        /// Requiere: dar clic al boton de "Ver"
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idMantenimiento = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());
            
            List<MantenimientoCorrectivo> listaMantenimientosCorrectivos = (List<MantenimientoCorrectivo>)Session["listaMantenimientosCorrectivosFiltrada"];

            MantenimientoCorrectivo mantenimientoVer = new MantenimientoCorrectivo();

            foreach (MantenimientoCorrectivo mantenimiento in listaMantenimientosCorrectivos)
            {
                if (mantenimiento.Id_mantenimiento == idMantenimiento)
                {
                    mantenimientoVer = mantenimiento;
                    break;
                }
            }

            Session["mantenimientoVer"] = mantenimientoVer;

            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/VerMantenimientoCorrectivo.aspx");
            Response.Redirect(url);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            ViewState["Id_mantenimiento"] = txtBuscarIdMantenimiento.Text;
            ViewState["fecha"] = TextBuscarFecha.Text;
            ViewState["placa_activo"] = TextBuscarPlacaActivo.Text;
            ViewState["id_ubicacion"] = TextBuscarUbicacion.Text;

            mostrarDatosTabla();
        }
        #endregion
    }
}