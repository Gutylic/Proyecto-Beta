using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Movimiento_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Movimiento_SupervisorResult> Mostrar_Movimientos(string Datos,string Empresa, int Opcion)
        {
            return db.Mostrar_Movimiento_Supervisor(Datos,Empresa, Opcion).ToList();
        }

        public int? Contar_Movimientos(string Datos,string Empresa, int Opcion)
        {
            db.Contar_Movimiento_Supervisor(Datos, Empresa, Opcion, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Movimiento_SupervisorResult> Seleccionar_Movimientos(int Identidad)
        {
            return db.Seleccionar_Movimiento_Supervisor(Identidad).ToList();
        }

        public int Borrar_Movimiento(int Identidad)
        {
            return db.Borrar_Movimiento_Supervisor(Identidad);
        }
    }
}
