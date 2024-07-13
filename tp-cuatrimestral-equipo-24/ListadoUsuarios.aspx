<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoUsuarios.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.ListadoUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EstilosFiltrar.css" rel="stylesheet" />
    <style>
        body {
            margin: 0;
            padding: 0;
            background: linear-gradient(rgba(0, 0, 0, .7), rgba(0, 0, 0, .7)), url("https://previews.123rf.com/images/yupiramos/yupiramos1307/yupiramos130700939/20982775-restaurante-de-piel-sobre-fondo-de-color-rosa-ilustraci%C3%B3n-vectorial.jpg");
            background-size: cover;
            font-family: 'Roboto', sans-serif;
        }

        .title {
            text-align: center;
            color: white;
            margin-top: 20px;
            font-size: 24px;
            font-weight: bold;
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
            width: 80%;
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
        <asp:TextBox ID="Filtro" AutoPostBack="true" OnTextChanged="Filtro_TextChanged" runat="server" CssClass="input-filtrar" />
    </div>

    <asp:GridView CssClass="tablaConEstilo" ID="dgvUsuario" runat="server" DataKeyNames="Id" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged" OnPageIndexChanging="dgvUsuario_PageIndexChanging" AllowPaging="true" PageSize="5">
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
