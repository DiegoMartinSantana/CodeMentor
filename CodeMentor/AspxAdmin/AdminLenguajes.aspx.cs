using Dominio;
using Dominio.DTOS;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace CodeMentor.AspxAdmin
{
    public partial class AdminLenguajes : System.Web.UI.Page
    {
        public List<Lenguaje> ListaLenguajes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarLenguajes();
                PanelCursosAsociados.Visible = false;
                PanelAgregarLenguaje.Visible = false;
            }
        }
        public void llenarLenguajes()
        {
            var lenguajeGestion = new LenguajesGestion();
            ListaLenguajes = lenguajeGestion.ListarLenguajes();
            DgwLenguajes.DataSource = ListaLenguajes;
            DgwLenguajes.DataBind();
        }
        protected void DgwLenguajes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // agregar la logica para manejar otras acciones en el Gridview
            if (e.CommandName == "Cursos") { 
                string LenguajeId = e.CommandArgument.ToString();
                PanelCursosAsociados.Visible = true;
                var cursosGestion = new CursosGestion();
                var cursos = cursosGestion.ObtenerCursosPorLenguaje(int.Parse(LenguajeId));
                RptCursosLenguaje.DataSource = cursos;
                RptCursosLenguaje.DataBind();
                PanelAgregarLenguaje.Visible =false;
            }
        }
      
        protected void ddlAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(ddlAZ.SelectedValue);
            llenarLenguajes();
            if (selectedItem == 1)
            {
                ListaLenguajes = ListaLenguajes.OrderByDescending(x => x.Nombre).ToList();
            }
            else
            {
                ListaLenguajes = ListaLenguajes.OrderBy(x => x.Nombre).ToList();
            }
            DgwLenguajes.DataSource = ListaLenguajes;
            DgwLenguajes.DataBind();
        }

        protected void BtnAgregarLenguaje_Click1(object sender, EventArgs e)
        {
            PanelAgregarLenguaje.Visible = true;
            PanelCursosAsociados.Visible = false;
            var cursosGest = new CursosGestion();
            DgwCursosAsociar.DataSource = cursosGest.Listado();
            DgwCursosAsociar.DataBind();
          

        }
        protected void btnAgregarLenguaje_Click(object sender, EventArgs e)
        {
            var nuevoLenguaje = new Lenguaje();
            nuevoLenguaje.Nombre = TxtNombre.Text;
            var lenguajeGestion = new LenguajesGestion();
            lenguajeGestion.InsertarLenguaje(nuevoLenguaje);
            var lenguaje = lenguajeGestion.ListarLenguajes().Find(x => x.Nombre == nuevoLenguaje.Nombre);
            foreach (GridViewRow row in DgwCursosAsociar.Rows) // recorro las filas seleccionadas
            {
                CheckBox chkAsociar = (CheckBox)row.FindControl("chkAsociar"); // obtengo el check
                                                                                // 
                int idCurso = (int)DgwCursosAsociar.DataKeys[row.RowIndex].Value;//obtengo el id del curso que quiere asociar!
                if (chkAsociar != null && chkAsociar.Checked) //si esta check
                {
                    //asocio el lenguaje al curso
                    lenguajeGestion.AsociarLenguajes(lenguaje.IdLenguaje, idCurso);

                }
            }


            llenarLenguajes();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            PanelAgregarLenguaje.Visible = false;
                PanelCursosAsociados.Visible=false;
        }
    }
}