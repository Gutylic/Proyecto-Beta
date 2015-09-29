using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Panel_De_Control_Usuario_Admimistrador
    {

        DataClassesDataContext db = new DataClassesDataContext();

        public List<Mostrar_Usuario_AdministradorResult> Mostrar_Datos(string Dato, int ID_Empresa, int Opciones)
        {
            return db.Mostrar_Usuario_Administrador(Dato, ID_Empresa, Opciones).ToList();
        }
        
    }

}
