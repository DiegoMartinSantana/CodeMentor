using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RespuestasGestion
    {
        
        public Respuesta Existencia(int IdPreg)
        {
            var AccesoBD = new ConexionBD();
            try
            {
                AccesoBD.SetQuery("SELECT IDRESPUESTA,FECHA, CUERPO  FROM RESPUESTAS WHERE IDPREGUNTA=@IDPREG");
                AccesoBD.SetParametro("@IDPREG", IdPreg);
                AccesoBD.EjecutarLectura();
                if (AccesoBD.Lector.Read())
                {
                    Respuesta Resp = new Respuesta();
                    Resp.IdPregunta = IdPreg;
                    Resp.IdRespuesta = (int)AccesoBD.Lector["IDRESPUESTA"];
                    Resp.Fecha = (DateTime)AccesoBD.Lector["FECHA"];
                    Resp.Cuerpo = (string)AccesoBD.Lector["CUERPO"];
                    return Resp;
                }
                return null;
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
        public void ModificarRespuesta(Respuesta Resp)
        {
            var AccesoBD = new ConexionBD();
            try
            {
                string query = "UPDATE RESPUESTAS SET CUERPO=@BODY WHERE IDRESPUESTA=@IDRESP";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@BODY", Resp.Cuerpo);
                AccesoBD.SetParametro("@IDRESP", Resp.IdRespuesta);
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
        public List<Respuesta> ListadoRespuestas(int IdPregunta)
        {
            var AccesoBD = new ConexionBD();
            try
            {
                string query = "SELECT IDRESPUESTA,IDPREGUNTA,FECHA, CUERPO  FROM RESPUESTAS";
                AccesoBD.SetQuery(query);
                AccesoBD.EjecutarLectura();
                var ListRespuestas = new List<Respuesta>();
                while (AccesoBD.Lector.Read())
                {
                    Respuesta Resp = new Respuesta();
                    Resp.IdRespuesta = (int)AccesoBD.Lector["IDRESPUESTA"];
                    Resp.IdPregunta = (int)AccesoBD.Lector["IDPREGUNTA"];
                    Resp.Fecha = (DateTime)AccesoBD.Lector["FECHA"];
                    Resp.Cuerpo = (string)AccesoBD.Lector["RESPUESTA"];
                    ListRespuestas.Add(Resp);
                }
                return ListRespuestas;
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
        public void BajaRespuesta(int IdRespuesta)
        {
            var AccesoBD = new ConexionBD();
            try
            {
                string query = "DELETE FROM RESPUESTAS WHERE IDRESPUESTA=@IDRESP";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IDRESP", IdRespuesta);
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
        public void AltaRespuesta(Respuesta Resp)
        {
            var AccesoBD = new ConexionBD();
            try
            {
                // IMPORTANTE = FECHA AUTOMATICA EN BD. PARA MAYORIA CASOS ES ASI!
                string query = "INSERT INTO RESPUESTAS (IDPREGUNTA,CUERPO) VALUES (@IDPREGUNTA,@BODY)";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IDPREGUNTA", Resp.IdPregunta);
                AccesoBD.SetParametro("@BODY", Resp.Cuerpo);
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
    }
}
