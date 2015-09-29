using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Activar_Oferta_Administrador
    {
        Bloque_Activar_Oferta_Administrador BAOA = new Bloque_Activar_Oferta_Administrador();

        public List<Mostrar_Activar_Oferta_AdministracionResult> Logica_Mostrar_Activar_Ofertas(int ID_Empresa)
        {
            return BAOA.Mostrar_Activacion_Oferta(ID_Empresa).ToList();
        }

    }
}
