using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comprar_Ejercicios_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Ejercicios_AdministradorResult> Mostrar_Ejercicios(string Usuario)
        {
            return db.Mostrar_Ejercicios_Administrador(Usuario).ToList();
        }
        public int? Contar_Ejercicios(string Usuario)
        {
            db.Contar_Ejercicios_Administrador(Usuario, ref Cantidad);
            return Cantidad;
        }
    }
}
