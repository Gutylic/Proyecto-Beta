using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Panel_De_Control_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Datos_AdministradorResult> Lista_Datos_Del_Administrador(string Administrador) // buscar los datos del administrador
        {
            return db.Datos_Administrador(Administrador).ToList();
        }

        public int Actualizar_Perfil_Administrador(string Administrador, string Password) // actualizar el administrador desde el mismo administrador
        {
            return db.Actualizar_Administrador(Administrador, Password);
        }

    }
}
