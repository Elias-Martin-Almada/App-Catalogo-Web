using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using controlador;

namespace Catálogo_Web
{
    public partial class Login : System.Web.UI.Page
    {
        // NOTAS:
        // ACCESO A LAS PANTALLAS:      CLASE "Seguridad"   
        // Home: Todos los Usuarios     Metodos:
        // Listado: Solo Admin          sessionActiva(Usuario usuario)
        // Mi Perfil: Logueado          esAdmin(Usuario usuario)
        // Favoritos: Logueado
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioDatos datos = new UsuarioDatos();
            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPassword.Text;
                if (datos.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o Contraseña incorrectos");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}