using Dominio;
using Dominio.DTOS;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeMentor.AspxUsuario
{
    public partial class Reseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar que no exista una ya
            if (Session["IdCursoReseña"] == null)
            {
                Response.Redirect("InicioRegistrado.aspx", false);
            }
            if (!IsPostBack)
            {
                BtnVerMas.Visible = false;
                H2Yadejo.Visible = true;
                H2Yadejo.InnerText = "Dejar una reseña";
                //validar si no existe ya una

                int idcurso = (int)Session["IdCursoReseña"];
                var GestionCurso = new CursosGestion();
                var curso = GestionCurso.Existencia(idcurso);
                var InfoUser = Validaciones.Helper.ObtenerDatos(Session["Usuario"]);
                var inscripcionGestion = new InscripcionesGestion();
                var inscrip = inscripcionGestion.ObtenerInscripcion(curso.IdCurso, InfoUser.Idusuario);
                if (InfoUser.Baja || inscrip.Baja)
                {
                    Response.Redirect("Inicio.aspx", false);
                }
                var GestionReseña = new ReseñaGestion();
                if (GestionReseña.Existencia(idcurso, inscrip.IdInscripcion) != null){
                    var Reseña = GestionReseña.Existencia(idcurso, inscrip.IdInscripcion);
                    H2Yadejo.Visible = true;
                    H2Yadejo.InnerText = "Ya dejo su reseña.";

                    EnviarReseña.Visible = false;
                    BtnVerMas.Visible = true;
                    TxtDescripcion.Text = Reseña.Descripcion;
                    DdlPuntaje.SelectedValue = Reseña.Puntaje.ToString();
                    TxtDescripcion.Enabled = false;
                    DdlPuntaje.Enabled = false;

                }

            }
        }

        protected void EnviarReseña_Click(object sender, EventArgs e)
        {
            //tenemos que obtener el id del curso
            int idcurso = (int)Session["IdCursoReseña"];
            var GestionCurso = new CursosGestion();
            var curso = GestionCurso.Existencia(idcurso);

            //el id del usuario 
            var InfoUser = Validaciones.Helper.ObtenerDatos(Session["Usuario"]);

            //el id de la inscripcion
            var inscripcionGestion = new InscripcionesGestion();
            var inscrip = inscripcionGestion.ObtenerInscripcion(curso.IdCurso, InfoUser.Idusuario);
            if (!inscrip.Baja)
            {
                var GestionReseña = new ReseñaGestion();
                Dominio.Reseña reseña = new Dominio.Reseña(); //especifico x que confunde con el aspx
                reseña.Descripcion = TxtDescripcion.Text;
                reseña.Puntaje = int.Parse(DdlPuntaje.SelectedValue);
                reseña.IdInscripcion = inscrip.IdInscripcion;
                reseña.IdCurso = curso.IdCurso;

                GestionReseña.InsertarReseña(reseña);
                EnviarReseña.Visible = false;
                BtnVerMas.Visible = true;

            }
        }

        protected void BtnVerMas_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisCursos.aspx", false);
        }
    }
}