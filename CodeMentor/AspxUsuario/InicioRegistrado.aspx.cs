using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CodeMentor.AspxUsuario
{
    public partial class InicioRegistrado : System.Web.UI.Page
    {
        public List<Curso> ListaCursosInscripto { get; set; }
        public List<Curso> ListaNoInscripto { get; set; }
        public Usuario UsuarioActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Ingresar.aspx",false);
            }
            if (!IsPostBack)
            {
                ObtenerUsuario();

                CargarCursos();
                CargarCursosNoFinalizados();
            }
            ObtenerUsuario();

            
            CargarCursos();
            CargarCursosNoFinalizados();

        }
        public void CargarCursosNoFinalizados()
        {
            var CursoGestion = new CursosGestion();
            ListaNoInscripto = new List<Curso>();
            ListaNoInscripto = CursoGestion.CursosNOInscripto(UsuarioActual.IdUsuario);

        }

        private void ObtenerUsuario()
        {
            if (Session["Usuario"] != null)
            {
                UsuarioActual = (Usuario)Session["Usuario"];
                if (UsuarioActual == null)
                {
                    Response.Redirect("Ingresar.aspx");
                }
            }
            else
            {
                Response.Redirect("Ingresar.aspx");
            }

        }
        public void CargarCursos()
        {
            var CursoGestion = new CursosGestion();
            ListaCursosInscripto = CursoGestion.CursosInscripto(UsuarioActual.IdUsuario);
        }

        protected void TxtFiltroCursos_TextChanged(object sender, EventArgs e)
        {
            CargarCursos();
            ListaCursosInscripto = ListaCursosInscripto.FindAll(x => x.Nombre.ToLower().Contains(TxtFiltroCursos.Text.ToLower()));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CargarCursos();
            CargarCursosNoFinalizados();
            ListaCursosInscripto = ListaCursosInscripto.FindAll(x => x.Nombre.ToLower().Contains(TxtFiltroCursos.Text.ToLower()));
            ListaNoInscripto = ListaNoInscripto.FindAll(x => x.Nombre.ToLower().Contains(TxtFiltroCursos.Text.ToLower()));
        }

       
    }
}
