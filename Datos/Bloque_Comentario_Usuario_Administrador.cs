using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comentario_Usuario_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Comentarios_De_Usuario_AdministradorResult> Mostra_Comentarios(int ID_Empresa)
        {
            return db.Mostrar_Comentarios_De_Usuario_Administrador(ID_Empresa).ToList();
        
        }

        public int? Contar_Comentarios(int ID_Empresa)
        {
            db.Contar_Comentarios_De_Usuario_Administrador(ID_Empresa, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Comentarios_De_Usuario_AdministradorResult> Seleccionar_Comentarios(int Identidad)
        {
            return db.Seleccionar_Comentarios_De_Usuario_Administrador(Identidad).ToList();
        }


    }
}
