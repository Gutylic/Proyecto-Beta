using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comprar_Videos_Dios
    {

        Bloque_Comprar_Videos_Dios BCVD = new Bloque_Comprar_Videos_Dios();

        public List<Mostrar_Videos_DiosResult> Logica_Mostrar_Videos(string Datos, int Opcion)
        {
            return BCVD.Mostrar_Videos(Datos, Opcion).ToList();
        }

        public List<Seleccionar_Video_DiosResult> Logica_Seleccionar_Video(int Identificador)
        {
            return BCVD.Seleccionar_Video(Identificador).ToList();
        }

        public int? Logica_Contar_Videos(string Datos, int Opcion)
        {
            return BCVD.Contar_Video(Datos, Opcion);

        }

        public int Logica_Borrar_Videos(int Identificador)
        {
            return BCVD.Borrar_Videos(Identificador);
        }
    }
}
