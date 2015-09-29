using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Activar_Oferta_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public List<Mostrar_Activar_Oferta_SupervisorResult> Mostrar_Activacion_Oferta(int ID_Empresa)
        {
            return db.Mostrar_Activar_Oferta_Supervisor(ID_Empresa).ToList();
        }

        public int Actualizar_Activar_Oferta(int ID_Empresa, bool Oferta_1, bool Oferta_2,bool Oferta_3, bool Oferta_4,bool Oferta_5,bool Oferta_6, bool Oferta_7,bool Oferta_8, bool Oferta_9,bool Oferta_10, bool Oferta_11,bool Oferta_12, bool Oferta_13, bool Oferta_14, bool Oferta_15 )
        {
            return db.Actualizar_Activar_Oferta_Supervisor(ID_Empresa, Oferta_1, Oferta_2, Oferta_3, Oferta_4, Oferta_5,Oferta_6, Oferta_7, Oferta_8, Oferta_9, Oferta_10, Oferta_11, Oferta_12, Oferta_13, Oferta_14, Oferta_15);
        }
    }
}
