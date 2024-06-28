using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class ModificarPersonal : System.Web.UI.Page
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
                            txtLegajo.Value = usu.Legajo.ToString();
                            txtNombrePersonal.Value = usu.Nombre;
                            txtApellido.Value = usu.Apellido;

                            txtEmail.Value = usu.Email;
                            txtDomicilio.Value = usu.Domicilio;
                            txtNacimiento.Value = usu.Nacimiento.ToString();
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

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    NombreUsuario = txtUsuario.Value,
                    Puesto = int.Parse(txtPuesto.Value),
                    Legajo = int.Parse(txtLegajo.Value),
                    Dni = int.Parse(txtDni.Value),
                    Nombre = txtNombrePersonal.Value,
                    Apellido = txtApellido.Value,
                    Nacimiento = Convert.ToDateTime((txtNacimiento.Value)),
                    Genero = ddlGenero.Value,
                    Telefono = int.Parse(txtTelefono.Value),
                    Email = txtEmail.Value,
                    Domicilio = txtDomicilio.Value
                };

                UsuarioGestion gestionUsuario = new UsuarioGestion();
                gestionUsuario.ModificarUsuario(nuevoUsuario);

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