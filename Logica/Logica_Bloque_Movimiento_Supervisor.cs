using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Movimiento_Supervisor
    {
        Bloque_Movimiento_Supervisor BMS = new Bloque_Movimiento_Supervisor();
        public List<Mostrar_Movimiento_SupervisorResult> Logica_Mostrar_Movimientos(string Datos, string Empresa, int Opcion)
        {
            return BMS.Mostrar_Movimientos(Datos, Empresa, Opcion).ToList();
        }

        public int? Logica_Contar_Movimientos(string Datos, string Empresa, int Opcion)
        {
            return BMS.Contar_Movimientos(Datos, Empresa, Opcion);
            
        }

        public List<Seleccionar_Movimiento_SupervisorResult> Logica_Seleccionar_Movimientos(int Identidad)
        {
            return BMS.Seleccionar_Movimientos(Identidad).ToList();
        }

        public int Logica_Borrar_Movimiento(int Identidad)
        {
            return BMS.Borrar_Movimiento(Identidad);
        }
    }
}
