using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comprar_Ejercicios_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Ejercicios_DiosResult> Mostrar_Ejercicios(string Datos, int Opcion)
        {
            return db.Mostrar_Ejercicios_Dios(Datos, Opcion).ToList();
        }

        public List<Seleccionar_Ejercicio_DiosResult> Seleccionar_Ejercicio(int Identificador)
        {
            return db.Seleccionar_Ejercicio_Dios(Identificador).ToList();
        }

        public int? Contar_Ejercicios(string Datos, int Opcion)
        {
            db.Contar_Ejercicios_Dios(Datos, Opcion, ref Cantidad);
            return Cantidad;
        }
        public int Borrar_Ejercicios(int Identificador)
        {
            return db.Borrar_Ejercicio_Dios(Identificador);
        }

    }
}
