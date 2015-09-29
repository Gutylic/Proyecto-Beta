using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Panel_De_Control_Dios
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public int? Contar_Administradores(string Empresa, string Administrador) // contar los administradores desde el supervisor segun se pida
        {
            db.Contar_Administradores_Dios(Empresa, Administrador, ref Cantidad);
            return Cantidad;
        }

        public List<Mostrar_Administradores_DiosResult> Mostrar_Administradores(string Empresa, string Administrador) // mostrar la lista de administradores de una empresa segun el supervisor
        {
            return db.Mostrar_Administradores_Dios( Administrador , Empresa).ToList();
        }

        public List<Seleccionar_Administradores_DiosResult> Seleccionar_Administradores(int ID_Administrador)
        {
            return db.Seleccionar_Administradores_Dios(ID_Administrador).ToList();
        }

        public int Actualizar_Administradores(int ID_Administrador, string Empresa, string Administrador, string Password, string IP_Address, bool Bloqueo) // actualiza los datos del administrador el supervisor
        {
            return db.Actualizar_Administrador_Dios(ID_Administrador, Empresa, Administrador, Password, IP_Address, Bloqueo);
        }

        public int Insertar_Administradores(string Administrador, string Password, string Empresa) // el supervisor inserta un dato
        {
            return db.Insertar_Administrador_Dios(Administrador, Password, Empresa);
        }

        public int Borrar_Administradores(int ID_Administrador) // borra el supervisor los datos
        {
            return db.Borrar_Administrador_Dios(ID_Administrador);
        }

    }
}
