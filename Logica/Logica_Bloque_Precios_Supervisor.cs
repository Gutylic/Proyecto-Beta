using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Precios_Supervisor
    {
        Bloque_Precios_Supervisor BPS = new Bloque_Precios_Supervisor();

        public List<Mostrar_Precios_SupervisorResult> Logica_Mostrar_Precios(int ID_Empresa)
        {
            return BPS.Mostrar_Precios(ID_Empresa).ToList();
        }

        public int? Logica_Actualizar_Precios(int ID_Empresa,decimal Valor_Ejercicio,decimal Valor_Explicacion,decimal Valor_Video ,decimal Valor_Conjunto_De_Videos, decimal Valor_Explicacion_Personalizada, decimal Valor_Video_Personalizado, decimal Valor_Ejercicio_Personalizado, decimal Valor_Impresion, decimal Valor_Prestamo_SOS, int Duracion_De_Los_Videos,int Duracion_De_Ejercicios_Y_Explicaciones)
        {
            return BPS.Actualizar_Precios(ID_Empresa, Valor_Ejercicio, Valor_Explicacion, Valor_Video, Valor_Conjunto_De_Videos, Valor_Explicacion_Personalizada, Valor_Video_Personalizado, Valor_Ejercicio_Personalizado, Valor_Impresion, Valor_Prestamo_SOS, Duracion_De_Los_Videos, Duracion_De_Ejercicios_Y_Explicaciones);
        }
        public List<Seleccionar_Precios_SupervisorResult> Logica_Seleccionar_Precios(int Identificador)
        {
            return BPS.Seleccionar_Precios(Identificador).ToList();
        }
    }
}
