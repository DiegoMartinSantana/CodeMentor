using Dominio;
using Dominio.DataTransferObjects;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;

namespace CodeMentor.AspxAdmin
{
    public partial class DiseñarCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                var GestionCat = new CategoriasGestion();
                DdlCategorias.DataSource = GestionCat.ListarCategorias();
                DdlCategorias.DataValueField = "IdCategoria";
                DdlCategorias.DataTextField = "Nombre";
                DdlCategorias.DataBind();
                BtnModificarCurso.Visible = false;



            }
        }

        protected void btnGuardarCurso_Click(object sender, EventArgs e)
        {
            //crea el curso, y deshabilito todo una vez crea. y activo modificar
            var CursoInsertar = new Curso();
            CursoInsertar.Nombre = TxtNombreCurso.Text;
            CursoInsertar.Descripcion =TxtDescripcionCurso.Text;
            CursoInsertar.IdCategoria = int.Parse(DdlCategorias.SelectedValue);
            CursoInsertar.Requisitos = TxtRequisitos.Text;
            CursoInsertar.Importe = decimal.Parse(TxtImporte.Text);
            //MANEJO DE IMAGEN : 
            string ruta = Server.MapPath("./Imagenes/Cursos/");//me ubico en la carpeta a trabajar

            //si guardo nombre, nombre contiene espacios, los limpio.
            string nombreLimpio = TxtNombreCurso.Text.Replace(" ", "_"); //reemplazo espacios por _

            TxtImagenCurso.PostedFile.SaveAs(ruta + "Curso-" + nombreLimpio + ".jpg");
            CursoInsertar.UrlPortada = "Curso-" + nombreLimpio + ".jpg";

            var GestionCurso= new CursosGestion();
            GestionCurso.AñadirCurso(CursoInsertar);
            Session.Add("CursoAñadido", CursoInsertar);
            //deshabilito todo y activo modificar

            BtnModificarCurso.Visible = true;
            btnGuardarCurso.Visible = false;

            TxtDescripcionCurso.Enabled = false;
            TxtNombreCurso.Enabled = false;
            TxtImporte.Enabled = false;
            TxtImagenCurso.Disabled = true;
            TxtRequisitos.Enabled = false;
            DdlCategorias.Enabled = false;


        }

        protected void BtnModificarCurso_Click(object sender, EventArgs e)
        {
            var GestionCurso = new CursosGestion();
           
            var Curso = GestionCurso.Listado().Last();
            Response.Redirect($"AdminCursoRev.aspx?IdCurso={Curso.IdCurso}", false);
        }

        protected void BtnAñadirUnidades_Click(object sender, EventArgs e)
        {
            if (Session["CursoAñadido"] == null)
            {
               Response.Write("<script>alert('Debe guardar el curso antes de añadir unidades');</script>"); //ejecutramos un  alert de js.
                return;
            }
            Curso curso = (Curso)Session["CursoAñadido"];
            CursosAdminDto cursoDto = Helper.LlenaryMapearCursosAdminDto().Find(x => x.Nombre == curso.Nombre);
            Session.Add("CursoEdicion", cursoDto);
            Response.Redirect("EdicionCurso.aspx", false);
        }
    }
}