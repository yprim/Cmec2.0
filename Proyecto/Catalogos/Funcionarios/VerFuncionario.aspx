﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="VerFuncionario.aspx.cs" Inherits="Proyecto.Catalogos.Funcionarios.VerFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
    <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
    </div>
            <%-- fin titulo accion --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- campos a llenar --%>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblCedFuncionario" runat="server" Text="Usuario: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtCedFuncionario" runat="server" ReadOnly="true"></asp:Label>
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
