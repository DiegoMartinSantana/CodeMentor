<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="BackOffice.aspx.cs" Inherits="CodeMentor.BackOffice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <!-- biblioteca iconos fonts awesome-->
    <div class="container">
        <div class="row" style="margin-top: 3%">
            <div class="jumbotron">
                <h1 class="display-4">¡Bienvenido Admin!</h1>
                <p class="lead">Aquí podrás visualizar y administrar todo el contenido de la plataforma.</p>
                <hr class="my-4">
                <p>Como administrador, tienes acceso a varias herramientas y funcionalidades para gestionar usuarios, cursos, y contenido.</p>
                <p>Revisa y responde a las preguntas de los usuarios, actualiza la información de los cursos, y supervisa el rendimiento de la plataforma.</p>
            </div>
        </div>

        <div class="row" style="margin-top: 2.5%">
            <div class="col-6 mb-3">
                <!-- Cantidad de inscriptos Total  -->
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <div class="d-flex justify-content-between">
                            <div>
                                <h5 class="card-title">Total de Inscripciones</h5>
                                <asp:Label CssClass="card-text display-4" ID="LblCantInscriptos" runat="server" />
                                <!-- display-4 = h4 pero mas grande-->
                            </div>
                            <div class="align-self-center">
                                <i class="fas fa-users fa-4x"></i>
                                <!-- icono!-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-6 mb-3">
                <!-- Ultima reseña  -->
                <div class="card text-white bg-success">

                    <div class="card-body">
                        <div class="d-flex justify-content-between">
                            <div>
                                <h5 class="card-title">Última Reseña </h5>

                                <p class="card-text">"<%:UltimaReseña.Descripcion %>"</p>
                                <small><%:UltimaReseña.Nombre_Apellido%></small>
                                <small> ,<%:UltimaReseña.NombreCurso %></small>
                                <small> - <%:UltimaReseña.FechaReseña.ToString("dd/MM/yyyy")%></small>

                            </div>
                        <div class="align-self-center" style="margin:1%">
                            <i class="fas fa-comments fa-4x"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="margin-top: 2.5%">
        <div class="col-6  mb-3">
            <!--Ultimo Curso añadido -->
            <div class="card text-white bg-info">
                <div class="card-body">
                    <div class="d-flex justify-content-between">
                        <div>
                            <h5 class="card-title">Último Curso Añadido</h5>
                            <p class="card-text"><%:UltimoCurso.Nombre %></p>
                            <small>Publicado el: <%:UltimoCurso.FechaCreacion.ToString("dd/MM/yyyy")%></small>
                        </div>
                        <div class="align-self-center">
                            <i class="fas fa-book-open fa-4x"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-6  mb-3">
            <!--Total de certificaciones emitidas -->
            <div class="card text-white bg-warning">
                <div class="card-body">
                    <div class="d-flex justify-content-between">
                        <div>
                            <h5 class="card-title">Certificaciones Emitidas</h5>
                            <asp:Label ID="LblCantCertificados" CssClass="card-text display-4" runat="server" />
                        </div>
                        <div class="align-self-center">
                            <i class="fas fa-award fa-4x"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>


