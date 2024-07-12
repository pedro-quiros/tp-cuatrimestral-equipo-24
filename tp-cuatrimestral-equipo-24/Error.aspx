<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilo_Error.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-container">
        <h1>Error</h1>
        <p id="lblErrorMessage" runat="server">Lo sentimos, ha ocurrido un error. Por favor, intenta nuevamente más tarde.</p>
        <asp:Label ID="lblmenssaje" runat="server" Text="☠️☠️☠️"></asp:Label>
        <p><a href="Default.aspx">Volver a la página principal</a></p>
        <%--<asp:Button ID="Button1" runat="server" CssClass="Ingresar" Text="Loguearte" OnClick="txtvolver_Click" />--%>
    </div>
</asp:Content>
