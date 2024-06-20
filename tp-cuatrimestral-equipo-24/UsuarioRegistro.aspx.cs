using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                            txtLegajo.Value = usu.datos.Legajo.ToString();
                            txtNombrePersonal.Value = usu.datos.Nombre.ToString();
                            txtApellido.Value = usu.datos.Apellido;

                            txtEmail.Value = usu.datos.Email;
                            txtDomicilio.Value = usu.datos.Domicilio;
                            txtNacimiento.Value = usu.datos.Nacimiento.ToString();
                            ddlGenero.Value = usu.datos.Genero;
                            txtTelefono.Value = usu.datos.Telefono;

                            txtDni.Value = usu.datos.Dni.ToString();

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

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    NombreUsuario = txtUsuario.Value, // Asumiendo que tienes un TextBox para el nombre de usuario
                    //Clave = txtClave.Text, // Asumiendo que tienes un TextBox para la clave
                    //Puesto = int.Parse(txtPuesto.value), // Convierte el texto a int, asumiendo que tienes un TextBox para el puesto
                    //Activo = chkActivo.Checked, // Asumiendo que tienes un CheckBox para el estado activo
                    datos = new DatosPersonales
                    {
                        Legajo = int.Parse(txtLegajo.Value),
                        Dni = txtDni.Value,
                        Nombre = txtNombrePersonal.Value,
                        Apellido = txtApellido.Value,
                        Nacimiento = txtNacimiento.Value,
                        //Genero = ,
                        Telefono = txtTelefono.Value,
                        Email = txtEmail.Value,
                        Domicilio = txtDomicilio.Value
                    }
                };

                UsuarioGestion gestionUsuario = new UsuarioGestion();
                gestionUsuario.AgregarUsuario(nuevoUsuario);

                // Redirigir a otra página o mostrar un mensaje de éxito
                Response.Redirect("Home.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }


    }
}




