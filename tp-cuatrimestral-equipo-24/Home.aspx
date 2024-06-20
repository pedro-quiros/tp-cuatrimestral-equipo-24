<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstilosFiltrar.css" rel="stylesheet" />
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
        /*Boton Agregar usuario*/
        .Ingresar {
            display: inline-block;
            text-decoration: none;
            color: #ffffff;
            background-color: #007bff; /* Cambiado a azul */
            border-radius: 30px;
            border: 1px solid #007bff; /* Azul */
            padding: 10px 20px; /* Ajuste de padding */
            margin-top: 30px;
            transition: .5s;
            cursor: pointer;
        }

            .Ingresar:hover {
                background-color: #0056b3; /* Color de fondo al pasar el mouse */
                border: 1px solid #0056b3; /* Azul oscuro */
                color: #fff;
            }

        .button-container {
            width: 40%;
            margin: 20px auto 0; /* Centrado y con margen superior */
            text-align: right; /* Alineado a la derecha */
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="title">Lista usuarios</p>


    <div class="filter-container">
        <i class="fas fa-search">Buscar</i>
        <asp:Label ID="LabelFiltrar" runat="server" Text="" CssClass="label-filtrar"></asp:Label>
        <asp:TextBox ID="Filtro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" runat="server" CssClass="input-filtrar" />
    </div>

    <asp:GridView CssClass="tablaConEstilo" ID="dgvUsuario" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged" OnPageIndexChanging="dgvUsuario_PageIndexChanging" AllowPaging="true" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="ID Empleado" DataField="Id" />
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Puesto" DataField="Puesto" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="📝" />
        </Columns>
    </asp:GridView>

    <div class="button-container">
        <asp:Button ID="btnAgregar" runat="server" CssClass="Ingresar" Text="Agregar" OnClick="btnAgregar_Click" />
    </div>


</asp:Content>
