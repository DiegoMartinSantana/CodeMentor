using Dominio;
using Dominio.DataTransferObjects;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validaciones
{

    public static class Helper
    {
        
        public static string InsertarIframe(string urlYoutube)
        {
            string UrlIframe = PonerEmbed(urlYoutube);
            return "<iframe width='560' height='315' src='"+ UrlIframe + "' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";
        }
        public static string PonerEmbed(string url)
        {
            string urlLimpia = url.Replace("watch?v=", "embed/");
            return urlLimpia;
        }
        public static string SacarEmbed(string url)
        {
            //REEMPLAZA!
            string urlLimpia = url.Replace("embed/", "watch?v=");
            return urlLimpia;
        }
     
        public static List<PreguntaRespuestaDto> LlenaryMapearPreg_Resp(int idcurso)
        {


            var UsuarioGestion = new UsuariosGestion();
            var CursoGestion = new CursosGestion();
            var RespGestion = new RespuestasGestion();
            var PregGestion = new PreguntasGestion();

            //recorro todas preguntas existentes 
            var ListadoPreguntasRespuestas = new List<PreguntaRespuestaDto>();

            foreach (var pregunta in PregGestion.ListadoPreguntas(idcurso))
            {
                var Usuario = UsuarioGestion.ObtenerDatos(pregunta.IdUsuario);
                var Curso = CursoGestion.Existencia(pregunta.IdCurso);
                var Respuesta = RespGestion.Existencia(pregunta.IdPregunta);

                var PreguntaRespuesta = new PreguntaRespuestaDto
                {
                    IdPregunta = pregunta.IdPregunta,
                    IdCurso = pregunta.IdCurso,
                    NombreCurso = Curso.Nombre,
                    IdUsuario = pregunta.IdUsuario,
                    NombreApellidoUser = Usuario.Nombre + " " + Usuario.Apellido,
                    FechaPregunta = pregunta.Fecha,
                    TituloPregunta = pregunta.Titulo,
                    CuerpoPregunta = pregunta.Cuerpo,
                    IdRespuesta = null,
                    CuerpoRespuesta = null,
                    FechaRespuesta = null,
                };
                if (Respuesta != null)
                {
                    PreguntaRespuesta.IdRespuesta = Respuesta.IdRespuesta;
                    PreguntaRespuesta.CuerpoRespuesta = Respuesta.Cuerpo;
                    PreguntaRespuesta.FechaRespuesta = Respuesta.Fecha;
                }
                ListadoPreguntasRespuestas.Add(PreguntaRespuesta);
            }
            ListadoPreguntasRespuestas = ListadoPreguntasRespuestas.OrderByDescending(x => x.FechaPregunta).ToList(); //ORDENAMOS POR FECHA RECIENTE!

            return ListadoPreguntasRespuestas;

        }


        //devuelve el DTO
        public static List<CursosAdminDto> LlenaryMapearCursosAdminDto()
        {
            //gestiones
            var cursoGestion = new CursosGestion();
            var UnidadesGestion = new UnidadGestion();
            var ClasesGestion = new ClaseGestion();
            var CategoriaGestion = new CategoriasGestion();
            var InscripcionGestion = new InscripcionesGestion();
            var LenguajesGestion = new LenguajesGestion();

            //listados necesarios
            var listaCursos = cursoGestion.Listado();
            var listaCursosDto = new List<CursosAdminDto>();

            //llenado de info
            foreach (var curso in listaCursos)
            {
                //info curso
                var cursoDto = new CursosAdminDto();
                cursoDto.IdCurso = curso.IdCurso;
                cursoDto.Nombre = curso.Nombre;
                cursoDto.Descripcion = curso.Descripcion;
                cursoDto.Requisitos = curso.Requisitos;
                cursoDto.Importe = curso.Importe;
                cursoDto.UrlPortada = curso.UrlPortada;
                cursoDto.IdCategoria = curso.IdCategoria;
                cursoDto.FechaCreacion = curso.FechaCreacion;
                //cats
                cursoDto.NombreCategoria = CategoriaGestion.ObtenerNombreCategoria(curso.IdCategoria);


                //info inscripciones
                cursoDto.CantidadInscriptos = InscripcionGestion.CantidadInscriptos(curso.IdCurso);

                //info lenguajes

                cursoDto.LenguajesAsociados = LenguajesGestion.ObtenerLenguajesPorCurso(curso.IdCurso);

                //info unidades y clases
                cursoDto.Unidades = UnidadesGestion.ObtenerUnidadesPorCurso(curso.IdCurso);
                //recorro unidades y asigno mediante clave valor al Dicc
                foreach (var unidad in cursoDto.Unidades)
                {
                    var clases = ClasesGestion.ObtenerClasesPorUnidad(unidad.IdUnidad);
                    cursoDto.UnidadesClasesDiccionario.Add(unidad.IdUnidad, clases);
                }

                listaCursosDto.Add(cursoDto);
            }

            return listaCursosDto;

        }
        public static InfoUsuarioDto MapearUsuario(Usuario user, InformacionUsuario userDatos) //para no usar autommaping por tema de tiempos .
        {
            var DtoUser = new InfoUsuarioDto();
            DtoUser.Idusuario = userDatos.Idusuario;
            DtoUser.UrlFotoPerfil = userDatos.UrlFotoPerfil;
            DtoUser.Nombre = userDatos.Nombre;
            DtoUser.Apellido = userDatos.Apellido;
            DtoUser.Email = user.Email;
            DtoUser.Celular = userDatos.Celular;
            DtoUser.FechaNacimiento = userDatos.FechaNacimiento;
            DtoUser.Pass = user.Pass;
            return DtoUser;
        }

        public static InformacionUsuario ObtenerDatos(object user)
        {
            var UserGestion = new UsuariosGestion();
            var InfoUser = new InformacionUsuario();

            Usuario usuario = (Usuario)user;
            InfoUser = UserGestion.ObtenerDatos(usuario.IdUsuario);
            InfoUser.Idusuario = usuario.IdUsuario;
            return InfoUser;

        }

        public static string ObtenerNombreAdmin()
        {
            var UserGestion = new UsuariosGestion();
            var infoAdmin = UserGestion.ObtenerAdmin();
            string nombre = infoAdmin.Nombre + " " + infoAdmin.Apellido;
            return nombre;

        }


        // **string codigo = new GeneradorCodigos().GenerarCodigoAleatorio() **               

        public static string GenerarCodigoAleatorio()
        {
            int longitud = 8; // o la que consideremos
        Random random = new Random();
            const string caracteresPermitidos = "0123456789";
            char[] codigo = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                codigo[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }

            return new string(codigo);
        }



    }
}
