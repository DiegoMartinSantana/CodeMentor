<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="EdicionPerfil.aspx.cs" Inherits="CodeMentor.AspxUsuario.EdicionPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/EdicionPerfil.css" rel="stylesheet" />
    <div class="container edit-profile-container">
        <div class="edit-profile-header">
            <h2>Editar Perfil</h2>
        </div>
        <div class="edit-profile-form">
            <div class="form-group">
                <label>Nombre:</label>
                <asp:TextBox ID="TxtNombre" runat="server" CssClass=" form-control form-control2"></asp:TextBox>
                <p class="error " id="PNombreError" visible="false" runat="server"></p>

            </div>
            <div class="form-group">
                <label>Apellido:</label>
                <asp:TextBox ID="TxtApellido" runat="server" CssClass=" form-control form-control2"></asp:TextBox>
                <p class="error " id="PApellidoError" visible="false" runat="server"></p>

            </div>
            <div class="form-group">
                <label>Celular:</label>
                <asp:TextBox ID="TxtCelular" runat="server" CssClass=" form-control form-control2"></asp:TextBox>
                <p class="error " id="PCelularError" visible="false" runat="server"></p>

            </div>
            <div class="form-group">
                <label>Imagen de Perfil:</label>
                <input id="TxtCargaImagen" runat="server" class="form-control" type="file" />

                <asp:Image Style="margin-top: 3%" ID="ImgPerfil" runat="server" CssClass="profile-img" />
            </div>
        </div>
        <div class="save-button">
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="BtnGuardar_Click" />
        </div>
    </div>
</asp:Content>
