using Dominio;
using Dominio.DataTransferObjects;
using Negocio;

using Negocio.ServicioEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeMentor.AspxAdmin
{
    public partial class AdminRespuesta : System.Web.UI.Page
    {
        public PreguntaRespuestaDto Preg { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Validar admin..

                if (Request.QueryString["Id"] == null && Request.QueryString["IdModificar"] == null)
                {
                    Response.Redirect("Ingresar.aspx", false);
                }
                TxtRespuestaModificar.Enabled = false;
                LLenarDto();
                TxtRespuestaModificar.Text = Preg.CuerpoRespuesta;
            }
        }


        public void LLenarDto()
        {

            int id;
            if (Request.QueryString["Id"] != null)
            {
                id = int.Parse(Request.QueryString["Id"]);

            }
            else if ((Request.QueryString["IdModificar"] != null))
            {
                id = int.Parse(Request.QueryString["IdModificar"]);
                BtnModificar.Visible = true;
                BtnGuardarCambios.Visible = false;

            }
            else
            {
                return;
            }

            var pregGestion = new PreguntasGestion();

            var UsuarioGestion = new UsuariosGestion();
            var CursoGestion = new CursosGestion();
            var RespGestion = new RespuestasGestion();

            var pregunta = pregGestion.Obtener(id);

            var Usuario = UsuarioGestion.ObtenerDatos(pregunta.IdUsuario);
            var Curso = CursoGestion.Existencia(pregunta.IdCurso);
            var Respuesta = RespGestion.Existencia(pregunta.IdPregunta);
            Preg = new PreguntaRespuestaDto();
            Preg.IdPregunta = pregunta.IdPregunta;
            Preg.IdCurso = pregunta.IdCurso;
            Preg.NombreCurso = Curso.Nombre;
            Preg.IdUsuario = pregunta.IdUsuario;
            Preg.NombreApellidoUser = Usuario.Nombre + " " + Usuario.Apellido;
            Preg.FechaPregunta = pregunta.Fecha;
            Preg.TituloPregunta = pregunta.Titulo;
            Preg.CuerpoPregunta = pregunta.Cuerpo;
            Preg.IdRespuesta = null;
            Preg.CuerpoRespuesta = null;
            Preg.FechaRespuesta = null;

            if (Respuesta != null)
            {

                Preg.IdRespuesta = Respuesta.IdRespuesta;
                Preg.CuerpoRespuesta = Respuesta.Cuerpo;
                Preg.FechaRespuesta = Respuesta.Fecha;
                BtnEnviarRespuesta.Visible = false;
            }
            else
            {
                BtnModificar.Visible = false;
                BtnGuardarCambios.Visible = false;
            }
        }

        protected void BtnEnviarRespuesta_Click(object sender, EventArgs e)
        {
            var RespGestion = new RespuestasGestion();
            string Cuerpo = TxtRespuesta.Text;
            var Resp = new Respuesta();
            LLenarDto();

            Resp.Cuerpo = Cuerpo;
            Resp.IdPregunta = Preg.IdPregunta;
            RespGestion.AltaRespuesta(Resp);
            BtnEnviarRespuesta.Visible = false;
            BtnModificar.Visible = true;
            TxtRespuesta.Enabled = false;

            // Envio Email a Usuario que pregunto Avisando
            var Envio = new EnvioGmail();
            string mensaje = $"Hola {Preg.NombreApellidoUser}! Se ha respondido a su pregunta : {Preg.TituloPregunta} en {Preg.NombreCurso} ingrese a la plataforma para ver la respuesta.";
            var DatosGestion = new UsuariosGestion();
            var Datos = DatosGestion.ObtenerUsuario(Preg.IdUsuario);
            string asunto = $"Respuesta en {Preg.NombreCurso}";
            Envio.EmailUsuarioRespuesta(Datos.Email, asunto, mensaje);
            Envio.EnviarEmail();
            Response.Redirect("AdminRespuesta.aspx?IdModificar=" + Preg.IdPregunta, false);
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            LLenarDto();
            BtnGuardarCambios.Visible = true;
            BtnModificar.Visible = false;
            TxtRespuestaModificar.Enabled = true;


        }

        protected void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            var RespGestion = new RespuestasGestion();
            LLenarDto();
            string Cuerpo = TxtRespuestaModificar.Text;
            var Resp = new Respuesta();
            Resp.IdRespuesta = Preg.IdRespuesta.Value;
            Resp.Cuerpo = Cuerpo;
            Resp.Fecha = DateTime.Now; //actualizamos la fecha tambien
            Resp.IdPregunta = Preg.IdPregunta;
            RespGestion.ModificarRespuesta(Resp);
            Response.Redirect("AdminRespuesta.aspx?IdModificar=" + Preg.IdPregunta);
        }
    }
}