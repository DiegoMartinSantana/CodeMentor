using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOS
{
    public class InscripcionesGestionDto
    {

        public string Nombre { get; set; }

        public int IdUsuario { get; set; }
        public string Apellido { get; set; }

        public string NombreCurso { get; set; }
        public int IdCurso { get; set; }

        public int IdInscripcion { get; set; }

        public bool Baja { get; set; }
        public bool Habilitada { get; set; }


    }
}
