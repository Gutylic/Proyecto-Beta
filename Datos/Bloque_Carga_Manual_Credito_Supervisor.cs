using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Carga_Manual_Credito_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Carga_De_Credito_SupervisorResult> Mostrar_Carga_Credito_Manual(string Datos, int Opcion, string Empresa)
        {
           return db.Mostrar_Carga_De_Credito_Supervisor(Datos, Opcion, Empresa).ToList();
        }

        public int? Contar_Carga_Credito_Supervisor(string Datos,int Opcion,string Empresa)
        {
            db.Contar_Carga_De_Credito_Supervisor(Datos, Opcion, Empresa,ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Carga_De_Credito_SupervisorResult> Seleccionar_Carga_Credito_Manual(int Identificador)
        {
            return db.Seleccionar_Carga_De_Credito_Supervisor(Identificador).ToList();
        }

        public int Actualizar_Carga_Credito_Supervisor(int ID_Usuario, decimal Plata, int Descripcion, string IP_Address )
        {
            return db.Actualizar_Carga_De_Credito_Supervisor(ID_Usuario, Plata, Descripcion, IP_Address);
        }

    }
}
