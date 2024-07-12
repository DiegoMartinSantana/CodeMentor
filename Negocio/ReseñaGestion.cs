using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.DataTransferObjects;

namespace Negocio
{
    public class ReseñaGestion
    {
        public Reseña Existencia(int idcurso,int idinscripcion)
        {
            ConexionBD Acceso = new ConexionBD();
            try
            {
                Acceso.SetQuery("SELECT IDRESEÑA,IDCURSO,IDINSCRIPCION,PUNTAJE,DESCRIPCION,FECHA FROM RESEÑAS WHERE IDCURSO=@IDCURSO AND IDINSCRIPCION = @IDINSCRIP");
                Acceso.SetParametro("@IDCURSO", idcurso);
                Acceso.SetParametro("@IDINSCRIP", idinscripcion);
                Acceso.EjecutarLectura();
                Reseña reseña = new Reseña();

                if (Acceso.Lector.Read())
                {
                    reseña.IdReseña = (int)Acceso.Lector["IDRESEÑA"];
                    reseña.IdCurso = (int)Acceso.Lector["IDCURSO"];
                    reseña.IdInscripcion = (int)Acceso.Lector["IDINSCRIPCION"];
                    reseña.Puntaje = (int)Acceso.Lector["PUNTAJE"];
                    reseña.Descripcion = (string)Acceso.Lector["DESCRIPCION"];
                    reseña.Fecha = (DateTime)Acceso.Lector["FECHA"];
                }
                return reseña;

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

        public List<ReseñasDto> ListarReseñas(int IdCurso = 0) //devuelve todas o por curso. MANEJA DTO
        {
            ConexionBD Acceso = new ConexionBD();
            List<ReseñasDto> listareseña = new List<ReseñasDto>();
            try
            {
                if (IdCurso != 0)
                {
                    Acceso.SetQuery("SELECT r.IDRESEÑA, c.IDCURSO as IDCURSO ,iu.APELLIDO, iu.NOMBRE,c.NOMBRE as NOMBRECURSO,r.PUNTAJE,r.DESCRIPCION, r.FECHA , iu.URL_FOTOPERFIL FROM INFORMACION_USUARIO iu INNER JOIN INSCRIPCIONES i on i.IDUSUARIO=iu.IDUSUARIO INNER JOIN RESEÑAS r on r.IDINSCRIPCION=i.IDINSCRIPCION INNER JOIN CURSOS c on c.IDCURSO=i.IDCURSO WHERE c.IDCURSO=@IDCurso");
                    Acceso.SetParametro("@IDCurso", IdCurso);


                }
                else
                {
                    Acceso.SetQuery("SELECT  r.IdReseña, c.IDCURSO,iu.APELLIDO, iu.NOMBRE,c.NOMBRE as NOMBRECURSO,r.PUNTAJE,r.DESCRIPCION, r.FECHA , iu.URL_FOTOPERFIL  FROM INFORMACION_USUARIO iu INNER JOIN INSCRIPCIONES i on i.IDUSUARIO=iu.IDUSUARIO INNER JOIN RESEÑAS r on r.IDINSCRIPCION=i.IDINSCRIPCION INNER JOIN CURSOS c on c.IDCURSO=i.IDCURSO ");
                }
                Acceso.EjecutarLectura();
                while (Acceso.Lector.Read())
                {
                    ReseñasDto reseña = new ReseñasDto();
                    reseña.IdReseña = (int)Acceso.Lector["IDRESEÑA"];
                    reseña.IdCurso = (int)Acceso.Lector["IDCURSO"]; 
                    var apellido = (string)Acceso.Lector["APELLIDO"];
                    var nombre = (string)Acceso.Lector["NOMBRE"];
                    reseña.Nombre_Apellido = nombre + " " + apellido;
                    reseña.NombreCurso = (string)Acceso.Lector["NOMBRECURSO"];
                    reseña.Puntaje = (int)Acceso.Lector["PUNTAJE"];
                    reseña.Descripcion = (string)Acceso.Lector["DESCRIPCION"];
                    reseña.FechaReseña = (DateTime)Acceso.Lector["FECHA"];
                    if (Acceso.Lector["URL_FOTOPERFIL"] != DBNull.Value)
                    {
                        reseña.UrlFotoPerfil = (string)Acceso.Lector["URLFOTOPERFIL"];
                    }
                    else
                    {
                        reseña.UrlFotoPerfil = "https://statics.forbesargentina.com/2022/06/629f81fe391f3.jpg";
                            }
                    listareseña.Add(reseña);
                }
                return listareseña;
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
        public void InsertarReseña(Reseña reseña)
        {
            var Acceso = new ConexionBD();
            try
            {

                Acceso.SetQuery("INSERT INTO RESEÑAS  (IDINSCRIPCION,IDCURSO,PUNTAJE,DESCRIPCION) VALUES (@IDInscripcion,@IDCurso,@Puntaje,@Descripcion)");
                Acceso.SetParametro("@IDInscripcion", reseña.IdInscripcion);
                Acceso.SetParametro("@IDCurso", reseña.IdCurso);
                Acceso.SetParametro("@Puntaje", reseña.Puntaje);
                Acceso.SetParametro("@Descripcion", reseña.Descripcion);
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

        public void ModificarReseña(Reseña Reseña)
        {
            var Acceso = new ConexionBD();
            try
            {

                Acceso.SetQuery("UPDATE RESEÑAS SET PUNTAJE=@Puntaje, DESCRIPCION=@Descripcion WHERE IDRESEÑA=@IDReseña");
                Acceso.SetParametro("@Puntaje", Reseña.Puntaje);
                Acceso.SetParametro("@Descripcion", Reseña.Descripcion);
                Acceso.SetParametro("@IDReseña", Reseña.IdReseña);
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


        public void EliminarReseña(int Id)
        {
            var Acceso = new ConexionBD();
            try
            {

                Acceso.SetQuery("DELETE FROM RESEÑAS WHERE IDRESEÑA=@IDReseña");
                Acceso.SetParametro("@IDReseña", Id);
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




    }
}
