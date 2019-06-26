using Entidades;
using Microsoft.Reporting.WebForms;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Informes
{
    public partial class CierrePlanPreventivo : System.Web.UI.Page
    {


        ActivoPlanPreventivoServicios activoPlanPreventivoServicios = new ActivoPlanPreventivoServicios();



        protected void Page_Load(object sender, EventArgs e)
        {

            ReportViewer1.Reset();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("CierrePlanPreventivo.rdlc");

          
            List<ActivoPlanPreventivo> activoPlanPreventivos = activoPlanPreventivoServicios.obtenerTodo();

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", activoPlanPreventivos);

            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);

            ReportViewer1.DataBind();

            

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

           // String filtro = TextBox1.Text;

           // Label4.Text = filtro;

           // ReportViewer1.Reset();
           // ReportViewer1.ProcessingMode = ProcessingMode.Local;
           // ReportViewer1.LocalReport.ReportPath = Server.MapPath("CierrePlanPreventivo.rdlc");

           // List<Funcionario> funcionarios = new List<Funcionario>();

           //funcionarios = funcionarioServicios.getFuncionarios();


           // ReportDataSource reportDataSource = new ReportDataSource("DataSet1", funcionarios);
        
           // ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
    
           // ReportViewer1.DataBind();
        }
    }
}