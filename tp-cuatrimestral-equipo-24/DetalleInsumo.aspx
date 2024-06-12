<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleInsumo.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.DetalleInsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Mochiy+Pop+One&display=swap">
    <link href="EstilosDetalle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detalle-articulo">
        <h1>DETALLE ARTICULO</h1>

        <div class="form-group">
            <asp:Label ID="lblnombre" runat="server" Text="Nombre:" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lbldescripcion" runat="server" Text="Descripcion:" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblprecio" runat="server" Text="Precio: $" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="Lblmarca" runat="server" Text="Marca:" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtmarca" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblcategoria" runat="server" Text="Categoria:" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

            <div class="imagen-container">
                <asp:Repeater runat="server" ID="repDetalle">
                    <ItemTemplate>
                        <div class="cardImg h-100">
                            <img src='<%# Container.DataItem %>' alt="Imagen" class="img-fluid mt-1" onerror="this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSt4xXXEwlOngpYGhvok77NVHkRONev9pOY_XHZ3M29aA&s';" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

    </div>

    <div class="mt-auto d-flex justify-content-around">
        <a href="Menu.aspx" class="btnEstandar btn btn-primary btn-back">Volver</a>
        <a href="Modificar.aspx" class="btnEstandar btn btn-primary btn-back">Modificar</a>
    </div>
</asp:Content>
