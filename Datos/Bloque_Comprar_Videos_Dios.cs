using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comprar_Videos_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Videos_DiosResult> Mostrar_Videos(string Datos, int Opcion)
        {
            return db.Mostrar_Videos_Dios(Datos, Opcion).ToList();
        }

        public List<Seleccionar_Video_DiosResult> Seleccionar_Video(int Identificador)
        {
            return db.Seleccionar_Video_Dios(Identificador).ToList();
        }

        public int? Contar_Video(string Datos, int Opcion)
        {
            db.Contar_Videos_Dios(Datos, Opcion, ref Cantidad);
            return Cantidad;
        }

        public int Borrar_Videos(int Identificador)
        {
            return db.Borrar_Video_Dios(Identificador);
        }
    }
}
