using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comentario_Administrador_Supervisor
    {
        
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Comentarios_Administrador_SupervisorResult> Comentario_Administradores(int ID_Empresa) // muestra los comentarios al supervisor
        {
            return db.Mostrar_Comentarios_Administrador_Supervisor(ID_Empresa).ToList();
        }
        public int? Contar_Comentarios(int ID_Empresa) // selecciona un comentario el supervisor o dios
        {
            db.Contar_Comentarios_Administrador_Supervisor(ID_Empresa,ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Comentario_Administrador_SupervisorResult> Seleccionar_Comentario(int ID_Comentario) // borra el comentario el supervisor o dios
        {
            return db.Seleccionar_Comentario_Administrador_Supervisor(ID_Comentario).ToList();
        }

        public int Borrar_Comentario(int ID_Comentario) // cuenta los comentarios realizados para dios y utilizado para el paginado
        {
            return db.Borrar_Comentario_Administrador_Supervisor(ID_Comentario);
        }
    }
}
