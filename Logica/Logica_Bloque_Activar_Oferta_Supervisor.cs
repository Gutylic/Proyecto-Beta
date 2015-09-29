using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Activar_Oferta_Supervisor
    {
        Bloque_Activar_Oferta_Supervisor BAOS = new Bloque_Activar_Oferta_Supervisor();

        public List<Mostrar_Activar_Oferta_SupervisorResult> Logica_Mostrar_Activar_Oferta(int ID_Empresa)
        {
            return BAOS.Mostrar_Activacion_Oferta(ID_Empresa).ToList();
        }

        public int Logica_Actualizar_Activar_Oferta(int ID_Empresa, bool Oferta_1, bool Oferta_2, bool Oferta_3, bool Oferta_4, bool Oferta_5,bool Oferta_6, bool Oferta_7, bool Oferta_8, bool Oferta_9, bool Oferta_10, bool Oferta_11, bool Oferta_12, bool Oferta_13, bool Oferta_14, bool Oferta_15)
        {
            return BAOS.Actualizar_Activar_Oferta(ID_Empresa, Oferta_1, Oferta_2, Oferta_3, Oferta_4, Oferta_5,Oferta_6, Oferta_7, Oferta_8, Oferta_9, Oferta_10, Oferta_11, Oferta_12, Oferta_13, Oferta_14, Oferta_15);
        }


    }
}
