<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroLogin.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.RegistroLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4">
            <h2>Creá tu Usuario </h2>
            <div class="mb-3">
                <label class="form-label">Usuario:</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Puesto:</label>
                <asp:DropDownList runat="server" ID="ddlPuesto" CssClass="form-select">
                    <asp:ListItem Text="Empleado" />
                    <asp:ListItem Text="Gerente" />
                </asp:DropDownList>
            </div>
            <%--<div class="mb-3">
                <label class="form-label">Activo</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>--%>
            <div class="mb-3">
                <label class="form-label">DNI:</label>
                <asp:TextBox ID="txtdni" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido:</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nacimiento:</label>
                <asp:TextBox ID="txtnacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblgenero" runat="server" Text="Género:" CssClass="form-label"></asp:Label>
                <div class="col-sm-10">
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Hombre" />
                            <asp:ListItem Text="Mujer" />
                            <asp:ListItem Text="Otro" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>


            <div class="mb-3">
                <label class="form-label">Telefono:</label>
                <asp:TextBox ID="txttelefono" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Domicilio:</label>
                <asp:TextBox ID="txtdomicilio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
            <a href="/">Cancelar</a>

        </div>
    </div>
</asp:Content>
