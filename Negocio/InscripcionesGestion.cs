using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.DTOS;

namespace Negocio
{
    public class InscripcionesGestion
    {
        public int CantCertificaciones()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                string query = "SELECT COUNT(IDCERTIFICACIONES) FROM CERTIFICACIONES";
                conexionBD.SetQuery(query);
                conexionBD.EjecutarLectura();
                conexionBD.Lector.Read();
                int cant = (int)conexionBD.Lector[0];
                return cant;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public int CantidadInscriptos(int IdCurso = 0)
        {
            ConexionBD AccesoBD = new ConexionBD();
            try
            {
                string query = "";
                if (IdCurso == 0)
                {
                    query = "SELECT COUNT(IDINSCRIPCION) FROM INSCRIPCIONES";
                }
                else
                {
                    query = "SELECT COUNT(IDINSCRIPCION) FROM INSCRIPCIONES WHERE IDCURSO= @IdCurso";
                    AccesoBD.SetParametro("@IdCurso", IdCurso);

                }
                AccesoBD.SetQuery(query);
                AccesoBD.EjecutarLectura();
                AccesoBD.Lector.Read();
                int cant = (int)AccesoBD.Lector[0];
                return cant;
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
        public List<InscripcionesGestionDto> ListarInscripciones()
        {
            ConexionBD AccesoBD = new ConexionBD();

            try
            {
                string query = "SELECT i.APELLIDO , i.NOMBRE, c.NOMBRE as NombreCurso,C.IDCURSO AS C_IDCURSO, ins.IDINSCRIPCION,ins.Baja as insBaja ,i.IDUSUARIO AS IDUSER,ins.Habilitada FROM INFORMACION_USUARIO i INNER JOIN INSCRIPCIONES ins on ins.IDUSUARIO=i.IDUSUARIO INNER JOIN CURSOS c on c.IDCURSO=ins.IDCURSO ";
                AccesoBD.SetQuery(query);
                AccesoBD.EjecutarLectura();
                var ListaInscripciones = new List<InscripcionesGestionDto>();
                while (AccesoBD.Lector.Read())
                {
                    InscripcionesGestionDto inscripcion = new InscripcionesGestionDto();

                    inscripcion.Nombre = (string)AccesoBD.Lector["NOMBRE"];
                    inscripcion.IdCurso = (int)AccesoBD.Lector["C_IDCURSO"];
                    inscripcion.IdUsuario = (int)AccesoBD.Lector["IDUSER"];
                    inscripcion.Habilitada = (bool)AccesoBD.Lector["Habilitada"];
                    inscripcion.Apellido = (string)AccesoBD.Lector["APELLIDO"];
                    inscripcion.NombreCurso = (string)AccesoBD.Lector["NombreCurso"];
                    inscripcion.IdInscripcion = (int)AccesoBD.Lector["IDINSCRIPCION"];
                    inscripcion.Baja = (bool)AccesoBD.Lector["insBaja"];
                    ListaInscripciones.Add(inscripcion);
                }
                return ListaInscripciones;
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

        public void InsertarInscripcion(Inscripcion insc)
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "INSERT INTO INSCRIPCIONES (IDCURSO,IDUSUARIO) VALUES (@NombreCurso,@IdUsuario)";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@NombreCurso", insc.IdCurso);
                Acceso.SetParametro("@IdUsuario", insc.IdUsuario);


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

        public void ModificarInscripcion(Inscripcion insc)
        {
            ConexionBD Acceso = new ConexionBD();

            try
            {
                Acceso.SetQuery("UPDATE INSCRIPCIONES SET IDCURSO = @IDCurso, IDUSUARIO = @IDUsuario WHERE IDINSCRIPCION=@IDInscripcion");
                Acceso.SetParametro("@IDInscripcion", insc.IdInscripcion);
                Acceso.SetParametro("IDCURSO", insc.IdCurso);
                Acceso.SetParametro("IDUSUARIO", insc.IdUsuario);
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
        public void AltaInscripcionHabilitada(int Id)
        {
            ConexionBD Acceso = new ConexionBD();

            try
            {
                Acceso.SetQuery("UPDATE INSCRIPCIONES  SET HABILITADA = 1 WHERE IDINSCRIPCION=@IDInscripcion ");
                Acceso.SetParametro("@IDInscripcion", Id);
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
        public void BajaInscripcionHabilitada(int Id)
        {
            ConexionBD Acceso = new ConexionBD();

            try
            {
                Acceso.SetQuery("UPDATE INSCRIPCIONES  SET HABILITADA=0 WHERE IDINSCRIPCION=@IDInscripcion ");
                Acceso.SetParametro("@IDInscripcion", Id);
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
        public void AltaInscripcion(int Id)
        {
            ConexionBD Acceso = new ConexionBD();

            try
            {
                Acceso.SetQuery("UPDATE INSCRIPCIONES  SET BAJA = 0 WHERE IDINSCRIPCION=@IDInscripcion ");
                Acceso.SetParametro("@IDInscripcion", Id);
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
        public void BajaInscripcion(int Id)
        {
            ConexionBD Acceso = new ConexionBD();

            try
            {
                Acceso.SetQuery("UPDATE INSCRIPCIONES  SET Baja=1 WHERE IDINSCRIPCION=@IDInscripcion ");
                Acceso.SetParametro("@IDInscripcion", Id);
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
        public bool Existencia(int Id)
        {
            ConexionBD AccesoBD = new ConexionBD();

            try
            {
                AccesoBD.SetQuery("SELECT IDINSCRIPCION,IDCURSO,IDUSUARIO,FECHA,BAJA,Habilitada FROM INSCRIPCIONES WHERE IDUSUARIO=@IdUsuario");
                AccesoBD.SetParametro("@IdUsuario", Id);
                AccesoBD.EjecutarLectura();
                if (AccesoBD.Lector.Read())
                {

                    return true;
                }
                else
                {
                    return false;
                }
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
        public Inscripcion ObtenerInscripcion(int idcurso, int iduser)
        {
            ConexionBD AccesoBD = new ConexionBD();

            try
            {
                string query = "SELECT IDINSCRIPCION,IDCURSO,IDUSUARIO,FECHA,BAJA, Habilitada FROM INSCRIPCIONES WHERE IDUSUARIO = @IDUSER AND IDCURSO=@IDCURSO";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IDUSER", iduser);
                AccesoBD.SetParametro("@IDCURSO", idcurso);
                AccesoBD.EjecutarLectura();
                if (AccesoBD.Lector.Read())
                {
                    Inscripcion inscripcion = new Inscripcion();
                    inscripcion.IdInscripcion = (int)AccesoBD.Lector["IDINSCRIPCION"];
                    inscripcion.IdCurso = (int)AccesoBD.Lector["IDCURSO"];
                    inscripcion.IdUsuario = (int)AccesoBD.Lector["IDUSUARIO"];
                    inscripcion.Fecha = (DateTime)AccesoBD.Lector["FECHA"];
                    inscripcion.Baja = (bool)AccesoBD.Lector["BAJA"];
                    inscripcion.Habilitada = (bool)AccesoBD.Lector["Habilitada"];
                    return inscripcion;
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
                AccesoBD.CerrarConexion();
            }
        }
        public InscripcionesGestionDto ObtenerdtoInscripciones(int Id) //ojo, devuelve la primera, puede haber mas de una inscripcion
        {
            ConexionBD AccesoBD = new ConexionBD();
            InscripcionesGestionDto inscripto = new InscripcionesGestionDto();

            try
            {
                AccesoBD.SetQuery("SELECT INF.NOMBRE AS NOMBREUSUARIO,INF.APELLIDO AS APELLIDOUSUARIO,INF.IDUSUARIO AS INF_IDUSUARIO ,C.NOMBRE AS NOMBRECURSO,C.IDCURSO AS C_IDCURSO ,I.IDINSCRIPCION AS IDINSCRIPCION,I.Habilitada,I.BAJA AS ESTADO FROM INSCRIPCIONES I INNER JOIN CURSOS C ON I.IDCURSO=C.IDCURSO INNER JOIN INFORMACION_USUARIO INF ON INF.IDUSUARIO=I.IDUSUARIO WHERE I.BAJA=0 AND I.IDUSUARIO=@IdUsuario");
                AccesoBD.SetParametro("@IdUsuario", Id);
                AccesoBD.EjecutarLectura();
                if (AccesoBD.Lector.Read())
                {
                    inscripto.IdInscripcion = (int)AccesoBD.Lector["IDINSCRIPCION"];

                    inscripto.Nombre = (string)AccesoBD.Lector["NOMBREUSUARIO"];
                    inscripto.Apellido = (string)AccesoBD.Lector["APELLIDOUSUARIO"];
                    inscripto.IdCurso = (int)AccesoBD.Lector["C_IDCURSO"];
                    inscripto.IdUsuario = (int)AccesoBD.Lector["INF_IDUSUARIO"];
                    inscripto.NombreCurso = (string)AccesoBD.Lector["NOMBRECURSO"];
                    inscripto.Baja = (bool)AccesoBD.Lector["ESTADO"];
                    inscripto.Habilitada = (bool)AccesoBD.Lector["Habilitada"];
                    return inscripto;
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
                AccesoBD.CerrarConexion();
            }


        }


    }
}
