<%@ Page Title="Menú" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstilosTarjetas.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="title">Menú</p>
    <section class="body-def">
        <div class="container wrap">
            <div class="row column-4">
                <asp:Repeater runat="server" ID="idRep">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4 article-card">
                            <div class="card h-100 tarjeta-rest" style="background: url('<%# Eval("UrlImagen") %>') center; background-size: cover;">
                                <div class="wrap-text_tarjeta-rest">
                                    <h3><%# Eval("Nombre") %></h3>
                                    <p>
                                        <%# Eval("Tipo") %><br />
                                        Cant. <%# Eval("Stock") %>
                                        <%# Eval("descripcion")%>
                                    </p>
                                    <div class="cta-wrap_tarjeta-rest">
                                        <div class="precio_tarjeta-rest">
                                            <span>$ <%# Eval("Precio") %></span>
                                        </div>
                                        <div class="cta_tarjeta-rest">
                                            <a href='<%# "DetalleArticulo.aspx?IdArticulo=" + Eval("IdInsumo") %>'>Pedir ahora</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

    <asp:GridView ID="dgvArticulos" runat="server"></asp:GridView>
</asp:Content>
