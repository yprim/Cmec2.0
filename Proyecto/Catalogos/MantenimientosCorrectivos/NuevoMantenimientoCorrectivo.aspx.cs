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
        EdificioServicios edificioServicios = new EdificioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtNumeroUbicacion.Attributes.Add("oninput", "validarTexto(this)");
                txtFechaMantenimiento.Attributes.Add("oninput", "validarTexto(this)");
                txtDescripcionMantenimiento.Attributes.Add("oninput", "validarTexto(this)");
                Activo activoMantenimiento = (Activo)Session["activoMantenimiento"];
                textPlacaActivo.Text = activoMantenimiento.Placa.ToString();
                CargarUbicacion();
                CargarResponsable();
                CargarTarea();
                CargarEdificios();
                accionesMantenimientoPreventivo();
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
                    ListItem item = new ListItem(ubicacion.edificio.nombre + " " + ubicacion.numeroAula.ToString(),ubicacion.idUbicacion.ToString());
                    UbicacionDDL.Items.Add(item);
                }
            }
        }

        private void CargarEdificios()
        {
            List<Edificio> edificios = new List<Edificio>();
            EdificiosDDL.Items.Clear();
            edificios = edificioServicios.getEdificios();

            if (edificios.Count > 0)
            {
                foreach (Edificio edificio in edificios)
                {
                    ListItem item = new ListItem(edificio.nombre, edificio.idEdificio.ToString());
                    EdificiosDDL.Items.Add(item);
                }
            }
        }



        private void CargarResponsable()
        {
            List<Responsable> responsables = new List<Responsable>();
            ResponsableDDL.Items.Clear();
            responsables = this.responsableServicios.getResponsables();

            if (responsables.Count > 0)
            {
                foreach (Responsable responsable in responsables)
                {
                    ListItem item = new ListItem(responsable.idResponsable.ToString()+" "+ responsable.nombre, responsable.idResponsable.ToString() );
                    ResponsableDDL.Items.Add(item);
                }
            }

        }

        private void CargarTarea()
        {
            List<Tarea> tareas = new List<Tarea>();
            TareasDDL.Items.Clear();
            tareas = this.tareaServicios.getTareas();

            if (tareas.Count > 0)
            {
                foreach (Tarea tarea in tareas)
                {
                    ListItem item = new ListItem(tarea.idTarea.ToString()+" "+ tarea.descripcion, tarea.idTarea.ToString() );
                    TareasDDL.Items.Add(item);
                }
            }

        }

        /// <summary>
        /// Steven Camacho Barboza
        /// 19/6/2019
        /// Metodo que verifica si se desea realizar un mantenimiento preventido o correctivo
        /// Recibe: Por medio de variable de session una cadena de texto que permite comprobar la procedencia de la solicitud.
        /// </summary>
        private void accionesMantenimientoPreventivo() {
            String procedencia = (String) Session["procedencia"];
            if (procedencia == "mantenimientoPreventivo")
            {
                divMensaje.Style.Add("display", "block");
                ListItem item;
                
                for (int i = 1; i < 7; i++)
                {
                    item = TareasDDL.Items.FindByValue(i+"");
                    item.Selected = true;
                }
            }
            else
                divMensaje.Style.Add("display", "none");

            Session["procedencia"] = "";
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

            #region validacion ubicacion

            if (UbicacionDDL.Items.Count == 0)
            {
                divUbicacionIncorrecto.Style.Add("display", "block");
                
                validados = false;
            }
            #endregion

            #region validacion Responsables

            if (ResponsableDDL.Items.Count == 0)
            {
                divResponsableIncorrecto.Style.Add("display", "block");

                validados = false;
            }

            #endregion


            #region validacion fecha

            String fechaMantenimiento = txtFechaMantenimiento.Text;
            if (fechaMantenimiento.Trim() == "")
            {
                divFechaIncorrecto.Style.Add("display", "block");

                validados = false;
            }

            #endregion

            #region validacion descripcion

            String descripcion = txtDescripcionMantenimiento.Text;
            if (descripcion.Trim() == "")
            {
                divDescripcionMantenimientoIncorrecto.Style.Add("display", "block");

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
                MantenimientoCorrectivo mantenimiento = new MantenimientoCorrectivo();

                mantenimiento.Fecha = txtFechaMantenimiento.Text;
                mantenimiento.Descripcion = txtDescripcionMantenimiento.Text;
                mantenimiento.Id_responsable = Convert.ToInt32(ResponsableDDL.SelectedValue);
                mantenimiento.Placa_activo = Convert.ToInt32(textPlacaActivo.Text);
                mantenimiento.Id_ubicacion = Convert.ToInt32(UbicacionDDL.SelectedValue);
                

                List<String> listaTareas = new List<String>();

                string selectedItems = String.Join(",",
                 TareasDDL.Items.OfType<ListItem>().Where(r => r.Selected)
                .Select(r => r.Value));

                String[] lista = selectedItems.Split(',');

                for (int c = 0; c <= lista.Length - 1; ++c)
                {
                    listaTareas.Add(lista[c]);
                }
                
                
                String url = "";

                               
                //Verificación que se hace para determinar si es preventivo o correctivo, así mismo determinar el valor y redirección
                //según corresponda.
                String procedencia = (String)Session["procedencia"];
                
                if (procedencia == "mantenimientoPreventivo")
                {
                    //VERIFICAR QUE SE GUARDE EL ATRIBUTO ES_CORRECTIVO=0 AL SE DE TIPO PREVENTIVO
                    url = Page.ResolveUrl("~/Catalogos/PlanMantenimientoPreventivo/PlanMantenimientoPreventivo.aspx");
                    mantenimiento.Es_correctivo = false;
                }
                else
                {
                    url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
                    mantenimiento.Es_correctivo = true;
                }
                mantenimientoServicios.insertarMantenimiento(mantenimiento, listaTareas);

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
            String procedencia = (String)Session["procedencia"];
            String url = "";
            if (procedencia == "mantenimientoPreventivo")
                url = Page.ResolveUrl("~/Catalogos/PlanMantenimientoPreventivo/PlanMantenimientoPreventivo.aspx");
            else
                url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
            Response.Redirect(url);
        }
        
       

        #endregion
    }
}