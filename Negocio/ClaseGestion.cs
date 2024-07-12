using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClaseGestion
    {
        
        public void EliminarClases_Unidad(int idunidad)
        {

            var Acceso = new ConexionBD();
            try
            {
                string query = "Delete from Clases where IdUnidad = @idunidad";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@idunidad", idunidad);
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
        public Clase ClaseUnidad(int IdUnidad)
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "Select Id,Descripcion from clases where IdUnidad = @idunidad";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@idunidad", IdUnidad);
                Acceso.EjecutarLectura();
                var clase = new Clase();
                if (Acceso.Lector.Read())
                {
                    clase.IdClase = (int)Acceso.Lector["Id"];
                    clase.Descripcion = (string)Acceso.Lector["Descripcion"];
                }
                return clase; // si no encuentra nada, devuelve un objeto vacio
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

        public List<Clase> ListarClases()
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "Select IdClase,Descripcion,IdUnidad,Url_Video,Numero from Clases";
                Acceso.SetQuery(query);
                Acceso.EjecutarLectura();
                var ListaClase = new List<Clase>();
                while (Acceso.Lector.Read())
                {
                    var clase = new Clase();
                    clase.IdClase = (int)Acceso.Lector["IdClase"];
                    clase.Descripcion = (string)Acceso.Lector["Descripcion"];
                    clase.IdUnidad = (int)Acceso.Lector["IdUnidad"];
                    clase.UrlVideo = (string)Acceso.Lector["Url_Video"];
                    clase.Numero = (int)Acceso.Lector["Numero"];
                    ListaClase.Add(clase);
                }
                return ListaClase;
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

        public List<Clase> ObtenerClasesPorUnidad(int idUnidad) // OBTENER CLASES DE UNA UNIDAD
        {
            // Obtengo una lista de clases asociados a una unidad utilizando la tabla CLASES
            // Ya que peude ser mas de una clase por unidad

            var Acceso = new ConexionBD();
            try
            {
                string query = "SELECT IDCLASE, IDUNIDAD, NUMERO, DESCRIPCION, DURACION, URL_VIDEO FROM CLASES WHERE IDUNIDAD = @idUnidad";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@idUnidad", idUnidad);
                Acceso.EjecutarLectura();
                var ListaClases = new List<Clase>();

                while (Acceso.Lector.Read())
                {
                    var Clas = new Clase();
                    Clas.IdClase = (int)Acceso.Lector["IDCLASE"];
                    Clas.IdUnidad = (int)Acceso.Lector["IDUNIDAD"];
                    Clas.Numero = (int)Acceso.Lector["NUMERO"];
                    Clas.Descripcion = (string)Acceso.Lector["DESCRIPCION"];
                    Clas.Duracion = (int)Acceso.Lector["DURACION"];
                    Clas.UrlVideo = (string)Acceso.Lector["URL_VIDEO"];
                    ListaClases.Add(Clas);
                }

                return ListaClases;

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

        public void InsertarClase(Clase clase)
        {
            var Acceso = new ConexionBD();
            try
            {
                // ATENCION: EN DOMINIO CLASE NO TIENE PROP DE NUMERO PERO EN LA BD SI // agrege prop numero en Dominio/Clase.cs
                Acceso.SetQuery("INSERT INTO CLASES (IDUNIDAD,NUMERO,DESCRIPCION,DURACION,URL_VIDEO) VALUES(@IDUnidad,@Numero,@Descripcion,@Duracion,@UrlVideo)");
                Acceso.SetParametro("@IDUnidad", clase.IdUnidad);
                Acceso.SetParametro("@Numero", clase.Numero);
                Acceso.SetParametro("@Descripcion", clase.Descripcion);
                Acceso.SetParametro("@Duracion", clase.Duracion);
                Acceso.SetParametro("@UrlVideo", clase.UrlVideo);
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
        public void ModificarClase(Clase clase)
        {
            var Acceso = new ConexionBD();
            try
            {

                Acceso.SetQuery("UPDATE CLASES SET IDUNIDAD=@IDUnidad,NUMERO=@Numero,DESCRIPCION=@Descripcion,DURACION=@Duracion,URL_VIDEO=@UrlVideo WHERE IDCLASE=@IDClase ");
                Acceso.SetParametro("@IDUnidad", clase.IdUnidad);
                Acceso.SetParametro("@Numero", clase.Numero);
                Acceso.SetParametro("@Descripcion", clase.Descripcion);
                Acceso.SetParametro("@Duracion", clase.Duracion);
                Acceso.SetParametro("@UrlVideo", clase.UrlVideo);
                Acceso.SetParametro("@IDClase", clase.IdClase);
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


        public void EliminarClase(int Id)
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "Delete from Clases where IdClase = @Id";
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

