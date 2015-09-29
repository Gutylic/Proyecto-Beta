using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Activar_Oferta_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public List<Mostrar_Activar_Oferta_AdministracionResult> Mostrar_Activacion_Oferta(int ID_Empresa)
        {
            return db.Mostrar_Activar_Oferta_Administracion(ID_Empresa).ToList();
        }
    }
}
