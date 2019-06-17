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
            if (!IsPostBack)
            {
                txtNombreFuncionario.Attributes.Add("oninput", "validarTexto(this,'nombre')");
                txtApellidosFuncionario.Attributes.Add("oninput", "validarTexto(this,'apellidos')");
                txtFechaNacimiento.Attributes.Add("oninput", "validarTexto(this,'fecha_nacimiento')");
                txtNumeroTelefonoUno.Attributes.Add("oninput", "validarTexto(this,'numero_telefono_uno')");
                txtNumeroTelefonoDos.Attributes.Add("oninput", "validarTexto(this,'numero_telefono_dos')");
                txtCorreoFuncionario.Attributes.Add("oninput", "validarTexto(this,'correo')");
                txtOcupacionFuncionario.Attributes.Add("oninput", "validarTexto(this,'ocupacion')");

                //cargar campos
                Funcionario funcionario = (Funcionario)Session["funcionarioEditar"];
                textIDFuncionario.Text = funcionario.Id.ToString();
                txtNombreFuncionario.Text = funcionario.Nombre;
                txtUsuarioFuncionario.Text = funcionario.Usuario;
                txtApellidosFuncionario.Text = funcionario.Apellidos;
                txtCorreoFuncionario.Text = funcionario.Correo;
                txtNumeroTelefonoUno.Text = funcionario.Numero_Telefono1;
                txtNumeroTelefonoDos.Text = funcionario.Numero_Telefono2;
                txtFechaNacimiento.Text = funcionario.Fecha_Nacimiento.ToString();
                txtOcupacionFuncionario.Text = funcionario.Ocupacion;
            }
        }

        #endregion

        #region logica

        /// <summary>
        /// Metodo que valida los campos que debe ingresar el usuario
        /// </summary>
        /// <returns>Devuelve true si todos los campos esta con datos correctos sino devuelve false
        /// y marcar lo campos para que el usuario vea cuales son los campos que se encuentran mal</returns>
        public Boolean validarCampos()
        {
            Boolean validados = true;

            #region validacion nombre funcionario
            String nombreFuncionario = txtNombreFuncionario.Text;

            if (nombreFuncionario.Trim() == "")
            {
                txtNombreFuncionario.CssClass = "form-control alert-danger";
                divNombreFuncionarioIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion apellidos funcionario
            String apellidosFuncionario = txtApellidosFuncionario.Text;

            if (apellidosFuncionario.Trim() == "")
            {
                txtApellidosFuncionario.CssClass = "form-control alert-danger";
                divApellidosFuncionarioIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion Usuario funcionario
            String usuarioFuncioanrio = txtUsuarioFuncionario.Text;

            if (usuarioFuncioanrio.Trim() == "")
            {
                txtUsuarioFuncionario.CssClass = "form-control alert-danger";
                divUsuarioFuncionarioIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion fecha nacimiento funcionario
            String fechaNacimiento = txtFechaNacimiento.Text;

            if (fechaNacimiento.Trim() == "")
            {
                txtFechaNacimiento.CssClass = "form-control alert-danger";
                divFechaNacimientoIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion correo funcionario
            String correoFuncionario = txtCorreoFuncionario.Text;

            if (correoFuncionario.Trim() == "")
            {
                txtCorreoFuncionario.CssClass = "form-control alert-danger";
                divCorreoIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion numero telefono dos funcionario
            String numeroTelefonoDosFuncionario = txtNumeroTelefonoDos.Text;

            if (numeroTelefonoDosFuncionario.Trim() == "")
            {
                txtNumeroTelefonoDos.CssClass = "form-control alert-danger";
                divNumeroTelefonoDosIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion numero telefono uno funcionario
            String numeroTelefonoUnoFuncionario = txtNumeroTelefonoUno.Text;

            if (numeroTelefonoUnoFuncionario.Trim() == "")
            {
                txtNumeroTelefonoUno.CssClass = "form-control alert-danger";
                divNumeroTelefonoUnoIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion
            #region validacion ocupacion uno funcionario
            String ocupacionFuncionario = txtOcupacionFuncionario.Text;

            if (ocupacionFuncionario.Trim() == "")
            {
                txtOcupacionFuncionario.CssClass = "form-control alert-danger";
                divOcupacionFuncionarioIncorrecto.Style.Add("display", "block");

                validados = false;
            }


            #endregion
            return validados;
        }

        #endregion

        #region eventos

        /// <summary>
        /// Metodo que se activa cuando se da click al boton de guardar
        /// valida que todos los campos se hayan ingrsado correctamente 
        /// y guarda los datos en la base de datos 
        /// redirecciona a la pantalla de administacion de funcionarios
        /// </summary>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de guardar los datos en la base de datos
            if (validarCampos())
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Id = Int32.Parse(textIDFuncionario.Text);
                funcionario.Nombre = txtNombreFuncionario.Text;
                funcionario.Apellidos = txtApellidosFuncionario.Text;
                funcionario.Usuario = txtUsuarioFuncionario.Text;
                funcionario.Fecha_Nacimiento = txtFechaNacimiento.Text;
                funcionario.Numero_Telefono1 = txtNumeroTelefonoUno.Text;
                funcionario.Numero_Telefono2 = txtNumeroTelefonoDos.Text;
                funcionario.Ocupacion = txtOcupacionFuncionario.Text;
             

                funcionarioServicios.actualizarFuncionario(funcionario);

                String url = Page.ResolveUrl("~/Catalogos/Funcionarios/AdministrarFuncionario.aspx");
                Response.Redirect(url);
            }
        }


        /// <summary>
        /// Metodo que se activa cuando se le da click al boton cancelar
        /// redirecciona a la pantalla de adminstracion de activos
        /// </summary>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Funcionarios/AdministrarFuncionario.aspx");
            Response.Redirect(url);
        }


        #endregion

    }
}