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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {   
                // Configuracion inicial de la pantalla.
                if (!IsPostBack)
                {
                    MarcaDatos datosMarca = new MarcaDatos();
                    List<Marca> listaMarca = datosMarca.listarMarcas();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    CategoriaDatos datosCat = new CategoriaDatos();
                    List<Categoria> listaCat = datosCat.listarCategorias();
                    ddlCategoria.DataSource = listaCat;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }

                // Configuracion si estamos Modificando.
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                // Pregunto por el Post, porque al Modificar me recarga y pisa la info.
                if (id != "" && !IsPostBack) 
                {
                    ArticuloDatos datos = new ArticuloDatos();
                    //List<Articulo> lista = datos.listarArticulos(id);     // Lista con un solo Art.
                    //Articulo seleccionado = lista[0];
                    Articulo seleccionado = (datos.listarArticulos(id))[0]; // Misma lista, mas corta. 

                    // Pre cargar todos los campos.
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    // Precarga Imagen.
                    txtUrlImagen.Text = seleccionado.UrlImagen;
                    txtUrlImagen_TextChanged(sender, e);
                    // Pre cargar los desplegables.
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloDatos datos = new ArticuloDatos();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtUrlImagen.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    // Importante! Le paso el Id para modificar, porque el objeto (nuevo) no lo tiene, porque lo creo en el Click.
                    nuevo.Id = int.Parse(txtId.Text); 
                    datos.modificarConSP(nuevo);
                }
                else
                {
                    datos.agregarConSP(nuevo);
                }

                Response.Redirect("ArticulosLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }
    }
}