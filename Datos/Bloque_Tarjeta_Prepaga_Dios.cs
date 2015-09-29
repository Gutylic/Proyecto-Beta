using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Tarjeta_Prepaga_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Tarjeta_Prepaga_DiosResult> Mostrar_Tarjetas_Prepagas(string Datos, int Opcion)
        {
            return db.Mostrar_Tarjeta_Prepaga_Dios(Datos, Opcion).ToList();
        }

        public int? Contar_Tarjetas_Prepagas(string Datos, int Opcion)
        {
            db.Contar_Tarjeta_Prepaga_Dios(Datos, Opcion, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Tarjeta_Prepaga_DiosResult> Seleccionar_Tarjetas_Prepagas(int Identificador)
        {
            return db.Seleccionar_Tarjeta_Prepaga_Dios(Identificador).ToList();
        }


        public int Borrar_Tarjeta_Prepaga(int ID_Tarjeta)
        {
            return db.Borrar_Tarjeta_Prepaga_Supervisor(ID_Tarjeta);
        }

    }
}
