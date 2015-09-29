using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comentario_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;
        public int Insertar_Comentario(int Administrador, string Comentario) // inserta el comentario realizado por un administrador
        {
            return db.Insertar_Comentario_Administrador(Administrador, Comentario);
        }

    }
}
