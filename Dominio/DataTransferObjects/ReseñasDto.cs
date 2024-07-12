using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataTransferObjects
{
    public class ReseñasDto
    {
        public int IdReseña { get; set; }

        public string Nombre_Apellido { get; set; }
        public string NombreCurso { get; set; }
        public int IdCurso { get; set; }

        public int Puntaje { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaReseña { get; set;}
        
        public string UrlFotoPerfil { get; set; }
        public string FechaFormateada
        {
            get { return FechaReseña.ToString("dd/MM/yyyy"); }
        }
    }
}
