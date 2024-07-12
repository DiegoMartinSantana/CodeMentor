using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;

namespace CodeMentor
{
    public partial class Ingresar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.Login(Session["Usuario"]))
            {
                Response.Redirect("InicioRegistrado.aspx"); // si ya esta logueado , no puede volver a ingresar
            }
            if (!IsPostBack)
            {
                LblErrorLogin.Visible = false;
            }
      //if (Validaciones.Seguridad.Login(Session["Usuario"])) Response.Redirect("InicioRegistrado.aspx"); // si ya esta logueado , no puede volver a ingresar

        }
        
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            var UsuarioGestion = new UsuariosGestion();
            //Validacion No vacios , Definir despues si via JS en el aspx ,si con validators o FluentValidation

            try //intenta ir  al gestor 
            {
                var User = UsuarioGestion.ValidarYObtenerUser(TxtEmailLogin.Text, TxtPassLogin.Text);

                
                if (User != null)
                {
                    Session["Usuario"] = User;
                    if (User.EsAdmin == true)
                    {
                        Response.Redirect("~/AspxAdmin/BackOffice.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("InicioRegistrado.aspx", false);
                    }
                    
                }
                else
                {
                    LblErrorLogin.Text = "Usuario o Contraseña Incorrectos"; // Si devuelve null . mostramos mensajito y no hacemos nada
                    LblErrorLogin.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //manejo de errores
                throw ex;
            }


        }
    }
}