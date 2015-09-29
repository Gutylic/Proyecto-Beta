using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Panel_De_Control_Usuario_Supervisor
    {
        Bloque_Panel_De_Control_Usuario_Supervisor BPDCUS = new Bloque_Panel_De_Control_Usuario_Supervisor();

        public List<Mostrar_Usuario_SupervisorResult> Logica_Mostrar_Usuario(string Dato, int ID_Empresa, int Opcion)
        {
            return BPDCUS.Mostrar_Usuario(Dato, ID_Empresa, Opcion).ToList();
        }

        public int? Logica_Contar_Usuarios(string Dato, int ID_Empresa, int Opcion)
        {
            return BPDCUS.Contar_Usuarios(Dato, ID_Empresa, Opcion);           
        }

        public List<Seleccionar_Usuario_SupervisorResult> Logica_Seleccionar_Usuario(int Identificador)
        {
            return BPDCUS.Seleccionar_Usuario(Identificador).ToList();
        }

        public int Logica_Borrar_Usuario(int Identificador)
        {
            return BPDCUS.Borrar_Usuario(Identificador);
        }

        public int Logica_Insertar_Usuario(string Usuario, string Correo, int ID_Empresa, string Administrador)
        {
            return BPDCUS.Insertar_Usuario(Usuario, Correo, ID_Empresa, Administrador);
        }

        public int Logica_Actualizar_Usuario(string Comparar_Correo, bool Activacion_Usuario, int Identificador, int ID_Empresa, string Correo, string Usuario_Skype, string Numero_De_Celular, string Modelo_De_Celular,string Usuario)
        {
            return BPDCUS.Actualizar_Usuario(Comparar_Correo, Activacion_Usuario, Identificador, ID_Empresa, Correo, Usuario_Skype, Numero_De_Celular, Modelo_De_Celular, Usuario);
        }

    }
}
