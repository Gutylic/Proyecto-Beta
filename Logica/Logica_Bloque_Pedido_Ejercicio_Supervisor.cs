using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Pedido_Ejercicio_Supervisor
    {
        Bloque_Pedido_Ejercicio_Supervisor BPES = new Bloque_Pedido_Ejercicio_Supervisor();

        public List<Mostrar_Ejercicio_Pedido_SupervisorResult> Logica_Mostrar_Ejercicio(string Empresa)
        {
            return BPES.Mostrar_Ejercicio(Empresa).ToList();
        }

        public List<Seleccionar_Ejercicio_Pedido_SupervisorResult> Logcia_Seleccionar_Ejercicicio(int Identidad)
        {
            return BPES.Seleccionar_Ejercicicio(Identidad).ToList();
        }

        public int? Logica_Contar_Cantidad_Ejercicios(string Empresa)
        {
            return BPES.Contar_Cantidad_Ejercicios(Empresa);
        }

        public int Logica_Actualizar_Ejercicio(string Administrador, bool Realizado, int Identidad)
        {
            return BPES.Actualizar_Ejercicio(Administrador, Realizado, Identidad);
        }

        public int Logica_Borrar_Ejercicico(int Identidad)
        {
            return BPES.Borrar_Ejercicico(Identidad);
        }
    }
}
