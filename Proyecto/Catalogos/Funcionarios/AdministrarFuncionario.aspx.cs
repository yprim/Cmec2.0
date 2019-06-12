using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
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

        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {


            Session["listaFuncionarios"] = null;
            Session["funcionarioEditar"] = null;
            Session["funcionarioEliminar"] = null;
            cargarDatosTblFuncionario();


        }
        #endregion

        #region logica
        /// <summary>
        /// Leonado Gomez
        /// 5/10/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los funcionarios que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblFuncionario()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            listaFuncionarios = funcionarioServicios.getFuncionarios();
            rpFuncionario.DataSource = listaFuncionarios;
            rpFuncionario.DataBind();

            Session["listaFuncionarios"] = listaFuncionarios;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Leonardo Gomez
        ///5/10/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo funcionario,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Funcionarios/NuevoFuncionario.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Leonardo Gomez
        ///5/10/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un funcionario,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int ced = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Funcionario> listaFuncionarios = (List<Funcionario>)Session["listaFuncionarios"];

            Funcionario funcionarioEditar = new Funcionario();

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                if (Convert.ToInt32(funcionario.Usuario) == ced)
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
        /// Leonardo Gomez
        ///5/10/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un funcionario,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int ced = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Funcionario> listaFuncionarios = (List<Funcionario>)Session["listaFuncionarios"];

            Funcionario funcionarioEliminar = new Funcionario();

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                if (Convert.ToInt32(funcionario.Usuario) == ced)
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
        /// Leonardo Gomez
        /// 5/10/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un Funcionario,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int ced = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Funcionario> listaFuncionarios = (List<Funcionario>)Session["listaFuncionarios"];

            Funcionario funcionarioVer = new Funcionario();

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                if (Convert.ToInt32(funcionario.Usuario) == ced)
                {
                    funcionarioVer = funcionario;
                    break;
                }
            }

            Session["funcionarioVer"] = funcionarioVer;

            String url = Page.ResolveUrl("~/Catalogos/Funcionaios/VerFuncionario.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Leonardo Gomez 
        /// 5/10/2019
        /// Efecto: habilita o desabilita los botones de editar y elminar segun el rol
        /// Requiere: -
        /// Modifica: visibilidad de botones
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpFuncionario_ItemDataBound(object sender, RepeaterItemEventArgs e)
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