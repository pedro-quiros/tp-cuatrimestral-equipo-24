<%@ Page Title="Menú" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstilosTarjetas.css" rel="stylesheet" />
    <link href="EstilosFiltrar.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="title">Menú</p>

<div class="filter-container">
    <i class="fas fa-search"> Buscar</i>
    <asp:Label ID="LabelFiltrar" runat="server" Text="" CssClass="label-filtrar"></asp:Label>
    <asp:TextBox ID="Filtro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" runat="server" CssClass="input-filtrar" />
</div>

    <section class="body-def">
        <div class="contenedor-card">
            <asp:Repeater runat="server" ID="idRep">
                <ItemTemplate>
                    <div class="card h-100 tarjeta-rest" style="background: url('<%# Eval("UrlImagen") %>') center; background-size: cover;">
                        <div class="wrap-text_tarjeta-rest">
                            <h3><%# Eval("Nombre") %></h3>
                            <p><%# Eval("Tipo") %></p>
                            <p>Cant. <%# Eval("Stock") %></p>
                            <p><%# Eval("descripcion") %></p>
                            <h3>$ <%# Eval("Precio") %></h3>

                            <div class="cta_tarjeta-rest">
                                <a href='<%# "ModificarInsumo.aspx?IdInsumo=" + Eval("IdInsumo") %>'>Modificar</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           
        </div>
    </section>
      
    <asp:GridView ID="dgvArticulos" runat="server"></asp:GridView>
</asp:Content>
