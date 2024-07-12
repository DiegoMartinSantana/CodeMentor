<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="CodeMentor.PerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <link href="../Content/PerfilUsuario.css" rel="stylesheet" />
    <div class="container profile-container" style="margin-top: 6.5%; margin-bottom: 8%">
        <div class="profile-header">
            <h2>Mi Perfil</h2>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Image runat="server" ID="ImgPerfil" class="profile-img" alt="Imagen de Perfil" />
            </div>
            <div class="col-md-8 profile-info">
                <div class="form-group">
                    <label>Email:</label>
                    <asp:Label ID="LblEmail" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <label>Nombre:</label>
                    <asp:Label ID="LblNombre" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <label>Apellido:</label>
                    <asp:Label ID="LblApellido" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <label>Fecha de Nacimiento:</label>
                    <asp:Label ID="LblFechaNacimiento" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <label>País:</label>
                    <asp:Label ID="LblPais" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <label>Celular:</label>
                    <asp:Label ID="LblCelular" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <label>Sexo:</label>
                    <asp:Label ID="LblSexo" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>
        </div>
        <div class="edit-button">
            <a href="EdicionPerfil.aspx"  class="btn btn-primary">Editar Perfil</a>
        </div>
    </div>
</asp:Content>
