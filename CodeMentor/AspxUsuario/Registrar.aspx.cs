using Dominio;
using Validaciones.Logicas;
using Negocio.ServicioEmail;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.DataTransferObjects;
using System.Security.Cryptography.X509Certificates;

namespace CodeMentor
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Validaciones.Seguridad.Login(Session["Usuario"]))
            {
                Response.Redirect("InicioRegistrado.aspx", false);
            }
            if (!IsPostBack)
            {
                DdlListaPaises();
                DdlLlenarSexo();
                LblErrorPass.Visible = false;
            }

            //OPCION DE VER CONTRASEÑA


        }


        protected void BtnRegistro_Click(object sender, EventArgs e)
        {

            if (TxtPass.Text != TxtRepetirPass.Text)
            {
                LblErrorPass.Text = "*Las contraseñas no coinciden";
                LblErrorPass.Visible = true;
                return;
            }

            InsertarUsuario();

        }

        private void InsertarUsuario()
        {
            try
            {
                var User = new Usuario();
                User.Email = TxtEmail.Text;
                User.Pass = TxtPass.Text;
                var UserDatos = new InformacionUsuario();
                UserDatos.Nombre = TxtNombre.Text;
                UserDatos.Apellido = TxtApellido.Text;
                UserDatos.FechaNacimiento = DateTime.Parse(TxtFechaNacimiento.Text);
                UserDatos.IdPais = int.Parse(DdlPais.SelectedValue);
                UserDatos.Celular = TxtCelular.Text;
                UserDatos.Sexo = DdlSexo.SelectedValue;

                // validamos con FLUENT
                if (!ValidarDatosUsuario(UserDatos, User))
                {
                    return; // Si usuario no es valido,
                }

                //llego aca = TODO OK
                if (!string.IsNullOrEmpty(TxtCargaImagen.PostedFile.FileName))
                {
                    // GUARDAR IMAGEN
                    string ruta = Server.MapPath("./Imagenes/Perfil/");//me ubico en la carpeta a trabajar
                                                                       //listo, guardo!
                                                                       //le paso como dato unico su email(es unique).ya que todavia no esta insertado!
                    TxtCargaImagen.PostedFile.SaveAs(ruta + "Perfil-" + TxtEmail.Text + ".jpg");
                    UserDatos.UrlFotoPerfil = "Perfil-" + TxtEmail.Text + ".jpg";
                }

                //ADMIN = DEFAULT 0 EN BD, FECHA CREACION DEFAULT EN BD
                var UsuarioGestion = new UsuariosGestion();
                int IdInsertado = UsuarioGestion.InsertarUsuarioSP(User.Email, User.Pass, UserDatos);


                //GUARDAR ID EN SESSION
                User.IdUsuario = IdInsertado;
                Session.Add("Usuario", User);

                //ENVIAR EMAIL DE BIENVENIDA
                var Envio = new EnvioGmail();
                Envio.EmailUsuarioBienvenida(User.Email, "Bienvenido a CodeMentor");
                Envio.EnviarEmail();


                Response.Redirect("InicioRegistrado.aspx", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool ValidarDatosUsuario(InformacionUsuario Datos, Usuario user)
        {
            var Dto = Validaciones.Helper.MapearUsuario(user, Datos); // mapeamos el usuario con los datos a validar

            var Validador = new RegistroValidaciones(); // Creamos Obj de la clase que hereda de AbstractValidator <--
                                                        //le paso entidad a validar
            var Resultado = Validador.Validate(Dto); // validamos la entidad

            string Valido = "form-control form-control-lg bg-light fs-6 is-valid";
            string Invalido = "  is-invalid";
            // manejamos donde esta el error ! 
            if (!Resultado.IsValid) //
            {
                //ERROR ES UNA LISTA! PODEMOS USARLA PARA DETECTAR CUAL ES EL ERROR!

                var errorNombre = Resultado.Errors.FirstOrDefault(e => e.PropertyName == "Nombre"); // capturamos
                if (errorNombre != null)
                {
                    TxtNombre.CssClass += Invalido; // añado la clase! importante el espacio
                    PNombreError.InnerText = errorNombre.ErrorMessage;// MUESTRA EL MENSAJE DE ERROR EN EL FRONT
                    PNombreError.Visible = true;
                }
                else
                {
                    TxtNombre.CssClass = Valido;
                    PNombreError.Visible = false;
                }

                var errorApellido = Resultado.Errors.FirstOrDefault(e => e.PropertyName == "Apellido");
                if (errorApellido != null)
                {
                    TxtApellido.CssClass += Invalido;
                    PApellidoError.InnerText = errorApellido.ErrorMessage;
                    PApellidoError.Visible = true;

                }
                else
                {
                    TxtApellido.CssClass = Valido;
                    PApellidoError.Visible = false;
                }

                var errorCelular = Resultado.Errors.FirstOrDefault(e => e.PropertyName == "Celular");
                if (errorCelular != null)
                {
                    TxtCelular.CssClass += Invalido;
                    PCelularError.InnerText = errorCelular.ErrorMessage;
                    PCelularError.Visible = true;
                }
                else
                {
                    TxtCelular.CssClass = Valido;
                    PCelularError.Visible = false;

                }
                var errorFechaNacimiento = Resultado.Errors.FirstOrDefault(e => e.PropertyName == "FechaNacimiento");
                if (errorFechaNacimiento != null)
                {
                    TxtFechaNacimiento.CssClass += Invalido;
                    PFNacimientoError.InnerText = errorFechaNacimiento.ErrorMessage;
                    PFNacimientoError.Visible = true;
                }
                else
                {
                    TxtFechaNacimiento.CssClass = Valido;
                    PFNacimientoError.Visible = false;
                }
                var errorEmail = Resultado.Errors.FirstOrDefault(e => e.PropertyName == "Email");
                if (errorEmail != null)
                {
                    TxtEmail.CssClass += Invalido;
                    PEmailError.InnerText = errorEmail.ErrorMessage;
                    PEmailError.Visible = true;
                }
                else
                {
                    TxtEmail.CssClass = Valido;
                    PEmailError.Visible = false;
                }
                var errorPass = Resultado.Errors.FirstOrDefault(e => e.PropertyName == "Pass");
                if (errorPass != null)
                {
                    TxtPass.CssClass += Invalido;
                    PPassError.InnerText = errorPass.ErrorMessage;
                    PPassError.Visible = true;
                }
                else
                {
                    TxtPass.CssClass = Valido;
                    PPassError.Visible = false;
                }

                return false;
            }
            return true;

        }

      
        private void DdlLlenarSexo()
        {
            var Sexo = new List<string>();
            Sexo.Add("Masculino");
            Sexo.Add("Femenino");
            DdlSexo.DataSource = Sexo;
            DdlSexo.DataBind();

        }
        private void DdlListaPaises() //metodos accesibles en este aspx nomas
        {
            var PaisesGestion = new PaisesGestion();

            DdlPais.DataSource = PaisesGestion.ListadoPaises();
            DdlPais.DataTextField = "Nombre";
            DdlPais.DataValueField = "IdPais";
            DdlPais.DataBind();
        }

    }
}