using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Tarjeta_Prepaga_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
       

        public List<Mostrar_Tarjeta_Prepaga_AdministradorResult> Mostrar_Tarjeta_Prepaga(int Codigo, string Empresa)
        {
            return db.Mostrar_Tarjeta_Prepaga_Administrador(Codigo, Empresa).ToList();
        }

        


    }
}
