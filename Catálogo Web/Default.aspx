<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catálogo_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style> 
        body{
            background-image:url("fondoBody2.jpg");
        }
    </style>
    <h1>Hola!</h1>
    <p>Este es tu Catálogo</p>

    <%--<div class="row row-cols-1 row-cols-md-3 g-4">
        <%  // C# Abre
            foreach (dominio.Articulo articulo in ListaArticulo)  // Repite la cantidad de Articulos que tenga DB.
            {
        %>  
                <div class="col">
                    <div class="card">
                        <img src="<%: articulo.UrlImagen %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: articulo.Nombre %></h5>
                            <p class="card-text"><%: articulo.Descripcion %></p>
                            <a href="DetalleArticulo.aspx?=id<%: articulo.Id %>">Ver Detalle</a> 
                        </div>
                    </div>
                </div> 
        <%  // C# Cierra
            }
        %>         
    </div>--%>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="background-color:lightgray; margin: 15px;">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <div style="display: flex; justify-content: center;">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            </div>
                            <%--<p class="card-text"><%#Eval("Descripcion") %></p>--%>
                             <div style="display: flex; justify-content: center;">
                                <a href="DetalleArticulo.aspx?id=<%#Eval("id") %>" class="btn btn-custom-azul" style="margin-right: 10px">Ver Detalle</a>
                                <%--<a href="FavoritosWeb.aspx?id=<%#Eval("id") %>" class="btn btn-custom-azul">Favoritos+</a>--%>
                             </div>
                            <%--<asp:Button Text="Ejemplo" CssClass="btn  btn-custom-azul" ID="btnEjemplo" OnClick="btnEjemplo_Click" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" runat="server"  />--%>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
