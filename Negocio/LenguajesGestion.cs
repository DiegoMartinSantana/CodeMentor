using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LenguajesGestion
    {
        public void AsociarLenguajes(int idlenguaje, int idcurso)
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                string query = "INSERT INTO LENGUAJESXCURSO (IDLENGUAJE,IDCURSO) VALUES (@idlenguaje,@idcurso)";
                conexionBD.SetQuery(query);
                conexionBD.SetParametro("@idlenguaje", idlenguaje);
                conexionBD.SetParametro("@idcurso", idcurso);
                conexionBD.EjecutarAccion();
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
            public List<Lenguaje> ObtenerLenguajesPorCurso(int IdCurso) // OBTENER LENGUAJES DE UN CURSO
            {
                // Obtengo una lista de lenguajes asociados a un curso utilizando la tabla LENGUAJESXCURSO
                // Ya que peude ser mas de un lenguaje por curso

                var Acceso = new ConexionBD();
                try
                {
                    string query = "SELECT L.IDLENGUAJE, L.NOMBRE FROM LENGUAJES L INNER JOIN LENGUAJESXCURSO LC ON LC.IDLENGUAJE = L.IDLENGUAJE WHERE LC.IDCURSO = @IdCurso";
                    Acceso.SetQuery(query);
                    Acceso.SetParametro("@IdCurso", IdCurso);
                    Acceso.EjecutarLectura();
                    var ListaLenguajes = new List<Lenguaje>();

                    while (Acceso.Lector.Read())
                    {
                        var Leng = new Lenguaje();
                        Leng.IdLenguaje = (int)Acceso.Lector["IDLENGUAJE"];
                        Leng.Nombre = (string)Acceso.Lector["NOMBRE"];
                        ListaLenguajes.Add(Leng);
                    }

                    return ListaLenguajes;
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
            public List<Lenguaje> ListarLenguajes() // LISTAR LENGUAJES
            {
                var Acceso = new ConexionBD();
                try
                {
                    string query = "SELECT IDLENGUAJE, NOMBRE FROM LENGUAJES";
                    Acceso.SetQuery(query);
                    Acceso.EjecutarLectura();
                    var ListaLenguajes = new List<Lenguaje>();

                    while (Acceso.Lector.Read())
                    {
                        var Leng = new Lenguaje();
                        Leng.IdLenguaje = (int)Acceso.Lector["IDLENGUAJE"];
                        Leng.Nombre = (string)Acceso.Lector["NOMBRE"];
                        ListaLenguajes.Add(Leng);
                    }

                    return ListaLenguajes;
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
            public void InsertarLenguaje(Lenguaje Leng) // ALTA LENGUAJE
            {
                var Acceso = new ConexionBD();
                try
                {
                    string query = "INSERT INTO LENGUAJES (NOMBRE) VALUES (@Nombre)";
                    Acceso.SetQuery(query);
                    Acceso.SetParametro("@Nombre", Leng.Nombre);
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
            public void ModificarLenguaje(Lenguaje Leng) // MODIFICAR LENGUAJE
            {
                var Acceso = new ConexionBD();
                try
                {
                    string query = "UPDATE LENGUAJES SET NOMBRE = @Nombre WHERE IDLENGUAJE = @Id";
                    Acceso.SetQuery(query);
                    Acceso.SetParametro("@Nombre", Leng.Nombre);
                    Acceso.SetParametro("@Id", Leng.IdLenguaje);
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
            public void EliminarLenguaje(int Id) // BAJA LENGUAJE
            {
                var Acceso = new ConexionBD();
                try
                {
                    string query = "DELETE FROM LENGUAJES WHERE IDLENGUAJE = @Id";
                    Acceso.SetQuery(query);
                    Acceso.SetParametro("@Id", Id);
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
