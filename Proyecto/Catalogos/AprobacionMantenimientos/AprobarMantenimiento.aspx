﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AprobarMantenimiento.aspx.cs" Inherits="Proyecto.Catalogos.pendienteMover.AprobarMantenimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
    <div class="col-md-12 col-xs-12 col-sm-12">
        <center>
                <asp:Label ID="lblRestaurarTarea" runat="server" Text="Aprobación de mantenimiento Activo" Font-Size="Large" ForeColor="Black"></asp:Label>
        </center>
    </div>
            <%-- fin titulo accion --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- campos a llenar --%>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblDescripcionMantenimiento" runat="server" Text="Detalle de mantenimiento: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  ID="txtDescripcionMantenimiento" TextMode="multiline" Columns="50" Rows="10" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <%-- fin campos a llenar --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- botones --%>
            <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                <asp:Button ID="btnAprobar" runat="server" Text="Aprobar" CssClass="btn btn-primary" OnClick="btnAprobar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
            </div>
            <%-- fin botones --%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
