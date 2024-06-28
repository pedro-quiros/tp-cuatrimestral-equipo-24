<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Salon.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Salon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
   
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link href="EstilosSalon.css" rel="stylesheet" />
<script src="JS/ScriptsSalon.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <p class="title">Salón</p>

    <div class="salon">
        <div class="mesas">
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa1" runat="server" Text="1" CssClass="mesa-btn" OnClientClick="mostrarModal(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa2" runat="server" Text="2" CssClass="mesa-btn" OnClientClick="mostrarModal(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa3" runat="server" Text="3" CssClass="mesa-btn" OnClientClick="mostrarModal(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa4" runat="server" Text="4" CssClass="mesa-btn" OnClientClick="mostrarModal(this); return false;" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa5" runat="server" Text="5" CssClass="mesa-btn" OnClientClick="mostrarModal(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa6" runat="server" Text="6" CssClass="mesa-btn" OnClientClick="mostrarModal(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa7" runat="server" Text="7" CssClass="mesa-btn" OnClientClick="mostrarModal(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa8" runat="server" Text="8" CssClass="mesa-btn" OnClientClick="mostrarModal(this); return false;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
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
                                <asp:Button ID="Button1" runat="server" Text="Cancelar" CssClass="btn btn-secondary" data-dismiss="modal" />

                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClientClick="confirmarMesa(); return false;" />
 
            </div>
        </div>
    </div>
</div>
</asp:Content>
