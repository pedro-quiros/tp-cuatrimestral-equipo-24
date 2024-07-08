<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Reportes1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstilosTarjetas.css" rel="stylesheet" />
    <link href="EstilosFiltrar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="title">Reportes</p>

    <div>
        <asp:Label ID="LblTipo" runat="server" Text="Filtrar por:" CssClass="control-label"></asp:Label>
        <asp:DropDownList runat="server" ID="ddlReportesFiltro" class="form-select" aria-label="Default select example"
            OnSelectedIndexChanged="ddlReportesFiltro_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="Hoy"></asp:ListItem>
            <asp:ListItem Text="Este mes"></asp:ListItem>
            <asp:ListItem Text="Este año"></asp:ListItem>
            <asp:ListItem Text="-"></asp:ListItem>
        </asp:DropDownList>
    </div>


<%--    <section class="body-def">
        <div class="contenedor-card">
            <asp:Repeater runat="server" ID="idRep">
                <ItemTemplate>
                    <div class="card h-100 tarjeta-rest">
                        <div class="wrap-text_tarjeta-rest">
                            <h3><%# Eval("FechaHoraGenerado") %></h3>
                            <asp:CheckBox ID="CheckBoxActivo" runat="server" Enabled="false" Text="Activo" Checked='<%# Eval("Estado") %>' />

                            <div class="cta_tarjeta-rest">
                                <a href='<%# "DetalleReporte.aspx?IdPedido=" + Eval("IdPedido") %>'>Detalles</a>
                            </div>
                            <%--                        <div class="mt-auto d-flex justify-content-around">
                            <asp:Button CssClass="btn-primary" Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" CommandArgument='<%# Eval("IdInsumo") %>' CommandName="IdInsumo" />
                        </div>--%>
<%--                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </section>--%>--%>

</asp:Content>
