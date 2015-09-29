using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Panel_De_Control_Usuario_Dios
    {
        Bloque_Panel_De_Control_Usuario_Dios BPDCUD = new Bloque_Panel_De_Control_Usuario_Dios();

        public List<Mostrar_Usuario_DiosResult> Logica_Mostrar_Usuario(string Dato, int Opcion)
        {
            return BPDCUD.Mostrar_Usuario(Dato, Opcion).ToList();
        }

        public int? Logica_Contar_Usuarios(string Dato, int Opcion)
        {
            return BPDCUD.Contar_Usuarios(Dato,Opcion);            
        }

        public List<Seleccionar_Usuario_DiosResult> Logica_Seleccionar_Usuario(int Identificador)
        {
            return BPDCUD.Seleccionar_Usuario(Identificador).ToList();
        }

        public int Logica_Borrar_Usuario(int Identificador)
        {
            return BPDCUD.Borrar_Usuario(Identificador);
        }
    }
}
