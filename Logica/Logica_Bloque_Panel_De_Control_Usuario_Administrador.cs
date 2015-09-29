using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Panel_De_Control_Usuario_Administrador
    {
        Bloque_Panel_De_Control_Usuario_Admimistrador BPDCUA = new Bloque_Panel_De_Control_Usuario_Admimistrador();

        public List<Mostrar_Usuario_AdministradorResult> Logica_Mostrar_Datos(string Dato, int ID_Empresa, int Opciones)
        {
            return BPDCUA.Mostrar_Datos(Dato, ID_Empresa, Opciones).ToList();
        }

    }
}
