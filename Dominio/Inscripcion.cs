using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Inscripcion
    {
        public int IdInscripcion { get; set; }

        public int IdCurso { get; set; }

        public int IdUsuario { get; set; }

        public DateTime? Fecha { get; set; } // SE CARGA EN BD
        public bool Baja { get; set; }
        public bool Habilitada { get; set; }



    }
}
