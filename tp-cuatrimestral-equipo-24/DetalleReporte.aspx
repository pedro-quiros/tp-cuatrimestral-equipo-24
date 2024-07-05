﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleReporte.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Mochiy+Pop+One&display=swap">
    <link href="EstilosModificar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detalle-articulo">
        <h1>DETALLE DEL REPORTE</h1>

        <div class="form-group">
            <asp:Label ID="lblPedidos" runat="server" Text="Cantidad Pedidos:" CssClass="control-label"></asp:Label>
            <asp:TextBox type="text" class="form-control" ID="txtPedidos" runat="server" ReadOnly="true"></asp:TextBox>
        </div>

<%--        <div class="form-group">
            <asp:Label ID="LblTipo" runat="server" Text="Tipo:" CssClass="control-label"></asp:Label>
            <asp:DropDownList class="form-select" runat="server" ID="ddlTipo" aria-label="Default select example" ReadOnly="true">
                <asp:ListItem Text="Desayuno/Merienda"></asp:ListItem>
                <asp:ListItem Text="Almuerzo/Cena"></asp:ListItem>
                <asp:ListItem Text="Postres"></asp:ListItem>
                <asp:ListItem Text="Bebidas"></asp:ListItem>
            </asp:DropDownList>
        </div>--%>

        <div class="form-group">
            <asp:Label ID="lblprecio" runat="server" Text="Precio: $" CssClass="control-label"></asp:Label>
            <asp:TextBox type="text" class="form-control" ID="txtPrecio" runat="server" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblMesa" runat="server" Text="Mesa:" CssClass="control-label"></asp:Label>
            <asp:TextBox type="text" class="form-control" ID="txtMesa" runat="server" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblMesero" runat="server" Text="Mesero:" CssClass="control-label"></asp:Label>
            <asp:TextBox type="text" class="form-control" ID="txtMesero" runat="server" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblReseña" runat="server" Text="Reseña:" CssClass="control-label"></asp:Label>
            <asp:TextBox type="text" class="form-control" ID="txtReseña" runat="server" ReadOnly="true"></asp:TextBox>
        </div>

    </div>

    <div class="mt-auto d-flex justify-content-around">
        <a href="Reporte.aspx" class="btnEstandar btn btn-primary btn-back">Volver</a>
        <%--    <asp:Button CssClass="btnEstandar btn btn-success" ID="btnModificarInsumo" runat="server" Text="Modificar" OnClick="btnModificarInsumo_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />
    <asp:Button CssClass="btnEstandar btn btn-success" ID="BajaAltaLogica" runat="server" Text="Inactivar" OnClick="BajaAltaLogica_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />--%>
    </div>

</asp:Content>
