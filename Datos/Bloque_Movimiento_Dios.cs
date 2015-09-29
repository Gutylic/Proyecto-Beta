using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Datos
{
    public class Bloque_Movimiento_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Movimiento_DiosResult> Mostrar_Movimientos(string Datos, int Opcion)
        {
            return db.Mostrar_Movimiento_Dios(Datos, Opcion).ToList();
        }

        public int? Contar_Movimientos(string Datos, int Opcion) 
        {
            db.Contar_Movimiento_Dios(Datos, Opcion, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Movimiento_DiosResult> Seleccionar_Movimientos(int Identidad)
        {
            return db.Seleccionar_Movimiento_Dios(Identidad).ToList();
        }

        public int Borrar_Movimiento(int Identidad)
        {
            return db.Borrar_Movimiento_Dios(Identidad);
        }


    }
}
