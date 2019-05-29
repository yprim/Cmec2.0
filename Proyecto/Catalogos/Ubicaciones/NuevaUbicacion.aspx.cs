using Servicios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.Ubicaciones
{
    public partial class NuevaUbicacion : System.Web.UI.Page
    {
        #region variables globales
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
        EdificioServicios edificioServicios = new EdificioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNumeroUbicacion.Attributes.Add("oninput", "validarTexto(this)");

                CargarEdificios();
            }

        }

        #endregion


        #region logica
        private void CargarEdificios()
        {
            List<Edificio> edificios = new List<Edificio>();
            EdificiosDDL.Items.Clear();
            edificios = this.edificioServicios.getEdificios();

            if (edificios.Count > 0)
            {
                foreach (Edificio edificio in edificios)
                {
                    ListItem item = new ListItem(edificio.nombre, edificio.idEdificio.ToString());
                    EdificiosDDL.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Adrian Serrano
        /// 5/29/2019
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

            #region validacion edificio ubicacion

            if (EdificiosDDL.Items.Count == 0)
            {
                divEdificioUbicacionIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion

            #region validacion descripcion ubicacion

            String descripcionUbicacion = txtNumeroUbicacion.Text;

            if (descripcionUbicacion.Trim() == "")
            {
                txtNumeroUbicacion.CssClass = "form-control alert-danger";
                divNumeroUbicacionIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Adrian Serrano
        /// 5/29/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtxDescripcionUbicacion_TextChanged(object sender, EventArgs e)
        {
            txtNumeroUbicacion.CssClass = "form-control";
            lblNumeroUbicacionIncorrecto.Visible = false;
        }


        /// <summary>
        /// Adrian Serrano
        /// 5/29/2019
        /// Efecto:Metodo que se activa cuando se da click al boton de guardar
        /// valida que todos los campos se hayan ingrsado correctamente 
        /// y guarda los datos en la base de datos 
        /// redirecciona a la pantalla de administacion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de guardar los datos en la base de datos
            if (validarCampos())
            {
                Ubicacion ubicacion = new Ubicacion();
                ubicacion.numeroAula = txtNumeroUbicacion.Text;

                ubicacion.edificio = new Edificio();
                ubicacion.edificio.idEdificio = Convert.ToInt32(EdificiosDDL.SelectedValue);

                ubicacionServicios.insertarUbicacion(ubicacion);

                String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/AdministrarUbicacion.aspx");
                Response.Redirect(url);
            }
        }


        /// <summary>
        /// Adrian Serrano
        /// 5/29/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/Ubicaciones/AdministrarUbicacion.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}