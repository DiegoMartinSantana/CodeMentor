using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Curso
    {
        public int IdCurso { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Requisitos { get; set; }

        public decimal Importe { get; set; }

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

    public DateTime FechaCreacion { get; set; } // ? = acepta nulos
        public bool Baja { get; set; }

}
}
