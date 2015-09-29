using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Cargar_Oferta_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public List<Mostrar_Cargar_Ofertas_SupervisorResult> Mostrar_Cargar_Oferta(int ID_Empresa)
        {
            return db.Mostrar_Cargar_Ofertas_Supervisor(ID_Empresa).ToList();
        }

        public int Actualizar_Cargar_Ofertas(int ID_Empresa, decimal Oferta_1, decimal Oferta_2, decimal Oferta_3, int Oferta_4, decimal Oferta_5, int Oferta_7, int Oferta_12, int Oferta_13, int Oferta_15)
        {
            return db.Actualizar_Cargar_Ofertas_Supervisor(ID_Empresa, Oferta_1, Oferta_2, Oferta_3, Oferta_4, Oferta_5, Oferta_7, Oferta_12, Oferta_13, Oferta_15);
        }
    }
}
