using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Panel_De_Control_Usuario_Dios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Usuario_DiosResult> Mostrar_Usuario(string Dato, int Opcion)
        {
            return db.Mostrar_Usuario_Dios(Dato, Opcion).ToList();
        }

        public int? Contar_Usuarios(string Dato, int Opcion)
        {
            db.Contar_Usuario_Dios(Dato, Opcion, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Usuario_DiosResult> Seleccionar_Usuario(int Identificador)
        {
            return db.Seleccionar_Usuario_Dios(Identificador).ToList();
        }

        public int Borrar_Usuario(int Identificador)
        {
            return db.Borrar_Usuario_Dios(Identificador);
        }
              
    }
}
