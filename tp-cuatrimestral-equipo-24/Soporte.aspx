<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Soporte.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Soporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="EstilosSoporte.css" rel="stylesheet" />
</head>
<body>
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
                        <button type="button" class ="btn-enviar">
                            <input type="submit" value="Enviar">
                        </button>
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
</body>
</html>