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
    public partial class EditarMantenimientoCorrectivo : System.Web.UI.Page
    {
        #region variables globales
        MantenimientoCorrectivoServicio mantenimientoServicios = new MantenimientoCorrectivoServicio();
        TareaServicios tareaServicios = new TareaServicios();
        ActivoServicios activoServicios = new ActivoServicios();
        ResponsableServicios responsableServicios = new ResponsableServicios();
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
        EdificioServicios edificioServicios = new EdificioServicios();
        FuncionarioServicios funcionarioServicios = new FuncionarioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //cargar Campos DateTime.Parse(activo.FechaCompra).ToString("yyyy-MM-dd");
                MantenimientoCorrectivo mantenimientoCorrectivo = (MantenimientoCorrectivo)Session["mantenimientoEditar"];
                txtFechaMantenimiento.Text = DateTime.Parse(mantenimientoCorrectivo.Fecha).ToString("yyyy-MM-dd");
                txtDescripcionMantenimiento.Text = mantenimientoCorrectivo.Descripcion;
                txtPlacaActivo.Text = mantenimientoCorrectivo.Placa_activo.ToString();
                bool es_correctivo = mantenimientoCorrectivo.Es_correctivo;
                if (!es_correctivo) Session["procedencia"] = "mantenimientoPreventivo";

                CargarUbicacion();
                CargarPlacas();
                CargarResponsable();
                CargarTarea();
                CargarEdificios();
                CargarFuncionario();
                accionesMantenimientoPreventivo();
            }
        }
        #endregion

        #region logica
        private void CargarUbicacion()
        {
            string nombreUbicacion = "";

            if (Session["nombreUbicacion"] != null)
            {
                nombreUbicacion = Session["nombreUbicacion"].ToString();
            }

            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            UbicacionDDL.Items.Clear();
            ubicaciones = this.ubicacionServicios.getUbicaciones();

            if (ubicaciones.Count > 0)
            {
                foreach (Ubicacion ubicacion in ubicaciones)
                {
                    if ((ubicacion.edificio.nombre != null && ubicacion.edificio.nombre.ToUpper().Contains(nombreUbicacion.ToUpper()))
                        || (ubicacion.numeroAula != null && ubicacion.numeroAula.ToString().ToUpper().Contains(nombreUbicacion.ToUpper())))
                    {
                        ListItem item = new ListItem(ubicacion.edificio.nombre + " " + ubicacion.numeroAula.ToString(), ubicacion.idUbicacion.ToString());
                        UbicacionDDL.Items.Add(item);
                    }
                }
            }
        }

        private void CargarPlacas()
        {
            string nombrePlaca = "";

            if (Session["nombrePlaca"] != null)
            {
                nombrePlaca = Session["nombrePlaca"].ToString();
            }

            List<Activo> activos = new List<Activo>();
            PlacasDDL.Items.Clear();
            activos = this.activoServicios.obtenerTodo();

            if (activos.Count > 0)
            {
                foreach (Activo activo in activos)
                {
                    if (activo.Placa.ToString() != null && activo.Placa.ToString().ToUpper().Contains(activo.Placa.ToString().ToUpper())
                        || activo.Modelo != null && activo.Modelo.ToUpper().Contains(activo.Modelo.ToUpper()))
                    {
                        ListItem item = new ListItem(activo.Placa + " " + activo.Modelo.ToString(), activo.Placa.ToString());
                        PlacasDDL.Items.Add(item);
                    }

                }
            }
        }

        private void CargarFuncionario()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            FuncionarioDDL.Items.Clear();
            funcionarios = this.funcionarioServicios.getFuncionarios();

            if (funcionarios.Count > 0)
            {
                foreach (Funcionario funcionario in funcionarios)
                {
                    ListItem item = new ListItem(funcionario.Nombre + " " + funcionario.Apellidos, funcionario.Id.ToString());
                    FuncionarioDDL.Items.Add(item);
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

        private void CargarActivo()
        {
            List<Activo> activos = new List<Activo>();
            PlacasDDL.Items.Clear();
            activos = this.activoServicios.obtenerTodo();

            if (activos.Count > 0)
            {
                foreach (Activo activo in activos)
                {
                    ListItem item = new ListItem(activo.Placa.ToString() + " " + activo.Modelo + " " + activo.Serie, activo.Placa.ToString());
                    PlacasDDL.Items.Add(item);
                }
            }
        }

        private void CargarResponsable()
        {
            List<Responsable> responsables = new List<Responsable>();
            ResponsableDDLSelect.Items.Clear();
            responsables = this.responsableServicios.getResponsables();

            if (responsables.Count > 0)
            {
                foreach (Responsable responsable in responsables)
                {
                    ListItem item = new ListItem(responsable.nombre, responsable.idResponsable.ToString());
                    ResponsableDDLSelect.Items.Add(item);
                }
            }

        }

        private void CargarTarea()
        {
            List<Tarea> tareas = new List<Tarea>();
            TareasDDL.Items.Clear();
            tareas = this.tareaServicios.getTareas();
            String procedencia = (String)Session["procedencia"];
            

                if (tareas.Count > 0)
            {
                foreach (Tarea tarea in tareas)
                {
                    ListItem item = new ListItem(tarea.descripcion, tarea.idTarea.ToString());
                    if (procedencia == "mantenimientoPreventivo")
                    {
                        TareasDDL.Items.Add(item);
                        if (tarea.idTarea <= 6)//estas tareas se prohibe poder no agregarlas cuando es preventivo, porque son para los mantenimientos
                        {
                            TareasDDL.Items.FindByValue(tarea.idTarea + "").Enabled = false;
                        }
                    }
                    else
                    {
                        if (tarea.idTarea > 6)//en caso de ser correctivo solo carga las tareas que no son de correctivos
                        {
                            TareasDDL.Items.Add(item);
                        }
                    }

                }
            }

        }

        /// <summary>
        /// Steven Camacho Barboza
        /// 19/6/2019
        /// Metodo que verifica si se desea realizar un mantenimiento preventido o correctivo
        /// Recibe: Por medio de variable de session una cadena de texto que permite comprobar la procedencia de la solicitud.
        /// </summary>
        private void accionesMantenimientoPreventivo()
        {
            String procedencia = (String)Session["procedencia"];
            if (procedencia == "mantenimientoPreventivo")
            {
                divMensaje.Style.Add("display", "block");
            }
            else
                divMensaje.Style.Add("display", "none");
        }

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

            if (ResponsableDDLSelect.Items.Count == 0)
            {
                divResponsableIncorrecto.Style.Add("display", "block");

                validados = false;
            }

            #endregion

            #region validacion activo

            if (PlacasDDL.Items.Count == 0)
            {
                lblPlacaIncorrecto.Style.Add("display", "block");

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

            #region

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
            
            MantenimientoCorrectivo mantenimiento = new MantenimientoCorrectivo();

            mantenimiento.Fecha = txtFechaMantenimiento.Text;
            mantenimiento.Descripcion = txtDescripcionMantenimiento.Text;
            mantenimiento.Id_responsable = txtBuscarResponsable.Text;
            mantenimiento.Placa_activo = Convert.ToInt32(txtPlacaActivo.Text.ToString());
            mantenimiento.Id_ubicacion = txtBuscarUbicacion.Text.ToString();
            mantenimiento.Id_funcionario = TxtBuscarFuncionario.Text;

            List<String> listaTareas = new List<String>();

                string selectedItems = String.Join(",",
                 TareasDDL.Items.OfType<ListItem>().Where(r => r.Selected)
                .Select(r => r.Value));

                String[] lista = selectedItems.Split(',');

                for (int c = 0; c <= lista.Length - 1; ++c)
                {
                    listaTareas.Add(lista[c]);
                }

                String url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");

                // ResponsableServicios.(responsable);

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
            mantenimientoServicios.actualizarMantenimiento(mantenimiento, listaTareas);

            Response.Redirect(url);
            
        }

        /// <summary>
        /// Leonardo Gomez
        /// 19/06/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Mantenimientos
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
                url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
            else
                url = Page.ResolveUrl("~/Catalogos/MantenimientosCorrectivos/AdministrarMantenimientoCorrectivo.aspx");
            Response.Redirect(url);
        }

        protected void SeleccionarUbicacion_Click(object sender, EventArgs e)
        {
            if (!UbicacionDDL.SelectedValue.Equals(""))
            {
                TxtUbicacion.Text = UbicacionDDL.SelectedItem.Text;
                txtBuscarUbicacion.Text = UbicacionDDL.SelectedItem.Value;
            }
            else
            {
                TxtUbicacion.Text = "";
            }
        }

        protected void BuscarUbicacion_OnChanged(object sender, EventArgs e)
        {
            Session["nombreUbicacion"] = txtBuscarUbicacion.Text;

            CargarUbicacion();
        }

        protected void SeleccionarPlaca_Click(object sender, EventArgs e)
        {
            if (!PlacasDDL.SelectedValue.Equals(""))
            {
                txtPlacaActivo.Text = PlacasDDL.SelectedItem.Text;
                txtBuscarPlacas.Text = PlacasDDL.SelectedItem.Value;
            }
            else
            {
                txtPlacaActivo.Text = "";
            }
        }

        protected void BuscarPlaca_OnChanged(object sender, EventArgs e)
        {
            Session["nombrePlaca"] = txtBuscarPlacas.Text;

            CargarPlacas();
        }

        protected void SeleccionarResponsable_Click(object sender, EventArgs e)
        {
            if (!ResponsableDDLSelect.SelectedValue.Equals(""))
            {
                TxtResponsable.Text = ResponsableDDLSelect.SelectedItem.Text;
                txtBuscarResponsable.Text = ResponsableDDLSelect.SelectedItem.Value;
            }
            else
            {
                TxtResponsable.Text = "";
            }
        }

        protected void BuscarResponsable_OnChanged(object sender, EventArgs e)
        {
            Session["nombreResponsable"] = txtBuscarResponsable.Text;

            CargarResponsable();
        }

        protected void SeleccionarFuncionario_Click(object sender, EventArgs e)
        {
            if (!FuncionarioDDL.SelectedValue.Equals(""))
            {
                TxtFuncionario.Text = FuncionarioDDL.SelectedItem.Text;
                TxtBuscarFuncionario.Text = FuncionarioDDL.SelectedItem.Value;
            }
            else
            {
                TxtFuncionario.Text = "";
            }
        }

        protected void BuscarFuncionario_OnChanged(object sender, EventArgs e)
        {
            Session["nombreFuncionario"] = TxtBuscarFuncionario.Text;

            CargarFuncionario();
        }


        #endregion

    }

}