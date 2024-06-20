<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UsuarioRegistro.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.UsuarioRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="title">Administración de usuarios</p>

    <div class="encuadre">

        <div class="form-group">
            <asp:Label ID="lblId" runat="server" Text="ID:" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblusuario" runat="server" Text="Usuario:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtUsuario" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lbllegajo" runat="server" Text="Legajo:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtLegajo" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblnombre" runat="server" Text="Nombre:" CssClass="control-label"></asp:Label>
           <input type="text" class="form-control" id="txtNombrePersonal" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtApellido" runat="server" />
        </div>

<div class="form-group">
    <asp:Label ID="lblDni" runat="server" Text="DNI:" CssClass="control-label"></asp:Label>
    <input type="text" class="form-control" id="txtDni" runat="server" />
</div>

        <div class="form-group">
            <asp:Label ID="LblNacimineto" runat="server" Text="Fecha de Nacimiento:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtNacimiento" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblgenero" runat="server" Text="Género:" CssClass="control-label"></asp:Label>
            <div class="col-sm-10">
                <select class="form-select" id="ddlGenero" runat="server" cssclass="form-control">
                    <option selected>Seleccione una opción</option>
                    <option value="1">Hombre</option>
                    <option value="2">Mujer</option>
                    <option value="3">Otro</option>
                </select>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtTelefono" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="LblMail" runat="server" Text="Mail:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtEmail" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtDomicilio" runat="server" />
        </div>

        <form class="row g-3">
            <div class="col-auto">
                <asp:Button ID="btnLogico" runat="server" Text="Inactivar" OnClick="btnInactivo_Click" CssClass="btn btn-outline-success" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-outline-success" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-outline-success" />
            </div>
        </form>
    </div>
</asp:Content>
