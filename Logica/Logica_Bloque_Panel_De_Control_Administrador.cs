using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Panel_De_Control_Administrador
    {
        Bloque_Panel_De_Control_Administrador BPDCA = new Bloque_Panel_De_Control_Administrador();

        public List<Datos_AdministradorResult> Logica_Lista_Datos_Del_Administrador(string Administrador) // busca los datos del administrador
        {
            return BPDCA.Lista_Datos_Del_Administrador(Administrador).ToList();
        }

        public int Logica_Actualizar_Perfil_Administrador(string Administrador, string Password) // actualiza los datos modificados por el mismo administrador
        {
            return BPDCA.Actualizar_Perfil_Administrador(Administrador, Password);
        }
    }
}
