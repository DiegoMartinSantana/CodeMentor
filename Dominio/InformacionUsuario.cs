using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class InformacionUsuario
    {
        public int Idusuario { get; set; }

        public string Nombre { get; set; } 

        public string Apellido { get; set; } 

        public DateTime FechaNacimiento { get; set; }

        public int IdPais { get; set; }

        public string Celular { get; set; } 

        public string Sexo { get; set; } 

        public string UrlFotoPerfil { get; set; }
        public bool Baja { get; set; }

        //prop para no evaluar en todos lados!
        public string SexoCompleto
        {
            get
            {
                return Sexo.ToUpper() == "M" ? "Masculino" : "Femenino"; // =  si es m devuelvo masculino, sino femenino
            }
        }

    }
}
