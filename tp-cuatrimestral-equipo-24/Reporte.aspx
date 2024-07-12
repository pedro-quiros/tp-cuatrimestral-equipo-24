<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Reportes1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estiloreportes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="title">Reportes</p>


    <div class="filtros">
        <asp:Label ID="LblTipo" runat="server" Text="Filtrar por:" CssClass="control-label"></asp:Label>
        <asp:DropDownList runat="server" ID="ddlReportesFiltro" CssClass="form-select"
            OnSelectedIndexChanged="ddlReportesFiltro_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="Hoy"></asp:ListItem>
            <asp:ListItem Text="Este mes"></asp:ListItem>
            <asp:ListItem Text="Este año"></asp:ListItem>
            <asp:ListItem Text="-"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="mt-auto d-flex justify-content-around">
        <asp:Button CssClass="btnEstandar btn btn-success" ID="btnMesa" runat="server" Text="Listar por Mesa" OnClick="btnMesa_Click" Visible="false" />
        <asp:Button CssClass="btnEstandar btn btn-success" ID="btnMesero" runat="server" Text="Listar por Mesero" OnClick="btnMesero_Click" Visible="false" />
    </div>

    <div class="title">
        <h2>RESEÑAS DEL RESTAURANTE </h2>
    </div>

    <div class="mt-auto d-flex justify-content-around">
        <asp:Button ID="txtReseña" runat="server" CssClass="btn btn-outline-primary" Text="Ver" OnClick="txtReseña_Click" />
    </div>
</asp:Content>
