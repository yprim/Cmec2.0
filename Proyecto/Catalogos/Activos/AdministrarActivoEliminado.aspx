﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AdministrarActivoEliminado.aspx.cs" Inherits="Proyecto.Catalogos.Activos.AdministrarActivoEliminado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <asp:ScriptManager ID="MainScriptManager" runat="server" EnableCdn="true"/>
             <asp:UpdatePanel ID="pnlUpdate" runat="server">
                    <ContentTemplate>

                    <div class="row">

                        <%-- titulo pantalla --%>
                        <div class="col-md-12 col-xs-12 col-sm-12">
                            <center>
                            <asp:Label ID="label" runat="server" Text="Activos Eliminados" Font-Size="Large" ForeColor="Black"></asp:Label>
                        </center>
                        </div>
                        <%-- fin titulo pantalla --%>

                        <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                            <hr />
                        </div>

                        <%-- tabla--%>
        
                                <div class="col-md-12 col-xs-12 col-sm-12">
                                    <table class="table">
                                            <tr>
                                                <td>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                                        <asp:TextBox ID="txtBuscarPlaca" runat="server" CssClass="form-control chat-input"  AutoPostBack="true" OnTextChanged="Button4_Click"  placeholder="Filtro placa"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                                        <asp:TextBox ID="txtBuscarSerie" runat="server" CssClass="form-control chat-input" AutoPostBack="true"  OnTextChanged="Button4_Click" placeholder="Filtro serie"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                                        <asp:TextBox ID="txtBuscarModelo" runat="server" CssClass="form-control chat-input" AutoPostBack="true"  OnTextChanged="Button4_Click" placeholder="Filtro modelo"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                                        <asp:TextBox ID="txtBuscarDescripcion" runat="server" CssClass="form-control chat-input" AutoPostBack="true"  OnTextChanged="Button4_Click" placeholder="Filtro descripción"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-search"></i></span>
                                                        <asp:TextBox ID="txtBuscarFecha" runat="server" CssClass="form-control chat-input" AutoPostBack="true"  OnTextChanged="Button4_Click" placeholder="Filtro fecha compra"></asp:TextBox>
                                                    </div>
                                                </td>  
                                            </tr>
                                    </table>
                                </div>


                                <div class="table-responsive col-md-12 col-xs-12 col-sm-12" style="text-align: center; overflow-y: auto;">

                                    <asp:Repeater ID="rpActivo" runat="server" >
                                        <HeaderTemplate>
                                            <table class="table table-bordered">
                                                <thead style="text-align: center">
                                                    <tr style="text-align: center" class="btn-primary">
                                                        <th></th>
                                                        <th>Placa</th>
                                                        <th>Serie</th>
                                                        <th>Modelo</th>
                                                        <th>Descripción</th>
                                                        <th>Fecha Compra</th>                                       
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                            <tr style="text-align: center">
                                                <td>
                                                    <asp:LinkButton ID="btnVer" runat="server" ToolTip="Ver" OnClick="btnVer_Click" CommandArgument='<%# Eval("placa") %>'><span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>
                                                    <asp:LinkButton ID="btnRestaurar" runat="server" ToolTip="Restaurar" OnClick="btnRestaurar_Click" CommandArgument='<%# Eval("placa") %>'><span class="fas fa-trash-restore"></span></asp:LinkButton>
                               
                                                </td>
                                                <td>
                                                    <%# Eval("placa") %>
                                                </td>
                                                <td>
                                                    <%# Eval("serie") %>
                                                </td>
                                                <td>
                                                     <%# Eval("modelo") %>
                                                </td>
                                                <td>
                                                     <%# Eval("descripcion") %>
                                                </td>
                                                <td>
                                                     <%# Eval("fechaCompra") %>
                                                </td>
                                            </tr>

                                        </ItemTemplate>

                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>

                                <div class="col-md-12 col-xs-12 col-sm-12" style="text-align: center; overflow-y: auto;">
                                    <center>
                                    <table class="table" style="max-width:664px;">
                                        <tr style="padding:1px !important">
                                            <td style="padding:1px !important">
                                                <asp:LinkButton ID="lbPrimero" runat="server" CssClass="btn btn-primary" OnClick="lbPrimero_Click"><span class="glyphicon glyphicon-fast-backward"></span></asp:LinkButton>
                                                </td>
                                            <td style="padding:1px !important">
                                                <asp:LinkButton ID="lbAnterior" runat="server" CssClass="btn btn-default" OnClick="lbAnterior_Click"><span class="glyphicon glyphicon-backward"></asp:LinkButton>
                                            </td>
                                            <td style="padding:1px !important">
                                                <asp:DataList ID="rptPaginacion" runat="server"
                                                    OnItemCommand="rptPaginacion_ItemCommand"
                                                    OnItemDataBound="rptPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbPaginacion" runat="server" CssClass="btn btn-default"
                                                            CommandArgument='<%# Eval("IndexPagina") %>' CommandName="nuevaPagina"
                                                            Text='<%# Eval("PaginaText") %>' ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                            <td style="padding:1px !important">
                                                <asp:LinkButton ID="lbSiguiente" CssClass="btn btn-default" runat="server" OnClick="lbSiguiente_Click"><span class="glyphicon glyphicon-forward"></asp:LinkButton>
                                                </td>
                                            <td style="padding:1px !important">
                                                <asp:LinkButton ID="lbUltimo" CssClass="btn btn-primary" runat="server" OnClick="lbUltimo_Click"><span class="glyphicon glyphicon-fast-forward"></asp:LinkButton>
                                                </td>
                                            <td style="padding:1px !important">
                                                <asp:Label ID="lblpagina" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                        </center>
                                </div>

                                <%-- fin tabla--%>
            
                        <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                            <hr />
                        </div>

                        <%-- botones --%>
                        <div class="col-md-2 col-sm-2 col-xs-1 col-md-offset-9 col-xs-offset-0 col-sm-offset-8">
        
                        </div>
                        <%-- fin botones --%>
                    </div>


                </ContentTemplate>
        </asp:UpdatePanel>

    <!-- script tabla jquery -->
    <script type="text/javascript">
</script>
    <!-- fin script tabla jquery -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
