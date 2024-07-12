<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="Reproduccion.aspx.cs" Inherits="CodeMentor.Reproduccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENEDOR PRINCIPAL -->
    <link href="../Content/Reproduccion.css" rel="stylesheet" />
    <div class="container mt-4">
        <div class="row">

            <h2 class="mb-3" id="curso-titulo"><%: CursoActual.Nombre %></h2>

            <p class="mb-4" id="videoDescription"><%: CursoActual.Descripcion %></p>
            <div class="col-md-8">

                <div class="ratio ratio-16x9 mb-4 video-container">
                    <asp:Literal ID="videoFrame" runat="server"></asp:Literal>
                </div>

                <div class="progress mt-4">
                    <div id="progressBar" class="progress-bar bg-info" role="progressbar" style="width: 0%;" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                </div>



            </div>

            <!-- UNIDADES Y CLASES -->
            <div class="col-md-4">
                <div class="accordion" style="background-color: #e5e5e517" id="acordeonClases">

                    <!-- FOREACH DE LISTA PARA CARGAR TODAS LAS UNIDADES DEL CURSO -->
                    <% 
                        int contador = 0;
                        foreach (var unidad in ListaUnidades)
                        {
                            var unidadId = "unidad" + unidad.IdUnidad;
                            bool valido = contador < 2; // logica para mostrar x cantidad desplegados
                            contador++;
                    %>

                    <div class="accordion-item">

                        <!-- ENCABEZADO DE ACORDEON: INDICA NUMERO Y NOMBRE DE UNIDAD -->
                        <h2 class="accordion-header">
                            <button class="accordion-button <%= valido ? "" : "collapsed" %>" type="button" data-bs-toggle="collapse" data-bs-target="#<%:unidadId%>" aria-expanded="<%= valido %>" aria-controls="<%:unidadId %>">
                                <%:unidad.Numero%>. <%:unidad.Nombre%>
                            </button>
                        </h2>

                        <!-- CUERPO DEL ACORDEON: INDICA LAS CLASES DE LA UNIDAD-->
                        <div id="<%:unidadId%>" class="accordion-collapse collapse <%= valido ? "show" : "" %>" data-bs-parent="#acordeonClases">
                            <div class="accordion-body" style="background-color: #e5e5e517">
                                <ul class="list-group">

                                    <!-- FOREACH DE LISTA PARA CARGAR TODAS LAS CLASES DE LA UNIDAD -->
                                    <%  foreach (var clase in ListarClases(unidad.IdUnidad))
                                        { %>
                                    <li class="list-group-item d-flex justify-content-between align-items-center">
                                        <div>
                                            <%: clase.Numero %>. <%: clase.Descripcion %>
                                        </div>
                                        <div class="d-flex align-items-center">

                                            <a href="Reproduccion.aspx?IdClase=<%:clase.IdClase %>" class="btn btn-link text-decoration-none text-reset" role="button">
                                                <img src="Imagenes/Iconos/youtube.png" alt="Icono" style="width: 30px; height: 30px;" />

                                            </a>
                                            <input class="form-check-input ms-2" type="checkbox" style="width: 30px; height: 30px;" value="" id="checkbox_<%: unidad.IdUnidad%>">
                                        </div>
                                    </li>
                                    <%}%>
                                </ul>
                            </div>

                        </div>
                    </div>
                    <%}%>
                </div>
            </div>
        </div>

        <%if (ListadoPreguntasRespuestas.Count!=0)
            {
        %>
        <div class="row col-8 mb-3" style="margin-top: 1%">
            <div class="d-flex justify-content-between align-items-center w-100">
                <div>
                    <p class="mb-0">Últimas Preguntas:</p>
                </div>
                <div>
                    <a class="btn btn-primary" href="PreguntasRespuestas.aspx?IdCurso=<%:CursoActual.IdCurso %>">Realizar Pregunta</a>
                    <a class="btn btn-secondary" href="PreguntasRespuestas.aspx?IdCurso=<%:CursoActual.IdCurso %>">Sección Preguntas y Respuestas</a>
                </div>

            </div>
        </div>
        <div class="row col-8" style="margin-bottom: 7%">

            <div class="list-group">

                <%foreach (var preg in ListadoPreguntasRespuestas)
                    { %>

                <div class="list-group-item" style="margin-bottom: 2%; background-color: #e5e5e517; border-radius: 15px; border: solid lightgrey 1px; font-weight: normal">
                    <div class="d-flex w-100 justify-content-between" style="margin-top: 0.8%; font-weight: normal">
                        <h5 class="mb-1"><%:preg.TituloPregunta %></h5>
                        <div class="mb-3">
                            <small><%:preg.NombreApellidoUser%></small>

                            <%if (!ObtenerRespuesta(preg.IdPregunta) && ViendoUsuarios)
                                { %>
                            <a href="PreguntaDetalle.aspx?Modificar=<%:preg.IdPregunta %>">
                                <img src="https://static.thenounproject.com/png/3082103-200.png" style="width: 30px; height: 30px" />
                            </a>

                            <% } %>
                        </div>
                    </div>
                    <p class="mb-1"><%:preg.CuerpoPregunta%></p>

                    <small><%:preg.FechaPregunta %></small>

                    <%if (ObtenerRespuesta(preg.IdPregunta))
                        {  %>
                    <div class="ml-4 mt-3">
                        <div class="card" style="border-radius: 15px">
                            <div class="card-body">
                                <p class="card-text"><%:preg.CuerpoRespuesta %></p>

                                <small class="text-muted">Respondido por : <%:Validaciones.Helper.ObtenerNombreAdmin() %> </small>
                                <small><%:preg.FechaRespuesta %></small>

                            </div>
                        </div>
                    </div>

                    <%}
                        else
                        {  %>
                    <div class="ml-4 mt-3">
                        <div class="card" style="border-radius: 15px">
                            <div class="card-body">
                                <h6 style="color: cornflowerblue">Consulta pendiente de Respuesta.</h6>

                            </div>
                        </div>
                    </div>
                    <%} %>
                </div>


                <% }

                %>
            </div>
        </div>
        <%}
            else
            {
        %>


         
    <h3>No existen preguntas en este curso. </h3>
                    <a class="btn btn-primary" style="margin-bottom:7%" href="PreguntasRespuestas.aspx?IdCursoNew=<%:CursoActual.IdCurso %>">Nueva Pregunta</a>


        <%} %>
    </div>


     

</asp:Content>
