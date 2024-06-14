<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarInsumo.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.ModificarInsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Mochiy+Pop+One&display=swap">
    <link href="EstilosModificar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detalle-articulo">
        <h1>MODIFICAR INSUMO</h1>

        <div class="form-group">
            <asp:Label ID="lblnombre" runat="server" Text="Nombre:" CssClass="control-label"></asp:Label>
            <%--<asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>--%>
            <input type="text" class="form-control" id="txtNombre" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="LblTipo" runat="server" Text="Tipo:" CssClass="control-label"></asp:Label>
            <%--<asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>--%>
            <input type="text" class="form-control" id="txtTipo" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblprecio" runat="server" Text="Precio: $" CssClass="control-label"></asp:Label>
            <%--<asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>--%>
            <input type="text" class="form-control" id="txtPrecio" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblStock" runat="server" Text="Stock:" CssClass="control-label"></asp:Label>
            <%--<asp:TextBox ID="txtStock" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>--%>
            <input type="text" class="form-control" id="txtStock" runat="server" />
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblImagen" runat="server" Text="UrlImagen:" CssClass="control-label"></asp:Label>
            <%--<asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>--%>
            <input type="text" class="form-control" id="txtImagen" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lbldescripcion" runat="server" Text="Descripcion:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtDescripcion" runat="server" />
            <%--<asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>--%>
        </div>



<%--        <div class="imagen-container">
            <asp:Repeater runat="server" ID="repDetalle">
                <ItemTemplate>
                    <div class="cardImg h-100">
                        <img src='<%# Container.DataItem %>' alt="Imagen" class="img-fluid mt-1" onerror="this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSt4xXXEwlOngpYGhvok77NVHkRONev9pOY_XHZ3M29aA&s';" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>

    </div>

    <div class="mt-auto d-flex justify-content-around">
        <a href="Menu.aspx" class="btnEstandar btn btn-primary btn-back">Volver</a>
        <asp:Button CssClass="btnEstandar btn btn-success" ID="btnModificarInsumo" runat="server" Text="Modificar" OnClick="btnModificarInsumo_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />
    </div>
</asp:Content>
