using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Cargar_Oferta_Supervisor
    {
        Bloque_Cargar_Oferta_Supervisor BCOS = new Bloque_Cargar_Oferta_Supervisor();
        public List<Mostrar_Cargar_Ofertas_SupervisorResult> Logica_Mostrar_Cargar_Oferta(int ID_Empresa)
        {
            return BCOS.Mostrar_Cargar_Oferta(ID_Empresa).ToList();
        }

        public int Logica_Actualizar_Cargar_Ofertas(int ID_Empresa, decimal Oferta_1, decimal Oferta_2, decimal Oferta_3, int Oferta_4, decimal Oferta_5, int Oferta_7, int Oferta_12, int Oferta_13, int Oferta_15)
        {
            return BCOS.Actualizar_Cargar_Ofertas(ID_Empresa, Oferta_1, Oferta_2, Oferta_3, Oferta_4, Oferta_5, Oferta_7, Oferta_12, Oferta_13, Oferta_15);
        }
    }
}
