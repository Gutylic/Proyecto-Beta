using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comentario_Usuario_Administrador
    {

        Bloque_Comentario_Usuario_Administrador BCUA = new Bloque_Comentario_Usuario_Administrador();
        public List<Mostrar_Comentarios_De_Usuario_AdministradorResult> Logica_Mostra_Comentarios(int ID_Empresa)
        {
            return BCUA.Mostra_Comentarios(ID_Empresa).ToList();

        }

        public int? Logica_Contar_Comentarios(int ID_Empresa)
        {
            return BCUA.Contar_Comentarios(ID_Empresa);
        }

        public List<Seleccionar_Comentarios_De_Usuario_AdministradorResult> Logica_Seleccionar_Comentarios(int Identidad)
        {
            return BCUA.Seleccionar_Comentarios(Identidad).ToList();
        }

    }
}
