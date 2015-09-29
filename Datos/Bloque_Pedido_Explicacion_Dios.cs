using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Pedido_Explicacion_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;


        public List<Mostrar_Explicacion_Pedida_DiosResult> Mostrar_Explicacion()
        {
            return db.Mostrar_Explicacion_Pedida_Dios().ToList();
        }

        public List<Seleccionar_Explicacion_Pedida_DiosResult> Seleccionar_Explicacion(int Identidad)
        {
            return db.Seleccionar_Explicacion_Pedida_Dios(Identidad).ToList();
        }

        public int? Contar_Cantidad_Explicacion()
        {
            db.Contar_Explicacion_Pedida_Dios(ref Cantidad);
            return Cantidad;

        }


        public int Borrar_Explicacion(int Identidad)
        {
            return db.Borrar_Explicacion_Pedida_Dios(Identidad);
        }
    }
}
