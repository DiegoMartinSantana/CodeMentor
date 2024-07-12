<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="MisCursos.aspx.cs" Inherits="CodeMentor.AspxUsuario.MisCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/MisCursos.css" rel="stylesheet" />
    <!----------------------- CONTENEDOR PRINCIPAL -------------------------->
    <div class="container bienvenida">

        <!---------------------- BIENVENIDA AL USUARIO ---------------------->

        <div class="container">
            <div class="row justify-content-center bienvenida-row" style="background-color:white;">
                <div class="col text-center">
                    <h2 class="bienvenida-titulo" style="color: black">¡Siga Aprendiendo <%: InfoUser.Nombre.ToUpperInvariant() %>!</h2>
                </div>
            </div>
        </div>

        <% if (CursosInscripto != null)
            { %>

        <!------------------ MOSTRAR CURSOS INSCRIPTOS ------------------->

        <div class="cursando">
            <div class="titulo-cursos">
                <h3 class="cursando-h3">Mis cursos:</h3>
            </div>
            <div class="row row-cols-1 row-cols-md-4 g-4">
                <% foreach (var curso in CursosInscripto)
                    { %>
                <div class="col mb-4">
                    <% if (FinalizoCurso(curso.IdCurso))
                        {

                    %>
                    <div class="card h-100 card-completa" style="margin-bottom: 0; border-radius: 22px">
                        <%}
                            else
                            {   %>
                        <div class="card  card-completa" style="margin-bottom: 0; border-radius: 22px">


                            <%} %>
                            <div class="card-img-top-wrapper" style="border-bottom: solid 0.3px lightgrey">
                                <% ImageCurso.ImageUrl = curso.UrlPortada; %>
                                <asp:Image ID="ImageCurso" class="card-img-top img-cuadrada" alt="Imagen del Curso" runat="server" />
                            </div>
                            <div class="card-body text-center body-card">
                                <div class="">
                                    <div class="curso-titulo-container">
                                        <h5 class="curso-titulo"><%: curso.Nombre %></h5>
                                    </div>
                                </div>
                                <div class="progress-section">
                                    <% BarraProgreso(curso.IdCurso);
%>
                                    <p>Progreso</p>
                                    <div class="progress">
                                        <div class="progress-bar" role="progressbar" runat="server" id="BarraProgresoCurso" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <p runat="server" id="pProgreso"></p>
                                </div>
                                <div class="col">
                                    <a href="Reproduccion.aspx?IdCurso=<%:curso.IdCurso%>" class="btn btn-Card mb-2" style="width: 100%; background-color: #66b3ff; color: white;">Ir al Curso</a>
                                    <% if (FinalizoCurso(curso.IdCurso))
                                        {  %>
                                    <div>
                                        <a href="Emitir.aspx?IdCurso=<%:curso.IdCurso %>" class="btn btn-certificado mb-3">
                                            <img src="Imagenes/Iconos/Certificado.png" alt="Certificado" class="certificado-icon" />
                                            Emitir Certificado
                                        </a>
                                    </div>
                                    <%} %>
                                </div>
                            </div>
                        </div>
                </div>
                <% }
                %>
            </div>
        </div>
        </div>
    </div>


    <% }
        else
        { %>

    <!------------------ SIN CURSOS INSCRIPTOS ------------------->

    <div class="row col cursando text-center">
        <div class="mb-3">
            <h3>No se ha inscripto a ningún curso.</h3>
        </div>
        <div class="mb-3">
            <a href="InicioRegistrado.aspx" class="btn btn-primary">Ver Cursos disponibles</a>
        </div>
    </div>
    <% } %>
</asp:Content>
