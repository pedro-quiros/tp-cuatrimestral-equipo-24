<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Soportes.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos3.css" rel="stylesheet" />
     <p class="title">Contactanos</p>
    <!-- SECCIÓN CONTACTO -->
    <section id="contacto">
    
      
        <div class="contenedor-form">
            <form id="contactForm" action="https://formspree.io/f/mqkrvvgz" method="POST">
                <div class="fila mitad">
                    <label>
                        Nombre Completo*:
                    <input type="text" name="nombre" placeholder="Nombre Completo" class="input-mitad" required>
                    </label>
                    <label>
                        Dirección de Email*:
                    <input type="email" name="email" placeholder="Dirección de Email" class="input-mitad" required>
                    </label>
                </div>
                <div class="fila">
                    <label>
                        Tema*:
                    <input type="text" name="tema" placeholder="Tema..." class="input-full" required>
                    </label>
                </div>
                <div class="fila">
                    <label>
                        Mensaje*:
                    <textarea name="mensaje" placeholder="Tu Mensaje..." class="input-full" required></textarea>
                    </label>
                </div>

                <button type="submit" class="btn-enviar">Enviar Mensaje</button>
            </form>
        </div>
    </section>
    <script>
        // Agregar escucha de evento cuando el DOM esté completamente cargado
        document.addEventListener("DOMContentLoaded", function () {
            var form = document.getElementById("contactForm");
            if (form) {
                form.addEventListener("submit", function (event) {
                    console.log("Formulario enviado");
                });
            } else {
                console.log("Formulario no encontrado");
            }
        });
    </script>
</asp:Content>
