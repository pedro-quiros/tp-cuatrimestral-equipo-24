using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Text.RegularExpressions;

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
                            txtPuesto.Value = usu.Puesto.ToString();
                            txtLegajo.Value = usu.Legajo.ToString();
                            txtNombrePersonal.Value = usu.Nombre;
                            txtApellido.Value = usu.Apellido;

                            txtEmail.Value = usu.Email;
                            txtDomicilio.Value = usu.Domicilio;
                            txtNacimiento.Text = usu.Nacimiento.ToString("yyyy-MM-dd");
                            ddlGenero.Value = usu.Genero;
                            txtTelefono.Value = usu.Telefono.ToString();

                            txtDni.Value = usu.Dni.ToString();

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
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Value))
                {
                    Response.Write("<script>alert('Por favor, complete el nombre del usuario.');</script>");
                }
                if (string.IsNullOrEmpty(txtNombrePersonal.Value))
                {
                    Response.Write("<script>alert('El Nombre del empleado es obligatorio.');</script>");
                }
                if (string.IsNullOrEmpty(txtApellido.Value))
                {
                    Response.Write("<script>alert('El Apellido del empleado es obligatorio.');</script>");
                }
                if (string.IsNullOrEmpty(txtDni.Value))
                {
                    Response.Write("<script>alert('El DNI del empleado es obligatorio.');</script>");
                }
                if (string.IsNullOrEmpty(txtEmail.Value))
                {
                    Response.Write("<script>alert('El Gmail del empleado es obligatorio.');</script>");
                }
                if (Regex.IsMatch(txtTelefono.Value, @"\D"))
                {
                    Response.Write("<script>alert('Ingresar solo numeros en el telefono');</script>");
                }
                if (Regex.IsMatch(txtPuesto.Value, @"\D"))
                {
                    Response.Write("<script>alert('Ingresar solo un numero en el Puesto');</script>");
                }
                if (Regex.IsMatch(txtDni.Value, @"\D"))
                {
                    Response.Write("<script>alert('Ingresar solo numeros en el DNI');</script>");
                }


                Usuario nuevoUsuario = new Usuario();

                    nuevoUsuario.Id = int.Parse(txtId.Text);
                    nuevoUsuario.NombreUsuario = txtUsuario.Value;
                    nuevoUsuario.Clave = txtClave.Value;    
                    nuevoUsuario.Puesto = int.Parse(txtPuesto.Value);
                    nuevoUsuario.Legajo = int.Parse(txtLegajo.Value);
                    nuevoUsuario.Dni = int.Parse(txtDni.Value);
                    nuevoUsuario.Nombre = txtNombrePersonal.Value;
                    nuevoUsuario.Apellido = txtApellido.Value;
                    nuevoUsuario.Nacimiento = DateTime.Parse((txtNacimiento.Text));
                    nuevoUsuario.Genero = ddlGenero.Value;
                    nuevoUsuario.Telefono = int.Parse(txtTelefono.Value);
                    nuevoUsuario.Email = txtEmail.Value;
                    nuevoUsuario.Domicilio = txtDomicilio.Value;

                    UsuarioGestion gestionUsuario = new UsuarioGestion();
                if (Regex.IsMatch(txtNombrePersonal.Value, @"^[a-zA-Z]+$") && Regex.IsMatch(txtApellido.Value, @"^[a-zA-Z]+$"))
                {
                    gestionUsuario.ModificarUsuario(nuevoUsuario);
                    Response.Write("<script>alert('Usuario Modificado.');</script>");
                    Response.Redirect("Home.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Los campos Nombre y Apellido no pueden contener numeros');</script>");
                }

                // Redirigir a otra página o mostrar un mensaje de éxito
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Value))
                {
                    Response.Write("<script>alert('Por favor, complete el nombre del usuario.');</script>");
                }
                if (string.IsNullOrEmpty(txtNombrePersonal.Value))
                {
                    Response.Write("<script>alert('El Nombre del empleado es obligatorio.');</script>");
                }
                if (string.IsNullOrEmpty(txtApellido.Value))
                {
                    Response.Write("<script>alert('Por favor, El Apellido del empleado es obligatorio.');</script>");
                }
                if (string.IsNullOrEmpty(txtDni.Value))
                {
                    Response.Write("<script>alert('Por favor, El DNI del empleado es obligatorio.');</script>");
                }
                if (string.IsNullOrEmpty(txtEmail.Value))
                {
                    Response.Write("<script>alert('Por favor, El Gmail del empleado es obligatorio.');</script>");
                }
                if (Regex.IsMatch(txtTelefono.Value, @"\D"))
                {
                    Response.Write("<script>alert('Ingresar solo numeros en el telefono');</script>");
                }
                if (Regex.IsMatch(txtPuesto.Value, @"\D"))
                {
                    Response.Write("<script>alert('Ingresar solo un numero en el Puesto');</script>");
                }
                if (Regex.IsMatch(txtDni.Value, @"\D"))
                {
                    Response.Write("<script>alert('Ingresar solo numeros en el DNI');</script>");
                }
                Usuario nuevoUsuario = new Usuario
                {
                    NombreUsuario = txtUsuario.Value,
                    Clave = txtClave.Value,
                    Puesto = int.Parse(txtPuesto.Value),
                    Activo = true,
                    Legajo = int.Parse(txtLegajo.Value),
                    Dni = int.Parse(txtDni.Value),
                    Nombre = txtNombrePersonal.Value,
                    Apellido = txtApellido.Value,
                    Nacimiento = DateTime.Parse((txtNacimiento.Text)),
                    Genero = ddlGenero.Value,
                    Telefono = int.Parse(txtTelefono.Value),
                    Email = txtEmail.Value,
                    Domicilio = txtDomicilio.Value
                };

                UsuarioGestion gestionUsuario = new UsuarioGestion();
                if(Regex.IsMatch(txtNombrePersonal.Value, @"^[a-zA-Z]+$") && Regex.IsMatch(txtApellido.Value, @"^[a-zA-Z]+$"))
                {
                    gestionUsuario.AgregarUsuario(nuevoUsuario);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Los campos Nombre y Apellido no pueden contener numeros');</script>");
                }
                // Redirigir a otra página o mostrar un mensaje de éxito
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

    }
}




