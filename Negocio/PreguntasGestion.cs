using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PreguntasGestion
    {
        public List<Pregunta> SinRespuestas()
        {

            var AccesoBD = new ConexionBD();
            List<Pregunta> listPreg = new List<Pregunta>();
            try

            {
                string query = "SELECT P.IDPREGUNTA,P.IDCURSO,P.IDUSUARIO,P.TITULO,P.CUERPO,P.FECHA FROM  PREGUNTAS P INNER JOIN RESPUESTAS R ON R.IDPREGUNTA = P.IDPREGUNTA WHERE R.IDPREGUNTA IS NULL";
                AccesoBD.SetQuery(query);
                AccesoBD.EjecutarLectura();
                while (AccesoBD.Lector.Read())
                {
                    Pregunta preg = new Pregunta();
                    preg.IdPregunta = (int)AccesoBD.Lector["IDPREGUNTA"];
                    preg.IdCurso = (int)AccesoBD.Lector["IDCURSO"];
                    preg.IdUsuario = (int)AccesoBD.Lector["IDUSUARIO"];
                    preg.Titulo = (string)AccesoBD.Lector["TITULO"];
                    preg.Cuerpo = (string)AccesoBD.Lector["CUERPO"];
                    preg.Fecha = (DateTime)AccesoBD.Lector["FECHA"];
                    listPreg.Add(preg);
                }
                return listPreg;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                AccesoBD.CerrarConexion();
            }
        }
        public Pregunta Obtener(int id)
        {
            var AccesoBD = new ConexionBD();
            try
            {
                string query = "SELECT IDPREGUNTA,IDCURSO,IDUSUARIO,TITULO,CUERPO,FECHA FROM PREGUNTAS WHERE IDPREGUNTA=@IDPREG ";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IDPREG", id);
                AccesoBD.EjecutarLectura();
                Pregunta preg = new Pregunta();

                if (AccesoBD.Lector.Read())
                {
                    preg.IdPregunta = id;
                    preg.IdCurso = (int)AccesoBD.Lector["IDCURSO"];
                    preg.IdUsuario = (int)AccesoBD.Lector["IDUSUARIO"];
                    preg.Titulo = (string)AccesoBD.Lector["TITULO"];
                    preg.Cuerpo = (string)AccesoBD.Lector["CUERPO"];
                    preg.Fecha = (DateTime)AccesoBD.Lector["FECHA"];
                }
                if (preg == null)
                {
                    return null;
                }
                return preg;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoBD.CerrarConexion();
            }

        }
        public void AltaPregunta(Pregunta Preg)
        {
            var AccesoBD = new ConexionBD();
            try
            {
                // IMPORTANTE = FECHA AUTOMATICA EN BD. PARA MAYORIA CASOS ES ASI!
                string query = "INSERT INTO PREGUNTAS (IDCURSO,IDUSUARIO,TITULO,CUERPO) VALUES (@IDCURSO,@IDUSER,@TIT,@BODY)";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IDCURSO", Preg.IdCurso);
                AccesoBD.SetParametro("@IDUSER", Preg.IdUsuario);
                AccesoBD.SetParametro("@TIT", Preg.Titulo);
                AccesoBD.SetParametro("@BODY", Preg.Cuerpo);
                AccesoBD.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                AccesoBD.CerrarConexion();
            }

        }

        public void BajaPregunta(int IdPregunta)
        {
            var AccesoBD = new ConexionBD();
            try
            {
                string query = "DELETE FROM PREGUNTAS WHERE IDPREGUNTA=@IDPREG";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IDPREG", IdPregunta);
                AccesoBD.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoBD.CerrarConexion();
            }
        }
        public void ModificarPregunta(Pregunta Preg)
        {
            var AccesoBD = new ConexionBD();
            try
            {
                string query = "UPDATE PREGUNTAS SET TITULO=@TIT,CUERPO=@BODY WHERE IDPREGUNTA=@IDPREG";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@TIT", Preg.Titulo);
                AccesoBD.SetParametro("@BODY", Preg.Cuerpo);
                AccesoBD.SetParametro("@IDPREG", Preg.IdPregunta);
                AccesoBD.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoBD.CerrarConexion();
            }
        }
        public Pregunta UltimaPregunta()
        {
            var AccesoBD = new ConexionBD();

            try
            {
                string query = "SELECT TOP(1)  IDPREGUNTA,IDCURSO,IDUSUARIO,TITULO,CUERPO,FECHA from PREGUNTAS ORDER BY IDPREGUNTA DESC";
                AccesoBD.SetQuery(query);
                AccesoBD.EjecutarLectura();
                Pregunta preg = new Pregunta();
                if (AccesoBD.Lector.Read())
                {
                    preg.IdPregunta = (int)AccesoBD.Lector["IDPREGUNTA"];
                    preg.IdCurso = (int)AccesoBD.Lector["IDCURSO"];
                    preg.IdUsuario = (int)AccesoBD.Lector["IDUSUARIO"];
                    preg.Titulo = (string)AccesoBD.Lector["TITULO"];
                    preg.Cuerpo = (string)AccesoBD.Lector["CUERPO"];
                    preg.Fecha = (DateTime)AccesoBD.Lector["FECHA"];
                }
                if (preg == null)
                {
                    return null;
                }
                return preg;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoBD.CerrarConexion();
            }

        }


        public List<Pregunta> ListadoPreguntas(int IdCurso = 0) //USO = MOSTRAR PREGUNTAS DE UN CURSO, LINQ PARA FILTRAR POR USUARIO  Y POR USUARIO Y CURSO!
        {

            var AccesoBD = new ConexionBD();
            List<Pregunta> listPreg = new List<Pregunta>();
            try
            {
                if (IdCurso != 0)
                {
                    string query = "SELECT IDPREGUNTA,IDCURSO,IDUSUARIO,TITULO,CUERPO,FECHA FROM PREGUNTAS WHERE IDCURSO=@IDCURSO";
                    AccesoBD.SetQuery(query);
                    AccesoBD.SetParametro("@IDCURSO", IdCurso);

                }
                else // si es 0, traigo todas las preguntas
                {
                    string query = "SELECT IDPREGUNTA,IDCURSO,IDUSUARIO,TITULO,CUERPO,FECHA FROM PREGUNTAS ";
                    AccesoBD.SetQuery(query);

                }
                AccesoBD.EjecutarLectura();
                while (AccesoBD.Lector.Read())
                {
                    Pregunta preg = new Pregunta();
                    preg.IdPregunta = (int)AccesoBD.Lector["IDPREGUNTA"];
                    preg.IdCurso = (int)AccesoBD.Lector["IDCURSO"];
                    preg.IdUsuario = (int)AccesoBD.Lector["IDUSUARIO"];
                    preg.Titulo = (string)AccesoBD.Lector["TITULO"];
                    preg.Cuerpo = (string)AccesoBD.Lector["CUERPO"];
                    preg.Fecha = (DateTime)AccesoBD.Lector["FECHA"];
                    listPreg.Add(preg);
                }
                return listPreg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                AccesoBD.CerrarConexion();
            }

        }
    }
}