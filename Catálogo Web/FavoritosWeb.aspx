<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FavoritosWeb.aspx.cs" Inherits="Catálogo_Web.FavoritosWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>favoritos</h2>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="background-color:lightgray; margin: 15px; max-width: 200px;">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <div style="display: flex; justify-content: center;">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            </div>
                             <div style="display: flex; justify-content: center;">
                                <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-custom-azul" style="margin-right: 10px">Ver Detalle</a>
                             </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
