using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comentario_Administrador_Supervisor
    {
        Bloque_Comentario_Administrador_Supervisor BCAS = new Bloque_Comentario_Administrador_Supervisor();

        public List<Mostrar_Comentarios_Administrador_SupervisorResult> Logica_Comentario_Administradores(int ID_Empresa) // muestra los comentarios al supervisor
        {
            return BCAS.Comentario_Administradores(ID_Empresa).ToList();
        }
        public int? Logica_Contar_Comentarios(int ID_Empresa) // selecciona un comentario el supervisor o dios
        {
            return BCAS.Contar_Comentarios(ID_Empresa);                       
        }

        public List<Seleccionar_Comentario_Administrador_SupervisorResult> Logica_Seleccionar_Comentario(int ID_Comentario) // borra el comentario el supervisor o dios
        {
            return BCAS.Seleccionar_Comentario(ID_Comentario).ToList();
        }

        public int Logica_Borrar_Comentario(int ID_Comentario) // cuenta los comentarios realizados para dios y utilizado para el paginado
        {
            return BCAS.Borrar_Comentario(ID_Comentario);
        }



    }
}
