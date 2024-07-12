using Dominio;
using Dominio.DataTransferObjects;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;

namespace CodeMentor.AspxAdmin
{
    public partial class AdminCursoRev : System.Web.UI.Page
    {
        public CursosAdminDto CursoDto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["idClase"] == null)
            {

                LLenarCurso();
                LLenarCategorias();

                DeshabiitarCampos();
            }

            if (Request.QueryString["idClase"] != null)
            {

                DdlCategorias.Visible = false;

                var idClase = int.Parse(Request.QueryString["idClase"]);
                var ClaseGestion = new ClaseGestion();
                var clase = ClaseGestion.ListarClases().FirstOrDefault(c => c.IdClase == idClase);

                var GestionUnidades = new UnidadGestion();
                var Unidad = GestionUnidades.Listado(clase.IdUnidad);

                //llenar cursos 
                var GestionCurso = new CursosGestion();
                CursoDto = Helper.LlenaryMapearCursosAdminDto().FirstOrDefault(c => c.IdCurso == Unidad.FirstOrDefault().IdCurso);
                DeshabiitarCampos();

                // MUESTRO EL VIDEO
            }
        }
        private void DeshabiitarCampos()
        {
            TxtModifDescripcion.Enabled = false;
            TxtModifDescripcion.Visible = false;
            TxtModifNombre.Enabled = false;
            TxtModifNombre.Visible = false;
            TxtModifImporte.Enabled = false;
            TxtModifImporte.Visible = false;
            TxtModifRequisitos.Enabled = false;
            TxtModifRequisitos.Visible = false;


            BtnGuardarCambios.Visible = false;
            BtnCancelarCambios.Visible = false;
            DdlCategorias.Visible = false;
            BtnModificar.Visible = true;
            TxtNuevaImagen.Visible = false;
        }

        public void LLenarCurso()
        {
            int IdCurso = int.Parse(Request.QueryString["IdCurso"]);
            CursoDto = Validaciones.Helper.LlenaryMapearCursosAdminDto().FirstOrDefault(c => c.IdCurso == IdCurso);
            Session.Add("CursoEdicion", CursoDto);

        }
        public List<Clase> ListarClases(int IdUnidad)
        {
            var ClaseGestion = new ClaseGestion();
            return ClaseGestion.ObtenerClasesPorUnidad(IdUnidad);
        }
        public void LLenarCategorias()
        {
            var GestionCategorias = new CategoriasGestion();
            DdlCategorias.DataTextField = "Nombre";
            DdlCategorias.DataValueField = "IdCategoria";
            DdlCategorias.DataSource = GestionCategorias.ListarCategorias();

            DdlCategorias.DataBind();
            DdlCategorias.Visible = true;
        }

        protected void BtnCancelarCambios_Click(object sender, EventArgs e)
        {
            LLenarCurso();
            DeshabiitarCampos();
        }
        protected void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            LLenarCurso();
            int con = 0;


            if (TxtModifNombre.Text != CursoDto.Nombre && TxtModifNombre.Enabled)
            {

                CursoDto.Nombre = TxtModifNombre.Text;
                if (TxtNuevaImagen.PostedFile != null)
                {
                    string ruta = Server.MapPath("./Imagenes/Cursos/"); //me ubico en la carpeta a trabajar

                    // si guardo nombre, nombre contiene espacios, los limpio.
                    string nombreLimpio = CursoDto.Nombre.Replace(" ", "_"); // reemplazo espacios por _
                    string nombreArchivo = "Curso-" + nombreLimpio + ".jpg";
                    string rutaCompleta = Path.Combine(ruta, nombreArchivo);


                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                    }

                    TxtNuevaImagen.PostedFile.SaveAs(rutaCompleta);

                    CursoDto.UrlPortada = nombreArchivo;
                }
               
            }
            else
            {
                con += 2;
                if (TxtNuevaImagen.PostedFile != null)
                {
                    string ruta = Server.MapPath("./Imagenes/Cursos/"); //me ubico en la carpeta a trabajar

                    // si guardo nombre, nombre contiene espacios, los limpio.
                    string nombreLimpio = CursoDto.Nombre.Replace(" ", "_"); // reemplazo espacios por _
                    string nombreArchivo = "Curso-" + nombreLimpio + ".jpg";
                    string rutaCompleta = Path.Combine(ruta, nombreArchivo);

                    
                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                    }

                    TxtNuevaImagen.PostedFile.SaveAs(rutaCompleta);

                    CursoDto.UrlPortada = nombreArchivo;
                }

            }

            if (TxtModifDescripcion.Text != CursoDto.Descripcion && TxtModifDescripcion.Enabled)
            {
                CursoDto.Descripcion = TxtModifDescripcion.Text;
            }
            else
            {
                con++;
            }

            if (TxtModifImporte.Text != CursoDto.ImporteFormateado && TxtModifImporte.Enabled)
            {
                CursoDto.Importe = decimal.Parse(TxtModifImporte.Text);
            }
            else
            {
                con++;
            }

            if (DdlCategorias.Visible)
            {
                var inta = DdlCategorias.SelectedIndex;
                CursoDto.IdCategoria = int.Parse(DdlCategorias.SelectedItem.Value);
            }
            else
            {
                con++;
            }
            if (TxtModifRequisitos.Text != CursoDto.Requisitos && TxtModifRequisitos.Enabled)
            {
                CursoDto.Requisitos = TxtModifRequisitos.Text;
            }
            else
            {
                con++;
            }
            if (con == 6)
            {
                // si contador llega a 6, no existen cambios. sino tengoque evaluar nuevamente cada campo..
                Response.Redirect("AdminCursoRev.aspx?IdCurso=" + CursoDto.IdCurso);
            }

            var CursoGestion = new CursosGestion();
            var Curso = CursoGestion.Existencia(CursoDto.IdCurso);
            Curso.Nombre = CursoDto.Nombre;
            Curso.Descripcion = CursoDto.Descripcion;
            Curso.Importe = CursoDto.Importe;
            Curso.IdCategoria = CursoDto.IdCategoria;
            Curso.UrlPortada = CursoDto.UrlPortada;
            CursoGestion.ModificarCurso(Curso);
            Response.Redirect("AdminCursoRev.aspx?IdCurso=" + CursoDto.IdCurso);

        }
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            LLenarCurso();
            LLenarCategorias();
            BtnCancelarCambios.Visible = true;
            BtnModificar.Visible = false;
            BtnGuardarCambios.Visible = true;

            TxtModifDescripcion.Enabled = true;
            TxtModifDescripcion.Visible = true;
            TxtModifImporte.Enabled = true;
            TxtModifImporte.Visible = true;
            TxtModifNombre.Enabled = true;
            TxtModifNombre.Visible = true;
            TxtModifRequisitos.Enabled = true;
            TxtModifRequisitos.Visible = true;
            TxtNuevaImagen.Visible = true;
            DdlCategorias.Visible = true;

            TxtModifImporte.Text = CursoDto.ImporteFormateado;
            TxtModifNombre.Text = CursoDto.Nombre;
            TxtModifDescripcion.Text = CursoDto.Descripcion;
            TxtModifRequisitos.Text = CursoDto.Requisitos;

        }


    }
}