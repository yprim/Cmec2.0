<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditarFuncionario.aspx.cs" Inherits="Proyecto.Catalogos.Funcionarios.EditarFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    <div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
                        <asp:Label ID="lblEditarFuncionario" runat="server" Text="Editar Funcionario" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
            </div>
            <%-- fin titulo accion --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- campos a llenar --%>
            <%-- campo identificacion --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFuncionario" runat="server" Text="Identificacion <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  class="form-control " ID="textIDFuncionario"  runat="server"></asp:Label>                              
                </div>
            </div>

            <%-- campo nombre --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNombreFuncionario" runat="server" Text="Nombre <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtNombreFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divNombreFuncionarioIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNombreFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

             <%-- campo apellido --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtApellidosFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divApellidosFuncionarioIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblApellidosFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

             <%-- campo usuario --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtUsuarioFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divUsuarioFuncionarioIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblUsuarioFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- fecha nacimiento --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox ID="txtFechaNacimiento" TextMode="Date" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divFechaNacimientoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblFechaNacimientoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

             <%-- campo correo --%>
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

            <%-- campo numero1 --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNumeroTelefonoUno" runat="server" Text="Numero Telefono <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtNumeroTelefonoUno" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divNumeroTelefonoUnoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNumeroTelefonoUnoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo numero2 --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNumeroTelefonoDos" runat="server" Text="Numero Telefono Dos <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtNumeroTelefonoDos" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divNumeroTelefonoDosIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNumeroTelefonoDosIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

             <%-- campo ocupacion--%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblOcupacion" runat="server" Text="Ocupacion <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtOcupacionFuncionario" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divOcupacionFuncionarioIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblOcupacionFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
<script type="text/javascript">
        /*
        Evalúa de manera inmediata los campos de texto que va ingresando el usuario.
        */

    function validarTexto(txtBox,id) {
        var lblNombreFuncionarioIncorrecto = document.getElementById('<%= divNombreFuncionarioIncorrecto.ClientID %>');
        var lblApellidosFuncionarioIncorrecto = document.getElementById('<%= divApellidosFuncionarioIncorrecto.ClientID %>');
        var lblFechaNacimientoIncorrecto = document.getElementById('<%= divFechaNacimientoIncorrecto.ClientID %>');
        var lblCorreoFuncionarioIncorrecto = document.getElementById('<%= divCorreoIncorrecto.ClientID %>');
        var Incorrecto = document.getElementById('<%= divUsuarioFuncionarioIncorrecto.ClientID %>');
        var lblNumeroTelefonoUnoIncorrecto = document.getElementById('<%= divNumeroTelefonoUnoIncorrecto.ClientID %>');
        var lblNumeroTelefonoDosIncorrecto = document.getElementById('<%= divNumeroTelefonoDosIncorrecto.ClientID %>');
        var lblOcupacionFuncionarioIncorrecto = document.getElementById('<%= divOcupacionFuncionarioIncorrecto.ClientID %>');


            if (txtBox.value != "") {
                
                txtBox.className = "form-control";

                if (id == 'nombre')
                    lblNombreFuncionarioIncorrecto.style.display = 'none';
                if (id == 'apellidos')
                    lblApellidosFuncionarioIncorrecto.style.display = 'none';
                if (id == 'usuario')
                    lblUsuarioFuncionarioIncorrecto.style.display = 'none';
                if (id == 'correo')
                    lblCorreoFuncionarioIncorrecto.style.display = 'none';
                if (id == 'fecha_nacimiento')
                    lblFechaNacimientoIncorrecto.style.display = 'none';
                if (id == 'numero_telefono_uno')
                    lblNumeroTelefonoUnoIncorrecto.style.display = 'none';
                if (id == 'numero_telefono_dos')
                    lblNumeroTelefonoDosIncorrecto.style.display = 'none';
                if (id == 'ocupacion')
                    lblOcupacionFuncionarioIncorrecto.style.display = 'none';
                
            } else {
                txtBox.className = "form-control alert-danger";

                if (id == 'nombre')
                    lblNombreFuncionarioIncorrecto.style.display = 'block';
                if (id == 'apellidos')
                    lblApellidosFuncionarioIncorrecto.style.display = 'block';
                if (id == 'usuario')
                    lblUsuarioFuncionarioIncorrecto.style.display = 'block';
                if (id == 'correo')
                    lblCorreoFuncionarioIncorrecto.style.display = 'none';
                if (id == 'fecha_nacimiento')
                    lblFechaNacimientoIncorrecto.style.display = 'block';
                if (id == 'numero_telefono_uno')
                    lblNumeroTelefonoUnoIncorrecto.style.display = 'block';
                if (id == 'numero_telefono_dos')
                    lblNumeroTelefonoDosIncorrecto.style.display = 'block';
                if (id == 'ocupacion')
                    lblOcupacionFuncionarioIncorrecto.style.display = 'block';
            }
        }
        
    </script>
</asp:Content>
