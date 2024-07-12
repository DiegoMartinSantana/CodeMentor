using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;

namespace CodeMentor.Masters
{
    public partial class MasterAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar mediante Page solo ADMIN 
            if (Session["Usuario"] != null)
            {
                if (!Seguridad.EsAdmin(Session["Usuario"]))
                {
                    Response.Redirect(ResolveUrl("~/AspxUsuario/InicioRegistrado.aspx"));

                }
            }
            else
            {
                Response.Redirect(ResolveUrl("~/AspxUsuario/Ingresar.aspx"));

            }

        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(ResolveUrl("~/AspxUsuario/Ingresar.aspx"));


        }
    }
}