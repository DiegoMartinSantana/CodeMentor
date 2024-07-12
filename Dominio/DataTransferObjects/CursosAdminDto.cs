using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataTransferObjects
{
    public class CursosAdminDto
    {
        public int IdCurso { get; set; }
        
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Requisitos { get; set; }

        public decimal Importe { get; set; }
        
        public string ImporteFormateado { get { return Importe.ToString("F2"); } }
        public string UrlPortada { get; set; }

        public string UrlPortadaCarpeta
        {
            get
            {
                //logica para manejo en carpetas desde aspxAdmin/imagenes/ o via url!

                if (UrlPortada.ToLower().Contains("https")) //si es una url
                {
                    return UrlPortada;
                }
                else
                {
                    return "~/AspxAdmin/Imagenes/Cursos/" + UrlPortada;

                }
            }
        }
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; }

        public DateTime FechaCreacion { get; set; }
        public List<Unidad> Unidades;

        //diccionario (clave , valor) clave = id unidad , valor = sus clases
       public Dictionary<int, List<Clase>> UnidadesClasesDiccionario = new Dictionary<int, List<Clase>>();
        public int CantidadInscriptos { get; set; }
        public List<Lenguaje> LenguajesAsociados { get; set; }

    }
}
