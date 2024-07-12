using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataTransferObjects
{
    public class CertificadosDto
    {
        public int IdCertificacion { get; set; }
        public int IdInscripcion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCurso { get; set; }
    }
}
