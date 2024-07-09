<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleReporte.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Mochiy+Pop+One&display=swap">
    <link href="EstilosModificar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detalle-articulo">
        <h1>REPORTE POR MESA</h1>

        <div class="container text-center">
            <div class="row">
                <div class="col order-last">
                    Pedidos
                </div>
                <div class="col">
                    Precio
                </div>
                <div class="col order-first">
                    Mesa
                </div>
                <div class="col order-first">
                    Id Mesero
                </div>
                <div class="col order-first">
                    Mesero
                </div>
<%--                <div class="col order-first">
                    PuntajeReseña
                </div>--%>
            </div>
        </div>
        <asp:Repeater runat="server" ID="idRep">
            <ItemTemplate>
                <table class="table table-bordered">
                    <div class="container text-center">
                        <div class="row">
                            <div class="col order-last">
                                <p><%# Eval("CantidadPedidos") %></p>
                            </div>
                            <div class="col">
                                <p><%# Eval("Precio") %></p>
                            </div>
                            <div class="col order-first">
                                <p><%# Eval("NumeroMesa") %></p>
                            </div>
                            <div class="col order-first">
                                <p><%# Eval("IdMesero") %></p>
                            </div>
                            <div class="col order-first">
                                <p><%# Eval("NombreApellidoMesero ")%></p>
                            </div>
<%--                            <div class="col order-first">
                                <p><%# Eval("PuntajeReseña") %></p>
                            </div>--%>
                        </div>
                    </div>
                </table>
            </ItemTemplate>
        </asp:Repeater>


        <%--<div class="form-group">
            <asp:Label ID="lblPedidos" runat="server" Text="Cantidad Pedidos:" CssClass="control-label"></asp:Label>
            <asp:TextBox type="text" class="form-control" ID="txtPedidos" runat="server" ReadOnly="true"></asp:TextBox>
        </div>

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

    </div>--%>

        <div class="mt-auto d-flex justify-content-around">
            <a href="Reporte.aspx" class="btnEstandar btn btn-primary btn-back">Volver</a>
            <%--    <asp:Button CssClass="btnEstandar btn btn-success" ID="btnModificarInsumo" runat="server" Text="Modificar" OnClick="btnModificarInsumo_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />
    <asp:Button CssClass="btnEstandar btn btn-success" ID="BajaAltaLogica" runat="server" Text="Inactivar" OnClick="BajaAltaLogica_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />--%>
        </div>
</asp:Content>
