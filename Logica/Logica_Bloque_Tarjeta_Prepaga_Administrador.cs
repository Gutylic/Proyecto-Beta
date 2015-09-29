using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Tarjeta_Prepaga_Administrador
    {
        Bloque_Tarjeta_Prepaga_Administrador BTPA = new Bloque_Tarjeta_Prepaga_Administrador();

        public List<Mostrar_Tarjeta_Prepaga_AdministradorResult> Logica_Mostrar_Tarjeta_Prepaga(int Codigo, string Empresa)
        {
            return BTPA.Mostrar_Tarjeta_Prepaga(Codigo, Empresa).ToList();
        }
    }
}
