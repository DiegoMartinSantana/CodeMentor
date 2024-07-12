using Dominio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CodeMentor.AspxUsuario
{
    public partial class Emitir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Ingresar.aspx");
                }
                if (Request.QueryString["IdCurso"] == null)
                {

                    Response.Redirect("InicioRegistrado.aspx");

                }
            }
        }

        protected void btnEmitir_Click(object sender, EventArgs e)
        {
            var InfoUser = Validaciones.Helper.ObtenerDatos(Session["Usuario"]);

            string nombre = InfoUser.Nombre + " " + InfoUser.Apellido;
            var curso = new Curso();
            if (Request.QueryString["IdCurso"] != null)
            {
                var cursoId = int.Parse(Request.QueryString["IdCurso"]);
                var GestionCurso = new CursosGestion();
                curso = GestionCurso.Existencia(cursoId);
                Session.Add("IdCursoReseña", cursoId);
            }
            else
            {
                Response.Redirect("InicioRegistrado.aspx");

            }
            //PARA AGREGAR ESTILOS O PARRAFOS ( PARAGRAPH, CHUNK, ETC) SE DEBE AGREGAR LA LIBRERIA ITEXTSHARP

            Document pdfDoc = new Document(PageSize.A4.Rotate(), 50, 50, 25, 25); // Medidas ajustadas para formato horizontal
            MemoryStream memoryStream = new MemoryStream(); // Se usa para hacer cosas en la memoria
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream); // Le pasamos al escritor las medidas y la memoria

            pdfDoc.Open(); // Abrimos el documento

            // Título con diseño
            Paragraph title = new Paragraph("Certificado de Finalización", new Font(Font.FontFamily.HELVETICA, 22, Font.BOLD, BaseColor.DARK_GRAY));
            title.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(title);

            pdfDoc.Add(new Paragraph("\n\n")); // Espacio

            // Subtítulo con diseño
            Paragraph nombreUsuario = new Paragraph("Este certificado se otorga a:", new Font(Font.FontFamily.HELVETICA, 16, Font.NORMAL, BaseColor.DARK_GRAY));
            nombreUsuario.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(nombreUsuario);

            pdfDoc.Add(new Paragraph("\n"));
            pdfDoc.Add(new Paragraph("\n\n")); // Espacio


            // Crear un Chunk con el nombre del usuario y el estilo deseado
            Chunk nombreDinamicoChunk = new Chunk(nombre, new Font(Font.FontFamily.HELVETICA, 26, Font.BOLDITALIC, BaseColor.RED));
            Paragraph nombreDinamico = new Paragraph(nombreDinamicoChunk);
            nombreDinamico.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(nombreDinamico);

            pdfDoc.Add(new Paragraph("\n\n"));

            // Texto del cuerpo con diseño
            Paragraph body = new Paragraph($"CodeMentor certifica que ha finalizado con éxito el curso de: {curso.Nombre}", new Font(Font.FontFamily.HELVETICA, 14, Font.NORMAL));
            body.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(body);

            pdfDoc.Add(new Paragraph("\n\n"));

            // Añadir una imagen (logo de la organización, por ejemplo)
            string logoPath = Server.MapPath("~/AspxUsuario/Imagenes/Iconos/codementor-fondonegro.png");
            if (File.Exists(logoPath))
            {
                Image logo = Image.GetInstance(logoPath);
                logo.Alignment = Element.ALIGN_CENTER;
                logo.ScaleToFit(300f, 300f);
                pdfDoc.Add(logo);
            }

            pdfDoc.Add(new Paragraph("\n\n"));

            // Fecha con diseño
            Paragraph fecha = new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.DARK_GRAY));
            fecha.Alignment = Element.ALIGN_RIGHT;
            pdfDoc.Add(fecha);


            pdfDoc.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();

            // Enviar el PDF al navegador
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Certificado.pdf");
            Response.BinaryWrite(bytes);
            Response.End();

        }

        protected void btnDejar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["IdCurso"] != null)
            {
                
                var cursoId = int.Parse(Request.QueryString["IdCurso"]);
                var GestionCurso = new CursosGestion();
               var curso = GestionCurso.Existencia(cursoId);
                Session.Add("IdCursoReseña", cursoId);
                Response.Redirect("Reseña.aspx", false);
            }
        }
    }
}