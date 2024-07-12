using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.ServicioEmail;
using Dominio;
using Negocio;
namespace CodeMentor.AspxUsuario
{
    public partial class ErrorUsuarioDeBaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Acceder a la Master Page
            MasterUsuario myMasterPage = (MasterUsuario)this.Master;

            if (myMasterPage != null)
                myMasterPage.OcultarBotones();       


        }

        protected void BtnEnviarProblema_Click(object sender, EventArgs e)
        {
            var envioGmail = new EnvioGmail();
            string mensaje = TxtMensaje.Text;
            string asunto = TxtEmail.Text;
            envioGmail.EmailUsuariodeBaja(asunto, mensaje);
            envioGmail.EnviarEmail();
            TxtEmail.Enabled = false;
            TxtMensaje.Enabled = false;
            TxtEmail.Text = "";
            TxtMensaje.Text = "Mensaje enviado";
            BtnEnviarMensaje.Enabled = false;

        }
       

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx", false);
        }
    }

}