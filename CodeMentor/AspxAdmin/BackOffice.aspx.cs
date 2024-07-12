using System;
using Negocio;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
using Dominio.DataTransferObjects;

namespace CodeMentor
{
    public partial class BackOffice : System.Web.UI.Page
    {
        public Curso UltimoCurso { get; set; }

        public ReseñasDto UltimaReseña { get; set; }    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               /* if (!Validaciones.Seguridad.EsAdmin(Session["Usuario"]))
                {
                   Response.Redirect(ResolveUrl("~/AspxUsuario/Ingresar.aspx"));

                }
               */
                LLenarInscriptos();
                LLenarUltimoCurso();
                LlenarUltimaReseña();
                LlenarCantCertificados();
            }
        }
        public void LlenarCantCertificados()
        {
            var GestionInscrip = new InscripcionesGestion();
            LblCantCertificados.Text = GestionInscrip.CantCertificaciones().ToString();  
        }
        public void LlenarUltimaReseña() {
            var GestionReseña = new ReseñaGestion();
            UltimaReseña = GestionReseña.ListarReseñas().Last(); // MANEJA DTO


        }
        public void LLenarInscriptos()
        {
            var GestionInscrip = new InscripcionesGestion();
            LblCantInscriptos.Text = GestionInscrip.CantidadInscriptos().ToString();
        }
        public void LLenarUltimoCurso()
        {
            var GestionCursos = new CursosGestion();
            var cursos = GestionCursos.Listado();
            UltimoCurso= cursos.Last();

        }
    }
}