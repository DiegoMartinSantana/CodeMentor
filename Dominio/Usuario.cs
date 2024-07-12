using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; } 

        public string Pass { get; set; } 

        public bool? EsAdmin { get; set; } //DEFAULT = 0

        public DateTime? FechaCreacion { get; set; } // se carga sola en la BD

        public bool Baja { get; set; }
    }
}
