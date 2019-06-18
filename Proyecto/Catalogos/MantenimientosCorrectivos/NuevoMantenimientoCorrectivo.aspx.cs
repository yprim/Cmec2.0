using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Catalogos.MantenimientosCorrectivos
{
    public partial class NuevoMantenimientoCorrectivo : System.Web.UI.Page
    {
        #region variables globales
        MantenimientoCorrectivoServicio mantenimientoServicios = new MantenimientoCorrectivoServicio();
        TareaServicios tareaServicios = new TareaServicios();
        ActivoServicios activoServicios = new ActivoServicios();
        ResponsableServicios responsableServicios = new ResponsableServicios();
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtNumeroUbicacion.Attributes.Add("oninput", "validarTexto(this)");
                txtFechaMantenimiento.Attributes.Add("oninput", "validarTexto(this)");
                txtDescripcionMantenimiento.Attributes.Add("oninput", "validarTexto(this)");
               
                CargarUbicacion();
            }

        }

        #endregion


        #region logica
        private void CargarUbicacion()
        {
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            UbicacionDDL.Items.Clear();
            ubicaciones = this.ubicacionServicios.getUbicaciones();

            if (ubicaciones.Count > 0)
            {
                foreach (Ubicacion ubicacion in ubicaciones)
                {
                    ListItem item = new ListItem(ubicacion.idUbicacion.ToString(), ubicacion.edificio.nombre+" "+ubicacion.numeroAula.ToString());
                    UbicacionDDL.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Leonardo Gomez
        /// 6/17/2019
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

            if (UbicacionDDL.Items.Count == 0)
            {
                divFechaIncorrecto.Style.Add("display", "block");
                
                validados = false;
            }
            if (ResponsableDDL.Items.Count == 0)
            {
                divResponsableIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            if (PlacaActivoDDL.Items.Count == 0)
            {
                divPlacaIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            String fechaMantenimiento = txtFechaMantenimiento.Text;
            if (fechaMantenimiento.Trim() == "")
            {
                divFechaIncorrecto.Style.Add("display", "block");

                validados = false;
            }

            #endregion
                        
            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Leonardo Gomez
        /// 18/06/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtxDescripcionUbicacion_TextChanged(object sender, EventArgs e)
        {
            txtFechaMantenimiento.CssClass = "form-control";
            lblFechaMantenimientoIncorrecto.Visible = false;
        }


        /// <summary>
        /// Leonardo Gomez
        /// 18/06/2019
        /// Efecto:Metodo que se activa cuando se da click al boton de guardar
        /// valida que todos los campos se hayan ingrsado correctamente 
        /// y guarda los datos en la base de datos 
        /// redirecciona a la pantalla de administacion de mantenimientos
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
                Responsable responsable = new Responsable();
                /*responsable.numeroAula = txtNumeroUbicacion.Text;

                responsable.edificio = new Edificio();
                responsable.edificio.idEdificio = Convert.ToInt32(EdificiosDDL.SelectedValue);
                
                ResponsableServicios.(responsable);
                */
                String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
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
            String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}