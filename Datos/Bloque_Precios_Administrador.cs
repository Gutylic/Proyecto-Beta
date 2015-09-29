using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Precios_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public List<Mostrar_Precios_AdministradorResult> Mostrar_Precios(int ID_Empresa)
        {
            return db.Mostrar_Precios_Administrador(ID_Empresa).ToList();
        }

    }
}
