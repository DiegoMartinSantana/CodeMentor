using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pregunta
    {
        public int IdPregunta { get; set; }

        public int IdCurso { get; set; }

        public int IdUsuario { get; set; }

        public DateTime? Fecha { get; set; } // la fecha se carga sola en la BD

        public string Titulo { get; set; } 

        public string Cuerpo { get; set; } 

    }
}
