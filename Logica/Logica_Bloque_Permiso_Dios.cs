using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Permiso_Dios
    {
        Bloque_Permiso_Dios BPD = new Bloque_Permiso_Dios();

        public int Logica_Insertar_Permisos_Dios(string Administrador)
        {
            return BPD.Insertar_Permisos_Dios(Administrador);
        }
    }
}
