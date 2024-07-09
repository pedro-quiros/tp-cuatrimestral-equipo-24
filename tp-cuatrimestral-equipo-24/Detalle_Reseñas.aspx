<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle_Reseñas.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Detalle_Reseñas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstilosModificar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detalle-articulo">
        <h1>Reseñas</h1>

        <div class="container text-center">
            <div class="row">
                <div class="col order-last">
                    Email
                </div>
                <div class="col">
                    Mensaje
                </div>
                <div class="col order-first">
                    Puntaje
                </div>
                <div class="col order-first">
                    Fecha
                </div>
            </div>
        </div>

        <asp:Repeater runat="server" ID="idRep">
            <ItemTemplate>
                <table class="table table-bordered">
                    <div class="container text-center">
                        <div class="row">
                            <div class="col order-last">
                                <p><%# Eval("Email") %></p>
                            </div>
                            <div class="col order-first">
                                <p><%# Eval("mensaje") %></p>
                            </div>
                            <div class="col">
                                <p><%# Eval("Puntaje") %></p>
                            </div>
                            <div class="col">
                                <p><%# Eval("Fecha") %></p>
                            </div>
                        </div>
                    </div>
                </table>
            </ItemTemplate>
        </asp:Repeater>

        <%-- Contador Neg y Pos --%>
        <div class="container text-center mt-4">
            <div class="alert alert-info">
                <h4>Contador de Reseñas</h4>
                <p>Positivas: <asp:Label runat="server" ID="lblPositivas"></asp:Label></p>
                <p>Negativas: <asp:Label runat="server" ID="lblNegativas"></asp:Label></p>
            </div>
        </div>
</asp:Content>
