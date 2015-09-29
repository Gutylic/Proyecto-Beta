using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comentario_Usuario_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Comentarios_De_Usuario_DiosResult> Mostra_Comentarios()
        {
            return db.Mostrar_Comentarios_De_Usuario_Dios().ToList();

        }

        public int? Contar_Comentarios()
        {
            db.Contar_Comentarios_De_Usuario_Dios(ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Comentarios_De_Usuario_DiosResult> Seleccionar_Comentarios(int Identidad)
        {
            return db.Seleccionar_Comentarios_De_Usuario_Dios(Identidad).ToList();
        }

        public int Borrar_Comentario(int Identidad)
        {
            return db.Borrar_Comentarios_De_Usuario_Dios(Identidad);
        }
    }
}
