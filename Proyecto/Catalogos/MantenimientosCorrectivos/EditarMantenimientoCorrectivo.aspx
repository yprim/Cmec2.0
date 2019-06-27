<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditarMantenimientoCorrectivo.aspx.cs" Inherits="Proyecto.Catalogos.MantenimientosCorrectivos.EditarMantenimientoCorrectivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:ScriptManager ID="MainScriptManager" runat="server" EnableCdn="true"/>
<div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
                        <asp:Label ID="lblNuevoMantenimiento" runat="server" Text="Modificar Mantenimiento" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
            </div>
            <%-- fin titulo accion --%>
            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
                <center>
                    <div id="divMensaje" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                        <asp:Label ID="lblMensaje" runat="server" Font-Size="Medium" class="label alert-danger" Text="*** Mantenimiento de tipo Preventivo ***" ForeColor="Black"></asp:Label>
                        <hr />
                        <asp:Label ID="lblMensaje2" runat="server" Font-Size="Small" class="label alert-danger" Text="*** Se agregan las tareas predefinidas de mantenimiento preventivo ***" ForeColor="Red"></asp:Label>
                    </div>
                </center>
            </div>
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
                    <asp:Label ID="txtPlacaActivo" runat="server" Text="" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div id="div1" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblPlacaIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Fecha --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom: 4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFechaMantenimiento" runat="server" Text="Fecha <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox TextMode="Date" class="form-control" ID="txtFechaMantenimiento" runat="server"></asp:TextBox>
                </div>
                <div id="divFechaIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblFechaMantenimientoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Descripcion --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom: 4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblDescripcionMantenimiento" runat="server" Text="Descripcion <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtDescripcionMantenimiento" runat="server"></asp:TextBox>
                </div>
                <div id="divDescripcionMantenimientoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblDescripcionMantenimientoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

             <%-- campo Responsable --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom: 4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblResponsableMantenimiento" runat="server" Text="Responsable <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <button type="button" id="buttonAbrirResponsables" class="btn btn-default form-control" data-toggle="modal" data-target="#abrirResponsables">Buscar Responsables</button>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label ID="TxtResponsable" runat="server" Text="" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div id="divResponsableIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblResponsableIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Ubicacion --%>
            <div class="col-md-12 col-xs-12 col-sm-12 form-group" style="margin-bottom: 4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblUbicacion" runat="server" Text="Ubicacion <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <button type="button" id="buttonAbrirUbicaciones" class="btn btn-default form-control" data-toggle="modal" data-target="#abrirUbicaciones">Buscar Ubicaciones</button>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label ID="TxtUbicacion" runat="server" Text="" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div id="divUbicacionIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblUbicacionIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Funcionario --%>
            <div class="col-md-12 col-xs-12 col-sm-12 form-group" style="margin-bottom: 4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFuncionario" runat="server" Text="Funcionario <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <button type="button" id="buttonAbrirFuncionarios" class="btn btn-default form-control" data-toggle="modal" data-target="#abrirFuncionarios">Buscar Funcionarios</button>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label ID="TxtFuncionario" runat="server" Text="" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div id="div2" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblFuncionarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Tareas --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom: 4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblTareas" runat="server" Text="Tareas <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-6 col-xs-6 col-sm-6">
                    <asp:CheckBoxList ID="TareasDDL" RepeatColumns="2" CellSpacing="20" runat="server">
                    </asp:CheckBoxList>
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
            <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                <button type="button" id="buttonModalResp" class="btn btn-info" data-toggle="modal" data-target="#responsableModal">Nuevo Responsable</button>
                <button type="button" id="buttonModalUbicacion" class="btn btn-info" data-toggle="modal" data-target="#ubicacionModal">Nueva Ubicacion</button>
                <button type="button" id="buttonModalTarea" class="btn btn-info" data-toggle="modal" data-target="#tareaModal">Nueva Tarea</button>
            </div>
            <%-- fin botones --%>
        </div>
    </div>

     <%-- modal responsable --%>
    <div class="modal" id="responsableModal" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Nuevo Responsable</h4>
                </div>
                <div class="modal-body">
                    
                    <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-3 col-xs-3 col-sm-3">
                    <asp:Label ID="lblNombreResponsable" runat="server" Text="Nombre <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtNombreResponsable" runat="server"></asp:TextBox>
                </div>
                <div id="divNombreResponsableIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNombreResponsableIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
                <br />
            </div>
           
                <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-3 col-xs-3 col-sm-3">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtUsuarioResponsable" runat="server"></asp:TextBox>
                </div>
                <div id="divUsuarioResponsableIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblUsuarioResponsableIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary">Nuevo Responsable</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <%-- modal ubicacion --%>
    <div class="modal" id="ubicacionModal" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Nueva Ubicacion</h4>
                </div>
                <div class="modal-body">
                    
                <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-3 col-xs-3 col-sm-3">
                    <asp:Label ID="lblEdificioUbicacion" runat="server" Text="Edificio <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:DropDownList AutoPostBack="true" ID="EdificiosDDL" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                </div>
                <div id="divEdificioUbicacionIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblEdificioUbicacionIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-3 col-xs-3 col-sm-3">
                    <asp:Label ID="lblNumeroUbicacion" runat="server" Text="Oficina <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtNumeroUbicacion" runat="server"></asp:TextBox>
                </div>
                <div id="divNumeroUbicacionIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNumeroUbicacionIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div> 

                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary">Nueva Ubicacion</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <%-- modal tarea --%>
    <div class="modal" id="tareaModal" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Nueva Tarea</h4>
                </div>
                <div class="modal-body">
                    
                    <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-3 col-xs-3 col-sm-3">
                    <asp:Label ID="lblDescripcionTarea" runat="server" Text="Descripción <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtDescripcionTarea" runat="server"></asp:TextBox>
                </div>
                <div id="divDescripcionTareaIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblDescripcionTareaIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary">Nueva Tarea</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

     <%-- Buscar ubicacion --%>
    <div class="modal" id="abrirUbicaciones" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Ubicaciones</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="pnlUpdate" runat="server">
                        <ContentTemplate>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                <asp:TextBox ID="txtBuscarUbicacion" runat="server" CssClass="form-control chat-input" AutoPostBack="true" OnTextChanged="BuscarUbicacion_OnChanged" placeholder="Filtro de Ubicaciones"></asp:TextBox>
                            </div>
                            <br />
                            <div class="col-md-4 col-xs-4 col-sm-4">
                                <asp:DropDownList ID="UbicacionDDL" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="ButtonSeleccionarUbicacion" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="SeleccionarUbicacion_Click" />
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <%-- Buscar Placa --%>
    <div class="modal" id="abrirPlacas" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Activos</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                <asp:TextBox ID="txtBuscarPlacas" runat="server" CssClass="form-control chat-input" AutoPostBack="true" OnTextChanged="BuscarPlaca_OnChanged" placeholder="Filtro de Activos"></asp:TextBox>
                            </div>
                            <br />
                            <div class="col-md-4 col-xs-4 col-sm-4">
                                <asp:DropDownList ID="PlacasDDL" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="ButtonSeleccionarPlaca" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="SeleccionarPlaca_Click" />
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <%-- Buscar Responsable --%>
    <div class="modal" id="abrirResponsables" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Responsables</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                <asp:TextBox ID="txtBuscarResponsable" runat="server" CssClass="form-control chat-input" AutoPostBack="true" OnTextChanged="BuscarResponsable_OnChanged" placeholder="Filtro de Responsables"></asp:TextBox>
                            </div>
                            <br />
                            <div class="col-md-4 col-xs-4 col-sm-4">
                                <asp:DropDownList ID="ResponsableDDLSelect" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="ButtonSeleccionarResponsable" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="SeleccionarResponsable_Click" />
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <%-- Buscar Funcionario --%>
    <div class="modal" id="abrirFuncionarios" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Funcionarios</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                <asp:TextBox ID="TxtBuscarFuncionario" runat="server" CssClass="form-control chat-input" AutoPostBack="true" OnTextChanged="BuscarFuncionario_OnChanged" placeholder="Filtro de Funcionarios"></asp:TextBox>
                            </div>
                            <br />
                            <div class="col-md-4 col-xs-4 col-sm-4">
                                <asp:DropDownList ID="FuncionarioDDL" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button1" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="SeleccionarFuncionario_Click" />
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">

</script>

    <style>
        #buttonModalResp, #buttonModalTarea, #buttonModalUbicacion {
            margin-top: 10px;
        }
    </style>
</asp:Content>
