<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Soporte.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Soporte" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Formulario de Soporte</title>
    <link href="EstilosSoporte.css" rel="stylesheet" />
</head>
<body>

    <section id="contacto">
        <div class="contenedor-form">
            <form id="form1" runat="server">
                <div class="fila mitad">
                    <label>
                        Nombre Completo*:
                        <asp:TextBox ID="TxtNombre" Text="" CssClass="input-mitad" runat="server"></asp:TextBox>
                    </label>
                    <label>
                        Dirección de Email*:
                        <asp:TextBox ID="TxtEmail" Text="" CssClass="input-mitad" runat="server"></asp:TextBox>
                    </label>
                </div>
                <div class="fila">
                    <label>
                        Mensaje*:
                        <asp:TextBox ID="txtmensaje" Text="" CssClass="input-mitad" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </label>
                </div>
                <asp:Button ID="BtnEnviar" runat="server" Text="Enviar" CssClass="btn-enviar" OnClick="BtnEnviar_Click" />
            </form>
        </div>
    </section>

</body>
</html>
