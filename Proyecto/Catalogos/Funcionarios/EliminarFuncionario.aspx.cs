using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Funcionarios
{
    public partial class EliminarFuncionario : System.Web.UI.Page
    {
        #region variables globales
        FuncionarioServicios funcionarioServicios = new FuncionarioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Funcionario funcionario = (Funcionario)Session["funcionarioEliminar"];
                txtCedFuncionario.Text = funcionario.Ced;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Leonardo Gomez
        /// 5/10/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Funcionarios
        /// elimina el tarea de la base de datos
        // redireccion a la pantalla de Administracion de funcionarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = (Funcionario)Session["funcionarioEliminar"];

            try
            {
                funcionarioServicios.eliminarFuncionario(funcionario);
                String url = Page.ResolveUrl("~/Catalogos/Funcionarios/AdministrarFuncionario.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Leonardo Gomez
        /// 5/10/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de funcionarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Funcionarios/AdministrarFuncionario.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}