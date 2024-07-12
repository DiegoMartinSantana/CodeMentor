using System;
using Dominio;
using Negocio;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.DataTransferObjects;

namespace CodeMentor.AdminAspx
{
    public partial class AdminPreguntas : System.Web.UI.Page
    {
        public PreguntaRespuestaDto UltimaPregunta { get; set; }

        public List<PreguntaRespuestaDto> ListadoPreguntasRespuestasAdmin { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarListado();
                UltimasPreguntas(5);
                LlenarCursosRpt();
                TxtRespuesta.Visible = false;
                TxtRespuesta.Enabled = false;
            }

        }
        public void UltimasPreguntas(int cant)
        {
            ListadoPreguntasRespuestasAdmin = ListadoPreguntasRespuestasAdmin.OrderByDescending(x => x.FechaPregunta).Take(cant).ToList(); // Muestra las queles pase
        }

        public void LlenarCursosRpt()
        {
            var CursoGestion = new CursosGestion();
            RptCursos.DataSource = CursoGestion.Listado();
            RptCursos.DataBind();
        }
        public void LLenarListado() // x defecto 0 .Sino busca el curso!
        {
            // a futuro= llenar campos con AutoMappers si se llega el tiempo

            //llenamos las props que maneja el DTO
            var UsuarioGestion = new UsuariosGestion();
            var CursoGestion = new CursosGestion();
            var RespGestion = new RespuestasGestion();
            var PregGestion = new PreguntasGestion();

            //recorro todas preguntas existentes 
            ListadoPreguntasRespuestasAdmin = new List<PreguntaRespuestaDto>();

            foreach (var pregunta in PregGestion.ListadoPreguntas())// x defecto 0 .Sino envio el Idcurso
            {
                var Usuario = UsuarioGestion.ObtenerDatos(pregunta.IdUsuario);
                var Curso = CursoGestion.Existencia(pregunta.IdCurso);
                var Respuesta = RespGestion.Existencia(pregunta.IdPregunta);

                var PreguntaRespuesta = new PreguntaRespuestaDto
                {
                    IdPregunta = pregunta.IdPregunta,
                    IdCurso = pregunta.IdCurso,
                    NombreCurso = Curso.Nombre,
                    IdUsuario = pregunta.IdUsuario,
                    NombreApellidoUser = Usuario.Nombre + " " + Usuario.Apellido,
                    FechaPregunta = pregunta.Fecha,
                    TituloPregunta = pregunta.Titulo,
                    CuerpoPregunta = pregunta.Cuerpo,
                    IdRespuesta = null,
                    CuerpoRespuesta = null,
                    FechaRespuesta = null,
                };
                if (Respuesta != null)
                {
                    PreguntaRespuesta.IdRespuesta = Respuesta.IdRespuesta;
                    PreguntaRespuesta.CuerpoRespuesta = Respuesta.Cuerpo;
                    PreguntaRespuesta.FechaRespuesta = Respuesta.Fecha;
                }
                ListadoPreguntasRespuestasAdmin.Add(PreguntaRespuesta);
            }
            ListadoPreguntasRespuestasAdmin = ListadoPreguntasRespuestasAdmin.OrderByDescending(x => x.FechaPregunta).ToList(); //ORDENAMOS POR FECHA RECIENTE!

        }

        protected void BtnPreguntasSinResponder_Click(object sender, EventArgs e)
        {
            LLenarListado();
            //lleno donde respuesta sea null
            ListadoPreguntasRespuestasAdmin = ListadoPreguntasRespuestasAdmin.Where(x => x.IdRespuesta == null).OrderBy(x => x.FechaPregunta).ToList();
            // importante = Ordeno por fecha mas lejana. Para dar prioridad a quienes preguntaron primero!
        }

        protected void BtnSeleccionCurso_Click(object sender, EventArgs e)
        {
            LLenarListado();
            string valor = ((Button)sender).CommandArgument;
            int IdCurso = int.Parse(valor);
            ListadoPreguntasRespuestasAdmin = ListadoPreguntasRespuestasAdmin.Where(x => x.IdCurso == IdCurso).ToList();
        }

        protected void BtnVerTodas_Click(object sender, EventArgs e)
        {
            
            LLenarListado();
        }

        protected void BtnUltimaSemana_Click(object sender, EventArgs e)
        {
            LLenarListado();
            ListadoPreguntasRespuestasAdmin = ListadoPreguntasRespuestasAdmin.Where(x => x.FechaPregunta >= DateTime.Now.AddDays(-7)).ToList();
            //DONDE X  SEA MENOR 7 DIAS A LA FECHA ACTUAL
        }


      
        
    }
}