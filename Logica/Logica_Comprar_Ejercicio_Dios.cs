using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comprar_Ejercicio_Dios
    {
        Bloque_Comprar_Ejercicios_Dios BCED = new Bloque_Comprar_Ejercicios_Dios();

        public List<Mostrar_Ejercicios_DiosResult> Logica_Mostrar_Ejercicios(string Datos, int Opcion)
        {
            return BCED.Mostrar_Ejercicios(Datos, Opcion).ToList();
        }

        public int? Logica_Contar_Ejercicios(string Datos, int Opcion)
        {
            return BCED.Contar_Ejercicios(Datos, Opcion);
        }

        public List<Seleccionar_Ejercicio_DiosResult> Logica_Seleccionar_Ejercicios(int Identidad)
        {
            return BCED.Seleccionar_Ejercicios(Identidad).ToList();
        }

        public int Borrar_Ejercicios(int Identidad)
        {
            return BCED.Borrar_Ejercicios(Identidad);
        }

    }
}
