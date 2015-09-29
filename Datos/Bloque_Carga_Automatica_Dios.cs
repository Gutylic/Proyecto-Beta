using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Carga_Automatica_Dios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public int Actualizar_URL(string URL, int Identificador)
        {
            return db.Actualizar_URL_Dios(URL, Identificador);
        }

        public List<Mostrar_URL_DiosResult> Mostrar_URL()
        {
            return db.Mostrar_URL_Dios().ToList();
        }

        public List<Seleccionar_URL_DiosResult> Seleccionar_URL(int Identificador)
        {
            return db.Seleccionar_URL_Dios(Identificador).ToList();
        }

        public int? Contar_URL()
        {
            db.Contar_URL_Dios(ref Cantidad);
            return Cantidad;
        }
    }
}
