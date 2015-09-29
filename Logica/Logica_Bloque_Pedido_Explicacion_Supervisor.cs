using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Pedido_Explicacion_Supervisor
    {
        Bloque_Pedido_Explicacion_Supervisor BPES = new Bloque_Pedido_Explicacion_Supervisor();

        public List<Mostrar_Explicacion_Pedida_SupervisorResult> Logica_Mostrar_Explicacion(string Empresa)
        {
            return BPES.Mostrar_Explicacion(Empresa).ToList();
        }

        public List<Seleccionar_Explicacion_Pedida_SupervisorResult> Logcia_Seleccionar_Explicacion(int Identidad)
        {
            return BPES.Seleccionar_Explicacion(Identidad).ToList();
        }

        public int? Logica_Contar_Cantidad_Explicacion(string Empresa)
        {
            return BPES.Contar_Cantidad_Explicacion(Empresa);
        }

        public int Logica_Actualizar_Explicacion(string Administrador, bool Realizado, int Identidad)
        {
            return BPES.Actualizar_Explicacion(Administrador, Realizado, Identidad);
        }

        public int Logica_Borrar_Explicacion(int Identidad)
        {
            return BPES.Borrar_Explicacion(Identidad);
        }
    }
}
