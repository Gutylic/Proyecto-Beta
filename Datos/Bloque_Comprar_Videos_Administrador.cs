using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comprar_Videos_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Videos_AdministradorResult> Mostrar_Videos(string Usuario)
        {
            return db.Mostrar_Videos_Administrador(Usuario).ToList();
        }
        public int? Contar_Videos(string Usuario)
        {
            db.Contar_Videos_Administrador(Usuario, ref Cantidad);
            return Cantidad;
        }
    }
}
