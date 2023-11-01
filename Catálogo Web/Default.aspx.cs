using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controlador;
using dominio;

namespace Catálogo_Web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            ListaArticulo = datos.listarConSP();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            // obtengo el ID del Articulo.
            int idArticulo = int.Parse(((Button)sender).CommandArgument);
            // Obtener el ID del usuario actual, por ejemplo, desde la sesión o cualquier otro método.
            if (Session["usuario"] != null)
            {
                Usuario user = (Usuario)Session["usuario"];
                int idUsuario = user.Id;

                FavoritosDatos favoritosDatos = new FavoritosDatos();
                favoritosDatos.AgregarFavorito(idUsuario, idArticulo);
                Response.Redirect("FavoritosWeb.aspx");
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}