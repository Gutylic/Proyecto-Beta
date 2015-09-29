using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comentario_Usuario_Dios
    {

        Bloque_Comentario_Usuario_Dios BCUD = new Bloque_Comentario_Usuario_Dios();
        public List<Mostrar_Comentarios_De_Usuario_DiosResult> Logica_Mostra_Comentarios()
        {
            return BCUD.Mostra_Comentarios().ToList();

        }

        public int? Logica_Contar_Comentarios()
        {
            return BCUD.Contar_Comentarios();
        }

        public List<Seleccionar_Comentarios_De_Usuario_DiosResult> Logica_Seleccionar_Comentarios(int Identidad)
        {
            return BCUD.Seleccionar_Comentarios(Identidad).ToList();
        }

        public int Logica_Borrar_Comentario(int Identidad)
        {
            return BCUD.Borrar_Comentario(Identidad);
        }


    }
}
