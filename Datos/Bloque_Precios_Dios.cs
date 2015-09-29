using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Precios_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Precios_DiosResult> Mostrar_Precios() 
        {
            return db.Mostrar_Precios_Dios().ToList();
        }

        public int? Contar_Precios()
        {
            db.Contar_Precios_Dios(ref Cantidad);
            return Cantidad;
        }
    }
}
