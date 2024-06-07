<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Soportes.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos2.css" rel="stylesheet" />
    <!-- SECCTION C O N T A C T O -->
    <section id="contacto">
        <h3 class="titulo-seccion">Contactanos</h3>
        <div class="contenedor-form">
            <form action="https://formspree.io/f/xnqewwap" method="POST">
                <div class="fila mitad">
                    <label>
                        Nombre Completo*:
                    <input type="text" name="nombre" placeholder="Nombre Completo" class="input-mitad">
                    </label>
                    <label>
                        Dirección de Email*:
                    <input type="email" name="email" placeholder="Dirección de Email" class="input-mitad">
                    </label>
                </div>
                <div class="fila">
                    <label>
                        Tema*:
                    <input type="text" name="tema" placeholder="Tema..." class="input-full">
                    </label>
                </div>
                <div class="fila">
                    <label>
                        Mensaje*:
                    <textarea name="mensaje" placeholder="Tu Mensaje..." class="input-full"></textarea>
                    </label>
                </div>

                <button type="submit" class="btn-enviar">Enviar Mensaje</button>
            </form>
        </div>
    </section>
    <script>
        document.getElementById("contactForm").addEventListener("submit", function(event) {
            console.log("Formulario enviado");
        });
    </script>

</asp:Content>
