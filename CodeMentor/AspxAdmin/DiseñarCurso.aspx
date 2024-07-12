<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="DiseñarCurso.aspx.cs" Inherits="CodeMentor.AspxAdmin.DiseñarCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .container {
            margin-top: 20px;
        }

        .card-header {
            background-color: #343a40;
            color: #fff;
        }

        .form-group label {
            font-weight: bold;
        }
    </style>
    <div class="container">
        <!-- CURSO -->
            <h2 class="mb-4">1 - Cree el Curso</h2>
            <div class="card mb-4">
                <div class="card-header">Información del Curso</div>
                <div class="card-body">
                    <div class="form-group">
                        <label>Nombre del Curso</label>
                        <asp:TextBox ID="TxtNombreCurso" runat="server" CssClass="form-control" PlaceHolder="Ingrese el nombre del curso" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Descripción</label>
                        <asp:TextBox runat="server" CssClass="form-control"  ID="TxtDescripcionCurso" Rows="4" PlaceHolder="Ingrese la descripcion del curso," />
                    </div>
                    <div class="form-group">
                        <label>Requisitos</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="TxtRequisitos" PlaceHolder="Ingrese Requisitos del mismo" Rows="3" />
                    </div>
                    <div class="form-group">
                        <label>Categoría</label>
                        <asp:DropDownList CssClass="form-select" ID="DdlCategorias" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Importe</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="TxtImporte" Style="margin-bottom: 2%" PlaceHolder="Ingrese Importe" />
                    </div>
                    <div class="form-group">
                        <label for="ImagenPortada">Imagen de Portada</label>
                        <input type="file" class="form-control" style="margin-top: 1%" id="TxtImagenCurso" runat="server">
                    </div>
                </div>
            </div>
            <asp:Button ID="btnGuardarCurso" runat="server" Text="Guardar Curso" CssClass="btn  btn-lg btn-primary" OnClick="btnGuardarCurso_Click" />
            <asp:Button ID="BtnModificarCurso" runat="server" Text="Modificar Curso" CssClass="btn btn-secondary "  OnClick="BtnModificarCurso_Click" />
            <asp:Button ID="BtnAñadirUnidades" runat="server" Text="Añadir Unidades y Clases" CssClass="btn btn-lg btn-secondary "  OnClick="BtnAñadirUnidades_Click" />

        </div>


</asp:Content>
