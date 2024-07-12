<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="InicioRegistrado.aspx.cs" Inherits="CodeMentor.AspxUsuario.InicioRegistrado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BusquedaCursos" runat="server">
    <asp:Panel runat="server" ID="PanelBusquedaCursos" CssClass="col">
        <div class="d-flex justify-content-center">
            <div class="d-flex">
                <div class="input-group" style="background: white; border-radius: 20px">
                    <asp:TextBox runat="server" Placeholder="Buscar cursos" CssClass="form-control" ID="TxtFiltroCursos" OnTextChanged="TxtFiltroCursos_TextChanged" Style="border: none; background: white" />
                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn " OnClick="btnSearch_Click">
                        <asp:Image ID="imgSearch" runat="server" ImageUrl="https://cdn.icon-icons.com/icons2/774/PNG/512/search_icon-icons.com_64617.png"
                            AlternateText="Search" Style="width: 26px; height: 26px;" />
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/InicioRegis.css" rel="stylesheet" />

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

    <div class="container " style="margin-top: 1.7%">
        <%if (ListaCursosInscripto.Count > 0)
            {  %>
        <!-- TITULO PRINCIPAL -->
        <div class="text-center mb-5">
            <div class="d-flex justify-content-center align-items-center">
                <h1 class="display-4 font-weight-bold text-dark mb-0">CONTINUAR APRENDIENDO</h1>
                <img src="Imagenes/Iconos/CandadoAbiertoLlave.png" class="imgIcon ml-3" style="width: 50px; height: 50px; margin-left: 2%" />
            </div>
        </div>



        <!-- CURSOS SIN COMPLETAR DEL USUARIO -->
        <div class="row row-cols-1 row-cols-md-4 g-4">
            <% foreach (var curso in ListaCursosInscripto)
                { %>
            <div class="col mb-4">
                <div class="card h-100">
                    <div class="card-img-top-wrapper" style="border-bottom: solid 0.5px lightgrey">
                        <% ImgCurso.ImageUrl = curso.UrlPortadaCarpeta; %>
                        <asp:Image ID="ImgCurso" runat="server" class="card-img-top img-cuadrada" alt="Imagen del curso" />
                    </div>
                    <div class="card-body text-center">
                        <h5 class="card-title font-weight-bold"><%:curso.Nombre %></h5>
                        <a href="Reproduccion.aspx?idCurso=<%:curso.IdCurso %>" class="btn btn-primary btn-lg mt-3">Continuar Curso</a>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
        <%}%>

        <hr class="lineaBonita">
        <%if (ListaNoInscripto.Count > 0)
            {  %>

        <div class="text-center mb-3">
            <div class="d-flex justify-content-center align-items-center">
                <h1 class="display-4 font-weight-bold text-dark mb-0">ADQUIRIR CURSOS</h1>
                <img src="Imagenes/Iconos/CandadoCerrado.png" class="imgIcon ml-3" style="width: 50px; height: 50px; margin-left: 2%" />
            </div>
        </div>

        <div class="row row-cols-1 row-cols-md-4 g-4">
            <% foreach (var curso in ListaNoInscripto)
                { %>
            <div class="col mb-4">
                <div class="card h-100">
                    <div class="card-img-top-wrapper">
                        <% ImgNoRegis.ImageUrl = curso.UrlPortadaCarpeta; %>
                        <asp:Image ID="ImgNoRegis" runat="server" class="card-img-top img-cuadrada" alt="Imagen del curso" />
                    </div>
                    <div class="card-body text-center">
                        <h5 class="card-title font-weight-bold"><%:curso.Nombre %></h5>
                        <a href="DetalleCurso.aspx?idCurso=<%:curso.IdCurso %>" class="btn btn-primary btn-lg mt-3">Ver detalles</a>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
        <%}%>
    </div>


</asp:Content>

