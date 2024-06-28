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
    <p class="title">Salón</p>

    <asp:GridView CssClass="tablaConEstilo" ID="dgvMesas" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMesas_SelectedIndexChanged" OnPageIndexChanging="dgvMesas_PageIndexChanging" AllowPaging="true" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="ID Mesa" DataField="Id" />
            <asp:BoundField HeaderText="Numero Mesa #" DataField="Numero" />
            <asp:BoundField HeaderText="Estado" DataField="Estado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnAbrirCerrar" runat="server" Text='<%# Eval("Estado").ToString() == "1" ? "Cerrar" : "Abrir" %>' CommandArgument='<%# Eval("Id") %>' OnClick="btnAbrirCerrar_Click" CssClass='<%# Eval("Estado").ToString() == "1" ? "btn btn-sm btn-danger" : "btn btn-sm btn-primary" %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <!-- Modal de Confirmación -->
    <div class="modal fade" id="modalConfirmar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Confirmar</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Desea abrir la mesa seleccionada?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="btnAceptar">Aceptar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
