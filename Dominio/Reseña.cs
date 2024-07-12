using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reseña
    {
        public int IdReseña { get; set; }

        public int IdInscripcion { get; set; }

        public int IdCurso { get; set; }

        public int Puntaje { get; set; }

        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
