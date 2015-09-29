using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Pedido_Ejercicio_Administrador
    {
        Bloque_Pedido_Ejercicio_Administrador BPEA = new Bloque_Pedido_Ejercicio_Administrador();

        public List<Mostrar_Ejercicio_Pedido_AdministradorResult> Logica_Mostrar_Ejercicio(string Empresa)
        {
            return BPEA.Mostrar_Ejercicio(Empresa).ToList();
        }

        public List<Seleccionar_Ejercicio_Pedido_AdministradorResult> Logcia_Seleccionar_Ejercicicio(int Identidad)
        {
            return BPEA.Seleccionar_Ejercicicio(Identidad).ToList();
        }

        public int? Logica_Contar_Cantidad_Ejercicios(string Empresa)
        {
            return BPEA.Contar_Cantidad_Ejercicios(Empresa);
        }

        public int Logica_Actualizar_Ejercicio(string Administrador, bool Realizado, int Identidad)
        {
            return BPEA.Actualizar_Ejercicio(Administrador, Realizado, Identidad);
        }

        
    }
}
