using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Pedido_Ejercicio_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;


        public List<Mostrar_Ejercicio_Pedido_DiosResult> Mostrar_Ejercicio()
        {
            return db.Mostrar_Ejercicio_Pedido_Dios().ToList();
        }

        public List<Seleccionar_Ejercicio_Pedido_DiosResult> Seleccionar_Ejercicicio(int Identidad)
        {
            return db.Seleccionar_Ejercicio_Pedido_Dios(Identidad).ToList();
        }

        public int? Contar_Cantidad_Ejercicios()
        {
            db.Contar_Ejercicio_Pedido_Dios( ref Cantidad);
            return Cantidad;

        }

       
        public int Borrar_Ejercicico(int Identidad)
        {
            return db.Borrar_Ejercicio_Pedido_Dios(Identidad);
        }
    }
}
