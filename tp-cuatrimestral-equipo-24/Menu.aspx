<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="body-def">
        <div class="container">
            <div class="row">

                <asp:Repeater runat="server" ID="idRep">
                    <itemtemplate>

                        <div class="col-md-3 mb-4 article-card">
                            <div class="card h-100">
                                <%--                                <img src="<%# Eval("Imagen") %>" class="card-img-top" onerror="this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSt4xXXEwlOngpYGhvok77NVHkRONev9pOY_XHZ3M29aA&s';">--%>
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text"><%#Eval("Tipo") %></p>
                                    <h3 class="card-text">$ <%#Eval("Precio") %></h3>
                                    <h3 class="card-text">$ <%#Eval("Stock") %></h3>
                                </div>


                                <%-- <div class=" mt-auto d-flex justify-content-around">
                                    <asp:Button class="btnEstandar btn btn-secondary" ID="btnDecrementar" runat="server" Text="-" OnClick="btnDecrementar_Click" CommandArgument='<%# Eval("IdInsumo") %>' CommandName="IdInsumo" />
                                    <asp:Label ID="lblCantidad" runat="server" Text="1"></asp:Label>
                                    <asp:Button class="btnEstandar btn btn-secondary" ID="btnIncrementar" runat="server" Text="+" OnClick="btnIncrementar_Click" CommandArgument='<%# Eval("IdInsumo") %>' CommandName="IdInsumo" />
                                    <asp:Button class="btnEstandar btn btn-success" ID="Button1" runat="server" Text="Agregar al carrito" OnClick="btnAgregarAlCarrito_Click" CommandArgument='<%# Eval("IdInsumo") %>' CommandName="IdInsumo" />
                                </div>--%>


                                <%--                                <div class=" d-grid gap-3 col-9 mx-auto">
                                    <a href='<%# "DetalleArticulo.aspx?IdArticulo=" + Eval("IdInsumo") %>' class="btnEstandar btn-link-as-button">Detalle del ArtÃculo</a>
                                </div>--%>
                            </div>
                        </div>
                    </itemtemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

    <asp:GridView ID="dgvArticulos" runat="server"></asp:GridView>
</asp:Content>
