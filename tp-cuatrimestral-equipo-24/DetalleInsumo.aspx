<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleInsumo.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.ModificarInsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Mochiy+Pop+One&display=swap">
    <link href="EstilosModificar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detalle-articulo">
        <h1>MODIFICAR INSUMO</h1>

        <div class="form-group">
            <asp:Label ID="lblnombre" runat="server" Text="Nombre:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtNombre" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="LblTipo" runat="server" Text="Tipo:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtTipo" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblprecio" runat="server" Text="Precio: $" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtPrecio" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblStock" runat="server" Text="Stock:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtStock" runat="server" />
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblImagen" runat="server" Text="UrlImagen:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtImagen" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lbldescripcion" runat="server" Text="Descripcion:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtDescripcion" runat="server" />
        </div>

    </div>

    <div class="mt-auto d-flex justify-content-around">
        <a href="Menu.aspx" class="btnEstandar btn btn-primary btn-back">Volver</a>
        <asp:Button CssClass="btnEstandar btn btn-success" ID="btnModificarInsumo" runat="server" Text="Modificar" OnClick="btnModificarInsumo_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />
        <asp:Button CssClass="btnEstandar btn btn-success" ID="BajaAltaLogica" runat="server" Text="Inactivar" OnClick="BajaAltaLogica_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />
    </div>
</asp:Content>
