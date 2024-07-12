<%@ Page Title="Ingresar" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="CodeMentor.Ingresar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/Ingresar.css" rel="stylesheet" />
    <!----------------------- CONTENEDOR PRINCIPAL -------------------------->

    <div class="container d-flex justify-content-center align-items-center min-vh-100">

        <!----------------------- LOGEO -------------------------->

        <div class="row border rounded-5 p-3 bg-white shadow box-area" style="margin-bottom:10%">

            <!--------------------------- BOX DE LA IZQUIERDA (IMAGEN) ----------------------------->

            <div class="col-md-6 rounded-4 d-flex justify-content-center align-items-center flex-column left-box">
                <div class="featured-image mb-3">
                    <img src="https://i.ibb.co/GcYcNGy/programming-background-with-person-working-with-codes-computer.jpg" class="img-fluid full-image">
                </div>
            </div>

            <!-------------------------- BOX LA DERECHA (DATOS) ---------------------------->

            <div class="col-md-6 right-box">
                <div class="row align-items-center">
                    <div class="header-text mb-4 text-center">
                        <h2 style="font-size:2.5rem">Bienvenido</h2>
                        <p  style="font-size:x-large" >¿Con ganas de aprender?</p>
                    </div>

                    <div class="input-group mb-3">
                        <asp:TextBox ID="TxtEmailLogin" type="text" CssClass="form-control form-control-lg bg-light fs-6" placeholder="Correo electrónico" runat="server" />
                    </div>
                    <div class="input-group mb-1">
                        <asp:TextBox runat="server" Id="TxtPassLogin" type="password" CssClass="form-control form-control-lg bg-light fs-6" placeholder="Contraseña" /> 
                    </div>
                    <div>
                        <small  class="text-danger"> <asp:Label runat="server" ID="LblErrorLogin"  /></small>
                    </div>
                    <div class="input-group mb-5 d-flex justify-content-between">
                       
                        <div class="forgot">
                            <small><a href="RecuperarContraseña.aspx">¿Olvidaste la contraseña?</a></small> <!-- Redirect a Aspx ResetPass-->
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:Button Text="Ingresar" runat="server" ID="BtnLogin" OnClick="BtnLogin_Click" CssClass="btn btn-lg btn-primary w-100 fs-6"/>
                    </div>
                    <div class="row">
                        <small>¿Aún no te has registrado? <a href="Registrar.aspx">Registrarme</a></small>
                    </div>
                </div>
            </div>
        </div>
    </div>

   
</asp:Content>
