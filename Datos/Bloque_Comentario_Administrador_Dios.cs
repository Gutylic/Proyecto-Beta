using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comentario_Administrador_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Comentarios_Administrador_DiosResult> Comentario_Administradores() // muestra los comentarios al Dios
        {
            return db.Mostrar_Comentarios_Administrador_Dios().ToList();
        }
        public int? Contar_Comentarios() // selecciona un comentario el Dios o dios
        {
            db.Contar_Comentarios_Administrador_Dios(ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Comentario_Administrador_DiosResult> Seleccionar_Comentario(int ID_Comentario) // borra el comentario el Dios o dios
        {
            return db.Seleccionar_Comentario_Administrador_Dios(ID_Comentario).ToList();
        }

        public int Borrar_Comentario(int ID_Comentario) // cuenta los comentarios realizados para dios y utilizado para el paginado
        {
            return db.Borrar_Comentario_Administrador_Dios(ID_Comentario);
        }
    }
}
