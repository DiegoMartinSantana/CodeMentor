using Dominio;
using Dominio.DataTransferObjects;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuariosGestion
    {

        public void ActualizarDatos( InfoUsuarioDto datos)
        {
            var Acceso = new ConexionBD();
            try
            {
                Acceso.SetQuery("UPDATE INFORMACION_USUARIO SET NOMBRE = @Nombre, APELLIDO = @Apellido,  CELULAR = @Celular,  URL_FOTOPERFIL = @UrlFotoPerfil WHERE IDUSUARIO = @IdUsuario");
                Acceso.SetParametro("IdUsuario", datos.Idusuario);
                Acceso.SetParametro("@Nombre", datos.Nombre);
                Acceso.SetParametro("@Apellido", datos.Apellido);
                Acceso.SetParametro("@Celular", datos.Celular);
                if (!string.IsNullOrEmpty(datos.UrlFotoPerfil))
                {
                    Acceso.SetParametro("@UrlFotoPerfil", datos.UrlFotoPerfil);
                }
                else
                {
                    Acceso.SetParametro("@UrlFotoPerfil", (object)DBNull.Value); // le mando nulo sino!

                }
                Acceso.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Acceso.CerrarConexion();
            }
        }
        //DEVUELVE EL ID INSERTADO. PORQUE ES NECESARIO PARA METERLO EN SESSION
        public Usuario ObtenerUsuario(int id)
        {
            var Acceso = new ConexionBD();
            try
            {
                Acceso.SetQuery("SELECT IDUSUARIO,EMAIL,ES_ADMIN,FECHA_CREACION FROM USUARIOS WHERE IDUSUARIO = @ID");
                Acceso.SetParametro("@ID", id);
                Acceso.EjecutarLectura();
                if (Acceso.Lector.Read())
                {
                    Usuario user = new Usuario();
                    user.IdUsuario = (int)Acceso.Lector["IDUSUARIO"];
                    user.Email = (string)Acceso.Lector["EMAIL"];
                    user.EsAdmin = (bool)Acceso.Lector["ES_ADMIN"];
                    user.FechaCreacion = (DateTime)Acceso.Lector["FECHA_CREACION"];
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Acceso.CerrarConexion();
            }
        }
     
    
        public int InsertarUsuarioSP(string email, string pass, InformacionUsuario datos)
        {
            var Acceso = new ConexionBD();
            try
            {
                Acceso.SetSP("SP_INSERTUSUARIO");
                Acceso.SetParametro("@Email", email);
                Acceso.SetParametro("@Pass", pass);
                Acceso.SetParametro("@Nombre", datos.Nombre);
                Acceso.SetParametro("@Apellido", datos.Apellido);
                Acceso.SetParametro("@FechaNacimiento", datos.FechaNacimiento);
                Acceso.SetParametro("@IdPais", datos.IdPais);
                Acceso.SetParametro("@Celular", datos.Celular);
                //Acceso.SetParametro("@Baja", datos.Baja); --> creo que no es necesario por que por default es 0

                if (!string.IsNullOrEmpty(datos.UrlFotoPerfil))
                {
                    Acceso.SetParametro("@UrlFoto", datos.UrlFotoPerfil);
                }
                else
                {
                    Acceso.SetParametro("@UrlFoto", (object)DBNull.Value); // le mando nulo sino!

                }
                if (datos.Sexo == "Masculino")
                {
                    Acceso.SetParametro("@Sexo", "M");
                }
                else
                {
                    Acceso.SetParametro("@Sexo", "F");
                }
                return Acceso.EjecutarScalar(); //ejecuta el SP y devuelve el ID insertado
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Acceso.CerrarConexion();

            }

        }
        public InformacionUsuario ObtenerDatos(int id)
        {
            var Acceso = new ConexionBD();
            var datos = new InformacionUsuario();

            try
            {

                Acceso.SetQuery("SELECT NOMBRE,APELLIDO,FECHA_NACIMIENTO,IDPAIS,CELULAR,SEXO,URL_FOTOPERFIL FROM INFORMACION_USUARIO WHERE IDUSUARIO = @ID");
                Acceso.SetParametro("@ID", id);
                Acceso.EjecutarLectura();
                if (Acceso.Lector.Read())
                {
                    datos.Nombre = (string)Acceso.Lector["NOMBRE"];
                    datos.Apellido = (string)Acceso.Lector["APELLIDO"];
                    datos.FechaNacimiento = (DateTime)Acceso.Lector["FECHA_NACIMIENTO"];
                    datos.IdPais = (int)Acceso.Lector["IDPAIS"];
                    datos.Celular = (string)Acceso.Lector["CELULAR"];
                    datos.Sexo = (string)Acceso.Lector["SEXO"];
                    
                    //validamos nulidad x que es opcional la foto!
                    if (!(Acceso.Lector["URL_FOTOPERFIL"] is DBNull))
                    {
                        datos.UrlFotoPerfil = (string)Acceso.Lector["URL_FOTOPERFIL"];
                    }
                }
                return datos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Acceso.CerrarConexion();
            }

        }

        public Usuario ValidarYObtenerUser(string email, string password)
        {
            var Acceso = new ConexionBD();
            try
            {
                Acceso.SetQuery("SELECT IDUsuario,Email,Pass,Es_Admin,Fecha_Creacion FROM USUARIOS WHERE Email = @Email");
                Acceso.SetParametro("@Email", email);
                Acceso.EjecutarLectura();

                if (Acceso.Lector.Read())
                {
                    string PassBd = (string)Acceso.Lector["Pass"];
                    if (PassBd != null)
                    {
                        if (PassBd == password)
                        {


                            Usuario user = new Usuario();
                            user.IdUsuario = (int)Acceso.Lector["IDUsuario"];
                            user.Email = email;
                            user.Pass = password;
                            user.EsAdmin = (bool)Acceso.Lector["Es_Admin"];
                            user.FechaCreacion = (DateTime)Acceso.Lector["Fecha_Creacion"];
                            
                            return user;
                        }
                        else
                        {
                            return null; // si passwords no coinciden
                        }
                    }
                    else
                    {
                        return null; // si no existe una pass , email invalido , devuelvo null
                    }
                }
                else
                {
                    return null; // error al leer la bd
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Acceso.CerrarConexion();
            }
        }
        public InformacionUsuario ObtenerAdmin()
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "SELECT UF.NOMBRE,UF.APELLIDO,UF.FECHA_NACIMIENTO,UF.IDPAIS,UF.CELULAR,UF.SEXO,UF.URL_FOTOPERFIL FROM INFORMACION_USUARIO UF INNER JOIN USUARIOS U ON U.IDUSUARIO = UF.IDUSUARIO WHERE U.ES_ADMIN=1";
                Acceso.SetQuery(query);
                Acceso.EjecutarLectura();
                InformacionUsuario InfoAdmin = new InformacionUsuario();
                if (Acceso.Lector.Read())
                {
                    InfoAdmin.Nombre = (string)Acceso.Lector["NOMBRE"];
                    InfoAdmin.Apellido = (string)Acceso.Lector["APELLIDO"];
                    InfoAdmin.FechaNacimiento = (DateTime)Acceso.Lector["FECHA_NACIMIENTO"];
                    InfoAdmin.IdPais = (int)Acceso.Lector["IDPAIS"];
                    InfoAdmin.Celular = (string)Acceso.Lector["CELULAR"];
                    InfoAdmin.Sexo = (string)Acceso.Lector["SEXO"];
                    if (!(Acceso.Lector["URL_FOTOPERFIL"] is DBNull)) // DISTINTO DE NULO
                    {
                        InfoAdmin.UrlFotoPerfil = (string)Acceso.Lector["URL_FOTOPERFIL"];
                    }
                }
                return InfoAdmin;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Acceso.CerrarConexion();
            }

        }

        public void ResetPassword(string email, string newPass)
        {
            var Acceso = new ConexionBD();

            try
            {
                Acceso.SetQuery("UPDATE USUARIOS SET PASS = @NewPass WHERE EMAIL = @EditEmail");
                Acceso.SetParametro("@EditEmail", email);
                Acceso.SetParametro("@NewPass", newPass);
                Acceso.EjecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Acceso.CerrarConexion();
            }


        }

        public List<InfoUsuarioDto> ListarUsuarios()
        {


            List<InfoUsuarioDto> list = new List<InfoUsuarioDto>();
            ConexionBD Acceso = new ConexionBD();
            try
            {
                Acceso.SetQuery("SELECT I.IDUSUARIO, I.NOMBRE, I.APELLIDO, I.FECHA_NACIMIENTO,P.NOMBRE  as NOMBREPAIS,I.CELULAR,I.SEXO,I.URL_FOTOPERFIL,U.Email, U.Baja FROM INFORMACION_USUARIO I INNER JOIN PAISES P ON P.IDPAIS=I.IDPAIS INNER JOIN USUARIOS U ON U.IDUSUARIO=I.IDUSUARIO ");
                Acceso.EjecutarLectura();
                while (Acceso.Lector.Read())
                {
                    InfoUsuarioDto user = new InfoUsuarioDto();
                    if (user.Baja==false)
                    {
                    user.Idusuario = Acceso.Lector["IDUSUARIO"] != DBNull.Value ? (int)Acceso.Lector["IDUSUARIO"] : 0;
                    user.Nombre = Acceso.Lector["NOMBRE"] != DBNull.Value ? (string)Acceso.Lector["NOMBRE"] : "";
                    user.Apellido = Acceso.Lector["APELLIDO"] != DBNull.Value ? (string)Acceso.Lector["APELLIDO"] : "";
                    user.FechaNacimiento = Acceso.Lector["FECHA_NACIMIENTO"] != DBNull.Value ? (DateTime)Acceso.Lector["FECHA_NACIMIENTO"] : DateTime.MinValue;
                    user.Pais = Acceso.Lector["NOMBREPAIS"] != DBNull.Value ? (string)Acceso.Lector["NOMBREPAIS"] : "";
                    user.Celular = Acceso.Lector["CELULAR"] != DBNull.Value ? (string)Acceso.Lector["CELULAR"] : "";
                    user.Sexo = Acceso.Lector["SEXO"] != DBNull.Value ? (string)Acceso.Lector["SEXO"] : "";
                    user.UrlFotoPerfil = Acceso.Lector["URL_FOTOPERFIL"] != DBNull.Value ? (string)Acceso.Lector["URL_FOTOPERFIL"] : "";
                        user.Email = Acceso.Lector["Email"] != DBNull.Value ? (string)Acceso.Lector["Email"] : "";
                        user.Baja = Acceso.Lector["BAJA"] != DBNull.Value ? (bool)Acceso.Lector["BAJA"] : false;
                    list.Add(user);
                    }

                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Acceso.CerrarConexion();
            }
        }
        public void EliminarUsuario(int Id)
        {
            ConexionBD Acceso = new ConexionBD();

            try
            {

                Acceso.SetQuery("UPDATE USUARIOS  SET BAJA=1  WHERE IDUSUARIO=@ID");
                Acceso.SetParametro("@ID", Id);
                Acceso.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if(Acceso != null) 
                Acceso.CerrarConexion();



            }


        }

        public void CambiarContraseña(string mail, string pass)
        {
            ConexionBD Acceso = new ConexionBD();
            try
            {
                Acceso.SetQuery("UPDATE USUARIOS SET PASS=@PASS WHERE EMAIL=@MAIL");
                Acceso.SetParametro("@PASS", pass);
                Acceso.SetParametro("@MAIL", mail);
                Acceso.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (Acceso != null)
                    Acceso.CerrarConexion();



            }
        }

        //public void EliminarTablaInformacion(int Id)
        //{
        //    ConexionBD Acceso = new ConexionBD();

        //    try
        //    {
        //        Acceso.SetQuery("DELETE FROM INFORMACION_USUARIO WHERE IDUSUARIO=@Id");
        //        Acceso.SetParametro("@Id", Id);
        //        Acceso.EjecutarAccion();
        //        EliminarUsuario(Id);
           

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (Acceso != null)
        //            Acceso.CerrarConexion();



        //    }


        //}

    }
}


