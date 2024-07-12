using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriasGestion
    {
        public string ObtenerNombreCategoria(int id)
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "Select Nombre from Categorias where IdCategoria = @Id";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@Id", id);
                Acceso.EjecutarLectura();
                if (Acceso.Lector.Read())
                {
                    return (string)Acceso.Lector["Nombre"];
                }
                return ""; // si no encuentra nada
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

        public Categoria CategoriaCurso(int IdCurso)
        {
            var Acceso = new ConexionBD();
            try
            {
                string query= "Select cat.IdCategoria,cat.Nombre from categorias cat inner join cursos c on c.idcategoria = cat.IdCategoria where c.IdCurso = @idcurso";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@idcurso", IdCurso);
                Acceso.EjecutarLectura();
                var Cat = new Categoria();
                if (Acceso.Lector.Read())
                {
                    Cat.IdCategoria = (int)Acceso.Lector["IdCategoria"];
                    Cat.Nombre= (string)Acceso.Lector["Nombre"]; 
                }
                return Cat; // si no encuentra nada, devuelve un objeto vacio
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
        public List<Categoria> ListarCategorias()
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "Select IdCategoria,Nombre from categorias";
                Acceso.SetQuery(query);
                Acceso.EjecutarLectura();
                var ListaCategorias = new List<Categoria>();
                while (Acceso.Lector.Read())
                {
                    var Cat = new Categoria();
                    Cat.IdCategoria = (int)Acceso.Lector["IdCategoria"];
                    Cat.Nombre = (string)Acceso.Lector["Nombre"];
                    ListaCategorias.Add(Cat);
                }
                return ListaCategorias;
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
        public void InsertarCategoria(Categoria Cat) // podriamos recibir string. Pero mejor el objeto por si tenemos alguna propiedad nueva en el futuro
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "Insert into Categorias (Nombre) values (@Nombre)";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@Nombre", Cat.Nombre);
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
        public void ModificarCategoria(Categoria Cat)
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "Update Categorias set Nombre = @Nombre where Id = @Id";
                Acceso.SetQuery(query);
                Acceso.SetParametro("@Nombre", Cat.Nombre);
                Acceso.SetParametro("@Id", Cat.IdCategoria);
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
        public void EliminarCategoria(int Id)
        {
            var Acceso = new ConexionBD();
            try
            {
                string query = "Delete from Categorias where Id = @Id";
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
