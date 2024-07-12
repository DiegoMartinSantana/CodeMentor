<%@ Page Title="titulo" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminCategorias.aspx.cs" Inherits="CodeMentor.AdminAspx.AdminCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .center-horizontal {
            text-align: center;
            margin-top: 0; /* Asegúrate de que no haya margen superior */
        }
        .content-container {
            display: flex;
            justify-content: center;
            align-items: flex-start;
            margin: 20px auto; /* Centrando horizontalmente */
            width: 60%; /* Ajusta el ancho según sea necesario */
        }
        .image-container {
            margin-right: 20px; /* Espacio entre la imagen y el contenedor de botones */
        }
        .button-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            border: 1px solid #ccc;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 300px; /* Ancho del contenedor */
        }
        .button-container button {
            width: 100%;
            margin: 10px 0; /* Espacio entre botones */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:darkslategrey">
            <div class="center-horizontal">
        <h1 >ADMINISTRACION CATEGORIAS</h1>
    </div>
    <hr />
    <hr />
    <div class="content-container" >
        <div class="image-container">
            <img src="data:image/jpeg;base64,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" alt="Descripción de la imagen" style="width: 200px; height: 200px;" />
        </div>
        <div class="button-container"style="background-color:azure ">
            <asp:Panel runat="server">
                 <asp:Button ID="btn_VerCategorias" runat="server" Cssclass="btn btn-outline-primary" Text="Ver Categorias" />
                 <asp:Button ID="btn_AltaCAtegoria" runat="server" Cssclass="btn btn-outline-primary" Text="Alta Categoria" />
                 <asp:Button ID="btn_ModificarCategoria" runat="server" Cssclass="btn btn-outline-primary" Text="Modificar Categoria" />              
                 <asp:Button ID="btn_EliminarCategoria" runat="server" Cssclass="btn btn-outline-danger" Text="Eliminar Categoria" />
         
            </asp:Panel>
        </div>
    </div>
    </div>
</asp:Content>
