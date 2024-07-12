using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Validaciones;

namespace CodeMentor.AspxUsuario
{
    public partial class DetalleCurso : Page
    {
        public Curso CursoActual { get; set; }
        public List<Unidad> ListaUnidades { get; set; }
        public Dictionary<int, List<Clase>> ClasesPorUnidad { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.Login(Session["Usuario"])){
                Response.Redirect("Ingresar.aspx", false);
            }

            var CursoGestion = new CursosGestion();
            var UnidadGestion = new UnidadGestion();
            var ClaseGestion = new ClaseGestion();

            try
            {
                if (!int.TryParse(Request.QueryString["idCurso"], out int idCurso))
                {
                    // Si idCurso no es un numero valido redirigir a la pagina de inicio
                    Response.Redirect("Inicio.aspx");
                    return;
                }

                CursoActual = CursoGestion.Existencia(idCurso);

                if (CursoActual == null)
                {
                    // Si el curso no existe redirigir a la pagina de inicio
                    Response.Redirect("Inicio.aspx");
                    return;
                }

                // Obtener la lista de unidades para el curso actual
                ListaUnidades = UnidadGestion.ObtenerUnidadesPorCurso(idCurso);

                if (ListaUnidades == null)
                {
                    ListaUnidades = new List<Unidad>();
                }

                // Inicializar el diccionario para almacenar las clases por unidad
                ClasesPorUnidad = new Dictionary<int, List<Clase>>();

                // Obtener las clases para cada unidad
                foreach (var unidad in ListaUnidades)
                {
                    var clases = ClaseGestion.ObtenerClasesPorUnidad(unidad.IdUnidad);
                    ClasesPorUnidad[unidad.IdUnidad] = clases ?? new List<Clase>();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?mensaje=" + HttpUtility.UrlEncode(ex.Message));
            }
        }
    }
}


