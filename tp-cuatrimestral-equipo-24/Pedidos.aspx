﻿<%@ Page Title="Pedidos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="tp_cuatrimestral_equipo_24.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p class="title">Pedidos</p>
 
    <div class="encuadre">
        <div class="mb-3 row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Plato</label>
            <div class="col-sm-10">
                <select class="form-select" aria-label="Default select example">
                    <option selected>Seleccione una opción</option>
                    <option value="0">Nada</option>
                    <option value="1">Salchichas con pochoclos</option>
                    <option value="2">Hamburguesa con miel</option>
                    <option value="3">Milanesas bañadas en chocolate</option>
                </select>
            </div>
        </div>
        <div class="mb-3 row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Bebida</label>
            <div class="col-sm-10">
                <select class="form-select" aria-label="Default select example">
                    <option selected>Seleccione una opción</option>
                    <option value="0">Nada</option>
                    <option value="1">Agua saborizada</option>
                    <option value="2">Agua</option>
                    <option value="3">Gaseosa</option>
                </select>
            </div>
        </div>
        <div class="mb-3 row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Mesa</label>
            <div class="col-sm-10">
                <select class="form-select" aria-label="Default select example">
                    <option selected>Seleccione una opción</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>
            </div>
        </div>
        <div class="mb-3 row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Mesero</label>
            <div class="col-sm-10">
                <select class="form-select" aria-label="Default select example">
                    <option selected>Seleccione una opción</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                </select>
            </div>
        </div>
        <div class="mb-3 row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Reseña</label>
            <div class="col-sm-10">
                <input class="form-control" id="inputPassword">
            </div>
        </div>
        <div class="mb-3 row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Precio</label>
        </div>

        <form class="row g-3">
            <div class="col-auto">
                <button type="button" class="btn btn-outline-danger">Cerrar pedido</button>
            </div>
        </form>
    </div>
</asp:Content>
