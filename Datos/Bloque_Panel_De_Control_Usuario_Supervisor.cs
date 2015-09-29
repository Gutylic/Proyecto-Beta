using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Panel_De_Control_Usuario_Supervisor
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Usuario_SupervisorResult> Mostrar_Usuario(string Dato, int ID_Empresa, int Opcion)
        {
            return db.Mostrar_Usuario_Supervisor(Dato, ID_Empresa, Opcion).ToList();
        }

        public int? Contar_Usuarios(string Dato, int ID_Empresa, int Opcion)
        {
            db.Contar_Usuario_Supervisor(Dato, ID_Empresa, Opcion, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Usuario_SupervisorResult> Seleccionar_Usuario(int Identificador)
        {
            return db.Seleccionar_Usuario_Supervisor(Identificador).ToList();
        }

        public int Borrar_Usuario(int Identificador) 
        {
            return db.Borrar_Usuario_Supervisor(Identificador);
        }

        public int Insertar_Usuario(string Usuario, string Correo, int ID_Empresa, string Administrador)
        {
            return db.Insertar_Usuario_Supervisor(Usuario, Correo, ID_Empresa, Administrador);
        }

        public int Actualizar_Usuario(string Comparar_Correo, bool Activacion_Usuario, int Identificador, int ID_Empresa, string Correo, string Usuario_Skype, string Numero_De_Celular, string Modelo_De_Celular,string Usuario)
        {
            return db.Actualizar_Usuario_Supervisor(Comparar_Correo, Activacion_Usuario, Identificador, ID_Empresa, Correo, Usuario_Skype, Numero_De_Celular, Modelo_De_Celular, Usuario);
        }


    }
}
