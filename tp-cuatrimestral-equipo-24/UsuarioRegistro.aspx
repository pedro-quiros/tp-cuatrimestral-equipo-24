﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UsuarioRegistro.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3 row">
        <label for="staticEmail" class="col-sm-2 col-form-label">Nombre</label>
        <div class="col-sm-10">
            <input class="form-control" id="inputPassword">
        </div>
    </div>
    <div class="mb-3 row">
        <label for="inputPassword" class="col-sm-2 col-form-label">Apellido</label>
        <div class="col-sm-10">
            <input class="form-control" id="inputPassword">
        </div>
    </div>
    <div class="mb-3 row">
        <label for="inputPassword" class="col-sm-2 col-form-label">DNI</label>
        <div class="col-sm-10">
            <input class="form-control" id="inputPassword">
        </div>
    </div>
    <div class="mb-3 row">
        <label for="inputPassword" class="col-sm-2 col-form-label">Fecha de Nacimiento</label>
        <div class="col-sm-10">
            <input class="form-control" id="inputPassword">
        </div>
    </div>
    <div class="mb-3 row">
        <label for="inputPassword" class="col-sm-2 col-form-label">Genero</label>
        <div class="col-sm-10">
            <select class="form-select" aria-label="Default select example">
                <option selected>Seleccione una opcion</option>
                <option value="1">Hombre</option>
                <option value="2">Mujer</option>
                <option value="3">Trans</option>
                <option value="3">Otro</option>
            </select>
        </div>
    </div>
    <div class="mb-3 row">
        <label for="inputPassword" class="col-sm-2 col-form-label">Telefono</label>
        <div class="col-sm-10">
            <input class="form-control" id="inputPassword">
        </div>
    </div>
    <div class="mb-3 row">
        <label for="inputPassword" class="col-sm-2 col-form-label">Email</label>
        <div class="col-sm-10">
            <input class="form-control" id="inputPassword">
        </div>
    </div>
    <div class="mb-3 row">
        <label for="inputPassword" class="col-sm-2 col-form-label">Domicilio</label>
        <div class="col-sm-10">
            <input class="form-control" id="inputPassword">
        </div>
    </div>
</asp:Content>