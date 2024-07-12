using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;
using Negocio.ServicioEmail;
using Negocio;

namespace CodeMentor.AspxUsuario
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtCodigo.Enabled = false;
                BtnConfirmarCodigo.Visible = false;
                btnconfirmarPass.Visible = false;
                TxtPass.Visible = false;
                TxtRepetirPass.Visible = false;
                lblErrorCodigo.Visible = false;
            }
        }

        protected void BtnEnviarCodigo_Click(object sender, EventArgs e)
        {
            EnvioGmail envio = new EnvioGmail();
            string codigo= Helper.GenerarCodigoAleatorio();
            string destino = TxtEmail.Text;
            envio.EmailRecuperarPass(destino, codigo);
            envio.EnviarEmail();
            BtnEnviarCodigo.Visible = false;
            BtnConfirmarCodigo.Visible = true;
            TxtCodigo.Enabled = true;
            Session["codigo"]=codigo;

        }

        protected void BtnConfirmarCodigo_Click(object sender, EventArgs e)
        {
            int codigo =int.Parse(Session["codigo"].ToString());
            if (TxtCodigo.Text == codigo.ToString())
            {
                TxtPass.Visible = true;
                TxtRepetirPass.Visible=true;
            }
            else
            {
                lblErrorCodigo.Visible = true;
            }
        }

        protected void confirmarPass_Click(object sender, EventArgs e)
        {
            UsuariosGestion user = new UsuariosGestion();
            string mail = TxtEmail.Text;
            string pass = TxtPass.Text;

            user.CambiarContraseña(mail, pass);
        }
    }
}