using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comentario_Usuario_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Comentarios_De_Usuario_SupervisorResult> Mostra_Comentarios(int ID_Empresa)
        {
            return db.Mostrar_Comentarios_De_Usuario_Supervisor(ID_Empresa).ToList();

        }

        public int? Contar_Comentarios(int ID_Empresa)
        {
            db.Contar_Comentarios_De_Usuario_Supervisor(ID_Empresa, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Comentarios_De_Usuario_SupervisorResult> Seleccionar_Comentarios(int Identidad)
        {
            return db.Seleccionar_Comentarios_De_Usuario_Supervisor(Identidad).ToList();
        }

        public int Borrar_Comentario(int Identidad)
        {
            return db.Borrar_Comentarios_De_Usuario_Supervisor(Identidad);
        }

    }
}
