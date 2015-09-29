using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Movimiento_Dios
    {

        Bloque_Movimiento_Dios BMD = new Bloque_Movimiento_Dios();
        public List<Mostrar_Movimiento_DiosResult> Logica_Mostrar_Movimientos(string Datos, int Opcion)
        {
            return BMD.Mostrar_Movimientos(Datos, Opcion).ToList();
        }

        public int? Logica_Contar_Movimientos(string Datos, int Opcion)
        {
            return BMD.Contar_Movimientos(Datos, Opcion);

        }

        public List<Seleccionar_Movimiento_DiosResult> Logica_Seleccionar_Movimientos(int Identidad)
        {
            return BMD.Seleccionar_Movimientos(Identidad).ToList();
        }

        public int Logica_Borrar_Movimiento(int Identidad)
        {
            return BMD.Borrar_Movimiento(Identidad);
        }
    }
}
