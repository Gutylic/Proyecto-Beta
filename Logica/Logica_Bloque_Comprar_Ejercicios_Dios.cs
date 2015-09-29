using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comprar_Ejercicios_Dios
    {
        Bloque_Comprar_Ejercicios_Dios BCED = new Bloque_Comprar_Ejercicios_Dios();

        public List<Mostrar_Ejercicios_DiosResult> Logica_Mostrar_Ejercicios(string Datos, int Opcion)
        {
            return BCED.Mostrar_Ejercicios(Datos, Opcion).ToList();
        }

        public List<Seleccionar_Ejercicio_DiosResult> Logica_Seleccionar_Ejercicio(int Identificador)
        {
            return BCED.Seleccionar_Ejercicio(Identificador).ToList();
        }

        public int? Logica_Contar_Ejercicios(string Datos, int Opcion)
        {
            return BCED.Contar_Ejercicios(Datos, Opcion);
    
        }

        public int Logica_Borrar_Ejercicios(int Identificador)
        {
            return BCED.Borrar_Ejercicios(Identificador);
        }
    }
}
