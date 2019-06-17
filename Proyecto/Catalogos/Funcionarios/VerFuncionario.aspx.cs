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
    public partial class VerFuncionario : System.Web.UI.Page
    {
        #region variables globales
        FuncionarioServicios funcionarioServicios = new FuncionarioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Funcionario funcionario = (Funcionario)Session["funcionarioVer"];
                txtCedFuncionario.Text = funcionario.Usuario;
                txtNombreFuncionario.Text = funcionario.Nombre;
                txtApellidos.Text = funcionario.Apellidos;
                txtCorreo.Text = funcionario.Correo;
                txtFechaNacimiento.Text = funcionario.Fecha_Nacimiento;
                txtNumeroTelefonoUno.Text = funcionario.Numero_Telefono1;
                txtNumeroTelefonoDos.Text = funcionario.Numero_Telefono2;
                txtOcupacion.Text = funcionario.Ocupacion;

            }

        }
        #endregion

        #region eventos


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
            Funcionario funcionario = (Funcionario)Session["funcionarioVer"];
            String url;
            if (funcionario.Habilitado == 1)
            {
                url = Page.ResolveUrl("~/Catalogos/Funcionarios/AdministrarFuncionario.aspx");
            }
            else
            {
                url = Page.ResolveUrl("~/Catalogos/Funcionarios/AdministrarActivoFuncionario.aspx");
            }
            Response.Redirect(url);
        }

        #endregion
    }
}