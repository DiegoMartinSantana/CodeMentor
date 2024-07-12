<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminReseñas.aspx.cs" Inherits="CodeMentor.AspxAdmin.AdminReseñas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../Content/ReseñasStyle.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" />
    <div class="container">
        <h1>Reseñas de Cursos</h1>

        <div class="filter-container">
            <div style="margin-left: 3%">
                <a class="form-label dropdown-toggle btn btn-lg" id="ToggleCursos" runat="server" data-toggle="dropdown" style="margin-left: 1%; border: solid 0.5px grey" role="button" aria-haspopup="true" aria-expanded="false">Buscar por Curso </a>
                <div class="dropdown-menu">
                    <asp:Repeater runat="server" ID="RptCursos">
                        <ItemTemplate>
                            <asp:Button Text='<%#Eval("Nombre")%>' CssClass="dropdown-item form-label  btn btn-lg" runat="server" ID="BtnSeleccionCurso" OnClick="BtnSeleccionCurso_Click" CommandName="ObtenerCurso"
                                CommandArgument='<%# Eval("IdCurso") %>' />
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
            <div>

                <a class="form-label dropdown-toggle btn btn-lg" id="ToggleFiltros" runat="server" data-toggle="dropdown" style="margin-left: 1%; border: solid 0.5px grey" role="button" aria-haspopup="true" aria-expanded="false">Filtrar por Puntuación</a>
                <div class="dropdown-menu">
                    <asp:Repeater runat="server" ID="RptFiltroPuntuacion">
                        <ItemTemplate>
                            <asp:Button Text='<%#Eval("NombreFiltro")%>' CssClass="dropdown-item form-label  btn btn-lg" runat="server" ID="BtnSeleccionFiltro" OnClick="BtnSeleccionFiltro_Click" CommandName="ObtenerFiltro"
                                CommandArgument='<%# Eval("IdFiltro") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div style="margin-right: 5%">
                <asp:Button Text="Todas" CssClass="form-label  btn btn-lg" runat="server" Style="margin-left: 1%; border: solid 0.5px grey" ID="BtnTodas" OnClick="BtnTodas_Click" />
            </div>
        </div>
        <div class="reseña">
            <%if (Request.QueryString["IdEliminar"] == null)
                {  %>
            <%foreach (var dtoReseña in reseñasDtos)
                { %>

            <div class="card">
                <div class="reseña-header">
                    <img class="Imagen-Perfil" src='<%:dtoReseña.UrlFotoPerfil%>' alt="<%:dtoReseña.Nombre_Apellido%>" style="margin-right: 5%">
                    <div class="reseña-detalles">
                        <div class="fecha"><%:dtoReseña.FechaFormateada%></div>
                        <div class="puntaje">
                            <%AsignarEstrellas(dtoReseña.Puntaje);%>
                            <div id="DivEstrellas" style="margin-bottom:13%" runat="server"></div>
                        </div>
                    </div>
                </div>
                <div class="nombre"><%:dtoReseña.Nombre_Apellido %></div>
                <div class="curso"><%:dtoReseña.NombreCurso%></div>
                <div class="descripcion"><%:dtoReseña.Descripcion%></div>

                <a href="AdminReseñas.aspx?IdEliminar=<%:dtoReseña.IdReseña %>" style="text-align:center ; width: 100%;margin-top:2%;margin-bottom:1%" class="delete-btn " >Eliminar</a>

            </div>

            <% }
            %>
            <%}%>
            <%if (Request.QueryString["IdEliminar"] != null)
                {  %>


            <div class="card">
                <div class="reseña-header">
                    <img class="Imagen-Perfil" src='<%:ReseñaEliminar.UrlFotoPerfil %>' alt="<%:ReseñaEliminar.Nombre_Apellido%>" style="margin-right: 5%">
                    <div class="reseña-detalles">
                        <div class="fecha"><%:ReseñaEliminar.FechaFormateada%></div>
                        <div class="puntaje">
                            <%AsignarEstrellas(ReseñaEliminar.Puntaje);%>
                            <div id="DivEstrellasEliminar" runat="server"></div>
                        </div>
                    </div>
                </div>
                <div class="nombre"><%:ReseñaEliminar.Nombre_Apellido%></div>
                <div class="curso"><%:ReseñaEliminar.NombreCurso%></div>
                <div class="descripcion"><%:ReseñaEliminar.Descripcion%></div>


                <asp:Button Text="Confirmar" ID="BtnConfirmaEliminar" class=" delete-btn mb-2" OnClick="BtnConfirmaEliminar_Click" Style="width: 100%" runat="server" />
                <asp:Button Text="Cancelar" CssClass="btn btn-secondary" ID="BtnCancelaEliminar" OnClick="BtnCancelaEliminar_Click" runat="server" />

            </div>
        </div>


        <%} %>
    </div>

</asp:Content>
