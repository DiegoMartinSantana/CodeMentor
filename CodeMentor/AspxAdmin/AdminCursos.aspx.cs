using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.DataTransferObjects;
using Negocio;

namespace CodeMentor.AdminAspx
{
    public partial class AdminCursos : System.Web.UI.Page
    {

        public List<CursosAdminDto> ListaCursos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LlenarCursos();
            }

        }
      
        public void LlenarCursos()
        {
            ListaCursos = Validaciones.Helper.LlenaryMapearCursosAdminDto();
            DgwCursos.DataSource = ListaCursos.OrderBy(x => x.Nombre);
            DgwCursos.DataBind();
        }
        protected void DgwCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //explicacion = row commmanod maneja los eventos de los botones o comandos de la grilla
            //necesitamos evaluar que comando esta usandose! por eso el btn tiene su propio Command Name 

            if (e.CommandName == "Visualizar")
            {
                // Obtener el ID del curso desde el CommandArgument
                string cursoID = e.CommandArgument.ToString();

                // Redirigir a la otra página con el ID del curso como parámetro en la URL
                Response.Redirect("AdminCursoRev.aspx?IdCurso=" + cursoID);
            }
        }
     
      

        protected void ddlOrdenarPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
           int selectedItem = int.Parse(ddlOrdenarPrecio.SelectedValue);
            LlenarCursos();
            if (selectedItem == 1)
            {
                ListaCursos = ListaCursos.OrderBy(x => x.Importe).ToList();
            }
            else
            {
                ListaCursos = ListaCursos.OrderByDescending(x => x.Importe).ToList();
            }
            DgwCursos.DataSource = ListaCursos;
            DgwCursos.DataBind();

        }
        protected void ddlOrdenarInscripciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(ddlOrdenarInscripciones.SelectedValue);
            LlenarCursos();

            if (selectedItem == 1)
            {
                //ordenar x inscripciones
                ListaCursos = ListaCursos.OrderByDescending(x => x.CantidadInscriptos).ToList();

            }
            else
            {
               ListaCursos = ListaCursos.OrderBy(x => x.CantidadInscriptos).ToList();
            
            }
            DgwCursos.DataSource = ListaCursos;
            DgwCursos.DataBind();
        }

        protected void ddlAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(ddlAZ.SelectedValue);
            LlenarCursos();
            if (selectedItem == 1)
            {
                ListaCursos = ListaCursos.OrderByDescending(x => x.Nombre).ToList();

            }
            else
            {
                ListaCursos = ListaCursos.OrderBy(x => x.Nombre).ToList();

            }
            DgwCursos.DataSource = ListaCursos;
            DgwCursos.DataBind();
        }
    }
}