using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos
{
    public partial class EditarTarea : System.Web.UI.Page
    {
        #region variables globales
        TareaServicios tareaServicios = new TareaServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                Tarea tarea = (Tarea)Session["tareaEditar"];
                txtDescripcionTarea.Text = tarea.descripcion;
                txtDescripcionTarea.Attributes.Add("oninput", "validarTexto(this)");
            }
        }

        #endregion

        #region logica


        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
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

            #region validacion descripcion tarea

            String DescripcionTarea = txtDescripcionTarea.Text;

            if (DescripcionTarea.Trim() == "")
            {
                txtDescripcionTarea.CssClass = "form-control alert-danger";
                divDescripcionTareaIncorrecto.Style.Add("display", "block");
                lblDescripcionTareaIncorrecto.Visible = true;

                validados = false;
            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtDescripcionTarea_Changed(object sender, EventArgs e)
        {
            txtDescripcionTarea.CssClass = "form-control";
            lblDescripcionTarea.Visible = false;
        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de actualizar
        ///valida que todos los campos se hayan ingresado correctamente y guarda los datos en la base de datos
        ///redireccion a la pantalla de Administracion de tareas
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
                Tarea tarea = (Tarea)Session["tareaEditar"];
                tarea.descripcion = txtDescripcionTarea.Text;

                tareaServicios.actualizarTarea(tarea);

                String url = Page.ResolveUrl("~/Catalogos/Tareas/AdministrarTarea.aspx");
                Response.Redirect(url);
            }


        }

        /// <summary>
        /// Priscilla Mena
        /// 5/6/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de tareas
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Tareas/AdministrarTarea.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}