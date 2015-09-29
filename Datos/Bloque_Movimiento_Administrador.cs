using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Movimiento_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Movimiento_AdministradorResult> Mostrar_Movimiento(string Usuario,string Empresa)
        {
            return db.Mostrar_Movimiento_Administrador(Usuario,Empresa).ToList();
        }

        public int? Contar_Movimientos(string Usuario, string Empresa)
        {
            db.Contar_Movimiento_Administrador(Usuario,Empresa, ref Cantidad);
            return Cantidad;
        }
    }
}
