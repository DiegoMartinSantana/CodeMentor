using CodeMentor.AspxUsuario;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeMentor
{
    public partial class MasterUsuario : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           //Validar acceso  por Pagina . Porque hay Paginas que accede logueado no!.


        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx", false); //redirige a la pagina de login
            Session.Clear();//limpia la session del usuario

        }
        public void OcultarBotones()
        {
          BtnLogout.Visible = false;

        }

    }
}