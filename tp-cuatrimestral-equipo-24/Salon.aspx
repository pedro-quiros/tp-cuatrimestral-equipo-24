<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Salon.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Salon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link href="/CSS/EstilosSalon.css" rel="stylesheet" />
    <script src="/JS/ScriptsSalon.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="salon">
        <p class="title">Salón</p>
        <asp:GridView CssClass="tablaConEstilo" ID="dgvMesas" runat="server" DataKeyNames="IdMesa" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMesas_SelectedIndexChanged" OnPageIndexChanging="dgvMesas_PageIndexChanging" AllowPaging="true" PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Mesa #" DataField="Numero" />
                <asp:BoundField HeaderText="Estado" DataField="Estado" />
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
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="btnAceptarModal" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptarModal_Click" />
                    </div>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="hdfIdMesa" runat="server" />
    </div>
</asp:Content>
