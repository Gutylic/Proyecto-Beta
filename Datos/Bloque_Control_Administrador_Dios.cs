using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Control_Administrador_Dios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Control_Administradores_DiosResult> Control_Administradores(string Administrador, string Empresa)
        {
            return db.Mostrar_Control_Administradores_Dios(Administrador, Empresa).ToList();
        }

        public int? Contar_Control_Administradores(string Administrador, string Empresa)
        {
            db.Contar_Control_Administradores_Dios(Administrador, Empresa, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Control_Administrador_DiosResult> Seleccionar_Control_Administradores(int ID_Ingreso_Egreso)
        {
            return db.Seleccionar_Control_Administrador_Dios(ID_Ingreso_Egreso).ToList();

        }
        public int Borrar_Control_Administrador(int ID_Ingreso_Egreso)
        {
            return db.Borrar_Control_Administrador_Dios(ID_Ingreso_Egreso);
        }
    }
}
