<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista Usuario:</h1>
    <asp:GridView ID="dgvUsuario" runat="server" DataKeyNames="Id" CssClass="table table dark table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged" OnPageIndexChanging="dgvUsuario_PageIndexChanging" AllowPaging="true" PageSize="5">
        <Columns>
           <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Puesto" DataField="Puesto" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="📝"  />
        </Columns>
    </asp:GridView>
    <a href="UsuarioRegistro.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
