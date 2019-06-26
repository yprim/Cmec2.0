using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Entidades;
using Servicios;

namespace Proyecto.Informes
{
    public partial class ReportePrueba : System.Web.UI.Page
    {

        FuncionarioServicios funcionarioServicios = new FuncionarioServicios();
        TareaServicios tareaServicios = new TareaServicios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("ReportePrueba.rdlc");

                List<Funcionario> funcionarios = funcionarioServicios.getFuncionarios();
                List<Tarea> tareas = tareaServicios.getTareas();

                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", funcionarios);
                ReportDataSource reportDataSourceTareas = new ReportDataSource("DataSet2",tareas);
                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.LocalReport.DataSources.Add(reportDataSourceTareas);
                ReportViewer1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("ReportePrueba.rdlc");

            List<Funcionario> funcionarios = new List<Funcionario>();
            List<Tarea> tareas = tareaServicios.getTareas();

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", funcionarios);
            ReportDataSource reportDataSourceTareas = new ReportDataSource("DataSet2", tareas);
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.LocalReport.DataSources.Add(reportDataSourceTareas);
            ReportViewer1.DataBind();
        }
    }
}