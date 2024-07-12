<%@ Page Title="titulo" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminCursos.aspx.cs" Inherits="CodeMentor.AdminAspx.AdminCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/AdminCursos.css" rel="stylesheet" />
    <div class="container " style="margin-top: 2%">
        <div class="row">
            <div class="col-12 text-center mb-2">
                <h2 class="title">Cursos</h2>
            </div>
        </div>
        <div class="row">
            <p class="mb-3">Ordenar por:</p>
            <div class="col-3 d-flex align-items-center">
                <asp:DropDownList OnSelectedIndexChanged="ddlAZ_SelectedIndexChanged" ID="ddlAZ" AutoPostBack="true" runat="server" CssClass="form-control form-select btn-secondary mb-3">
                    <asp:ListItem Text="A-Z" Value="2" />
                    <asp:ListItem Text="Z-A" Value="1"/>
                </asp:DropDownList>
            </div>
            <div class="col-3 d-flex align-items-center">
                <asp:DropDownList OnSelectedIndexChanged="ddlOrdenarPrecio_SelectedIndexChanged" AutoPostBack="true" ID="ddlOrdenarPrecio" runat="server" CssClass="form-control form-select btn-secondary mb-3">
                    <asp:ListItem Value="1" Text="Menor Precio" />
                    <asp:ListItem  Value="2" Text="Mayor Precio" />
                </asp:DropDownList>
            </div>
            <div class="col-3">
                <asp:DropDownList ID="ddlOrdenarInscripciones" AutoPostBack="true" OnSelectedIndexChanged="ddlOrdenarInscripciones_SelectedIndexChanged" runat="server" CssClass="form-control form-select btn-secondary mb-3">
                    <asp:ListItem Value="1" Text="Mas inscripciones" />
                    <asp:ListItem Value="2" Text="Menos inscripciones" />
                </asp:DropDownList>
            </div>

            <div class="col-3 text-end">
                <a href="DiseñarCurso.aspx" class="btn btn-primary mb-3 " style="background-color: #27ae60; border-color: #27ae60">Agregar Curso</a>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" ID="DgwCursos" OnRowCommand="DgwCursos_RowCommand" AutoGenerateColumns="False" CssClass="table-custom">
                    <Columns>
                        <asp:BoundField DataField="IdCurso" Visible="false" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre del Curso" Visible="True" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" Visible="True" />
                        <asp:BoundField DataField="NombreCategoria" HeaderText="Categoria" Visible="True" />
                        <asp:BoundField DataField="ImporteFormateado" HeaderText="Precio" Visible="True" />
                        <asp:BoundField DataField="CantidadInscriptos" HeaderText="Inscriptos" Visible="True" />
                        <asp:TemplateField HeaderText="Accion" Visible="True">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="Visualizar" CommandName="Visualizar" CommandArgument='<%#Eval("IdCurso") %>' CssClass="btn-visualizar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
  
</asp:Content>

