using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Pedido_Explicacion_Administrador
    {
        Bloque_Pedido_Explicacion_Administrador BPEA = new Bloque_Pedido_Explicacion_Administrador();

        public List<Mostrar_Explicacion_Pedida_AdministradorResult> Logica_Mostrar_Explicacion(string Empresa)
        {
            return BPEA.Mostrar_Explicacion(Empresa).ToList();
        }

        public List<Seleccionar_Explicacion_Pedida_AdministardorResult> Logcia_Seleccionar_Explicacion(int Identidad)
        {
            return BPEA.Seleccionar_Explicacion(Identidad).ToList();
        }

        public int? Logica_Contar_Cantidad_Explicaciones(string Empresa)
        {
            return BPEA.Contar_Cantidad_Explicaciones(Empresa);
        }

        public int Logica_Actualizar_Explicacion(string Administrador, bool Realizado, int Identidad)
        {
            return BPEA.Actualizar_Explicacion(Administrador, Realizado, Identidad);
        }

    }
}
