<%@ Page Title="Home
    "
    Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CodeMentor.AspxUsuario.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="BusquedaCursos">
    <!-- FILTRO PARA CURSOS UBICADO EN EL HEADER!-->
    <asp:Panel runat="server" ID="PanelBusquedaCursos" CssClass="col">
        <div class="d-flex justify-content-center">
            <div class="d-flex">
                <div class="input-group" style="background: white; border-radius: 20px">
                    <asp:TextBox runat="server" Placeholder="Buscar cursos" CssClass="form-control" OnTextChanged="TxtFiltroCursos_TextChanged" ID="TxtFiltroCursos" Style="border: none; background: white" />
                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn " OnClick="btnSearch_Click">
                        <asp:Image ID="imgSearch" runat="server" ImageUrl="https://cdn.icon-icons.com/icons2/774/PNG/512/search_icon-icons.com_64617.png"
                            AlternateText="Search" Style="width: 26px; height: 26px;" />
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../Content/InicioNoRegis.css" rel="stylesheet" />
    <div id="customCarousel" class="carousel slide mb-5" data-bs-ride="carousel">

        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://i.ibb.co/PgHcJ6H/banners.jpg" class="d-block w-100" alt="First slide">
            </div>
            <div class="carousel-item">
                <img src="https://i.ibb.co/1ZPsL2t/banners-2.jpg" class="d-block w-100" alt="Second slide">
            </div>
            <div class="carousel-item">
                <img src="https://i.ibb.co/vjYjBRj/banners-3.jpg" style="height: 400px" class="d-block w-100" alt="Third slide">
            </div>
        </div>
        <a class="carousel-control-prev" href="#customCarousel" role="button" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </a>
        <a class="carousel-control-next" href="#customCarousel" role="button" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </a>
    </div>

    <div class="container mt-5">
        <div class="text-center heading-section">
            <div class="background">
                <p class="lead">Descubre nuestros cursos y mejora tus habilidades</p>
                <p class="lead text-muted">Aprende nuevas habilidades y expande tus conocimientos con nuestros programas cuidadosamente diseñados.</p>
            </div>
        </div>
        <div class="row">
            <% foreach (var curso in ListaCursos)
                { %>
            <div class="col-md-3 mb-5">
                <div class="card h-100 shadow-sm position-relative">
                    <div class="card-img-top-wrapper position-relative">

                        <% ImgCurso.ImageUrl = curso.UrlPortadaCarpeta; %>
                        <asp:Image ID="ImgCurso" runat="server" class="card-img-top img-cuadrada" alt="Imagen del curso " />

                        <div class="overlay d-flex align-items-center justify-content-center">
                            <a href="DetalleCurso.aspx?idCurso=<%:curso.IdCurso %>" class="btn btn-light">Ver curso</a>
                        </div>
                    </div>
                    <div class="card-body text-center">
                        <h5 class="card-title font-weight-bold"><%:curso.Nombre %></h5>
                        <p class="card-text text-muted mb-4">Aprende más sobre <%:curso.Nombre %> con nuestros expertos.</p>
                        <a href="Registrar.aspx" class="btn btn-primary btn-block">¡Inscríbete Ahora!</a>
                    </div>
                </div>
            </div>
            <% } %>
        </div>


    </div>


</asp:Content>
