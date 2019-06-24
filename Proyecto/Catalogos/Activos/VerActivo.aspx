﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="VerActivo.aspx.cs" Inherits="Proyecto.Catalogos.Activos.VerActivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
    <div class="col-md-12 col-xs-12 col-sm-12">
        <center>
                        <asp:Label ID="lblVerActivo" runat="server" Text="Descripción de activo" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
    </div>
            <%-- fin titulo accion --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- campos a llenar --%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="Label1" runat="server" Text="Placa: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtPlacaActivo" runat="server" ReadOnly="true"></asp:Label>
                </div>
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="Label3" runat="server" Text="Serie: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtSerieActivo" runat="server" ReadOnly="true"></asp:Label>
                </div>
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblModeloActivo" runat="server" Text="Modelo: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtModeloActivo" runat="server" ReadOnly="true"></asp:Label>
                </div>
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="Label5" runat="server" Text="Equipo: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtDescripcionActivo" runat="server" ReadOnly="true"></asp:Label>
                </div>
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="Label7" runat="server" Text="Fecha de Compra: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtFechaCompraActivo" runat="server" ReadOnly="true"></asp:Label>
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
