<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="ErrorUsuarioDeBaja.aspx.cs" Inherits="CodeMentor.AspxUsuario.ErrorUsuarioDeBaja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <link href="../Content/ErrorUsuarioDeBaja.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" />

    <div class="container mt-5">
        <h1 class="text-center mb-4">Usuario dado de baja </h1>
        <h1 class="text-center mb-4">Contacte al administrador </h1>
        <div class="row justify-content-center" style="margin-bottom: 16%">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="form-group" style="margin-top: 2.5%">

                            <div class="form-group">
                                <label for="txtEmail">Ingrese su Email:</label>
                                <asp:TextBox ID="TxtEmail" PlaceHolder="ejemplo@ejemplo.com" runat="server" Style="width: 80%; background-color: white" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TxtMensaje">Mensaje:</label>
                            <asp:TextBox ID="TxtMensaje" Style="background-color: white" PlaceHolder="Describa su situacion" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"  />
                        </div>
                    </div>
                    <div class="text-center" style="margin-bottom: 2%">
                        <asp:Button ID="BtnEnviarMensaje" runat="server" Text="Enviar Mensaje" Onclick="BtnEnviarProblema_Click" CssClass="btn btn-primary" />
                    </div>
                    <div class="text-center" style="margin-bottom: 2%">
                        <asp:Button ID="BtnVolver" runat="server" Text="Volver" OnClick="BtnVolver_Click" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


