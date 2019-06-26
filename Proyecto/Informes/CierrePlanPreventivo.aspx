<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CierrePlanPreventivo.aspx.cs" Inherits="Proyecto.Informes.CierrePlanPreventivo" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtDescripcionTarea" runat="server"></asp:TextBox>
                </div>

    <asp:Button ID="Button1" runat="server" Text="Filtrar" OnClick="Button1_Click"/>

      <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" ClientIDMode="AutoID" AsyncRendering="False" Width="100%" Height="100%" SizeToReportContent="True" BackColor="" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" style="margin-top: 0px">
        <LocalReport ReportPath="Informes\CierrePlanPreventivo.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>

