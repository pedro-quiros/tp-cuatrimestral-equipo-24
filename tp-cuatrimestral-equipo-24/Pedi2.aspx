<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pedi2.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Pedi2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .modal-content {
            background-color: #f7f7f7;
            border-radius: 10px;
            padding: 20px;
        }
    </style>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script>
        // Funciones para incrementar y decrementar la cantidad
        function incrementarCantidad(idTextbox) {
            var txtCantidad = document.getElementById(idTextbox);
            if (txtCantidad.value === "") {
                txtCantidad.value = 1;
            } else {
                txtCantidad.value = parseInt(txtCantidad.value) + 1;
            }
        }

        function decrementarCantidad(idTextbox) {
            var txtCantidad = document.getElementById(idTextbox);
            if (txtCantidad.value === "" || txtCantidad.value <= 1) {
                txtCantidad.value = 1;
            } else {
                txtCantidad.value = parseInt(txtCantidad.value) - 1;
            }
        }

        // Función para cargar un producto seleccionado
        function cargarProducto() {
            var mesa = document.getElementById('<%= ddlMesa.ClientID %>').value;
            var plato = document.getElementById('<%= ddlPlato.ClientID %>').value;
            var bebida = document.getElementById('<%= ddlBebida.ClientID %>').value;
            var cantidadPlato = document.getElementById('<%= txtCantidadPlato.ClientID %>').value;
            var cantidadBebida = document.getElementById('<%= txtCantidadBebida.ClientID %>').value;

            // Validar que se haya seleccionado un plato o bebida
            if (plato === "0" && bebida === "0") {
                alert("Debe seleccionar al menos un plato o una bebida.");
                return;
            }

            var productosSeleccionados = [];

            // Procesar el plato seleccionado
            if (plato !== "0" && cantidadPlato !== "") {
                var nombrePlato = document.getElementById('<%= ddlPlato.ClientID %>').options[document.getElementById('<%= ddlPlato.ClientID %>').selectedIndex].text;
                var precioPlato = parseInt(document.getElementById('<%= ddlPlato.ClientID %>').value);
                var totalPlato = precioPlato * parseInt(cantidadPlato);
                productosSeleccionados.push({
                    nombre: nombrePlato,
                    cantidad: cantidadPlato,
                    precio: totalPlato
                });
            }

            // Procesar la bebida seleccionada
            if (bebida !== "0" && cantidadBebida !== "") {
                var nombreBebida = document.getElementById('<%= ddlBebida.ClientID %>').options[document.getElementById('<%= ddlBebida.ClientID %>').selectedIndex].text;
                var precioBebida = parseInt(document.getElementById('<%= ddlBebida.ClientID %>').value);
                var totalBebida = precioBebida * parseInt(cantidadBebida);
                productosSeleccionados.push({
                    nombre: nombreBebida,
                    cantidad: cantidadBebida,
                    precio: totalBebida
                });
            }

            // Agregar los productos al array general de productos
            productos = productos.concat(productosSeleccionados);

            // Mostrar el listado de productos en la tabla
            actualizarListaProductos();

            // Calcular y mostrar el precio total
            calcularTotal();

            // Cerrar el modal después de aceptar
            $('#modalCargarProducto').modal('hide');
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="title">Pedidos</p>

    <div class="encuadre">
        <div class="mb-3 row">
            <label for="mesa" class="col-sm-2 col-form-label">Mesa</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlMesa" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlMesa_SelectedIndexChanged">
                    <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="mb-3 row">
            <div class="col-auto">
                <asp:Button ID="btnCargarProducto" runat="server" Text="Cargar Producto" CssClass="btn btn-primary" OnClick="btnCargarProducto_Click" />
            </div>
        </div>

        <div class="mb-3 row">
            <label for="total" class="col-sm-2 col-form-label">Precio Total</label>
            <div class="col-sm-10">
                <asp:Label ID="lblTotal" runat="server" CssClass="form-control">0</asp:Label>
            </div>
        </div>
    </div>

    <!-- Modal para cargar productos -->
    <div class="modal fade" id="modalCargarProducto" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalLabel">Cargar Producto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="mb-3 row">
                        <label for="plato" class="col-sm-4 col-form-label">Plato</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlPlato" runat="server" CssClass="form-select" AutoPostBack="true">
                                <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Salchichas con pochoclos" Value="100"></asp:ListItem>
                                <asp:ListItem Text="Hamburguesa con miel" Value="150"></asp:ListItem>
                                <asp:ListItem Text="Milanesas bañadas en chocolate" Value="200"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="input-group mt-2">
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-secondary" onclick="decrementarCantidad('<%= txtCantidadPlato.ClientID %>')">-</button>
                                </span>
                                <asp:TextBox ID="txtCantidadPlato" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-secondary" onclick="incrementarCantidad('<%= txtCantidadPlato.ClientID %>')">+</button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <label for="bebida" class="col-sm-4 col-form-label">Bebida</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlBebida" runat="server" CssClass="form-select" AutoPostBack="true">
                                <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Agua saborizada" Value="50"></asp:ListItem>
                                <asp:ListItem Text="Agua" Value="30"></asp:ListItem>
                                <asp:ListItem Text="Gaseosa" Value="70"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="input-group mt-2">
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-secondary" onclick="decrementarCantidad('<%= txtCantidadBebida.ClientID %>')">-</button>
                                </span>
                                <asp:TextBox ID="txtCantidadBebida" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-secondary" onclick="incrementarCantidad('<%= txtCantidadBebida.ClientID %>')">+</button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Sección de pedidos -->
    <div id="seccionPedidos" style="display: none;">
        <h3>Pedido para mesa <span id="numeroMesa"></span></h3>
        <table class="table">
            <thead>
                <tr>
                    <th>Producto</th>
                    <th>Cantidad</th>
                    <th>Precio</th>
                </tr>
            </thead>
            <tbody id="tablaProductos">
                <!-- Aquí se mostrarán los productos dinámicamente -->
            </tbody>
        </table>
        <div class="mb-3 row">
            <label for="total" class="col-sm-2 col-form-label">Precio Total</label>
            <div class="col-sm-10">
                <asp:Label ID="Label1" runat="server" CssClass="form-control">0</asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
