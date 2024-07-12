using CodeMentor.AspxAdmin;
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CodeMentor.AspxUsuario.Ayuda
{
    public partial class Guia : System.Web.UI.Page
    {
        public Usuario UsuarioActual { get; set; }
        public Curso CursoManejo { get; set; }


        public InscripcionesGestion nuevaInscripcion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("CursoSolicitud"); 
                Obtenercurso();
                avisoIns.Visible = false;
            }
            Obtenercurso();
        }
        public void Obtenercurso()
        {
            if (Request.QueryString["ComoInscribirse"] == null && Session["CursoSolicitud"]== null)
            {
                return;
            }
            if (Session["CursoSolicitud"] == null)
            {
                int idCurso = int.Parse(Request.QueryString["ComoInscribirse"]);
                var GestionCurso = new CursosGestion();
                if (GestionCurso.Existencia(idCurso) == null)
                {
                    return;
                }
                CursoManejo = GestionCurso.Existencia(idCurso);
                Session.Add("CursoSolicitud", CursoManejo);
            }
            else
            {
                CursoManejo = (Curso)Session["CursoSolicitud"];
            }
           
        }

        protected void BtnGenerarInscripcion_Click(object sender, EventArgs e)
        {

            Obtenercurso();
            var inscripcionGest = new InscripcionesGestion();
            Inscripcion inscripcion = new Inscripcion();
            Curso curso = (Curso)Session["CursoSolicitud"];
            inscripcion.IdCurso = curso.IdCurso;
            UsuarioActual = (Usuario)Session["Usuario"];
            inscripcion.IdUsuario = UsuarioActual.IdUsuario;
            inscripcionGest.InsertarInscripcion(inscripcion);
            BtnGenerarInscripcion.Visible = false;
            avisoIns.Visible = true;
        }
    }
}