<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="Reseña.aspx.cs" Inherits="CodeMentor.AspxUsuario.Reseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BusquedaCursos" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/Reseña.css" rel="stylesheet" />
   
    <div class="container" style="margin-top: 3.5%; margin-bottom: 13%">
        <div class=" col-10 " style="margin-left: 5%">

            <h2 id="H2Yadejo" runat="server"> class="mb-4"</h2>
            <div class="card mb-4">
                <div class="card-header">Tu Reseña</div>
                <div class="card-body">
                    <div class="form-group ">
                        <label>Puntaje</label>
                        <asp:DropDownList Id="DdlPuntaje" runat="server" Width="50%" CssClass="form-control estrellita">
                            <asp:ListItem Value="5">★★★★★</asp:ListItem>
                            <asp:ListItem Value="4"> ★★★★</asp:ListItem>
                            <asp:ListItem Value="3">★★★</asp:ListItem>
                            <asp:ListItem Value="2">★★</asp:ListItem>
                            <asp:ListItem Value="1">★</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Descripción de la Reseña</label>
                        <asp:TextBox ID="TxtDescripcion" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="EnviarReseña" runat="server" Style="margin-top: 1.5%" Text="Enviar Reseña" CssClass="btn btn-primary" OnClick="EnviarReseña_Click" />
                    <asp:Button ID="BtnVerMas" runat="server" Style="margin-top: 1.5%" Text="Ver más Cursos" CssClass="btn btn-secondary" OnClick="BtnVerMas_Click" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
