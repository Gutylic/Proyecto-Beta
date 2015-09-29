using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Pedido_Explicacion_Dios
    {
        Bloque_Pedido_Explicacion_Dios BPED = new Bloque_Pedido_Explicacion_Dios();
        public List<Mostrar_Explicacion_Pedida_DiosResult> Logica_Mostrar_Explicacion()
        {
            return BPED.Mostrar_Explicacion().ToList();
        }

        public List<Seleccionar_Explicacion_Pedida_DiosResult> Logica_Seleccionar_Explicacion(int Identidad)
        {
            return BPED.Seleccionar_Explicacion(Identidad).ToList();
        }

        public int? Logica_Contar_Cantidad_Explicacion()
        {
            return BPED.Contar_Cantidad_Explicacion();
            
        }
        
        public int Logica_Borrar_Explicacion(int Identidad)
        {
            return BPED.Borrar_Explicacion(Identidad);
        }
    }
}
