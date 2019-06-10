<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditarActivo.aspx.cs" Inherits="Proyecto.Catalogos.Activos.EditarActivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="divRedondo">
        <div class="row">

    <%-- titulo accion--%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
                        <asp:Label ID="lblEditarActivo" runat="server" Text="Editar Activo" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
            </div>
            <%-- fin titulo accion --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

    <%-- campos a llenar --%>
            <%-- campo placa --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblPlacaActivo" runat="server" Text="Placa <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  class="form-control " ID="textPlacaActivo"  runat="server"></asp:Label>                              
                </div>
            </div>
            <%-- campo serie --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblSerieActivo" runat="server" Text="Serie <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtSerieActivo" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divSerieActivoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblSerieActivoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <%-- campo modelo --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblModeloActivo" runat="server" Text="Modelo <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtModeloActivo" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divModeloActivoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblModeloActivoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <%-- campo descripcion --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblDescripcionActivo" runat="server" Text="Descripción <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtDescripcionActivo" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divDescripcionActivoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblDescripcionActivoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
             <%-- campo fechaCompra --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFechaCompra" runat="server" Text="Fecha de Compra <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">                    
                    <asp:Textbox class="form-control" id="txtFechaActivo" TextMode="Date"  placeholder="dd/mm/aaaa" runat="server"></asp:Textbox>
                </div>
                <div id="divFechaCompraActivoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblFechaCompraActivoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
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
            var SerieActivoIncorrecto = document.getElementById('<%= divSerieActivoIncorrecto.ClientID %>');
            var ModeloActivoIncorrecto = document.getElementById('<%= divModeloActivoIncorrecto.ClientID %>');
            var DescripcionActivoIncorrecto = document.getElementById('<%= divDescripcionActivoIncorrecto.ClientID %>');
            var FechaActivoIncorrecto = document.getElementById('<%= divFechaCompraActivoIncorrecto.ClientID %>');
            if (txtBox.value != "") {
                
                txtBox.className = "form-control";

                if (id == 'serie')
                    SerieActivoIncorrecto.style.display = 'none';
                if (id == 'modelo')
                    ModeloActivoIncorrecto.style.display = 'none';
                if (id == 'desc')
                    DescripcionActivoIncorrecto.style.display = 'none';
                if (id == 'fecha')
                    FechaActivoIncorrecto.style.display = 'none';
                
            } else {
                txtBox.className = "form-control alert-danger";

                if (id == 'serie')
                    SerieActivoIncorrecto.style.display = 'block';
                if (id == 'modelo')
                    ModeloActivoIncorrecto.style.display = 'block';
                if (id == 'desc')
                    DescripcionActivoIncorrecto.style.display = 'block';
                if (id == 'fecha')
                    FechaActivoIncorrecto.style.display = 'block';
            }
        }
    </script>

</asp:Content>
