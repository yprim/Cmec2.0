<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditarResponsable.aspx.cs" Inherits="Proyecto.Catalogos.Responsables.EditarResponsable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
                        <asp:Label ID="lblEditarResponsable" runat="server" Text="Editar Responsable" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
            </div>
            <%-- fin titulo accion --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- campos a llenar --%>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNombreResponsable" runat="server" Text="Nombre <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtNombreResponsable" runat="server"></asp:TextBox>
                </div>
                <div id="divNombreResponsableIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNombreResponsableIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>

            </div>
             <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtUsuarioResponsable" runat="server"></asp:TextBox>
                </div>
                <div id="divUsuarioResponsableIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblUsuarioResponsableIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
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
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualiza_Click" />
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
          function validarTexto(txtBox) {
             var id = txtBox.id.substring(12);

             var NombreResponsableIncorrecto = document.getElementById('<%= divNombreResponsableIncorrecto.ClientID %>');
             var UsuarioResponsableIncorrecto = document.getElementById('<%= divUsuarioResponsableIncorrecto.ClientID %>');

             if (txtBox.value != "") {
                 txtBox.className = "form-control";

                 NombreResponsableIncorrecto.style.display = 'none';
             } else {
                 txtBox.className = "form-control alert-danger";
                 NombreResponsableIncorrecto.style.display = 'block';
             }
             if (txtBox.value != "") {
                 txtBox.className = "form-control";

                 UsuarioResponsableIncorrecto.style.display = 'none';
             } else {
                 txtBox.className = "form-control alert-danger";
                 UsuarioResponsableIncorrecto.style.display = 'block';

             }
         }
    </script>
</asp:Content>
