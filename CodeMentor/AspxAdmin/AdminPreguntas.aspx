<%@ Page Title="SeccionPreguntas 
    
    "
    Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminPreguntas.aspx.cs" Inherits="CodeMentor.AdminAspx.AdminPreguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/AdminPreguntas.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" />
    <div class="container mt-5" style="background:white;padding:1.7%;margin-bottom:1%; border-radius:20px">
        <div >

        <h2 class="mb-4" style="margin-left: 20%;">Administración de Preguntas y Respuestas</h2>

        <asp:Panel runat="server" ID="PanelNavegacion">

            <nav class="nav nav-pills " style="margin-left: 20%; margin-bottom: 3%">

                <asp:Button Text="Sin Responder" CssClass=" nav-item  Black btn btn-outline-dark" Style="margin-left: 1%;" runat="server" ID="BtnPreguntasSinResponder" OnClick="BtnPreguntasSinResponder_Click" />

                <a class="dropdown-toggle Black btn btn-outline-dark" data-toggle="dropdown" style="margin-left: 1%" role="button" aria-haspopup="true" aria-expanded="false">Por Cursos </a>
                <div class="dropdown-menu">
                    <asp:Repeater runat="server" ID="RptCursos">
                        <ItemTemplate>

                            <asp:Button Text='<%#Eval("Nombre")%>' CssClass="dropdown-item " runat="server" ID="BtnSeleccionCurso" CommandName="ObtenerCurso"
                                CommandArgument='<%# Eval("IdCurso") %>' OnClick="BtnSeleccionCurso_Click" />

                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                <asp:Button Text="Ultima Semana" CssClass=" nav-item  Black btn btn-outline-dark" Style="margin-left: 1%;" runat="server" ID="BtnUltimaSemana" OnClick="BtnUltimaSemana_Click" />
                <asp:Button Text="Ver Todas" CssClass=" nav-item  Black btn btn-outline-dark" Style="margin-left: 1%;" runat="server" ID="BtnVerTodas" OnClick="BtnVerTodas_Click" />

            </nav>

        </asp:Panel>
        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" ID="PreguntasRespuestasAdmin">
                    <!-- SIMPLEMENTE CAMBIO EL CONTENIDO DE LA LISTA!-->
                    <div class="row col-8" style="margin-left: 20%; margin-bottom: 7%">

                        <div class="list-group">

                            <%foreach (var preg in ListadoPreguntasRespuestasAdmin)
                                { %>

                            <div class="list-group-item" style="margin-bottom: 2%; border-radius: 15px; border: solid lightgrey 1px;">
                                <div class="d-flex w-100 justify-content-between" style="margin-top: 0.8%">
                                    <h5 class="mb-1"><%:preg.TituloPregunta %></h5>
                                    <div class="mb-3">
                                        <small><%:preg.NombreApellidoUser%></small>
                                        <%if (preg.IdRespuesta != null)
                                        { %>
                                        <a href="AdminRespuesta.aspx?IdModificar=<%:preg.IdPregunta %>">
                                            <img src="https://static.thenounproject.com/png/3082103-200.png" style="width: 30px; height: 30px" />
                                        </a>
                                        <%} %>
                                    </div>
                                </div>
                                <p class="mb-1"><%:preg.CuerpoPregunta%></p>

                                <small><%:preg.FechaPregunta %></small>

                                <%if (preg.IdRespuesta != null)
                                    {  %>
                                <div class="ml-4 mt-3">
                                    <div class="card" style="border-radius: 15px">
                                        <div class="card-body">
                                            <p class="card-text"><%:preg.CuerpoRespuesta %></p>

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

                                            <asp:TextBox runat="server" ID="TxtRespuesta" CssClass=" form-control form-text" PlaceHolder="Responda" TextMode="MultiLine" Rows="5" />
                                            <h6 class="form-text" style="color: cornflowerblue">Consulta pendiente de Respuesta.</h6>
                                        </div>
                                    </div>
                                    <div class="mb-3" style="margin-top: 1%">
                                        <a href="AdminRespuesta.aspx?Id=<%:preg.IdPregunta %>" class="btn btn-primary">Responder</a>

                                    </div>
                                </div>
                                <%} %>
                            </div>

                            <% } %>
                            <!-- validar aca si no existen preguntas todavia-->

                        </div>
                    </div>
                    <%if (ListadoPreguntasRespuestasAdmin.Count == 0 || ListadoPreguntasRespuestasAdmin == null)
                        {  %>
                    <div class="mb-3" style="margin-left: 20%;">
                        <h3>No hay preguntas en esta Seccion o Curso.</h3>
                    </div>

                    <%} %>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
