<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pedi2.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Pedi2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .numero-mesa {
            font-size: 24px;
            font-weight: bold;
            color: #333;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1 class="mb-4">Pedido para mesa <span id="numeroMesa" class="numero-mesa"><asp:Label ID="numeroMesaLabel" runat="server"></asp:Label></span></h1>
        
        <!-- Aquí va el contenido de tu página, por ejemplo la tabla de pedidos -->
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Productox" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
