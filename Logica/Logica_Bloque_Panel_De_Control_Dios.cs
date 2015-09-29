using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Panel_De_Control_Dios
    {

        Bloque_Panel_De_Control_Dios BPDCD = new Bloque_Panel_De_Control_Dios();

        public int? Logica_Contar_Administradores(string Empresa, string Administrador) // contar los administradores desde el supervisor segun se pida
        {
            return BPDCD.Contar_Administradores(Empresa, Administrador);
        }

        public List<Mostrar_Administradores_DiosResult> Logica_Mostrar_Administradores(string Empresa, string Administrador) // mostrar la lista de administradores de una empresa segun el supervisor
        {
            return BPDCD.Mostrar_Administradores(Empresa, Administrador).ToList();
        }

        public List<Seleccionar_Administradores_DiosResult> Logica_Seleccionar_Administradores(int ID_Administrador)
        {
            return BPDCD.Seleccionar_Administradores(ID_Administrador).ToList();
        }
        public int Logica_Actualizar_Administradores(int ID_Administrador, string Empresa, string Administrador, string Password, string IP_Address, bool Bloqueo) // actualiza los datos del administrador el supervisor
        {
            return BPDCD.Actualizar_Administradores(ID_Administrador, Empresa, Administrador, Password, IP_Address, Bloqueo);
        }

        public int Logica_Insertar_Administradores(string Administrador, string Password, string Empresa) // el supervisor inserta un dato
        {
            return BPDCD.Insertar_Administradores(Administrador, Password, Empresa);
        }

        public int Logica_Borrar_Administradores(int ID_Administrador) // borra el supervisor los datos
        {
            return BPDCD.Borrar_Administradores(ID_Administrador);
        }

    }
}

