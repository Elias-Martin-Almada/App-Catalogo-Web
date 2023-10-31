<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Catálogo_Web.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalles</h1>

    <style>
        .titulo{
            font-size: 25px;
            font-weight:600;
        }
        .aumentar-texto {
            font-size: 20px; 
        }
        /*.negrita{
            font-size: 20px;
            font-weight: 400;
        }
        .negta{
            font-size: 22px;
            font-weight: 500;
        }
        .imag{
            width:350px;
            height:350px;
            transition:0.6s;
        }*/
        body{
            background-image:url("fondoBody2.jpg");
        }
    </style>

    <asp:ScriptManager runat="server" ID="scriptManager5" />
    <div class="card mb-3" style="max-width: 900px;">
        <div class="row g-0">
            <div class="col-md-4">
                <%--<img src="..." class="img-fluid rounded-start" alt="...">--%>
                <asp:Image ID="imgArticulo" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                    style="max-width: 100%; height: auto;" runat="server" />
            </div>
            <div class="col-md-8">
                <div class="card-body">
                    <%--<h5 class="card-title">Card title</h5>--%>
                    <div class="mb-3">
                        <asp:Label ID="lblNombre" CssClass="titulo" runat="server" />
                    </div>
                    <div class="mb-1">
                        <asp:Label ID="lblMarca" CssClass="aumentar-texto" runat="server" />
                    </div>
                    <div class="mb-1">
                        <asp:Label ID="lblCategoria" CssClass="aumentar-texto" runat="server" />
                    </div>
                    <div class="mb-1">
                        <asp:Label ID="lblPrecio" CssClass="aumentar-texto" runat="server" />
                    </div>
                    <hr />
                    <div class="mb-4">
                        <asp:Label ID="lblDescripcion" runat="server" />
                    </div>
                    <div class="mb-4">
                        <a href="">Realizar pedido</a>
                    </div>
                    <%--<p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
