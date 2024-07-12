using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validaciones
{
    public class Seguridad
    {
        public static bool EsAdmin(object user)
        {
            Usuario usuario = (Usuario)user;
            if (usuario.EsAdmin == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Login(object usuario) //se lo pasa desde Session
        {
            //     Usuario user = usuario != null ? (Usuario)usuario : null; // valida si es null o no y transforma de object a Usuario

            Usuario user;
            if(usuario != null)
            {
                user = (Usuario)usuario;

            }
            else
            {
                user = null;
            }

            if (user != null )
            {
                return true;

            }
            else
            {
                return false;
            }


        }
      

    }
}
