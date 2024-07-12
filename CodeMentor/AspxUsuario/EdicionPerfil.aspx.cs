using System;
using Dominio;
using Negocio;
using Validaciones.Logicas;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeMentor.AspxUsuario
{
    public partial class EdicionPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Validaciones.Seguridad.Login(Session["Usuario"]))
            {
                Response.Redirect("Ingresar.aspx", false);
            }
            if(!IsPostBack)
            LLenarDatos();
          
        }
        private void LLenarDatos()
        {
            var User = new Usuario();
            User = (Usuario)Session["Usuario"];
            var DatosActuales = new InformacionUsuario();
            var GestionUser = new UsuariosGestion();
            DatosActuales = GestionUser.ObtenerDatos(User.IdUsuario);
            TxtApellido.Text = DatosActuales.Apellido;
            TxtNombre.Text = DatosActuales.Nombre;
            TxtCelular.Text = DatosActuales.Celular;
            if (!string.IsNullOrEmpty(DatosActuales.UrlFotoPerfil)){
                ImgPerfil.ImageUrl = "~/AspxUsuario/Imagenes/Perfil/" + DatosActuales.UrlFotoPerfil;
            }
            else
            {
                ImgPerfil.ImageUrl = "https://blog.jumboprinters.com/wp-content/uploads/2021/09/consejos-imagenes.jpg";
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            var User = new Usuario();
            User = (Usuario)Session["Usuario"];
            var DatosActuales = new InformacionUsuario();
            var GestionUser = new UsuariosGestion();
            DatosActuales = GestionUser.ObtenerDatos(User.IdUsuario);
            DatosActuales.Idusuario = User.IdUsuario;
            DatosActuales.Nombre = TxtNombre.Text;
            DatosActuales.Apellido = TxtApellido.Text;
            DatosActuales.Celular = TxtCelular.Text;
            if (!string.IsNullOrEmpty(TxtCargaImagen.PostedFile.FileName))
            {
                string ruta = Server.MapPath("./Imagenes/Perfil/");
                TxtCargaImagen.PostedFile.SaveAs(ruta + "Perfil-" + User.Email + ".jpg");
                DatosActuales.UrlFotoPerfil = "Perfil-" + User.Email + ".jpg";
            }
            var valido = new RegistroValidaciones();
            var DtoUser = Validaciones.Helper.MapearUsuario(User, DatosActuales);
            var Resultado = valido.Validate(DtoUser); // puedo usar este, porque contiene datos ya aceptados al registrar
            if (Resultado.IsValid)
            {
                GestionUser.ActualizarDatos(DtoUser);
            }
            else
            {
                var ValidoClass = " form-control form-control2 is-valid";
                var InvalidoClass = "  form-control form-control2 is-invalid";

                var errorNombre = Resultado.Errors.FirstOrDefault(x => x.PropertyName == "Nombre");
                if (errorNombre != null)
                {
                    TxtNombre.CssClass += InvalidoClass;
                    PNombreError.InnerText = errorNombre.ErrorMessage;
                    PNombreError.Visible = true;
                }
                else
                {
                    TxtNombre.CssClass = ValidoClass;
                    PNombreError.Visible = false;
                }

                var errorApellido = Resultado.Errors.FirstOrDefault(x => x.PropertyName == "Apellido");
                if (errorApellido != null)
                {
                    TxtApellido.CssClass += InvalidoClass;
                    PApellidoError.InnerText = errorApellido.ErrorMessage;
                    PApellidoError.Visible = true;

                }
                else
                {
                    TxtApellido.CssClass = ValidoClass;
                    PApellidoError.Visible = false;
                }

                var errorCelular = Resultado.Errors.FirstOrDefault(x => x.PropertyName == "Celular");
                if (errorCelular != null)
                {
                    TxtCelular.CssClass += InvalidoClass;
                    PCelularError.InnerText = errorCelular.ErrorMessage;
                    PCelularError.Visible = true;
                }
                else
                {
                    TxtCelular.CssClass = ValidoClass;
                    PCelularError.Visible = false;
                }

            }

        }
    }
}