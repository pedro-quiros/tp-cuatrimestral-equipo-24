<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstiloPagos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-register">


        <h4>Formulario Pago </h4>

        <div class="form-group">
            <asp:Label ID="lblpagos" runat="server" Text="Pagos:" CssClass="form-label"></asp:Label>
            <div class="col-sm-10">
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlPagos" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Efectivo" />
                        <asp:ListItem Text="Credito" />
                        <asp:ListItem Text="Debito" />
                        <asp:ListItem Text="Tranferencia" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        
            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="botons" OnClick ="btnConfirmar_Click" />
            <a href="Menu.aspx" class="btnEstandar btn btn-primary btn-back">Volver</a>
        
    </div>

    <div class="form-register" id="divtext" visible="false" runat="server" >
        <h4 id="htext" runat="server" Visible="false"> Recibo de Pago </h4>

        <div class="mb-3">
            <label id="lblMesa" runat="server" class="form-label" ReadOnly="true" Visible="false">Num de Mesa: </label>
            <asp:TextBox ID="txtMesa" runat="server" CssClass="controls" ReadOnly="true" Visible="false"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label id="lblmesero" runat="server" class="form-label" ReadOnly="true" Visible="false">Mesero:</label>
            <asp:TextBox ID="txtMesero" runat="server" CssClass="controls" ReadOnly="true" Visible="false"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label id="lblFecha" runat="server" class="form-label" ReadOnly="true" Visible="false">Fecha:</label>
            <asp:TextBox ID="Txtfecha" runat="server" CssClass="controls" ReadOnly="true" Visible="false"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label id="lbltotal" runat="server" class="form-label" ReadOnly="true" Visible="false">Total:</label>
            <asp:TextBox ID="txtTotal" runat="server" CssClass="controls" ReadOnly="true" Visible="false"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label id="lblTipo" runat="server" class="form-label" ReadOnly="true" Visible="false">Tipo de Pago:</label>
            <asp:TextBox ID="txtTipo" runat="server" CssClass="controls" ReadOnly="true" Visible="false"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label id="lblconsumicion" runat="server" class="form-label" ReadOnly="true" Visible="false">Consumicion:</label>
            <asp:TextBox ID="txtConsumicion" runat="server" CssClass="controls" ReadOnly="true" Visible="false"></asp:TextBox>
        </div>

    </div>



</asp:Content>
