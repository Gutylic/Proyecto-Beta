using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Pedido_Explicacion_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;


        public List<Mostrar_Explicacion_Pedida_SupervisorResult> Mostrar_Explicacion(string Empresa)
        {
            return db.Mostrar_Explicacion_Pedida_Supervisor(Empresa).ToList();
        }

        public List<Seleccionar_Explicacion_Pedida_SupervisorResult> Seleccionar_Explicacion(int Identidad)
        {
            return db.Seleccionar_Explicacion_Pedida_Supervisor(Identidad).ToList();
        }

        public int? Contar_Cantidad_Explicacion(string Empresa)
        {
            db.Contar_Explicacion_Pedida_Supervisor(Empresa, ref Cantidad);
            return Cantidad;

        }

        public int Actualizar_Explicacion(string Administrador, bool Realizado, int Identidad)
        {
            return db.Actualizar_Explicacion_Pedida_Supervisor(Administrador, Realizado, Identidad);
        }

        public int Borrar_Explicacion(int Identidad)
        {
            return db.Borrar_Explicacion_Pedida_Supervisor(Identidad);
        }
    }
}
