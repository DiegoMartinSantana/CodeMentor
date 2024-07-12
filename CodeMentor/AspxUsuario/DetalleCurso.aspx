<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="DetalleCurso.aspx.cs" Inherits="CodeMentor.AspxUsuario.DetalleCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <link href="../Content/DetalleCurso.css" rel="stylesheet" />

        <!----------------------- DETALLES DEL CURSO E INSCRIPCIÓN -------------------------->
        <div class="row justify-content-center">
            <div class="col-md-7 mb-4">
                <div class="curso-detalles p-4 rounded ">
                    <div class="curso-imagen-wrapper mb-4 text-center">

                        <% ImgCurso.ImageUrl = CursoActual.UrlPortadaCarpeta;  %>
                        <asp:Image ID="ImgCurso" runat="server" class="curso-imagen rounded" alt="Imagen del curso" />

                    </div>
                    <div class="curso-info">
                        <div class="curso-titulo mb-3 text-center">
                            <h2><%:CursoActual.Nombre %></h2>
                        </div>
                        <div class="curso-descripcion mt-3">
                            <h4>Descripción:</h4>
                            <p><%:CursoActual.Descripcion %></p>
                        </div>
                        <div class="curso-requisitos mt-3">
                            <h4>Requisitos:</h4>
                            <p><%:CursoActual.Requisitos %></p>
                        </div>
                        <div class="curso-costo-inscripcion d-flex justify-content-between align-items-center mt-3">
                            <div class="curso-costo mr-3">
                                <h4 style="font-weight: bold">Costo:</h4>
                                <p>$<%:CursoActual.Importe.ToString("F2") %></p>
                            </div>
                            <div class="curso-inscripcion text-left" style="margin-right: 10%">
                                <a href="Guia.aspx?ComoInscribirse=<%:CursoActual.IdCurso%>" class="btn btn-primary btn-lg mt-2">
                                    <img src="Imagenes/Iconos/llaveBorde.png" style="width: 30px; height: 30px; margin-right: 5px" />
                                    Inscribirme

                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!----------------------- UNIDADES Y CLASES -------------------------->
            <div class="col-md-5 mb-4">
                <div class="accordion" id="accordionExample">
                    <% foreach (var unidad in ListaUnidades)
                        { %>
                    <% var unidadId = "unidad" + unidad.IdUnidad; %>
                    <div class="accordion-item mb-2">
                        <h2 class="accordion-header" id="heading<%:unidadId %>">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#<%:unidadId %>" aria-expanded="false" aria-controls="<%:unidadId %>">
                                <%:unidad.Numero %>. <%:unidad.Nombre %>
                            </button>
                        </h2>
                        <div id="<%:unidadId %>" class="accordion-collapse collapse" aria-labelledby="heading<%:unidadId %>" data-bs-parent="#accordionExample">
                            <div class="accordion-body">
                                <ul class="list-group">
                                    <% if (ClasesPorUnidad.ContainsKey(unidad.IdUnidad))
                                        {
                                            foreach (var clase in ClasesPorUnidad[unidad.IdUnidad])
                                            { %>
                                    <li class="list-group-item rounded mb-2" style="background-color: white"><%:clase.Numero %>. <%:clase.Descripcion %></li>
                                    <% }
                                        } %>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <% } %>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
