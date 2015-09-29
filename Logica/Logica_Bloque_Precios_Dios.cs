using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Precios_Dios
    {
        Bloque_Precios_Dios BPD = new Bloque_Precios_Dios();

        public List<Mostrar_Precios_DiosResult> Logica_Mostrar_Precios()
        {
            return BPD.Mostrar_Precios().ToList();
        }

        public int? Logica_Contar_Precios()
        {
            return BPD.Contar_Precios();
        }
    }
}
