<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="NuevoFuncionario.aspx.cs" Inherits="Proyecto.Catalogos.Funcionarios.NuevoFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
                        <asp:Label ID="lblNuevoFuncionario" runat="server" Text="Nuevo Funcionario" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
            </div>
            <%-- fin titulo accion --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- campos a llenar --%>
            <%-- campo Nombre --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNombreFuncionario" runat="server" Text="Nombre <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtNombreFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divNombreIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNombreFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Apellidos --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblApellidosFuncionario" runat="server" Text="Apellidos <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtApellidosFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divApellidosIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblApellidosFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Usuario --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblUsuarioFuncionario" runat="server" Text="Usuario <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtUsuarioFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divUsuarioIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblUsuarioFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Fecha Nacimiento --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFechaNacimientoFuncionario" runat="server" Text="Fecha Nacimiento <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox TextMode="Date" class="form-control" ID="txtFechaNacimientoFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divFechaNacimientoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblFechaNacimientoFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Correo --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblCorreoFuncionario" runat="server" Text="Correo <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtCorreoFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divCorreoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblCorreoFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo num tel uno --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNumeroTelefonoUnoFuncionario" runat="server" Text="Numero Telefono Uno <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtNumeroTelefonoUnoFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divNumeroTelefonoUnoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNumeroTelefonoUnoFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo num tel dos --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNumeroTelefonoDosFuncionario" runat="server" Text="Numero Telefono Dos <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtNumeroTelefonoDosFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divNumeroTelefonoDosIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNumeroTelefonoDosFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo ocupacion --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblOcupacionFuncionario" runat="server" Text="Ocupacion <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtOcupacionFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divOcupacionIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblOcupacionIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>


            <div class="col-xs-12">
                <br />
                <div class="col-xs-12">
                    <h6 style="text-align: left">Los campos marcados con <span style='color: red'>*</span> son requeridos.</h6>
                </div>
            </div>

            <%-- fin campos a llenar --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- botones --%>
            <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
            </div>
            <%-- fin botones --%>
        </div>
    </div>

</asp:Content>

