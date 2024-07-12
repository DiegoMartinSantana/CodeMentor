<%@ Page Title="Guia" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="Guia.aspx.cs" Inherits="CodeMentor.AspxUsuario.Ayuda.Guia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <link href="../Content/Guia.css" rel="stylesheet" />
    <% if (Request.QueryString["ComoInscribirse"] != null)
        {

    %>
    <div class="container mt-5">
        <h1 class="text-center mb-4">¿Cómo Inscribirse en Nuestros Cursos?</h1>
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <h4>Información sobre Pagos</h4>
                        <p class="lead">Para inscribirte en <%:CursoManejo.Nombre %>, sigue los siguientes pasos:</p>
                        <ol>
                            <li>Realiza una transferencia bancaria al siguiente CVU:
                      
                   <div class="alert alert-info mt-2">
                       <strong>CVU:</strong> 0001234567891234567890<br>
                       <strong>Nombre Completo:</strong> Juan Pérez
                      
                   </div>
                            </li>
                            <li>El monto de la inscripción es de $<%:CursoManejo.Importe.ToString("F2") %>.</li>
                            <li>Una vez realizada la transferencia, envía el comprobante al siguiente correo electrónico:
                      
                   <div class="alert alert-info mt-2">
                       <strong>Correo Electrónico:</strong> codementor.net@gmail.com
                      
                   </div>
                            </li>
                            <li>El proceso de habilitación del curso puede demorar hasta 72 horas.</li>
                            <li>IMPORTANTE : EL EMAIL DESDE EL QUE SE ENVIE EL COMPROBANTE DEBERA SER EL MISMO POR EL QUE ACCEDIO A LA PLATAFORMA. </li>
                            <li>Recibirás un correo electrónico de confirmación una vez que tu inscripción haya sido procesada.</li>
                            <li>Deberas Generar  la Inscripcion para reservar tu cupo. </li>
                        </ol>
                        <div class="text-center">
                            <%if (Session["Usuario"] == null)
                                {%>

                            <a href="Registrar.aspx" class="btn btn-primary btn-lg">Inscribirse</a>

                            <a href="Contacto.aspx?Contacto=<%:1%>" class="btn btn-secondary btn-lg">Contactar soporte</a>


                            <%}
                                else
                                {  %>
                            <asp:Button ID="BtnGenerarInscripcion" CssClass="btn btn-primary btn-lg " runat="server" OnClick="BtnGenerarInscripcion_Click" Text="Generar Inscripcion" />

                            <a href="Contacto.aspx?Contacto=<%:1%>" class="btn btn-secondary btn-lg">Contactar soporte</a>
                            <h5 id="avisoIns" style="margin-top: 2%" runat="server">Solicitud de Inscripcion generada correctamente. Aguarde confirmacion al email una vez recibida la transferencia.</h5>
                            <%} %>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} %>
    <%if (Request.QueryString["ComoInscribirse"] == null && Request.QueryString["Certificado"] == null)
        {  %>
    <div class="container mt-5">
        <h1 class="text-center mb-4">¿Cómo Inscribirse en Nuestros Cursos?</h1>
        <div class="row justify-content-center" style="margin-bottom: 5%">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <h4>Información sobre Pagos</h4>
                        <p class="lead">Para inscribirte en nuestros cursos, sigue los siguientes pasos:</p>
                        <ol>
                            <li>Realiza una transferencia bancaria con el valor del curso al siguiente CVU:
                                
                             <div class="alert alert-info mt-2">
                                 <strong>CVU:</strong> 0001234567891234567890<br>
                                 <strong>Nombre Completo:</strong> Juan Pérez
                                
                             </div>
                            </li>
                            <li>El monto de la inscripción es de $XXXX.</li>
                            <li>Una vez realizada la transferencia, envía el comprobante al siguiente correo electrónico:
                                
                             <div class="alert alert-info mt-2">
                                 <strong>Correo Electrónico:</strong> inscripciones@example.com
                                
                             </div>
                            </li>
                            <li>El proceso de habilitación del curso puede demorar hasta 72 horas.</li>
                            <li>IMPORTANTE : EL EMAIL DESDE EL QUE SE ENVIE EL COMPROBANTE DEBERA SER EL MISMO POR EL QUE ACCEDIO A LA PLATAFORMA. </li>
                            <li>Recibirás un correo electrónico de confirmación una vez que tu inscripción haya sido procesada.</li>

                        </ol>
                        <div class="text-center">
                            <a href="Contacto.aspx?Contacto=<%:1%>" class="btn btn-primary btn-lg">Contactar soporte</a>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <%}%>
    <%if (Request.QueryString["Certificado"] != null)
        {
    %>
    <div class="container mt-5">
        <h1 class="text-center mb-4 header-title">Proceso de Certificación</h1>
        <div class="row justify-content-center" style="margin-bottom: 12%">
            <div class="col-md-10">
                <div class="card mb-4 step-card">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-3">
                            <div class="step-icon mr-3" style="margin-right: 20px">
                                <i class="fas fa-user-check"></i>
                            </div>
                            <h2 class="card-title mb-0">Paso 1: Inscribirse Correctamente en un Curso</h2>
                        </div>
                        <p class="card-text">
                            Para comenzar el proceso de certificación, primero debe inscribirse en el curso de su elección. 
                                Acceda a la sección de cursos disponibles, seleccione el curso deseado y complete el proceso de inscripción.
                           
                        </p>
                    </div>
                </div>
                <div class="card mb-4 step-card">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-3">
                            <div class="step-icon mr-3" style="margin-right: 30px">
                                <i class="fas fa-tasks"></i>
                            </div>
                            <h2 class="card-title mb-0">Paso 2: Finalizar Todas las Unidades del Curso</h2>
                        </div>
                        <p class="card-text">
                            Una vez inscripto, es necesario completar todas las unidades del curso. Asegúrese de tildarlas una vez finalizadas.
                           
                        </p>
                    </div>
                </div>
                <div class="card mb-4 step-card">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-3">
                            <div class="step-icon mr-3" style="margin-right: 30px">
                                <i class="fas fa-certificate"></i>
                            </div>
                            <h2 class="card-title mb-0">Paso 3: Ir a Mis Cursos y Emitir el Certificado</h2>
                        </div>
                        <p class="card-text">
                            Después de finalizar todas las unidades, diríjase a la sección "Mis Cursos". Allí encontrará la opción para emitir su certificado. 
                                Haga clic en "Emitir Certificado" y se le enviará a su email el certificado de su curso.<br />
                            El proceso de certificación no requiere de evaluación alguna, solo la finalización de las unidades. Le recomendamos poner en práctica lo visto en clase.
                           
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%}%>
</asp:Content>
