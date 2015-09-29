using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comprar_Ejercicios_Supervisor
    {

        Bloque_Comprar_Ejercicios_Supervisor BCES = new Bloque_Comprar_Ejercicios_Supervisor();
        public List<Mostrar_Ejercicios_SupervisorResult> Logica_Mostrar_Ejercicios(string Datos, int Opcion, string Empresa)
        {
            return BCES.Mostrar_Ejercicios(Datos, Opcion, Empresa).ToList();

        }
        public int? Logica_Contar_Ejercicios(string Datos, int Opcion, string Empresa)
        {
            return BCES.Contar_Ejercicios(Datos, Opcion, Empresa);
           
        }

        public List<Vista_Mis_Ejercicios> Logica_Seleccionar_Ejercicio(int Identificador)
        {
            return BCES.Seleccionar_Ejercicio(Identificador).ToList();
        }

        public int Logica_Actualizar_Ejercicio(int Identificador, int Dias_Que_Restan_Para_Usar_El_Producto)
        {
            return BCES.Actualizar_Ejercicios(Identificador, Dias_Que_Restan_Para_Usar_El_Producto);
        }

        public int Logica_Borrar_Ejercicio(int Identificador)
        {
            return BCES.Borrar_Ejercicios(Identificador);
        }

        public int Logica_Insertar_Ejercicio(string Usuario, int ID_Ejercicio, bool Ejercicio, bool Explicacion, int Dias_Que_Restan_Para_El_Producto)
        {
            return BCES.Insertar_Ejercicio(Usuario, ID_Ejercicio, Ejercicio, Explicacion, Dias_Que_Restan_Para_El_Producto);
        }
    }
}
