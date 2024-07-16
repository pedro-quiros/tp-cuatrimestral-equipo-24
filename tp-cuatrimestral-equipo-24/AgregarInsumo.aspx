<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarInsumo.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.AgregarInsumo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
            background: linear-gradient(rgba(0, 0, 0, .7), rgba(0, 0, 0, .7)), url("https://previews.123rf.com/images/yupiramos/yupiramos1307/yupiramos130700939/20982775-restaurante-de-piel-sobre-fondo-de-color-rosa-ilustraci%C3%B3n-vectorial.jpg");
            background-size: cover;
            background-color: #f5f0f0b6; /* Color de fondo rojo claro */
            color: #721c24; /* Color del texto rojo oscuro */
            min-height: 100vh; /* Para que el cuerpo ocupe al menos toda la pantalla visible */
            position: relative; /* Para que el footer se posicione correctamente */
        }

        #wrapper {
            min-height: 100vh; /* Para que el wrapper ocupe al menos toda la pantalla visible */
            display: flex;
            flex-direction: column;
        }
        /*botones*/
        .btn-container {
            display: flex;
            justify-content: center;
            margin: 20px 0;
        }

        .btn-custom {
            display: inline-block;
            padding: 10px 20px;
            font-size: 1rem;
            font-weight: bold;
            color: white;
            background-color: #0094ff; /* Color rojo para el botón */
            border: none;
            border-radius: 5px;
            text-align: center;
            text-decoration: none;
            transition: background-color 0.3s, transform 0.3s;
        }

            .btn-custom:hover {
                background-color: #084672; /* Color rojo más oscuro al pasar el mouse */
                transform: scale(1.05); /* Efecto de agrandar el botón al pasar el mouse */
            }

            .btn-custom:active {
                background-color: #07395c; /* Color rojo aún más oscuro al hacer clic */
                transform: scale(1); /* Regresa el botón a su tamaño original al hacer clic */
            }

        /* Estilo para detalle */
        .detalle-articulo {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            background: linear-gradient(135deg, #0a5489, #1a1717); /* Fondo gradiente */
            color: #fff; /* Color del texto blanco */
            text-align: center; /* Centra el contenido */
        }

            .detalle-articulo .form-group {
                margin-bottom: 1.5rem;
                text-align: left; /* Alinea el texto a la izquierda */
                color: #fff; /* Color del texto de los labels */
            }

            .detalle-articulo .form-control {
                color: #000; /* Color del texto de los inputs */
            }

            .detalle-articulo .imagen-container {
                text-align: center;
                margin-top: 20px;
                display: flex;
                justify-content: center;
                align-items: center;
            }

                .detalle-articulo .imagen-container img {
                    max-width: 100%;
                    height: auto;
                    border-radius: 8px;
                    display: block;
                    margin-left: auto;
                    margin-right: auto;
                }

            .detalle-articulo .button-container {
                display: flex;
                justify-content: space-between;
                margin-top: 20px;
            }

            .detalle-articulo .btn {
                padding: 10px 20px;
                border-radius: 4px;
                text-align: center;
                cursor: pointer;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detalle-articulo">
        <h1>AGREGAR INSUMO</h1>

        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Nombre:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtNombre" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="LblTipo" runat="server" Text="Tipo:" CssClass="control-label"></asp:Label>
            <asp:DropDownList class="form-select" runat="server" ID="ddlTipo" aria-label="Default select example">
                <asp:ListItem Text="Desayuno/Merienda"></asp:ListItem>
                <asp:ListItem Text="Almuerzo/Cena"></asp:ListItem>
                <asp:ListItem Text="Postres"></asp:ListItem>
                <asp:ListItem Text="Bebidas"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblprecio" runat="server" Text="Precio: $" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtPrecio" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblStock" runat="server" Text="Stock:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtStock" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblImagen" runat="server" Text="UrlImagen:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtImagen" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lbldescripcion" runat="server" Text="Descripcion:" CssClass="control-label"></asp:Label>
            <input type="text" class="form-control" id="txtDescripcion" runat="server" />
        </div>

    </div>

    <div class="mt-auto d-flex justify-content-around">
        <a href="Menu.aspx" class="btn-custom">Volver</a>
        <asp:Button CssClass="btn-custom" ID="btnAgregarInsumo" runat="server" Text="Agregar" OnClick="btnAgregarInsumo_Click" CommandArgument='<%# Request.QueryString["IdInsumo"] %>' />
    </div>
</asp:Content>
