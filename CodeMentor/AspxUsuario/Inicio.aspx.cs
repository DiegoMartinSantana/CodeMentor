using Dominio;
using Negocio;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeMentor.AspxUsuario
{
    public partial class Inicio : System.Web.UI.Page
    {
        public List<Curso> ListaCursos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                CargarCursos();
            }
        }
       
        public void CargarCursos()
        {
            var CursoGestion = new CursosGestion();
            ListaCursos = CursoGestion.Listado();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CargarCursos();
            ListaCursos = ListaCursos.FindAll(x => x.Nombre.ToLower().Contains(TxtFiltroCursos.Text.ToLower()));
        }

        protected void TxtFiltroCursos_TextChanged(object sender, EventArgs e)
        {

            CargarCursos();
            ListaCursos = ListaCursos.FindAll(x => x.Nombre.ToLower().Contains(TxtFiltroCursos.Text.ToLower()));
        }
    }
}