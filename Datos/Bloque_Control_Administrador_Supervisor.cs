using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Control_Administrador_Supervisor
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Control_Administradores_SupervisorResult> Control_Administradores(string Administrador, int ID_Empresa)
        {
            return db.Mostrar_Control_Administradores_Supervisor(Administrador, ID_Empresa).ToList();
        }

        public int? Contar_Control_Administradores(string Administrador, int ID_Empresa)
        {
            db.Contar_Control_Administradores_Supervisor(Administrador, ID_Empresa, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Control_Administrador_SupervisorResult> Seleccionar_Control_Administradores(int ID_Ingreso_Egreso)
        {
            return db.Seleccionar_Control_Administrador_Supervisor(ID_Ingreso_Egreso).ToList();

        }
        public int Borrar_Control_Administrador(int ID_Ingreso_Egreso)
        {
            return db.Borrar_Control_Administrador_Supervisor(ID_Ingreso_Egreso);
        }

    }
}
