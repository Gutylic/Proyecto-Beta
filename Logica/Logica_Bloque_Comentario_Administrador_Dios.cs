using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comentario_Administrador_Dios
    {

        Bloque_Comentario_Administrador_Dios BCAD = new Bloque_Comentario_Administrador_Dios();

        public List<Mostrar_Comentarios_Administrador_DiosResult> Logica_Comentario_Administradores() // muestra los comentarios al Dios
        {
            return BCAD.Comentario_Administradores().ToList();
        }
        public int? Logica_Contar_Comentarios() // selecciona un comentario el Dios o dios
        {
            return BCAD.Contar_Comentarios();
        }

        public List<Seleccionar_Comentario_Administrador_DiosResult> Logica_Seleccionar_Comentario(int ID_Comentario) // borra el comentario el Dios o dios
        {
            return BCAD.Seleccionar_Comentario(ID_Comentario).ToList();
        }

        public int Logica_Borrar_Comentario(int ID_Comentario) // cuenta los comentarios realizados para dios y utilizado para el paginado
        {
            return BCAD.Borrar_Comentario(ID_Comentario);
        }
    }
}
