using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Dominio.DataTransferObjects;
using Dominio.DTOS;
using iTextSharp.text;
using Negocio;
using static System.Collections.Specialized.BitVector32;

namespace CodeMentor.AspxAdmin
{
    public partial class AdminInscripciones1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<InscripcionesGestionDto> list = new List<InscripcionesGestionDto>();
                InscripcionesGestion inscripcionGest = new InscripcionesGestion();
                list = inscripcionGest.ListarInscripciones();
                GridViewInscripciones.DataSource = list;
                GridViewInscripciones.DataBind();
                H5Info.Visible = false;
            }
        }
       
        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewInscripciones.Rows)
            {
                CheckBox chkEliminar = (CheckBox)row.FindControl("chkHabilitar");
                int idInscripcion = (int)GridViewInscripciones.DataKeys[row.RowIndex].Value;

                var inscripcion = new InscripcionesGestionDto();

                var insGest = new InscripcionesGestion();

                if (chkEliminar != null && chkEliminar.Checked)
                {
                    insGest.AltaInscripcionHabilitada(idInscripcion);
                }
                if (chkEliminar.Checked == false && chkEliminar!=null)
                {
                    insGest.BajaInscripcionHabilitada(idInscripcion);
                }
            }
           
            Response.Redirect("AdminInscripciones.aspx", false);

        }

        protected void BtnDadasBaja_Click(object sender, EventArgs e)
        {
            InscripcionesGestion inscripcionGest = new InscripcionesGestion();

            var listainscripcion = inscripcionGest.ListarInscripciones();
            listainscripcion = listainscripcion.Where(x => x.Baja == true).ToList();
            GridViewInscripciones.DataSource = listainscripcion;
            GridViewInscripciones.DataBind();
            if (listainscripcion.Count == 0)
            {
                H5Info.Visible = true;
                H5Info.InnerText = "No hay inscripciones dadas de Baja";
                btnConfirmarEliminacion.Visible = false;
                btnHabilitar.Visible = false;

            }
            else
            {
                btnConfirmarEliminacion.Visible = true;
                btnHabilitar.Visible = true;

                H5Info.Visible = false;
            }
        }

        protected void BtnPendientes_Click(object sender, EventArgs e)
        {
            InscripcionesGestion inscripcionGest = new InscripcionesGestion();

            var listainscripcion = inscripcionGest.ListarInscripciones();
            listainscripcion = listainscripcion.Where(x => x.Habilitada == false).ToList();
            GridViewInscripciones.DataSource = listainscripcion;
            GridViewInscripciones.DataBind();
            if (listainscripcion.Count == 0)
            {
                H5Info.Visible = true;
                H5Info.InnerText = "No hay inscripciones pendientes";
                btnConfirmarEliminacion.Visible = false;
                btnHabilitar.Visible = false;
            }
            else
            {
                btnConfirmarEliminacion.Visible = true;
                btnHabilitar.Visible = true;

                H5Info.Visible = false;
            }
        }

        protected void BtnHabilitados_Click(object sender, EventArgs e)
        {
            InscripcionesGestion inscripcionGest = new InscripcionesGestion();

            var listainscripcion = inscripcionGest.ListarInscripciones();
            listainscripcion = listainscripcion.Where(x => x.Habilitada == true).ToList(); // este habilitada
            listainscripcion = listainscripcion.Where(x => x.Baja == false).ToList(); // pero no dada de baja
            GridViewInscripciones.DataSource = listainscripcion;
            GridViewInscripciones.DataBind();
            if (listainscripcion.Count == 0)
            {
                H5Info.Visible = true;
                H5Info.InnerText = "No hay inscripciones Habilitadas";
                btnConfirmarEliminacion.Visible = false;
                btnHabilitar.Visible = false;
            }
            else
            {
                btnConfirmarEliminacion.Visible = true; 
                btnHabilitar.Visible = true;
                H5Info.Visible = false;
            }
        }


        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewInscripciones.Rows)
            {
                CheckBox chkEliminar = (CheckBox)row.FindControl("chkEliminar");
                int idInscripcion = (int)GridViewInscripciones.DataKeys[row.RowIndex].Value;

                var inscripcion = new InscripcionesGestionDto();

                var insGest = new InscripcionesGestion();

                if (chkEliminar != null && chkEliminar.Checked)
                {
                    insGest.BajaInscripcion(idInscripcion);
                }
                if(chkEliminar != null && !chkEliminar.Checked)
                {
                    insGest.AltaInscripcion(idInscripcion);

                }
            }
            Response.Redirect("AdminInscripciones.aspx", false);
        }

        protected void BtnTodas_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInscripciones.aspx", false);

        }
    }
}
