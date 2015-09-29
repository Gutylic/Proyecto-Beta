using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Cargar_Oferta_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public List<Mostrar_Cargar_Ofertas_AdministradorResult> Mostrar_Cargar_Oferta(int ID_Empresa)
        {
            return db.Mostrar_Cargar_Ofertas_Administrador(ID_Empresa).ToList();
        }

    }
}
