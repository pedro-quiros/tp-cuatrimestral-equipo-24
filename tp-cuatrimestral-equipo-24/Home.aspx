<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tablaConEstilo {
            width: 40%;
            border-collapse: collapse;
            margin: 0 auto;
            text-align: center;
            font-family: 'Roboto', sans-serif;
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
    <p class="title">Lista usuarios</p>

    <asp:GridView CssClass="tablaConEstilo" ID="dgvUsuario" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged" OnPageIndexChanging="dgvUsuario_PageIndexChanging" AllowPaging="true" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="ID Empleado" DataField="Id" />
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Puesto" DataField="Puesto" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="📝" />
        </Columns>
    </asp:GridView>

    <a href="UsuarioRegistro.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
