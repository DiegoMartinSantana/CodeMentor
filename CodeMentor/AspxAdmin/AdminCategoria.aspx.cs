using Dominio;
using Dominio.DataTransferObjects;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeMentor.AspxAdmin
{
    public partial class AdminCategoria : System.Web.UI.Page
    {
        public List<Categoria> ListaCategorias { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarCategorias();
                PanelCursosAsociados.Visible = false;
                PanelAgregarCat.Visible = false;
            }
        }
        public void llenarCategorias()
        {
            var cateGestion = new CategoriasGestion();
            ListaCategorias = cateGestion.ListarCategorias();
            DgwCategorias.DataSource = ListaCategorias;
            DgwCategorias.DataBind();
        }
        protected void ddlAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(ddlAZ.SelectedValue);
            llenarCategorias();
            if (selectedItem == 1)
            {
                ListaCategorias = ListaCategorias.OrderByDescending(x => x.Nombre).ToList();

            }
            else
            {
                ListaCategorias = ListaCategorias.OrderBy(x => x.Nombre).ToList();

            }
            DgwCategorias.DataSource = ListaCategorias;
            DgwCategorias.DataBind();
        }

        protected void DgwCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                string CatId = e.CommandArgument.ToString();
                PanelCursosAsociados.Visible = true;
                PanelAgregarCat.Visible = false;
                var cursosGestion = new CursosGestion();
                var cursos = cursosGestion.ObtenerCursosPorCategoria(int.Parse(CatId));
                RptCursosCategoria.DataSource = cursos;
                RptCursosCategoria.DataBind();
            }

        }

        protected void BtnAgregar_Panel_Click(object sender, EventArgs e)
        {
            PanelAgregarCat.Visible = true;
            PanelCursosAsociados.Visible = false;
        }

        protected void BtnAgregarCat_Click(object sender, EventArgs e)
        {

            Categoria cat = new Categoria();
            var catGestion  = new CategoriasGestion();
            cat.Nombre = TxtNombre.Text;
            catGestion.InsertarCategoria(cat);
            Response.Redirect("AdminCategoria.aspx", false);

        }

        protected void BtnCancelarCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCategoria.aspx", false);
        }
    }
}