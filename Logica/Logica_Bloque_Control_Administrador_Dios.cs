using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Control_Administrador_Dios
    {
        Bloque_Control_Administrador_Dios BCAD = new Bloque_Control_Administrador_Dios();

        public List<Mostrar_Control_Administradores_DiosResult> Logica_Control_Administradores(string Administrador, string Empresa)
        {
            return BCAD.Control_Administradores(Administrador, Empresa).ToList();
        }

        public int? Logica_Contar_Control_Administradores(string Administrador, string Empresa)
        {
            return BCAD.Contar_Control_Administradores(Administrador, Empresa);           
        }

        public List<Seleccionar_Control_Administrador_DiosResult> Logica_Seleccionar_Control_Administradores(int ID_Ingreso_Egreso)
        {
            return BCAD.Seleccionar_Control_Administradores(ID_Ingreso_Egreso).ToList();
        }

        public int Logica_Borrar_Control_Administrador(int ID_Ingreso_Egreso)
        {
            return BCAD.Borrar_Control_Administrador(ID_Ingreso_Egreso);
        }


    }
}
