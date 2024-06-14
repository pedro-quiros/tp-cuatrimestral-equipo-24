<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Salon.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Salon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .salon {
            margin: 50px auto; /* Margen arriba y abajo, centrado horizontalmente */
            background-color: lightblue; /* Color de fondo suave */
            padding: 50px; /* Espacio alrededor del salón */
            border: 1px solid #ccc; /* Borde del salón */
            border-radius: 5px; /* Bordes redondeados del salón */
            box-shadow: 0 0 10px rgba(0,0,0,0.1); /* Sombra suave */
            width: 60%; /* Ancho del salón */
        }

        .mesa-btn {
            display: inline-block;
            width: 100px;
            height: 100px;
            line-height: 100px;
            text-align: center;
            border-radius: 50%;
            background-color: #f0f0f0;
            border: 1px solid #ccc;
            font-size: 18px;
            cursor: pointer;
            margin: 20px;
            transition: background-color 0.3s ease; /* Transición suave para el cambio de color */
        }

        .mesa-btn.clicked {
            background-color: #ff0000; /* Color rojo al hacer clic */
            color: #fff; /* Texto blanco para contraste */
        }
    </style>
    <script>
        function cambiarColor(btn) {
            btn.classList.add('clicked'); // Agrega la clase 'clicked' al botón
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="salon">
        <div class="mesas">
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa1" runat="server" Text="1" CssClass="mesa-btn" OnClientClick="cambiarColor(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa2" runat="server" Text="2" CssClass="mesa-btn" OnClientClick="cambiarColor(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa3" runat="server" Text="3" CssClass="mesa-btn" OnClientClick="cambiarColor(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa4" runat="server" Text="4" CssClass="mesa-btn" OnClientClick="cambiarColor(this); return false;" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa5" runat="server" Text="5" CssClass="mesa-btn" OnClientClick="cambiarColor(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa6" runat="server" Text="6" CssClass="mesa-btn" OnClientClick="cambiarColor(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa7" runat="server" Text="7" CssClass="mesa-btn" OnClientClick="cambiarColor(this); return false;" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnMesa8" runat="server" Text="8" CssClass="mesa-btn" OnClientClick="cambiarColor(this); return false;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>