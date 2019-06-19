<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="NuevoMantenimientoCorrectivo.aspx.cs" Inherits="Proyecto.Catalogos.MantenimientosCorrectivos.NuevoMantenimientoCorrectivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
                        <asp:Label ID="lblNuevoMantenimiento" runat="server" Text="Nuevo Mantenimiento" Font-Size="Large" ForeColor="Black"></asp:Label>
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
             <%-- campo Placa Activo --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblPlacaActivo" runat="server" Text="Placa <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:Label  class="form-control " ID="textPlacaActivo"  runat="server"></asp:Label>                              
                </div>
            </div>
            <%-- campo Fecha --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFechaMantenimiento" runat="server" Text="Fecha <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox TextMode="Date" class="form-control" ID="txtFechaMantenimiento" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divFechaIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblFechaMantenimientoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Descripcion --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblDescripcionMantenimiento" runat="server" Text="Descripcion <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox  class="form-control" ID="txtDescripcionMantenimiento" runat="server" ></asp:TextBox>                              
                </div>
                <div id="divDescripcionMantenimientoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblDescripcionMantenimientoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Responsable --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblResponsableMantenimiento" runat="server" Text="Responsable <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:DropDownList AutoPostBack="true" ID="ResponsableDDL" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                </div>
                <div id="divResponsableIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblResponsableIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <%-- campo Ubicacion --%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="margin-bottom:4px;">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblUbicacion" runat="server" Text="Ubicacion <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:DropDownList AutoPostBack="true" ID="UbicacionDDL" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                </div>
                <div id="divUbicacionIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblUbicacionIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%-- campo Tareas --%>

            <div class="col-md-4 col-xs-4 col-sm-4">
						<div class="panel panel-default">

							<div class="panel-body">
							
							<select	class="custom-select" id="id_tarea" multiple>
					<option>
                        <asp:DropDownList AutoPostBack="true" ID="TareaDDL" runat="server" CssClass="form-control">
                        </asp:DropDownList>
					</option>
				</select>
							
							</div>
						</div>
					</div>

					<div class="col-md-2 col-xs-4 col-sm-4">
						<button type="button" class="btn btn-primary" onclick="sacarDelArrayInicial()">Agregar</button>
						<button type="button" class="btn btn-primary" onclick="sacarDelArrayFinal()">Quitar</button>
					</div>

            <div class="col-md-4 col-xs-4 col-sm-4">
						<div class="panel panel-default">

							<div class="panel-body">
							
							<select	class="custom-select" id="listaF" multiple>
					<option>
					</option>
				</select>
							
							</div>
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
        function sacarDelArrayInicial(){
	var elemento = document.getElementById("id_tarea");
	var autor = elemento.options[elemento.selectedIndex];
	console.log(autor);
	
	var option = document.getElementById("listaF");
	option.add(autor);
	
}
function sacarDelArrayFinal(){
	var elemento = document.getElementById("listaF");
	var autor = elemento.options[elemento.selectedIndex];
	console.log(autor);
	
	var option = document.getElementById("idAutor");
	option.add(autor);
	
	
}
         </script>
</asp:Content>
