using Dominio;
using Negocio;
using Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;
using Dominio.DataTransferObjects;
using System.Runtime.InteropServices.WindowsRuntime;
using Org.BouncyCastle.Asn1.Ocsp;

namespace CodeMentor
{
    public partial class PreguntasRespuestas : System.Web.UI.Page
    {
        public bool ViendoUsuarios { get; set; }
        public InformacionUsuario UsuarioActual { get; set; }
        public List<PreguntaRespuestaDto> ListadoPreguntasRespuestas { get; set; }
        public Curso CursoActual { get; set; }

        private PreguntasGestion PregGestion = new PreguntasGestion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Validaciones.Seguridad.Login(Session["Usuario"]))
            {

                Response.Redirect("Ingresar.aspx");
            }

            if (!IsPostBack)
            {
                if (ObtenerCursoActual() == 0)
                {
                    Response.Redirect("InicioRegistrado.aspx");
                }
                LLenarPreguntasRespuestas();
                LlenarUltimasDos();
                PanelNuevaPregunta.Visible = false;
                if (Request.QueryString["IdCursoNew"] != null)
                {
                    PanelNuevaPregunta.Visible = true;
                }
            }

        }
        public void LlenarUltimasDos()
        {
            ListadoPreguntasRespuestas = ListadoPreguntasRespuestas.Take(2).ToList();
        }

        public void ObtenerUsuario()
        {
            UsuarioActual = Validaciones.Helper.ObtenerDatos(Session["Usuario"]);

        }
        public int ObtenerCursoActual()
        {
            var CursoGestion = new CursosGestion();
            try
            {
                if (Request.QueryString["IdCurso"] == null && Request.QueryString["IdCursoNew"] == null)
                {
                    Response.Redirect("InicioRegistrado.aspx", false);
                }

                int idCurso =0;
                if (Request.QueryString["IdCurso"] == null)
                {
                    idCurso = int.Parse(Request.QueryString["IdCursoNew"]);
                }
                else
                {
                    idCurso = int.Parse(Request.QueryString["IdCurso"]);

                }

                CursoActual = CursoGestion.Existencia(idCurso);
                if (CursoGestion == null)
                {

                    return 0;
                }
                Session.Add("CursoActual", CursoActual);

                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool ObtenerRespuesta(int idPregunta)
        {
            var RespuestaGestion = new RespuestasGestion();
            try
            {
                var RespuestaExiste = RespuestaGestion.Existencia(idPregunta);
                if (RespuestaExiste == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void BtnVerPreguntasUsuario_Click(object sender, EventArgs e)
        {
            ObtenerUsuario();
            ObtenerCursoActual();
            LLenarPreguntasRespuestas();
            ListadoPreguntasRespuestas = ListadoPreguntasRespuestas.Where(x => x.IdUsuario == UsuarioActual.Idusuario && x.IdCurso == CursoActual.IdCurso).ToList();
            ViendoUsuarios = true;
        }

        protected void BtnAñadirPregunta_Click(object sender, EventArgs e)
        {
            ObtenerUsuario();
            ObtenerCursoActual();
            PanelNuevaPregunta.Visible = true;

            PanelPreguntas.Visible = false;
        }

        protected void BtnCancelarAñadirPregunta_Click(object sender, EventArgs e)
        {

            ObtenerUsuario();
            ObtenerCursoActual();

            Response.Redirect("Preguntasrespuestas.aspx?IdCurso=" + CursoActual.IdCurso);
        }


        protected void BtnGuardarPregunta_Click(object sender, EventArgs e)
        {
            //validar nulo vacio 
            if (string.IsNullOrEmpty(TxtTitulo.Text) || string.IsNullOrEmpty(TxtCuerpo.Text))
            {
                return;
            }
            if (TxtTitulo.Text.Length > 150 || TxtCuerpo.Text.Length > 1700 || TxtTitulo.Text.Length < 3
                || TxtCuerpo.Text.Length < 30) //validar longitud NO SUPERE MAXIMO VARCHAR DE BD
            {
                return;
            }


            var Pregunta = new Pregunta();
            Pregunta.Titulo = TxtTitulo.Text;
            Pregunta.Cuerpo = TxtCuerpo.Text;
            ObtenerCursoActual();
            Pregunta.IdCurso = CursoActual.IdCurso;
            ObtenerUsuario();

            Pregunta.IdUsuario = UsuarioActual.Idusuario;
            var PregGestion = new PreguntasGestion();
            PregGestion.AltaPregunta(Pregunta);

            Response.Redirect("Preguntasrespuestas.aspx?IdCurso=" + CursoActual.IdCurso);

        }

        public void LLenarPreguntasRespuestas()
        {

            CursoActual = (Curso)Session["CursoActual"];
            ListadoPreguntasRespuestas = Helper.LlenaryMapearPreg_Resp(CursoActual.IdCurso);

        }

        protected void BtnVerTodas_Click1(object sender, EventArgs e)
        {

            ViendoUsuarios = false;
            LLenarPreguntasRespuestas();
        }

        protected void TxtFiltrarPreguntas_TextChanged(object sender, EventArgs e)
        {
            CursoActual = (Curso)Session["CursoActual"];

            ListadoPreguntasRespuestas = Helper.LlenaryMapearPreg_Resp(CursoActual.IdCurso).Where(x => x.TituloPregunta.Contains(TxtFiltrarPreguntas.Text)).ToList();
         
        }
    }
}