using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Carga_Automatica_Dios
    {
        Bloque_Carga_Automatica_Dios BCAD = new Bloque_Carga_Automatica_Dios();

        public int Logica_Actualizar_URL(string URL, int Identificador)
        {
            return BCAD.Actualizar_URL(URL, Identificador);
        }

        public List<Mostrar_URL_DiosResult> Logica_Mostrar_URL()
        {
            return BCAD.Mostrar_URL().ToList();
        }

        public List<Seleccionar_URL_DiosResult> Logica_Seleccionar_URL(int Identificador)
        {
            return BCAD.Seleccionar_URL(Identificador).ToList();
        }

        public int? Logica_Contar_URL()
        {
            return BCAD.Contar_URL();
        }
    }
}