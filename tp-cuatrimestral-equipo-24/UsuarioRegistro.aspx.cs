﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;

namespace tp_cuatrimestral_equipo_24
{

    public partial class UsuarioRegistro : System.Web.UI.Page
    {
        List<Usuario> listaUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioGestion usuarioGest = new UsuarioGestion();
                Usuario seleccionado = new Usuario();
                List<Usuario> listaUsu = new List<Usuario>();

                if (Session["Listado"] != null)
                {
                    listaUsu = (List<Usuario>)Session["Listado"];
                }
                else
                {
                    // Cargar la lista de usuarios si no está en la sesión
                    listaUsu = usuarioGest.ListarConSpUsuario();
                    Session["Listado"] = listaUsu;
                }

                try
                {
                    if (Request.QueryString["IdUsuario"] != null)
                    {
                        int id = Convert.ToInt32(Request.QueryString["IdUsuario"]);
                        Usuario usu = listaUsu.Find(u => u.Id == id);

                        if (usu != null)
                        {
                            txtId.Text = usu.Id.ToString();
                            txtUsuario.Value = usu.NombreUsuario;
                            txtNombre.Value = usu.datos.Nombre;
                            txtApellido.Value = usu.datos.Apellido;
                           
                            txtEmail.Value = usu.datos.Email;
                            txtDomicilio.Value = usu.datos.Domicilio;
                            txtNacimiento.Value = usu.datos.Nacimiento;
                            ddlGenero.Value = usu.datos.Genero;
                            txtTelefono.Value = usu.datos.Telefono;

                            txtDni.Value = usu.datos.Dni;

                          //  txtNacimiento.Value = usu.datos.Nacimiento.ToString("yyyy-MM-dd");


                            //  txtDni.Value = usu.datos.Dni.ToString();


                            /*
                             * txtNombre.Text = usu.DatosPersonales.Nombre;
                              txtApellido.Text = usu.DatosPersonales.Apellido;
                              txtDni.Text = usu.DatosPersonales.Dni.ToString();
                              txtFechaNacimiento.Text = usu.DatosPersonales.FechaNacimiento.ToString("yyyy-MM-dd");
                              txtGenero.Text = usu.DatosPersonales.Genero.ToString();
                              txtTelefono.Text = usu.DatosPersonales.Telefono.ToString();
                              txtEmail.Text = usu.DatosPersonales.Email;
                              txtDomicilio.Text = usu.DatosPersonales.Domicilio;
                            */
                        }
                        else
                        {
                            Response.Write("<script>alert('Usuario no encontrado.');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }

                /// OBTENEMOS EL USUARIO 
                int idu = Convert.ToInt32(Request.QueryString["IdUsuario"]);
                foreach (Usuario item in listaUsu)
                {
                    if (item.Id == idu)
                    {
                        seleccionado = item;
                    }
                }

                ///GUARDAMOS EN LA SESSION
                Session.Add("UsuarioSeleccionado", seleccionado);

                //// configuracion de accion 
                if (!seleccionado.Activo)
                {
                    btnLogico.Text = "Reactivar";
                }

            }
        }




        protected void btnInactivo_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = Convert.ToInt32(txtId.Text);
                UsuarioGestion usuario = new UsuarioGestion();
                Usuario usu = new Usuario();

                usu = (Usuario)Session["UsuarioSeleccionado"];

                if (usu.Activo == true)
                {
                    usuario.BajaLogica(usu);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    usuario.AltaLogica(usu);
                    Response.Redirect("Home.aspx");
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}




