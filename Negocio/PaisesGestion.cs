using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PaisesGestion
    {
        public string ObtenerPais(int id)
        {

            ConexionBD AccesoBD = new ConexionBD();
            string Pais = null; //devuelve null si no pudo leer
            try
            {
                string query = "SELECT NOMBRE FROM PAISES WHERE IDPAIS = @id";
                AccesoBD.SetQuery(query);
                AccesoBD.SetParametro("@id", id);
                AccesoBD.EjecutarLectura();
                if (AccesoBD.Lector.Read()) // SI LEE
                {
                    Pais = (string)AccesoBD.Lector["NOMBRE"]; //si lee pisa el null
                }
                return Pais;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        public IEnumerable<Pais> ListadoPaises() // Solo quiero mostrarlos. Ienumerable = Interfaz. No carga tanto como List (Clase)
        {

            ConexionBD AccesoBD = new ConexionBD();
            var Paises = new List<Pais>();
            try
            {
                string query = "Select IDPAIS,NOMBRE, CODIGOPAIS_3 from PAISES";
                AccesoBD.SetQuery(query);
                AccesoBD.EjecutarLectura();
                while (AccesoBD.Lector.Read())
                {
                    var Pais = new Pais();
                    Pais.IdPais = (int)AccesoBD.Lector["IDPAIS"];
                    Pais.Nombre = (string)AccesoBD.Lector["NOMBRE"];
                    Pais.Codigopais3 = (string)AccesoBD.Lector["CODIGOPAIS_3"];
                    Paises.Add(Pais);
                }
                return Paises;
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
