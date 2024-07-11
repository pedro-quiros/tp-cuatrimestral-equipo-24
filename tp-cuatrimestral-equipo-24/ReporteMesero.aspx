<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteMesero.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.ReporteMesero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detalle-articulo">
        <h1>REPORTE POR MESERO</h1>

        <div class="container text-center">
            <div class="row">
                <div class="col order-last">
                    Mesero
           
                </div>
                <div class="col">
                    ID
           
                </div>
                <div class="col order-first">
                    Numero Mesa/s
           
                </div>
                <div class="col order-first">
                    Precio
           
                </div>
                <div class="col order-first">
                    Pedidos
           
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
                                <p><%# Eval("NombreApellidoMesero") %></p>
                            </div>
                            <div class="col">
                                <p><%# Eval("IdMesero") %></p>
                            </div>
                            <div class="col order-first">
                                <p><%# Eval("NumeroMesaParaMesero") %></p>
                            </div>
                            <div class="col order-first">
                                <p><%# Eval("Precio") %></p>
                            </div>
                            <div class="col order-first">
                                <p><%# Eval("CantidadPedidos")%></p>
                            </div>
                        </div>
                    </div>
                </table>
            </ItemTemplate>
        </asp:Repeater>


        <div class="mt-auto d-flex justify-content-around">
            <a href="Reporte.aspx" class="btnEstandar btn btn-primary btn-back">Volver</a>
            <%--    <asp:Button CssClass="btnEstandar btn btn-success" ID="btnModificarInsumo" runat="server" Text="Modificar" OnClick="btnModificarInsumo_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />
<asp:Button CssClass="btnEstandar btn btn-success" ID="BajaAltaLogica" runat="server" Text="Inactivar" OnClick="BajaAltaLogica_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />--%>
        </div>
</asp:Content>
