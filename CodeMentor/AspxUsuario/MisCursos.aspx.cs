using Dominio;
using Negocio;
using Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeMentor.AspxUsuario
{

    public partial class MisCursos : System.Web.UI.Page
    {
        public List<Curso> CursosInscripto { get; set; }
        public InformacionUsuario InfoUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Validaciones.Seguridad.Login(Session["Usuario"]))

            {
                Response.Redirect("Ingresar.aspx");
            }
            if (!IsPostBack)
            {
                InfoUser = Validaciones.Helper.ObtenerDatos(Session["Usuario"]);

                LlenarLista();
            }

        }
        public void BarraProgreso(int idCurso)
        {
            InfoUser = Validaciones.Helper.ObtenerDatos(Session["Usuario"]);

            string progreso = ObtenerProgreso(idCurso);
            BarraProgresoCurso.Style.Add("width", progreso);
            pProgreso.InnerText = progreso;


        }
        public string ObtenerProgreso(int idCurso,int codigo=0)
        {
            // obtengo cantidad de unidades primero
            var UniGestion = new UnidadGestion();
            int Unidades = UniGestion.UnidadesPorCursoCant(idCurso);

            // obtengo unidades finalizadas
            int UnidadesFinalizadas = UniGestion.UnidadesFinalizadas(idCurso, InfoUser.Idusuario).Count;

            //calculo progreso
            int Progreso = (UnidadesFinalizadas * 100) / Unidades;
            if (codigo != 0)
            {
                return Progreso.ToString();
            }

            string progreso = Progreso.ToString() + "%";

            
            return progreso;

        }
        public bool FinalizoCurso(int idCurso)
        {
            //calculo en base a lo que ya esta!
            var Completado = int.Parse(ObtenerProgreso(idCurso,1));
            if (Completado == 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LlenarLista()
        {
            InfoUser = Validaciones.Helper.ObtenerDatos(Session["Usuario"]);

            var CursoGestion = new CursosGestion();
            CursosInscripto = new List<Curso>();
            CursosInscripto = CursoGestion.CursosInscripto(InfoUser.Idusuario);
        }

    }

}
