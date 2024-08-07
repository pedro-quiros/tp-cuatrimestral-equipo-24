﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteMesa.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.WebForm3" %>

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
