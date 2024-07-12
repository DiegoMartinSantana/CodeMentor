using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UnidadGestion
    {

        public List<Unidad> Listado(int IdUnidad = 0)
        {

            var Acceso = new ConexionBD();
            var Unidades = new List<Unidad>();
            try
            {
                string query = "";
                if (IdUnidad == 0)
                {
                    query = "SELECT IDUNIDAD, NUMERO, NOMBRE, DESCRIPCION, IDCURSO FROM UNIDADES ";
                }
                else
                {
                    query = "SELECT IDUNIDAD, NUMERO, NOMBRE, DESCRIPCION, IDCURSO FROM UNIDADES where IDUNIDAD = @IDUNIDAD";
                    Acceso.SetParametro("@IDUNIDAD", IdUnidad);
                }
                Acceso.SetQuery(query);
                Acceso.EjecutarLectura();
                var ListaUnidades = new List<Unidad>();

                while (Acceso.Lector.Read())
                {
                    var Uni = new Unidad();
                    Uni.IdUnidad = (int)Acceso.Lector["IDUNIDAD"];
                    Uni.Numero = (int)Acceso.Lector["NUMERO"];
                    Uni.Nombre = (string)Acceso.Lector["NOMBRE"];
                    Uni.Descripcion = (string)Acceso.Lector["DESCRIPCION"];
                    Uni.IdCurso = (int)Acceso.Lector["IDCURSO"];
                    ListaUnidades.Add(Uni);
                }
                return ListaUnidades;
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
        public List<Unidad> UnidadesFinalizadas(int idCurso, int idUser)
        {


            var Acceso = new ConexionBD();
            var Unidades = new List<Unidad>();
            try
            {
                //JOINEAMOS A UNIDADES X QUE AHI ESTA EL ID DEL CURSO!
                Acceso.SetQuery("SELECT UF.IDUNIDAD FROM UNIDADES_FINALIZADAS UF INNER JOIN UNIDADES U ON U.IDUNIDAD = UF.IDUNIDAD AND  UF.IDUSUARIO = @IDUSER AND U.IDCURSO = @IDCURSO");
                Acceso.SetParametro("@IDUSER", idUser);
                Acceso.SetParametro("@IDCURSO", idCurso);
                Acceso.EjecutarLectura();
                while (Acceso.Lector.Read())
                {
                    Unidad unidad = new Unidad();
                    unidad.IdUnidad = (int)Acceso.Lector["IDUNIDAD"];
                    Unidades.Add(unidad);
                }
                return Unidades;
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
        public int UnidadesPorCursoCant(int curso)
        {
            var Acceso = new ConexionBD();
            try
            {
                Acceso.SetQuery("SELECT COUNT(IDUNIDAD) AS CANTIDAD FROM UNIDADES WHERE IDCURSO = @IDCURSO");
                Acceso.SetParametro("@IDCURSO", curso);
                Acceso.EjecutarLectura();
                if (Acceso.Lector.Read())
                {
                    return (int)Acceso.Lector["CANTIDAD"];
                }
                else
                {
                    return 0;
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
        public List<Unidad> ObtenerUnidadesPorCurso(int idCurso) // OBTENER UNIDADES DE UN CURSO
        {
            // Obtengo una lista de unidades asociados a un curso utilizando la tabla UNIDADES
            // Ya que peude ser mas de un lenguaje por curso

            var Acceso = new ConexionBD();
            try
            {

                string query = "SELECT IDUNIDAD, NUMERO, NOMBRE, DESCRIPCION, IDCURSO FROM UNIDADES WHERE IDCURSO = @idCurso";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@idCurso", idCurso);
                Acceso.EjecutarLectura();
                var ListaUnidades = new List<Unidad>();

                while (Acceso.Lector.Read())
                {
                    var Uni = new Unidad();
                    Uni.IdUnidad = (int)Acceso.Lector["IDUNIDAD"];
                    Uni.Numero = (int)Acceso.Lector["NUMERO"];
                    Uni.Nombre = (string)Acceso.Lector["NOMBRE"];
                    Uni.Descripcion = (string)Acceso.Lector["DESCRIPCION"];
                    Uni.IdCurso = (int)Acceso.Lector["IDCURSO"];
                    ListaUnidades.Add(Uni);
                }

                return ListaUnidades;

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

        public void ModificarUnidad(Unidad Uni)
        {

            var Acceso = new ConexionBD();
            try
            {

                string query = "UPDATE UNIDADES SET  NOMBRE = @Nombre, DESCRIPCION = @Descripcion WHERE IDUNIDAD = @Id";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@Nombre", Uni.Nombre);
                Acceso.SetParametro("@Descripcion", Uni.Descripcion);
                Acceso.SetParametro("@Id", Uni.IdUnidad);
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
        public void InsertarUnidad(Unidad Uni) // ALTA UNIDAD
        {
            var Acceso = new ConexionBD();

            try
            {
                string query = "INSERT INTO UNIDADES (NUMERO, NOMBRE, DESCRIPCION, IDCURSO) VALUES ( @Numero, @Nombre, @Descripcion, @IdCurso)";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@Numero", Uni.Numero);
                Acceso.SetParametro("@Nombre", Uni.Nombre);
                Acceso.SetParametro("@Descripcion", Uni.Descripcion);
                Acceso.SetParametro("@IdCurso", Uni.IdCurso);
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
        
        public void EliminarFinalizadas(int idUnidad) // BAJA UNIDAD FINALIZADA
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "DELETE FROM UNIDADES_FINALIZADAS WHERE IDUNIDAD = @IDUNIDAD ";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@IDUNIDAD", idUnidad);
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

        public void EliminarUnidad(int IdUnidad,int idcurso,int numeroUnidad) // BAJA UNIDAD
        {
            var Acceso = new ConexionBD();
            try
            {
                EliminarFinalizadas(IdUnidad);
                var ClaseGestion = new ClaseGestion();
                ClaseGestion.EliminarClases_Unidad(IdUnidad);
                string query = "DELETE FROM UNIDADES WHERE NUMERO = @Nro AND @IDCURSO = IDCURSO AND IDUNIDAD= @ID";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@Id", IdUnidad);
                Acceso.SetParametro("@Nro", numeroUnidad);
                Acceso.SetParametro("@IDCURSO", idcurso);
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
