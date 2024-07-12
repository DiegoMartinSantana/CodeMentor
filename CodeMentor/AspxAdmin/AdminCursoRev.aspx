<%@ Page Title="CursoDiseño" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminCursoRev.aspx.cs" Inherits="CodeMentor.AspxAdmin.AdminCursoRev" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/AdminCursoRev.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" />
    <div class="container container-custom" style="margin-top:7px">
        <div class="header-custom">
            <h2><%: CursoDto.Nombre %></h2>
            <asp:TextBox runat="server" ID="TxtModifNombre" Style="width: 71%; font-size: large; margin-left: 15%;" CssClass="text-center form-control form-control-custom" placeholder="Modificar Nombre" />
        </div>

        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card card-custom">
                    <div class="card-body">
                        <h5 class="card-title card-title-custom">Descripción del Curso</h5>
                        <p id="PDescripcion" runat="server" class="card-text"><%: CursoDto.Descripcion %></p>
                        <asp:TextBox runat="server" ID="TxtModifDescripcion" CssClass="form-control form-control-custom" TextMode="MultiLine" Rows="5" placeholder="Modificar Descripción" />
                    </div>
                </div>

                <div class="card card-custom">
                    <div class="card-body">
                        <h5 class="card-title card-title-custom">Categoría</h5>
                        <p class="card-text"><%: CursoDto.NombreCategoria %></p>
                        <asp:DropDownList runat="server" ID="DdlCategorias" CssClass="form-select form-control-custom"></asp:DropDownList>
                    </div>
                </div>

                <div class="card card-custom">
                    <div class="card-body">
                        <h5 class="card-title card-title-custom">Importe</h5>
                        <p class="card-text"><%: CursoDto.ImporteFormateado %></p>
                        <asp:TextBox runat="server" ID="TxtModifImporte" CssClass="form-control form-control-custom" placeholder="Modificar Importe" />
                    </div>
                </div>

                <div class="card card-custom">
                    <div class="card-body">
                        <h5 class="card-title card-title-custom">Requisitos</h5>
                        <p class="card-text"><%: CursoDto.Requisitos %></p>
                        <asp:TextBox runat="server" ID="TxtModifRequisitos" CssClass="form-control form-control-custom" placeholder="Modificar Requisitos" />

                    </div>
                </div>
                <div class="card card-custom" style="padding-bottom:0">
                    <div class="card-body"  style="padding-bottom:0">
                        <h5 class="card-title card-title-custom">Imagen Portada :</h5>


                        <% ImgCurso.ImageUrl = CursoDto.UrlPortadaCarpeta; %>
                        <asp:Image ID="ImgCurso" runat="server" class="card-img-top " style="width:280px;margin-left:20%;margin-bottom:1%" alt="Imagen del curso " />
                        <input type="file" id="TxtNuevaImagen" runat="server" class="form-control" style="margin-bottom:1%"/>
                    </div>
                </div>
                <div>
                    <asp:Button Text="Modificar Informacion" ID="BtnModificar" OnClick="BtnModificar_Click" runat="server" CssClass="btn btn-primary-custom" />

                    <asp:Button Text="Guardar Cambios" CssClass="btn btn-success btn-custom" ID="BtnGuardarCambios" OnClick="BtnGuardarCambios_Click" runat="server" />
                    <asp:Button Text="Cancelar" CssClass="btn btn-danger btn-custom" ID="BtnCancelarCambios" OnClick="BtnCancelarCambios_Click" runat="server" />
                </div>
            </div>

        </div>
    </div>
    <div class="container container-custom"  style="margin-top:7px">

        <div class="d-flex justify-content-between mb-3">
            <a href="EdicionCurso.aspx?" class="btn btn-primary-custom w-45">Añadir o editar Unidades</a>
        </div>

        <div class="accordion" id="acordeonClases">
            <% foreach (var unidad in CursoDto.Unidades)
                {
                    var unidadId = "unidad" + unidad.IdUnidad;%>

            <div class="accordion-item">

                <!-- ENCABEZADO DE ACORDEON: INDICA NUMERO Y NOMBRE DE UNIDAD -->
                <h2 class="accordion-header">
                    <button style="font-size: 1.2rem; color: #2980b9" class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#<%:unidadId%>" aria-expanded="true" aria-controls="<%:unidadId %>">
                        <%:unidad.Numero%>. <%:unidad.Nombre%>
                    </button>
                </h2>

                <!-- CUERPO DEL ACORDEON: INDICA LAS CLASES DE LA UNIDAD-->
                <div id="<%:unidadId%>" class="accordion-collapse collapse show" data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        <ul class="list-group">

                            <!-- FOREACH DE LISTA PARA CARGAR TODAS LAS CLASES DE LA UNIDAD -->
                            <%  foreach (var clase in ListarClases(unidad.IdUnidad))
                                { %>
                            <li class="list-group-item d-flex justify-content-between align-items-center">
                                <div>
                                    <%: clase.Numero %>. <%: clase.Descripcion %>
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


</asp:Content>

