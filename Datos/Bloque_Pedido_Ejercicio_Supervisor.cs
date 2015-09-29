using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Pedido_Ejercicio_Supervisor
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;


        public List<Mostrar_Ejercicio_Pedido_SupervisorResult> Mostrar_Ejercicio(string Empresa)
        {
            return db.Mostrar_Ejercicio_Pedido_Supervisor(Empresa).ToList();
        }

        public List<Seleccionar_Ejercicio_Pedido_SupervisorResult> Seleccionar_Ejercicicio(int Identidad)
        {
            return db.Seleccionar_Ejercicio_Pedido_Supervisor(Identidad).ToList();
        }

        public int? Contar_Cantidad_Ejercicios(string Empresa)
        {
            db.Contar_Ejercicio_Pedido_Supervisor(Empresa, ref Cantidad);
            return Cantidad;

        }

        public int Actualizar_Ejercicio(string Administrador, bool Realizado, int Identidad)
        {
            return db.Actualizar_Ejercicio_Pedido_Supervisor(Administrador, Realizado, Identidad);
        }

        public int Borrar_Ejercicico(int Identidad)
        {
            return db.Borrar_Ejercicio_Pedido_Supervisor(Identidad);
        }
    }
}
