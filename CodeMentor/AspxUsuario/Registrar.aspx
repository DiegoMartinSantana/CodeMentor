<%@ Page Title="Registrar" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="CodeMentor.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/Registrar.css" rel="stylesheet" />
    
    <script>

        //Validacion de campos con Javascript
        function ValidarCampos() {
            const Nombre = document.getElementById('TxtNombre');
            const Apellido = document.getElementById('TxtApellido');
            const Email = document.getElementById('TxtEmail');
            const Pass = document.getElementById('TxtPass');
            const RepetirPass = document.getElementById('TxtRepetirPass');
            const Celular = document.getElementById('TxtCelular');

            var esValido = true;

            if (Nombre.value === "") {
                Nombre.classList.add("is-invalid");
                esValido = false;
            } else {
                Nombre.classList.remove("is-invalid");
            }

            if (Apellido.value=== "") {
                Apellido.classList.add("is-invalid");
                esValido = false;
            } else {
                Apellido.classList.remove("is-invalid");
            }

            if (Email.value === "") {
                Email.classList.add("is-invalid");
                esValido = false;
            } else {
                Email.classList.remove("is-invalid");
            }

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

            if (Celular.value === "") {
                Celular.classList.add("is-invalid");
                esValido = false;
            } else {
                Celular.classList.remove("is-invalid");
            }

            return esValido;

        }
    </script>

    <!----------------------- CONTENEDOR PRINCIPAL -------------------------->

    <div class="container d-flex justify-content-center align-items-center min-vh-100">

        <!----------------------- REGISTRO -------------------------->

        <div class="row border rounded-5 p-3 bg-white shadow box-area">

            <!-------------------------- BOX DE REGISTRO (DATOS) ---------------------------->

            <div class="col-md-12 right-box">
                <div class="row align-items-center">
                    <div class="header-text mb-4 text-center">
                        <h2>Registrarse</h2>
                        <p>¡Únete a nuestra comunidad!</p>
                    </div>

                    <div class="input-group mb-2">
                        <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg bg-light fs-6" ClientIDMode="Static" placeholder="Nombre" ID="TxtNombre" />
                    </div>

                    <p class="error " id="PNombreError" visible="false" runat="server"></p>

                    <div class="input-group mb-2">
                        <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg bg-light fs-6" ClientIDMode="Static" placeholder="Apellido" ID="TxtApellido" />
                    </div>
                    <p class="error " id="PApellidoError" visible="false" runat="server"></p>

                    <div class="input-group mb-2">
                        <asp:TextBox runat="server" type="date" CssClass="form-control form-control-lg bg-light fs-6" ClientIDMode="Static" placeholder="Fecha de Nacimiento" ID="TxtFechaNacimiento" />
                    </div>
                    <p class="error " id="PFNacimientoError" visible="false" runat="server"></p>

                    <div class="input-group mb-2">
                        <asp:TextBox runat="server" type="email" CssClass="form-control form-control-lg bg-light fs-6" ClientIDMode="Static" placeholder="Correo Electrónico" ID="TxtEmail" />
                    </div>
                    <p class="error " id="PEmailError" visible="false" runat="server"></p>

                    <div class="input-group mb-2 ">
                        <asp:TextBox runat="server" type="password" CssClass="form-control form-control-lg bg-light fs-6" ClientIDMode="Static" placeholder="Contraseña" ID="TxtPass" />
                    </div>
                    <p class="error " id="PPassError" visible="false" runat="server"></p>

                    <div class="input-group mb-2">
                        <asp:TextBox runat="server" type="password" CssClass="form-control form-control-lg bg-light fs-6" ClientIDMode="Static" placeholder="Repetir Contraseña" ID="TxtRepetirPass" />
                    </div>
                    <asp:Label ID="LblErrorPass" Style="color: red; font-size: 13px" runat="server" />


                    <div class="input-group mb-2">
                        <div>
                            <asp:Label Text="Pais : " CssClass=" form-control form-label bg-light fs-6 " runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList runat="server" ID="DdlPais"  CssClass="form-select  form-control-lg bg-light fs-6">
                            </asp:DropDownList>

                        </div>

                    </div>
                    <div class="input-group mb-2">
                        <asp:TextBox runat="server" CssClass="form-control form-control-lg bg-light fs-6" type="tel" ClientIDMode="Static" placeholder="Numero Celular " ID="TxtCelular" />
                    </div>
                    <p class="error " id="PCelularError" visible="false" runat="server"></p>

                    <div class="input-group mb-2">
                        <div>
                            <asp:Label Text="Sexo : " CssClass=" form-control form-label bg-light fs-6 " Style="margin-right: 20px" runat="server"></asp:Label>
                        </div>
                        <div style="margin-left: 40px">
                            <asp:DropDownList runat="server" ID="DdlSexo"  CssClass="form-select  form-control-lg bg-light fs-6">
                            </asp:DropDownList>

                        </div>
                    </div>

                    <div class="input-group mb-3">
                        <div>
                            <asp:Label Text="Imagen de perfil: *Opcional* " CssClass=" form-control form-label bg-light fs-6 "  Style="margin-right: 20px; background-color:white" runat="server"></asp:Label>
                        </div>
                     <div class="mb-1"  style="margin-top:2%">
                         <input Id="TxtCargaImagen" runat="server"  class="form-control" type="file" />
                        </div>
                    </div>

                <div class="input-group mb-3">

                    <asp:Button Text="Registrarse" ID="BtnRegistro" OnClientClick="return ValidarCampos()" OnClick="BtnRegistro_Click" runat="server" CssClass="btn btnBonito btn-lg btn-primary w-100 fs-6" />
                </div>
                <div class="row">
                    <small>¿Ya tienes una cuenta? <a href="Ingresar.aspx">Ingresar</a></small>
                </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
