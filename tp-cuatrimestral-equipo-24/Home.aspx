<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstiloHome.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-container">
        <h1>Bytes y Bocados</h1>
        <asp:Label ID="lblMensaje" runat="server" CssClass="asp-label"></asp:Label>
        <asp:Label ID="lblPuesto" runat="server" CssClass="asp-label"></asp:Label>
    </div>

</asp:Content>
