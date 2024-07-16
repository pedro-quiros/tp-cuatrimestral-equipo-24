<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Salon.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Salon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link href="/CSS/EstilosSalon.css" rel="stylesheet" />
    <script src="/JS/ScriptsSalon.js"></script>
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
            background: linear-gradient(rgba(0, 0, 0, .7), rgba(0, 0, 0, .7)), url("https://previews.123rf.com/images/yupiramos/yupiramos1307/yupiramos130700939/20982775-restaurante-de-piel-sobre-fondo-de-color-rosa-ilustraci%C3%B3n-vectorial.jpg");
            background-size: cover;
            background-color: #f5f0f0b6; /* Color de fondo rojo claro */
            color: #721c24; /* Color del texto rojo oscuro */
            min-height: 100vh; /* Para que el cuerpo ocupe al menos toda la pantalla visible */
            position: relative; /* Para que el footer se posicione correctamente */
        }

        #wrapper {
            min-height: 100vh; /* Para que el wrapper ocupe al menos toda la pantalla visible */
            display: flex;
            flex-direction: column;
        }

        .filter-container {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-top: 20px;
        }

            .filter-container i {
                color: white;
                margin-right: 10px;
            }

        .label-filtrar {
            color: white;
            margin-right: 10px;
        }

        .input-filtrar {
            padding: 8px;
            border-radius: 4px;
            border: 1px solid #ccc;
            width: 200px;
        }

        .tablaConEstilo {
            width: 80%;
            border-collapse: collapse;
            margin: 20px auto;
            text-align: center;
            background-color: white;
            opacity: 0.9;
            /*font-family: 'Roboto', sans-serif;*/
        }

            .tablaConEstilo th, .tablaConEstilo td {
                border: 1px solid #ddd;
                padding: 8px;
            }

            .tablaConEstilo th {
                padding-top: 12px;
                padding-bottom: 12px;
                background-color: #4CAF50;
                color: white;
            }

            .tablaConEstilo tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .tablaConEstilo tr:hover {
                background-color: #ddd;
            }
        
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="salon">
        <p class="title">Salón</p>
        <asp:GridView CssClass="tablaConEstilo" ID="dgvMesas" runat="server" DataKeyNames="IdMesa" AutoGenerateColumns="false" OnPageIndexChanging="dgvMesas_PageIndexChanging" AllowPaging="true" PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Mesa #" DataField="Numero" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text='<%# Convert.ToBoolean(Eval("Estado")) ? "Abierto" : "Cerrado" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnAbrirMesa" runat="server" Text="Abrir Mesa" CssClass="btn btn-primary mesa-btn" OnClick="btnAbrirMesa_Click" Visible='<%# !Convert.ToBoolean(Eval("Estado")) %>' />
                        <asp:Button ID="btnCargarPedidos" runat="server" Text="Cargar Pedidos" CssClass="btn btn-primary mesa-btn" OnClick="btnCargarPedidos_Click" Visible='<%# Convert.ToBoolean(Eval("Estado")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div id="modalConfirmar" class="modal fade" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Confirmar Apertura de Mesa</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <p id="modalMensaje">¿Estás seguro de que deseas abrir esta mesa?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnCancelarModal" runat="server" Text="Cancelar" CssClass="btn btn-secondary" data-dismiss="modal" />
                        <asp:Button ID="btnAceptarModal" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptarModal_Click" />
                    </div>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="hdfIdMesa" runat="server" />
    </div>
</asp:Content>
