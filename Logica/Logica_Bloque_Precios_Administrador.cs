using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Precios_Administrador
    {

        Bloque_Precios_Administrador BPA = new Bloque_Precios_Administrador();

        public List<Mostrar_Precios_AdministradorResult> Logica_Mostrar_Precios(int ID_Empresa)
        {
            return BPA.Mostrar_Precios(ID_Empresa).ToList();
        }
    }
}
