using Dominio;
using Dominio.DataTransferObjects;
using Negocio;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;

namespace CodeMentor
{
    public partial class Reproduccion : System.Web.UI.Page
    {
        public bool ViendoUsuarios { get; set; }

        public InformacionUsuario UsuarioActual { get; set; }
        public List<PreguntaRespuestaDto> ListadoPreguntasRespuestas { get; set; }

        public Curso CursoActual { get; set; }
        public List<Unidad> ListaUnidades { get; set; }
        public Dictionary<int, List<Clase>> ClasesPorUnidad { get; set; }

        // Metodos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Ingresar.aspx", false);
            }
            if (Request.QueryString["IdClaseOk"] != null)
            {

                int idClaseFinalizo = int.Parse(Request.QueryString["IdClaseOk"]);
                Session.Add("IdFinalizada", idClaseFinalizo);
                //finaliza la clase
                var ClaseGestion = new ClaseGestion();
                llenarCursoActual();
                 ObtenerUsuario();
                ClaseGestion.FinalizoClase(idClaseFinalizo,CursoActual.IdCurso,UsuarioActual.Idusuario);

                var idClase = int.Parse(Request.QueryString["IdClaseOk"]);
                var clase = ClaseGestion.ListarClases().FirstOrDefault(c => c.IdClase == idClase+1); //muestro la clase siguiente a donde finalizo

                var GestionUnidades = new UnidadGestion();
                ListaUnidades = GestionUnidades.Listado().Where(u => u.IdUnidad == clase.IdUnidad).ToList();

                //llenar cursos 
                var GestionCurso = new CursosGestion();
                CursoActual = GestionCurso.Existencia(ListaUnidades.FirstOrDefault().IdCurso);
                LlenarUltimasDos();

                llenarUnidades(CursoActual.IdCurso);

                // MUESTRO EL VIDEO
                MostrarVideo(clase.UrlVideo);
            }

            if (!IsPostBack && Request.QueryString["idClase"] == null || Session["IdFinalizada"] != null)
            {
                llenarCursoActual();
                llenarUnidades();
                llenarClases();
                LlenarUltimasDos();

                // Mostrar el video de la primera clase si existe
                if (ClasesPorUnidad.Count > 0)
                {
                    var primeraClase = ClasesPorUnidad.First().Value.FirstOrDefault();
                    if (primeraClase != null)
                    {
                        MostrarVideo(primeraClase.UrlVideo);
                    }
                }
            }

            if (Request.QueryString["idClase"] != null) //IMPORANTE : ACTUALIZAR TAMBIEN EN BASE A CUANDO DA X FINALIZADA
            {
                var idClase = int.Parse(Request.QueryString["idClase"]);
                var ClaseGestion = new ClaseGestion();
                var clase = ClaseGestion.ListarClases().FirstOrDefault(c => c.IdClase == idClase);

                var GestionUnidades = new UnidadGestion();
                ListaUnidades = GestionUnidades.Listado().Where(u => u.IdUnidad == clase.IdUnidad).ToList();

                //llenar cursos 
                var GestionCurso = new CursosGestion();
                CursoActual = GestionCurso.Existencia(ListaUnidades.FirstOrDefault().IdCurso);
                LlenarUltimasDos();

                llenarUnidades(CursoActual.IdCurso);

                // MUESTRO EL VIDEO
                MostrarVideo(clase.UrlVideo);
            }
            if (IsPostBack)
            {
                CursoActual = new Curso();
                ListadoPreguntasRespuestas = new List<PreguntaRespuestaDto>();
                ListaUnidades = new List<Unidad>();
                ClasesPorUnidad = new Dictionary<int, List<Clase>>();
            }
        }
        public void LlenarPreguntas()
        {

            var PregGestion = new PreguntasGestion();
            ListadoPreguntasRespuestas = Helper.LlenaryMapearPreg_Resp(CursoActual.IdCurso);
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
        public void LlenarUltimasDos()
        {
            LlenarPreguntas();
            ListadoPreguntasRespuestas = ListadoPreguntasRespuestas.Take(2).ToList();
        }

        public List<Clase> ListarClases(int IdUnidad)
        {
            var ClaseGestion = new ClaseGestion();
            return ClaseGestion.ObtenerClasesPorUnidad(IdUnidad);
        }
        public void llenarCursoActual()
        {
            var CursoGestion = new CursosGestion();
            int idCurso = 0;
            if (Request.QueryString["idCurso"] != null)
            {
                idCurso = int.Parse((Request.QueryString["idCurso"]));
                CursoActual = CursoGestion.Existencia(idCurso);
                if(CursoActual== null)
                {
                    Response.Redirect("InicioRegistrado.aspx", false);

                }
                Session.Add("CursoRep", CursoActual);

            }


            if (Session["CursoRep"]!=null)
            {
                CursoActual = (Curso)Session["CursoRep"];
            }
            else
            {
                Response.Redirect("Inicio.aspx", false);
            }

        }
        public void llenarUnidades() // Llena las unidades por primera vez en la pagina con el id de curso que se recibe por url
        {
            var UnidadGestion = new UnidadGestion();
            var curso = (Curso)Session["CursoRep"]; 
            ListaUnidades = UnidadGestion.ObtenerUnidadesPorCurso(curso.IdCurso);
        }
        public void llenarUnidades(int idCurso) // Llena las unidades luego de refrescar la pagina con otra clase
        {
            var UnidadGestion = new UnidadGestion();
            ListaUnidades = UnidadGestion.ObtenerUnidadesPorCurso(idCurso);
        }
        public void llenarClases()
        {
            // Inicializar el diccionario para almacenar las clases por unidad
            var ClaseGestion = new ClaseGestion();
            ClasesPorUnidad = new Dictionary<int, List<Clase>>();

            // Obtener las clases para cada unidad
            foreach (var unidad in ListaUnidades)
            {
                var clases = ClaseGestion.ObtenerClasesPorUnidad(unidad.IdUnidad);
                ClasesPorUnidad[unidad.IdUnidad] = clases ?? new List<Clase>();
            }
        }
        private void MostrarVideo(string urlVideo)
        {
            videoFrame.Text = Helper.InsertarIframe(urlVideo); // la db tiene el link normal de youtube
        }
        public void ObtenerUsuario()
        {
            UsuarioActual = Validaciones.Helper.ObtenerDatos(Session["Usuario"]);

        }
        public bool CheckedClases(int idclase)
        {
            //si esta finalizada cambio el valor del checkbox
            ObtenerUsuario();
            var ClaseGestion = new ClaseGestion();
            var clases = ClaseGestion.ClasesFinalizadas(UsuarioActual.Idusuario);

            var clase = clases.FirstOrDefault(c => c.IdClase == idclase);

            if (clase != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}