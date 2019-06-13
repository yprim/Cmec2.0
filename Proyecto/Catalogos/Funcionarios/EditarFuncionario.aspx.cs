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
    public partial class EditarFuncionario : System.Web.UI.Page
    {
        #region variables globales
        FuncionarioServicios funcionarioServicios = new FuncionarioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
        /*
            if (!IsPostBack)
            {
                Funcionario funcionario = (Funcionario)Session["funcionarioEditar"];
                txtCedFuncionario.Text = funcionario.Usuario;
                txtCedFuncionario.Attributes.Add("oninput", "validarTexto(this)");
            }*/
        }

        #endregion

        #region logica


        /// <summary>
        /// Leonardo Gomez
        /// 5/10/2019
        /// Efecto:Metodo que valida los campos que debe ingresar el usuario
        /// devuelve true si todos los campos esta con datos correctos
        /// sino devuelve false y marcar lo campos para que el usuario vea cuales son los campos que se encuntran mal
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean validarCampos()
        {
            Boolean validados = true;

            #region validacion ced funcionario

            String cedFuncionario = txtCedFuncionario.Text;

            if (cedFuncionario.Trim() == "")
            {
                txtCedFuncionario.CssClass = "form-control alert-danger";
                divCedFuncionarioIncorrecto.Style.Add("display", "block");
                lblCedFuncionarioIncorrecto.Visible = true;

                validados = false;
            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Leonardo
        /// 5/10/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        
        protected void txtCedFuncionario_Changed(object sender, EventArgs e)
        {
            txtCedFuncionario.CssClass = "form-control";
            lblCedFuncionarioIncorrecto.Visible = false;
        }

        /// <summary>
        /// Leonardo Gomez
        /// 5/10/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de actualizar
        ///valida que todos los campos se hayan ingresado correctamente y guarda los datos en la base de datos
        ///redireccion a la pantalla de Administracion de funcionarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnActualiza_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de actualizar los datos en la base de datos
            if (validarCampos())
            {
                Funcionario funcionario = (Funcionario)Session["funcionarioEditar"];
                funcionario.Usuario = txtCedFuncionario.Text;
                funcionario.Nombre = TextBox2.Text;
                funcionario.Apellidos = TextBox3.Text;
                funcionario.Fecha_Nacimiento = TextBox4.Text;
                funcionario.Correo = TextBox5.Text;
                funcionario.Numero_Telefono1 = TextBox6.Text;
                funcionario.Numero_Telefono2 = TextBox7.Text;
                funcionario.Ocupacion = TextBox8.Text;

                funcionarioServicios.actualizarFuncionario(funcionario);

                String url = Page.ResolveUrl("~/Catalogos/Funcionarios/AdministrarFuncionario.aspx");
                Response.Redirect(url);
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