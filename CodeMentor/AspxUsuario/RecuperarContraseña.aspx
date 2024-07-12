<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="CodeMentor.AspxUsuario.RecuperarContraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <link href="../Content/RecuperarContraseña.css" rel="stylesheet" />


     <script>

     //Validacion de campos con Javascript
     function ValidarCampos() {

         const Pass = document.getElementById('TxtPass');
         const RepetirPass = document.getElementById('TxtRepetirPass');
         

         var esValido = true;

         if (Pass.value === "") {
             Pass.classList.add("is-invalid");
             esValido = false;
         } else {
             Pass.classList.remove("is-invalid");
         }

         if (RepetirPass.value === "") {
             RepetirPass.classList.add("is-invalid");
             esValido = false;
         } else {
             RepetirPass.classList.remove("is-invalid");
         }


         return esValido;

     }
     </script>

    <asp:ScriptManager runat="server" />

    <div class="container mt-5">
        <h1 class="text-center mb-4">Recuperar Contraseña </h1>
        <h5 class="text-center mb-4">Presione el boton para enviar el codigo de recuperacion a su email.</h5>
        <div class="row justify-content-center" style="margin-bottom: 16%">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="form-group" style="margin-top: 2.5%">

                            <div class="form-group">
                                <label for="txtEmail">Ingrese su Email:</label>
                                <asp:TextBox ID="TxtEmail" PlaceHolder="ejemplo@ejemplo.com" runat="server" Style="width: 80%; background-color: white" CssClass="form-control" Required="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TxtCodigo">Codigo:</label>
                            <asp:TextBox ID="TxtCodigo" Style="background-color: white" PlaceHolder="Ingrese el codigo" runat="server" CssClass="form-control" Required="true" />
                             <asp:Label ID="lblErrorCodigo" text="Codigo incorrecto" Style="color: red; font-size: 13px" runat="server" />
                        </div>
                        <div class="input-group mb-2 ">
                            <asp:TextBox runat="server" type="password" CssClass="form-control form-control-lg bg-light fs-6" ClientIDMode="Static" placeholder="Contraseña" ID="TxtPass" />
                        </div>
                        <p class="error " id="PPassError" visible="false" runat="server"></p>

                        <div class="input-group mb-2">
                            <asp:TextBox runat="server" type="password" CssClass="form-control form-control-lg bg-light fs-6" ClientIDMode="Static" placeholder="Repetir Contraseña" ID="TxtRepetirPass" />
                        </div>
                         <div class="text-center" style="margin-bottom: 2%">
                        <asp:Label ID="LblErrorPass"  Style="color: red; font-size: 13px" runat="server" />
                          <asp:Button ID="btnconfirmarPass" runat="server" Text="Confirmar Pass" onClick="confirmarPass_Click" CssClass="btn btn-primary" />
                    
                         </div>
                    <div class="text-center" style="margin-bottom: 2%">
                        <asp:Button ID="BtnEnviarCodigo" runat="server" Text="Enviar codigo" OnClick="BtnEnviarCodigo_Click" CssClass="btn btn-primary" />
                        <asp:Button ID="BtnConfirmarCodigo" runat="server" Text="Confirmar" onClick="BtnConfirmarCodigo_Click" CssClass="btn btn-primary" />
                    </div>
                    <div class="text-center" style="margin-bottom: 2%">
                        <asp:Button ID="BtnVolver" runat="server" Text="Volver" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
