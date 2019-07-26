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

namespace Proyecto.Catalogos.Funcionarios
{
    public partial class AdministrarFuncionario : System.Web.UI.Page
    {
        #region variables globales
        FuncionarioServicios funcionarioServicios = new FuncionarioServicios();
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
                Session["listaFuncionarios"] = null;

                FuncionarioServicios funcionarioServicios = new FuncionarioServicios();

                List<Funcionario> listaFuncionarios = new List<Funcionario>();
                listaFuncionarios = funcionarioServicios.getFuncionarios();

                Session["listaFuncionarios"] = listaFuncionarios;
                Session["listaFuncionariosFiltrada"] = listaFuncionarios;

                mostrarDatosTabla();
            }

        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena Monge
        //// 26/07/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los funcionarios que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>

        private void mostrarDatosTabla()
        {
            List<Funcionario> listaSession = (List<Funcionario>)Session["listaFuncionarios"];
            String usuario = "";
            String nombre = "";
            String apellidos = "";
       
            String correo = "";
            String numeroTelefono1 = "";
            String numeroTelefono2 = "";
            String ocupacion = "";
      

            if (ViewState["usuario"] != null)
                usuario = ViewState["usuario"].ToString();

            if (ViewState["nombre"] != null)
                nombre = (String)ViewState["nombre"];

            if (ViewState["apellidos"] != null)
            {
                apellidos = (String)ViewState["apellidos"];
            }
            if (ViewState["correo"] != null)
                correo = (String)ViewState["correo"];

            if (ViewState["numeroTelefono1"] != null)
                numeroTelefono1 = (String)ViewState["numeroTelefono1"];

            if (ViewState["numeroTelefono2"] != null)
                numeroTelefono2 = (String)ViewState["numeroTelefono2"];

            if (ViewState["ocupacion"] != null)
                ocupacion = (String)ViewState["ocupacion"];

     

            List<Funcionario> listaFuncionarios = (List<Funcionario>)listaSession.Where(x => x.usuario.ToUpper().Contains(usuario.ToUpper()) && x.nombre.ToString().Contains(nombre)
                                            && x.apellidos.ToUpper().Contains(apellidos.ToUpper())  && x.correo.Contains(correo)
                                            && x.numero_telefono1.Contains(numeroTelefono1.ToUpper()) && x.numero_telefono2.Contains(numeroTelefono2.ToUpper())
                                            && x.ocupacion.Contains(ocupacion.ToUpper()) ).ToList();
            Session["listaFuncionariosFiltrada"] = listaFuncionarios;

            var dt = listaFuncionarios;
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

            rpFuncionario.DataSource = pgsource;
            rpFuncionario.DataBind();

            //metodo que realiza la paginacion
            Paginacion();
        }
        #endregion

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
        /// Priscilla Mena Monge
        /// 26/07/2019
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
        /// Priscilla Mena Monge
        //// 26/07/2019
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
        /// Priscilla Mena Monge
        //// 26/07/2019
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
        /// Priscilla Mena Monge
        /// 26/07/2019
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
        /// Priscilla Mena Monge
        /// 26/07/2019
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
        /// Priscilla Mena Monge
        /// 26/07/2019
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

        #region eventos

        /// <summary>
        /// Priscilla Mena Monge
        /// 26/07/2019
        /// Metodo que redirecciona a la pantalla para registrar un nuevo funcionario
        /// Este se activa al hacer click en la botón nuevo activo
        /// </summary>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Funcionarios/NuevoFuncionario.aspx");
            Response.Redirect(url);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Funcionario> listaFuncionarios = (List<Funcionario>)Session["listaFuncionariosFiltrada"];

            Funcionario funcionarioEditar = new Funcionario();

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                if (funcionario.id == id)
                {
                    funcionarioEditar = funcionario;
                    break;
                }
            }

            Session["funcionarioEditar"] = funcionarioEditar;

            String url = Page.ResolveUrl("~/Catalogos/Funcionarios/EditarFuncionario.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 26/07/2019
        /// Metodo que redirecciona a la pantalla donde se elimina (inhabilita) un funcionario
        /// se activa cuando se presiona el boton de Eliminar
        /// </summary>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Funcionario> listaFuncionarios = (List<Funcionario>)Session["listaFuncionariosFiltrada"];

            Funcionario funcionarioEliminar = new Funcionario();

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                if (funcionario.id == id)
                {
                    funcionarioEliminar = funcionario;
                    break;
                }
            }

            Session["funcionarioEliminar"] = funcionarioEliminar;

            String url = Page.ResolveUrl("~/Catalogos/Funcionarios/EliminarFuncionario.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 26/07/2019
        /// Efecto: redirrecciona a la pantalla de Ver
        /// Requiere: dar clic al boton de "Ver"
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Funcionario> listaFuncionarios = (List<Funcionario>)Session["listaFuncionariosFiltrada"];

            Funcionario funcionarioVer = new Funcionario();

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                if (funcionario.id == id)
                {
                    funcionarioVer = funcionario;
                    break;
                }
            }

            Session["funcionarioVer"] = funcionarioVer;

            String url = Page.ResolveUrl("~/Catalogos/Funcionarios/VerFuncionario.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 26/07/2019
        /// Efecto: realiza el filtrado
        /// Requiere: 
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Button4_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            ViewState["usuario"] = txtBuscarUsuario.Text;
            ViewState["nombre"] = txtBuscarNombre.Text;
            ViewState["apellidos"] = txtBuscarApellidos.Text;
            ViewState["correo"] = txtBuscarCorreo.Text;

            mostrarDatosTabla();
        }
        #endregion
    }

}