using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Cargar_Oferta_Administrador
    {
        Bloque_Cargar_Oferta_Administrador BCOA = new Bloque_Cargar_Oferta_Administrador();

        public List<Mostrar_Cargar_Ofertas_AdministradorResult> Logica_Mostrar_Cargar_Ofertas(int ID_Empresa)
        {
            return BCOA.Mostrar_Cargar_Oferta(ID_Empresa).ToList();
        }

    }
}
