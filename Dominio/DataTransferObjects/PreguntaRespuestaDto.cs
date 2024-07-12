using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataTransferObjects
{
    public class PreguntaRespuestaDto
    {
        // DTO para mostrar en AdminPreguntas

        public int IdPregunta { get; set; }
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }

        public int IdUsuario { get; set; }

        public string NombreApellidoUser { get; set; }

        public DateTime? FechaPregunta { get; set; } 

        public string TituloPregunta { get; set; }

        public string CuerpoPregunta { get; set; }

        public int? IdRespuesta { get; set; } //IMPORTANTE = Que acepten nulls  = int?

        public string CuerpoRespuesta { get; set; }

        public DateTime? FechaRespuesta { get; set; }
    }
}
