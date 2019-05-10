﻿using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos
{
    public partial class NuevaTarea : System.Web.UI.Page
    {
        #region variables globales
        FuncionarioServicios funcionarioServicios = new FuncionarioServicios();
        #endregion

        #region page
        protected void Page(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                txtCedFuncionario.Attributes.Add("oninput", "validarTexto(this)");
            }

        }

        #endregion


        #region logica


        /// <summary>
        /// Leonardo Gomez
        /// 05/10/2019
        /// Efecto:Metodo que valida los campos que debe ingresar el usuario
        /// devuelve true si todos los campos esta con datos correctos
        /// sino devuelve false y marcar lo campos para que el usuario vea cuales son los campos que se encuntran mal
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean validarCamposFuncionario()
        {
            Boolean validados = true;

            #region validacion ced funcionario

            String cedFuncionario = txtCedFuncionario.Text;

            if (cedFuncionario.Trim() == "")
            {
                txtCedFuncionario.CssClass = "form-control alert-danger";
                divCedFuncionarioIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Leonardo Gomez
        /// 05/10/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtxCedFuncionario_TextChanged(object sender, EventArgs e)
        {
            txtCedFuncionario.CssClass = "form-control";
            lblCedFuncionarioIncorrecto.Visible = false;
        }


        /// <summary>
        /// Leonado Gomez
        /// 05/10/2018
        /// Efecto:Metodo que se activa cuando se da click al boton de guardar
        /// valida que todos los campos se hayan ingrsado correctamente 
        /// y guarda los datos en la base de datos 
        /// redirecciona a la pantalla de administacion de funcionarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de guardar los datos en la base de datos
            if (validarCampos())
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Ced = txtCedFuncionario.Text;

                funcinarioServicios.insertarFuncionario(funcionario);

                String url = Page.ResolveUrl("~/Catalogos/Funcionarios/AdministrarFuncinario.aspx");
                Response.Redirect(url);
            }
        }


        /// <summary>
        /// Leonado Gomez
        /// 05/10/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de funcionario
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Funcionario/AdministrarFuncionario.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}