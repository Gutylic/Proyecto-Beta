using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Permisos_Supervisor
    {
        Bloque_Permisos_Supervisor BPS = new Bloque_Permisos_Supervisor();

        public int Logica_Existencia_Del_Administrador(string Administrador, int ID_Empresa)
        {
            return BPS.Existencia_Del_Administrador(Administrador,ID_Empresa);
        }

        public List<Vista_Categoria> Logica_Mostrar_Administrador(string Administrador, int ID_Empresa)
        {
            return BPS.Mostrar_Administrador(Administrador, ID_Empresa).ToList();
        }

        public int Logica_Actualizar_Categoria_De_Administradores(string Administrador, int ID_Empresa, int A1, int A2, int A3, int B1, int B2, int B3, int C1, int D1, int D2, int E1, int E2, int E3, int F1, int F2, int F3, int G1, int G2, int G3)
        {
            return BPS.Actualizar_Categoria_De_Administradores(Administrador, ID_Empresa, A1, A2, A3, B1, B2, B3, C1, D1, D2, E1, E2, E3, F1, F2, F3, G1, G2, G3);
        }
    }
}
