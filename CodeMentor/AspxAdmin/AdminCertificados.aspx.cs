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
    public partial class AdminCertificados : System.Web.UI.Page
    {
        public List<CertificadosDto> ListaCertificados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarCertificaciones();
            }
        }
        public void llenarCertificaciones()
        {
            var certicacionGestion = new CertificacionesGestion();
            ListaCertificados = certicacionGestion.ObtenerCertificacionesUsuariosCursos();
            DgwCertificados.DataSource = ListaCertificados;
            DgwCertificados.DataBind();
        }
        protected void ddlAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(ddlAZ.SelectedValue);
            llenarCertificaciones();
            if (selectedItem == 1)
            {
                ListaCertificados = ListaCertificados.OrderByDescending(x => x.NombreCurso).ToList();

            }
            else
            {
                ListaCertificados = ListaCertificados.OrderBy(x => x.NombreCurso).ToList();

            }
            DgwCertificados.DataSource = ListaCertificados;
            DgwCertificados.DataBind();
        }
    }
}

