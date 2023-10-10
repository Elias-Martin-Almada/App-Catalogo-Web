using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controlador;


namespace Catálogo_Web
{
    public partial class CatalogoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            dgvArticulos.DataSource = datos.listarConSP();
            dgvArticulos.DataBind();
        }
    }
}