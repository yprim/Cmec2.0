<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="VerFuncionario.aspx.cs" Inherits="Proyecto.Catalogos.Funcionarios.VerFuncionario" %>
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

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNombreFuncionario" runat="server" Text="Nombre: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtNombreFuncionario" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtApellidos" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblCorreo" runat="server" Text="Correo: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtCorreo" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtFechaNacimiento" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNumeroTelefonoUno" runat="server" Text="Numero Telefono : " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtNumeroTelefonoUno" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNumeroTelefonoDos" runat="server" Text="Numero Telefono Dos: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtNumeroTelefonoDos" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblOcupacion" runat="server" Text="Ocupacion: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  ID="txtOcupacion" runat="server" ReadOnly="true"></asp:Label>
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
