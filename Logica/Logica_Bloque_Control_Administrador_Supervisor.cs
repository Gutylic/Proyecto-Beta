using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Control_Administrador_Supervisor
    {
        Bloque_Control_Administrador_Supervisor BCAS = new Bloque_Control_Administrador_Supervisor();

        public List<Mostrar_Control_Administradores_SupervisorResult> Logica_Control_Administradores(string Administrador, int Empresa)
        {
            return BCAS.Control_Administradores(Administrador, Empresa).ToList();
        }

        public int? Logica_Contar_Control_Administradores(string Administrador, int Empresa)
        {
            return BCAS.Contar_Control_Administradores(Administrador, Empresa);
        }

        public List<Seleccionar_Control_Administrador_SupervisorResult> Logica_Seleccionar_Control_Administradores(int ID_Ingreso_Egreso)
        {
            return BCAS.Seleccionar_Control_Administradores(ID_Ingreso_Egreso).ToList();
        }

        public int Logica_Borrar_Control_Administrador(int ID_Ingreso_Egreso)
        {
            return BCAS.Borrar_Control_Administrador(ID_Ingreso_Egreso);
        }

    }
}
