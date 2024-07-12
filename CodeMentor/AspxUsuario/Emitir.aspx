<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="Emitir.aspx.cs" Inherits="CodeMentor.AspxUsuario.Emitir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BusquedaCursos" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
    <link href="../Content/EmitirCertificado.css" rel="stylesheet" />
       <div class="container containerEmitir" style="margin-top:10%;margin-bottom:11%">
           <h1>¡Felicitaciones!</h1>
           <p>Has finalizado el curso con éxito.</p>
           <asp:Button Text="Descargar" OnClick="btnEmitir_Click" CssClass="btn btnEmitir" ID="btnEmitir" runat="server" />
           <div class="thank-you">
               <p class="pGracias">¡Gracias por confiar en nosotros y completar este curso!</p>
           </div>
           <div class="invitation">
               <p class="pGracias">Te invitamos a dejar una reseña del curso! </p>
               <asp:Button Text="Dejar Reseña" CssClass="btn btn-secondary" ID="btnDejar" OnClick="btnDejar_Click" runat="server" />
           </div>
       </div>
    <script src="https://cdn.jsdelivr.net/npm/canvas-confetti@1.5.1/dist/confetti.browser.min.js"></script>
<script>
    function lanzarConfeti() {
        // Confeti en el lado izquierdo
        confetti({
            particleCount: 300,
            angle: 60,
            spread: 55,
            origin: { x: 0, y: 0.6 }
        });
        confetti({
            particleCount: 300,
            angle: 60,
            spread: 55,
            origin: { x: 0, y: 0.4 }
        });
        confetti({
            particleCount: 300,
            angle: 60,
            spread: 55,
            origin: { x: 0, y: 0.8 }
        });

        // Confeti en el lado derecho
        confetti({
            particleCount: 300,
            angle: 120,
            spread: 55,
            origin: { x: 1, y: 0.6 }
        });
        confetti({
            particleCount: 300,
            angle: 120,
            spread: 55,
            origin: { x: 1, y: 0.4 }
        });
        confetti({
            particleCount: 300,
            angle: 120,
            spread: 55,
            origin: { x: 1, y: 0.8 }
        });
    }

    function startCelebration() {
        let count = 0;
        const interval = setInterval(() => {
            lanzarConfeti();
            count++;
            if (count === 3) {
                clearInterval(interval);
            }
        }, 2000); // Intervalo de 2 segundos entre lanzamientos
    }

    window.onload = startCelebration;
</script>


</asp:Content>
