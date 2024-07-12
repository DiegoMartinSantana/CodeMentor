using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }

        public int IdPregunta { get; set; }

        public string Cuerpo { get; set; }

        public DateTime? Fecha { get; set; }
    }
}
