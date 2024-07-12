using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeMentor.AspxUsuario
{
    public partial class PreguntaDetalle : System.Web.UI.Page
    {

        public InformacionUsuario UsuarioActual { get; set; }

        public Pregunta Modificar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Validaciones.Seguridad.Login(Session["Usuario"]) == false)
            {
                Response.Redirect("Ingresar.aspx");
            }

            if (Request.QueryString["Modificar"] != null)
            {
                UsuarioActual = Validaciones.Helper.ObtenerDatos(Session["Usuario"]);


                PregUsuario.Visible = true;
                if (PreguntaModificar() == 0)
                {
                    Response.Redirect("InicioRegistrado.aspx");
                }
                if (!IsPostBack)
                {
                    BtnConfirmarBorrar.Visible = false;
                    TxtCuerpo.Text = Modificar.Cuerpo;
                    TxtTitulo.Text = Modificar.Titulo;
                    LblNoCambios.Visible = false;
                }
            }
            else
            {
                Response.Redirect("PreguntasRespuestas.aspx");
            }

        }

        public int PreguntaModificar()
        {
            int IdPregunta = int.Parse(Request.QueryString["Modificar"]);
            var PregGestion = new PreguntasGestion();
            Modificar = PregGestion.Obtener(IdPregunta); //validamos que no acceda donde no debe! por eso que coincidan ambas en la query
            if (Modificar == null)
            {
                return 0;
            }
            return 1;
        }




        protected void BtnConfirmarBorrar_Click(object sender, EventArgs e)
        {
            var PregGestion = new PreguntasGestion();
            PregGestion.BajaPregunta(Modificar.IdPregunta);
        }

        protected void BtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            BtnConfirmarBorrar.Visible = true;
        }

        protected void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            PreguntaModificar();
            if (TxtCuerpo.Text == Modificar.Cuerpo && TxtTitulo.Text == Modificar.Titulo)
            {
                LblNoCambios.Visible = true;
                return;

            }
            Pregunta Pregunta = Modificar;
            Pregunta.Cuerpo = TxtCuerpo.Text;
            Pregunta.Titulo = TxtTitulo.Text;
            var GestionPreg = new PreguntasGestion();
            GestionPreg.ModificarPregunta(Pregunta);
            Response.Redirect("PreguntaDetalle.aspx?Modificar=" + Pregunta.IdPregunta);
        }
    }
}