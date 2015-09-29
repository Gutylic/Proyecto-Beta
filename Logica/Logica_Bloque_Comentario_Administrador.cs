using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comentario_Administrador
    {
        Bloque_Comentario_Administrador BCA = new Bloque_Comentario_Administrador();

        public int Logica_Insertar_Comentario(int Administrador, string Comentario) // inserta el comentario realizado por un administrador
        {
            return BCA.Insertar_Comentario(Administrador, Comentario);
        }


    }
}
