using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Permiso_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public int Insertar_Permisos_Dios(string Administrador) 
        {
            return db.Permisos_Dios(Administrador);
        }
    }

}
