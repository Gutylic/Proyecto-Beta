using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Carga_Manual_Credito_Supervisor
    {
        Bloque_Carga_Manual_Credito_Supervisor BCMCS = new Bloque_Carga_Manual_Credito_Supervisor();
      
        public List<Mostrar_Carga_De_Credito_SupervisorResult> Logica_Mostrar_Carga_Credito_Supervisor(string Datos, int Opcion, string Empresa)
        {
            return BCMCS.Mostrar_Carga_Credito_Manual(Datos, Opcion, Empresa).ToList();
        }

        public int? Logica_Contar_Carga_Credito_Supervisor(string Datos, int Opcion, string Empresa)
        {
            return BCMCS.Contar_Carga_Credito_Supervisor(Datos, Opcion, Empresa);
        }

        public List<Seleccionar_Carga_De_Credito_SupervisorResult> Logica_Seleccionar_Carga_Credito_Manual(int Identificador)
        {
            return BCMCS.Seleccionar_Carga_Credito_Manual(Identificador).ToList();
        }

        public int Logica_Actualizar_Carga_Credito_Supervisor(int ID_Usuario, decimal Plata, int Descripcion, string IP_Address)
        {
            return BCMCS.Actualizar_Carga_Credito_Supervisor(ID_Usuario, Plata, Descripcion, IP_Address);
        }
    }
}
