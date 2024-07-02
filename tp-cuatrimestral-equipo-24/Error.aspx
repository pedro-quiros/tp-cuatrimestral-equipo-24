<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hubo un Error</h1>
    <asp:Label ID="lblmenssaje" runat="server" Text="Label"></asp:Label>

    <div class="mb-3 row">
        <asp:Button ID="txtvolver" runat="server" CssClass="Ingresar" Text="Loguearte" OnClick="txtvolver_Click" />
    </div>
</asp:Content>
