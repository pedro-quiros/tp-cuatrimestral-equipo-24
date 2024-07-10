﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroLogin.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.RegistroLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4">
            <h2>Creá tu Usuario </h2>
            <div class="mb-3">
                <label class="form-label">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
            <a href="/">Cancelar</a>

        </div>
    </div>
</asp:Content>
