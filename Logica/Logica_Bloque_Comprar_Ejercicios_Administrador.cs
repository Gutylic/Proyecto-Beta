using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comprar_Ejercicios_Administrador
    {
        Bloque_Comprar_Ejercicios_Administrador BCEA = new Bloque_Comprar_Ejercicios_Administrador();

        public List<Mostrar_Ejercicios_AdministradorResult> Logica_Mostrar_Ejercicios (string Usuario)
        {
            return BCEA.Mostrar_Ejercicios(Usuario).ToList();
        }

        public int? Logica_Contar_Ejercicios(string Usuario)
        {
            return BCEA.Contar_Ejercicios(Usuario);
        }
    }
}
