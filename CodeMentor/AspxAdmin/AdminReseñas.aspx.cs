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
    public partial class AdminReseñas : System.Web.UI.Page
    {
        public List<ReseñasDto> reseñasDtos { get; set; }

        public ReseñasDto ReseñaEliminar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarCursosRpt();
                LlenarReseñasRpt();
                LlenarReseñasDto();
            }
            if (Request.QueryString["IdEliminar"] != null)
            {
                LlenarReseñasDto();
                ReseñaEliminar = reseñasDtos.Find(x => x.IdReseña == int.Parse(Request.QueryString["IdEliminar"]));
                RptCursos.Visible= false;
                RptFiltroPuntuacion.Visible= false;
                BtnTodas.Visible = false;
                ToggleFiltros.Visible = false;
                ToggleCursos.Visible = false;
            }
        }
        private void LLenarCursosRpt()
        {
            var CursoGestion = new CursosGestion();
            RptCursos.DataSource = CursoGestion.Listado();
            RptCursos.DataBind();
        }
        private void LlenarReseñasRpt()
        {
            var Filtros = new List<Filtros>();
            Filtros.Add(new Filtros { IdFiltro = 1, NombreFiltro = "Menor a Mayor" });
            Filtros.Add(new Filtros { IdFiltro = 2, NombreFiltro = "Mayor a Menor" });
            RptFiltroPuntuacion.DataSource = Filtros;
            RptFiltroPuntuacion.DataBind();
        }
        private class Filtros
        {
            public string NombreFiltro { get; set; }
            public int IdFiltro { get; set; }
        }
        private void LlenarReseñasDto()
        {
            var ReseñasGestion = new ReseñaGestion();
            reseñasDtos = ReseñasGestion.ListarReseñas().OrderByDescending(x => x.FechaReseña).ToList();
        }

        protected void BtnSeleccionCurso_Click(object sender, EventArgs e)
        {

            string valor = ((Button)sender).CommandArgument;
            int IdCurso = int.Parse(valor);
            var ReseñasGestion = new ReseñaGestion();
            reseñasDtos = ReseñasGestion.ListarReseñas(IdCurso).ToList();

            Session.Add("IdCursoFiltro", IdCurso);
        }

        protected void BtnSeleccionFiltro_Click(object sender, EventArgs e)
        {

            string valor = ((Button)sender).CommandArgument;
            int IdFiltro = int.Parse(valor);
            int IdCursoFiltro = -1;

            if (Session["IdCursoFiltro"] != null)
            {
                IdCursoFiltro = (int)Session["IdCursoFiltro"];

            }
            if (IdFiltro == 1)
            {
                var ReseñasGestion = new ReseñaGestion();

                if (IdCursoFiltro != -1)
                {
                    var Lista = ReseñasGestion.ListarReseñas(IdCursoFiltro);
                    reseñasDtos = Lista.OrderBy(x => x.Puntaje).ToList();
                }
                else
                {
                    var Lista = ReseñasGestion.ListarReseñas();
                    reseñasDtos = Lista.OrderBy(x => x.Puntaje).ToList();
                }
            }
            else if (IdFiltro == 2)
            {
                var ReseñasGestion = new ReseñaGestion();
                if (IdCursoFiltro != -1)
                {
                    var Lista = ReseñasGestion.ListarReseñas(IdCursoFiltro);
                    reseñasDtos = Lista.OrderByDescending(x => x.Puntaje).ToList();

                }
                else
                {
                    var Lista = ReseñasGestion.ListarReseñas();
                    reseñasDtos = Lista.OrderByDescending(x => x.Puntaje).ToList();
                }
            }
        }

        protected void BtnTodas_Click(object sender, EventArgs e)
        {
            Session.Remove("IdCursoFiltro");
            LlenarReseñasDto();
        }

        public void AsignarEstrellas(int puntaje)
        {
            switch (puntaje)
            {
                case 1:

                    DivEstrellas.Attributes.Add("class", "estrella1");
                    DivEstrellasEliminar.Attributes.Add("class", "estrella1");

                    break;
                case 2:
                    DivEstrellas.Attributes.Add("class", "estrella2");
                    DivEstrellasEliminar.Attributes.Add("class", "estrella2");

                    break;
                case 3:
                    DivEstrellas.Attributes.Add("class", "estrella3");
                    DivEstrellasEliminar.Attributes.Add("class", "estrella3");

                    break;
                case 4:
                    DivEstrellas.Attributes.Add("class", "estrella4");
                    DivEstrellasEliminar.Attributes.Add("class", "estrella4");

                    break;
                case 5:
                    DivEstrellas.Attributes.Add("class", "estrella5");
                    DivEstrellasEliminar.Attributes.Add("class", "estrella5");

                    break;
            }

        }


        protected void BtnConfirmaEliminar_Click(object sender, EventArgs e)
        {

            LLenarCursosRpt();
            LlenarReseñasRpt();
            LlenarReseñasDto();
            EliminarReseña();
            EliminarReseña();
        }

        private void EliminarReseña()
        {
            var ReseñaGestion = new ReseñaGestion();

            int Id = int.Parse(Request.QueryString["IdEliminar"]);
            ReseñaGestion.EliminarReseña(Id);
            Response.Redirect("AdminReseñas.aspx");

        }

        protected void BtnCancelaEliminar_Click(object sender, EventArgs e)
        {

            LLenarCursosRpt();
            LlenarReseñasRpt();
            LlenarReseñasDto();
            Response.Redirect("AdminReseñas.aspx");

        }
    }
}