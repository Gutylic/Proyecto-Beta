using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comentario_Usuario_Supervisor
    {
        Bloque_Comentario_Usuario_Supervisor BCUS = new Bloque_Comentario_Usuario_Supervisor();
        public List<Mostrar_Comentarios_De_Usuario_SupervisorResult> Logica_Mostra_Comentarios(int ID_Empresa)
        {
            return BCUS.Mostra_Comentarios(ID_Empresa).ToList();

        }

        public int? Logica_Contar_Comentarios(int ID_Empresa)
        {
            return BCUS.Contar_Comentarios(ID_Empresa);
        }

        public List<Seleccionar_Comentarios_De_Usuario_SupervisorResult> Logica_Seleccionar_Comentarios(int Identidad)
        {
            return BCUS.Seleccionar_Comentarios(Identidad).ToList();
        }

        public int Logica_Borrar_Comentario(int Identidad)
        {
            return BCUS.Borrar_Comentario(Identidad);
        }
    }
}
