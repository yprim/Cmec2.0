<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="VerMantenimientoCorrectivo.aspx.cs" Inherits="Proyecto.Catalogos.MantenimientosCorrectivos.VerMantenimientoCorrectivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
    <div class="col-md-12 col-xs-12 col-sm-12">
        <center>
                        <asp:Label ID="lblVerMantenimiento" runat="server" Text="Información del Mantenimiento" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
    </div>
            <%-- fin titulo accion --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- campos a llenar --%>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="LabelId" runat="server" Text="ID: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtId" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="LabelId_placa" runat="server" Text="ID Placa: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtId_placa" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="LabelResponsable" runat="server" Text="Responsable: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtResponsable" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="LabelFecha" runat="server" Text="Fecha: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtFecha" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="LabelUbicacion" runat="server" Text="Ubicacion: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtUbicacion" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblDescripcionMantenimiento" runat="server" Text="Descripción: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtDescripcionMantenimiento" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="LabelEstado" runat="server" Text="Estado: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtEstadoMantenimiento" runat="server" ReadOnly="true"></asp:Label>
                </div>

            </div>
            <%-- fin campos a llenar --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- botones --%>
            <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                <asp:Button ID="btnCancelar" runat="server" Text="Regresar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
            </div>
            <%-- fin botones --%>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
