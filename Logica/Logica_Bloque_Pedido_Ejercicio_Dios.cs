using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Pedido_Ejercicio_Dios
    {
        Bloque_Pedido_Ejercicio_Dios BPED = new Bloque_Pedido_Ejercicio_Dios();
        public List<Mostrar_Ejercicio_Pedido_DiosResult> Logica_Mostrar_Ejercicio()
        {
            return BPED.Mostrar_Ejercicio().ToList();
        }

        public List<Seleccionar_Ejercicio_Pedido_DiosResult> Logica_Seleccionar_Ejercicicio(int Identidad)
        {
            return BPED.Seleccionar_Ejercicicio(Identidad).ToList();
        }

        public int? Logica_Contar_Cantidad_Ejercicios()
        {
            return BPED.Contar_Cantidad_Ejercicios();
            

        }
       

        public int Logica_Borrar_Ejercicico(int Identidad)
        {
            return BPED.Borrar_Ejercicico(Identidad);
        }
    }
}
