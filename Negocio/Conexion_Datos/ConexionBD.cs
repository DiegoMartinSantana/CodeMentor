using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ConexionBD
    {
     
        private SqlConnection _Conexion;
        private SqlCommand _Comando;
        private SqlDataReader _Lector;
     
        public SqlDataReader Lector
        {
            get { return _Lector; }
        }

        public ConexionBD()
        {           
            _Conexion = new SqlConnection(@"server =.\SQLEXPRESS;database=CODEMENTOR; integrated security = true"); 
            //inicializar Comando
            _Comando = new SqlCommand();
        }
     
        public void SetQuery(string query)
        {
            _Comando.CommandType = System.Data.CommandType.Text;
            _Comando.CommandText = query; 

        }

        public void EjecutarLectura()
        {
            _Comando.Connection = _Conexion; 
            try
            {
                _Conexion.Open();
                _Lector = _Comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void EjecutarAccion()
        {
            _Comando.Connection = _Conexion;
            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery(); // DEVUELVE CANT FILAS AFECTADAS
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetSP(string sp)
        {
            _Comando.CommandType = System.Data.CommandType.StoredProcedure;
            _Comando.CommandText= sp;
        }
        public void CerrarConexion()
        {
            if (Lector != null)
            {
                Lector.Close();
                _Conexion.Close();
            }
        }

        public int  EjecutarScalar() //SCALAR  = 1 ENTERO DE RESULTADO.
        {
            _Comando.Connection = _Conexion;
            try
            {
                _Conexion.Open();
               return int.Parse (_Comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetParametro(string name, object value) 
        {
            _Comando.Parameters.AddWithValue(name, value);
        }
        
    }
}

    

