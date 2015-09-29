using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comprar_Videos_Administrador
    {
        Bloque_Comprar_Videos_Administrador BCVA = new Bloque_Comprar_Videos_Administrador();

        public List<Mostrar_Videos_AdministradorResult> Logica_Mostrar_Videos(string Usuario)
        {
            return BCVA.Mostrar_Videos(Usuario).ToList();
        }

        public int? Logica_Contar_Videos(string Usuario)
        {
            return BCVA.Contar_Videos(Usuario);
        }
    }
}
