using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CursosGestion
    {
        public List<Curso> ObtenerCursosPorCategoria (int idCat)
        {
            ConexionBD AccesoBD = new ConexionBD();

            try
            {
                string query = "SELECT c.IdCurso as CursoId, c.NOMBRE,c.DESCRIPCION,c.REQUISITOS,c.IMPORTE,c.URL_PORTADA,c.IDCATEGORIA,c.FECHA_CREACION from CURSOS C WHERE C.IDCATEGORIA = @IdCat";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IdCat", idCat);
                AccesoBD.EjecutarLectura();
                var ListCursos = new List<Curso>();
                while (AccesoBD.Lector.Read())
                {
                    Curso curso = new Curso();
                    curso.IdCurso = (int)AccesoBD.Lector["CursoId"];
                    curso.Nombre = (string)AccesoBD.Lector["NOMBRE"];
                    curso.Descripcion = (string)AccesoBD.Lector["DESCRIPCION"];
                    curso.Requisitos = (string)AccesoBD.Lector["REQUISITOS"];
                    curso.Importe = (decimal)AccesoBD.Lector["IMPORTE"];
                    curso.UrlPortada = (string)AccesoBD.Lector["URL_PORTADA"];
                    curso.IdCategoria = (int)AccesoBD.Lector["IDCATEGORIA"];
                    curso.FechaCreacion = (DateTime)AccesoBD.Lector["FECHA_CREACION"];
                    ListCursos.Add(curso);
                }

                return ListCursos;
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
        public List<Curso> ObtenerCursosPorLenguaje(int idLenguaje)
        {
            ConexionBD AccesoBD = new ConexionBD();

            try
            {
                string query = "SELECT c.IdCurso as CursoId, c.NOMBRE,c.DESCRIPCION,c.REQUISITOS,c.IMPORTE,c.URL_PORTADA,c.IDCATEGORIA,c.FECHA_CREACION from CURSOS c inner join LENGUAJESXCURSO lc on c.IDCURSO = lc.IDCURSO where lc.idlenguaje = @idLenguaje";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IdLenguaje",idLenguaje);
                AccesoBD.EjecutarLectura();
                var ListCursos = new List<Curso>(); 
                while( AccesoBD.Lector.Read())
                {
                    Curso curso = new Curso();
                    curso.IdCurso = (int)AccesoBD.Lector["CursoId"];
                    curso.Nombre = (string)AccesoBD.Lector["NOMBRE"];
                    curso.Descripcion = (string)AccesoBD.Lector["DESCRIPCION"];
                    curso.Requisitos = (string)AccesoBD.Lector["REQUISITOS"];
                    curso.Importe = (decimal)AccesoBD.Lector["IMPORTE"];
                    curso.UrlPortada = (string)AccesoBD.Lector["URL_PORTADA"];
                    curso.IdCategoria = (int)AccesoBD.Lector["IDCATEGORIA"];
                    curso.FechaCreacion = (DateTime)AccesoBD.Lector["FECHA_CREACION"];
                    ListCursos.Add(curso);
                }
               
                return ListCursos;
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
        public void AñadirCurso(Curso cursoInsertar)
        {
            ConexionBD AccesoBd = new ConexionBD();
            try
            {
                string query = "INSERT INTO CURSOS (NOMBRE,DESCRIPCION,REQUISITOS,IMPORTE,URL_PORTADA,IDCATEGORIA) VALUES (@NOMBRE,@DESC,@REQUISITOS,@IMPORTE,@URL,@IDCAT)";
                AccesoBd.SetQuery(query);
                AccesoBd.SetParametro("@NOMBRE", cursoInsertar.Nombre);
                AccesoBd.SetParametro("@DESC", cursoInsertar.Descripcion);
                AccesoBd.SetParametro("@IMPORTE", cursoInsertar.Importe);
                AccesoBd.SetParametro("@REQUISITOS", cursoInsertar.Requisitos);
                AccesoBd.SetParametro("@URL", cursoInsertar.UrlPortada);
                AccesoBd.SetParametro("@IDCAT", cursoInsertar.IdCategoria);
                AccesoBd.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoBd.CerrarConexion();

            }
        }
        public List<Curso> CursosNOInscripto(int IdUsuario) // uso : solo mostrar los cursos que esta inscripto el usuario
        {
            ConexionBD AccesoBD = new ConexionBD();

            try
            {
                string query = "SELECT C.IDCURSO, C.NOMBRE, C.URL_PORTADA FROM CURSOS AS C LEFT JOIN INSCRIPCIONES AS I ON I.IDCURSO = C.IDCURSO AND I.IDUSUARIO = @IDUSER WHERE I.IDCURSO IS NULL";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IDUSER", IdUsuario);
                AccesoBD.EjecutarLectura();
                var ListCursos = new List<Curso>();
                while (AccesoBD.Lector.Read())
                {
                    Curso curso = new Curso();
                    curso.IdCurso = (int)AccesoBD.Lector["IDCURSO"];
                    curso.Nombre = (string)AccesoBD.Lector["NOMBRE"];
                    curso.UrlPortada = (string)AccesoBD.Lector["URL_PORTADA"];
                    ListCursos.Add(curso);
                }
                return ListCursos; // List usa Interfaz Ienum asique podemos retornarla. 
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
        public List<Curso> CursosInscripto(int IdUsuario) // uso : solo mostrar los cursos que esta inscripto el usuario
        {
            ConexionBD AccesoBD = new ConexionBD();

            try
            {
                string query = "SELECT C.IDCURSO ,C.NOMBRE,C.URL_PORTADA FROM CURSOS AS C INNER JOIN INSCRIPCIONES AS I ON I.IDCURSO = C.IDCURSO WHERE I.HABILITADA=1 AND I.IDUSUARIO = @IDUSER";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@IDUSER", IdUsuario);
                AccesoBD.EjecutarLectura();
                var ListCursos = new List<Curso>();
                while (AccesoBD.Lector.Read())
                {
                    Curso curso = new Curso();
                    curso.IdCurso = (int)AccesoBD.Lector["IDCURSO"];
                    curso.Nombre = (string)AccesoBD.Lector["NOMBRE"];
                    curso.UrlPortada = (string)AccesoBD.Lector["URL_PORTADA"];
                    ListCursos.Add(curso);
                }
                return ListCursos; // List usa Interfaz Ienum asique podemos retornarla. 
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
        public Curso Existencia(int Id)
        {
            ConexionBD AccesoBD = new ConexionBD();

            try
            {
                AccesoBD.SetQuery("SELECT NOMBRE,DESCRIPCION,REQUISITOS,IMPORTE,URL_PORTADA,IDCATEGORIA,FECHA_CREACION from CURSOS as c WHERE c.IDCURSO=@IdCurso");
                AccesoBD.SetParametro("@IdCurso", Id);
                AccesoBD.EjecutarLectura();
                if (AccesoBD.Lector.Read())
                {
                    Curso curso = new Curso();
                    curso.IdCurso = Id;
                    curso.Nombre = (string)AccesoBD.Lector["NOMBRE"];
                    curso.Descripcion = (string)AccesoBD.Lector["DESCRIPCION"];
                    curso.Requisitos = (string)AccesoBD.Lector["REQUISITOS"];
                    curso.Importe = (decimal)AccesoBD.Lector["IMPORTE"];
                    curso.UrlPortada = (string)AccesoBD.Lector["URL_PORTADA"];
                    curso.IdCategoria = (int)AccesoBD.Lector["IDCATEGORIA"];
                    curso.FechaCreacion = (DateTime)AccesoBD.Lector["FECHA_CREACION"];
                    return curso;
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

        public List<Curso> Listado()
        {
            ConexionBD AccesoBD = new ConexionBD();
            List<Curso> listCurso = new List<Curso>();

            try
            {
                AccesoBD.SetQuery("SELECT IDCURSO ,NOMBRE,DESCRIPCION,REQUISITOS,IMPORTE,URL_PORTADA,IDCATEGORIA,FECHA_CREACION from CURSOS  ");
                AccesoBD.EjecutarLectura();
                while (AccesoBD.Lector.Read())
                {
                    Curso curso = new Curso();
                    curso.IdCurso = (int)AccesoBD.Lector["IDCURSO"];
                    curso.Nombre = (string)AccesoBD.Lector["NOMBRE"];
                    curso.Descripcion = (string)AccesoBD.Lector["DESCRIPCION"];
                    curso.Requisitos = (string)AccesoBD.Lector["REQUISITOS"];
                    curso.Importe = (decimal)AccesoBD.Lector["IMPORTE"];
                    curso.UrlPortada = (string)AccesoBD.Lector["URL_PORTADA"];
                    curso.IdCategoria = (int)AccesoBD.Lector["IDCATEGORIA"];
                    curso.FechaCreacion = (DateTime)AccesoBD.Lector["FECHA_CREACION"];
                    listCurso.Add(curso);
                }
                return listCurso;
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

        public void ModificarCurso(Curso curso)
        {
            ConexionBD Acceso = new ConexionBD();
            try
            {
                Acceso.SetQuery("UPDATE CURSOS  SET NOMBRE=@Nombre, DESCRIPCION=@Descripcion, REQUISITOS=@Requisitos, IMPORTE=@Importe, URL_PORTADA=@UrlPortada,IDCATEGORIA=@IdCategoria WHERE IDCURSO=@IDCURSO");
                Acceso.SetParametro("@IDCurso", curso.IdCurso);
                Acceso.SetParametro("@Nombre", curso.Nombre);
                Acceso.SetParametro("@Descripcion", curso.Descripcion);
                Acceso.SetParametro("@Requisitos", curso.Requisitos);
                Acceso.SetParametro("@Importe", curso.Importe);
                Acceso.SetParametro("@UrlPortada", curso.UrlPortada);
                Acceso.SetParametro("@IDCategoria", curso.IdCategoria);
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
        public void EliminarCurso(int Id)
        {
            ConexionBD Acceso = new ConexionBD();
            try
            {
                Acceso.SetQuery("DELETE FROM CURSOS WHERE IDCURSO=@IDCurso");
                Acceso.SetParametro("@IDCurso", Id);
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


