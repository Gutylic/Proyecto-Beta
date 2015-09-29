using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Pedido_Explicacion_Administrador
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;


        public List<Mostrar_Explicacion_Pedida_AdministradorResult> Mostrar_Explicacion(string Empresa)
        {
            return db.Mostrar_Explicacion_Pedida_Administrador(Empresa).ToList();
        }

        public List<Seleccionar_Explicacion_Pedida_AdministardorResult> Seleccionar_Explicacion(int Identidad)
        {
            return db.Seleccionar_Explicacion_Pedida_Administardor(Identidad).ToList();
        }

        public int? Contar_Cantidad_Explicaciones(string Empresa)
        {
            db.Contar_Explicacion_Pedida_Administrador(Empresa, ref Cantidad);
            return Cantidad;

        }

        public int Actualizar_Explicacion(string Administrador, bool Realizado, int Identidad)
        {
            return db.Actualizar_Explicacion_Pedida_Administrador(Administrador, Realizado, Identidad);
        }
    }
}
