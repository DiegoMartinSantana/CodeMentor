using System;
using Dominio;
using Negocio.ServicioEmail;
using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;

namespace CodeMentor.AspxUsuario.Ayuda
{
    public partial class Contacto : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var GestionCurso = new CursosGestion();
                DdlCursos.DataSource = GestionCurso.Listado();
                DdlCursos.DataTextField = "Nombre";
                DdlCursos.DataValueField = "IdCurso";
                DdlCursos.DataBind();
                DdlCursos.Visible = false;
            }
            DdlCursos.Visible = ChkPertenece.Checked;
            BtnVolver.Visible = false;
            BtnVolverMensaje.Visible = false;
        }




        protected void BtnEnviarMensaje_Click(object sender, EventArgs e)
        {
            var usuarioGestion = new UsuariosGestion();
            var envioGmail = new EnvioGmail();
            var DatosPersonaUsuario = Helper.ObtenerDatos(Session["Usuario"]);
            Usuario user = (Usuario)Session["Usuario"];
            string asunto;
            asunto = $"MENSAJE DE {DatosPersonaUsuario.Nombre} {DatosPersonaUsuario.Apellido} : {TxtAsunto.Text} ";
            string mensaje = $"<br> Email : {user.Email} <br> Telefono : {DatosPersonaUsuario.Celular} <br> Mensaje : {TxtMensaje.Text} ";
            envioGmail.EmailHaciaAdmin("diego.santana@alumnos.frgp.utn.edu.ar", asunto, mensaje);
            envioGmail.EnviarEmail();
            BtnEnviarMensaje.Visible = false;
            TxtMensaje.Enabled = false;
            TxtAsunto.Enabled = false;
            TxtMensaje.Text = "";
            TxtMensaje.Text = "Mensaje Enviado";
            TxtMensaje.Style.Add("color", "green");
            TxtMensaje.Style.Add("font-weight", "bold");
            BtnVolverMensaje.Visible = true;
        }

        protected void BtnEnviarProblema_Click(object sender, EventArgs e)
        {
            var usuarioGestion = new UsuariosGestion();
            var envioGmail = new EnvioGmail();
            var DatosPersonaUsuario = Helper.ObtenerDatos(Session["Usuario"]);
            Usuario user = (Usuario)Session["Usuario"];
            string asunto;
            if (ChkPertenece.Checked == true)
            {
                var curso = DdlCursos.SelectedItem.Text;
                asunto = $"REPORTE DE PROBLEMA EN {curso} : ";
            }
            else
            {
                asunto = "REPORTE DE PROBLEMA : ";
            }
            asunto += TxtProblema.Text;
            string mensaje = $"<br> Enviado por : {DatosPersonaUsuario.Nombre} {DatosPersonaUsuario.Apellido} <br> Email : {user.Email} <br> Telefono : {DatosPersonaUsuario.Celular} <br> Mensaje : {TxtDescProblema.Text} ";
            envioGmail.EmailHaciaAdmin("diego.santana@alumnos.frgp.utn.edu.ar", asunto, mensaje); //Email  para checkear funcionamiento
            envioGmail.EnviarEmail();
            TxtDescProblema.Enabled = false;
            TxtProblema.Enabled = false;
            TxtDescProblema.Text = "";
            TxtDescProblema.Text = "Mensaje Enviado";
            TxtDescProblema.Style.Add("color", "green");
            TxtDescProblema.Style.Add("font-weight", "bold");
            BtnEnviarProblema.Visible = false;
            DdlCursos.Enabled = false;
            BtnVolver.Visible = true;
        }

        protected void ChkPertenece_CheckedChanged(object sender, EventArgs e)
        {
            DdlCursos.Visible = ChkPertenece.Checked;
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioRegistrado.aspx", false);
        }

        protected void BtnVolverMensaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioRegistrado.aspx", false);
        }
    }
}