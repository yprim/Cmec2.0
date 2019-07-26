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
                txtCedFuncionario.Text = funcionario.usuario;
                txtNombreFuncionario.Text = funcionario.nombre;
                txtApellidos.Text = funcionario.apellidos;
                txtCorreo.Text = funcionario.correo;
                txtFechaNacimiento.Text = funcionario.fecha_nacimiento.ToString();
                txtNumeroTelefonoUno.Text = funcionario.numero_telefono1;
                txtNumeroTelefonoDos.Text = funcionario.numero_telefono2;
                txtOcupacion.Text = funcionario.ocupacion;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Priscilla Mena
        /// 26/07/2019
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
            if (funcionario.habilitado == 1)
            {
                url = Page.ResolveUrl("~/Catalogos/Funcionarios/AdministrarFuncionario.aspx");


                Response.Redirect(url);
            }
        }

        #endregion
    }
}