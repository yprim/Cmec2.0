using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Entidades;

namespace Proyecto.Informes
{
    public partial class Prueba2 : System.Web.UI.Page
    {

        FuncionarioServicios funcionarioServicios = new FuncionarioServicios();
        TareaServicios tareaServicios = new TareaServicios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");

                
            }
        }


    }
}