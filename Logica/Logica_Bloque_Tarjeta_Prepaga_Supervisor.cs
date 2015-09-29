using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Tarjeta_Prepaga_Supervisor
    {
        Bloque_Tarjeta_Prepaga_Supervisor BTPS = new Bloque_Tarjeta_Prepaga_Supervisor();

        public List<Mostrar_Tarjeta_Prepaga_SupervisorResult> Logica_Mostrar_Tarjetas_Prepagas(string Datos, string Empresa, int Opcion)
        {
            return BTPS.Mostrar_Tarjetas_Prepagas(Datos, Empresa, Opcion).ToList();
        }

        public int? Logica_Contar_Tarjetas_Prepagas(string Datos, string Empresa, int Opcion)
        {
            return BTPS.Contar_Tarjetas_Prepagas(Datos, Empresa, Opcion);
           
        }

        public List<Seleccionar_Tarjeta_Prepaga_SupervisorResult> Logica_Seleccionar_Tarjetas_Prepagas(int Identificador)
        {
            return BTPS.Seleccionar_Tarjetas_Prepagas(Identificador).ToList();
        }

        public int Logica_Insetar_Tarjeta_Prepaga(int Cantidad_De_Tarjetas, DateTime Fecha_De_Vencimiento, int ID_Empresa, decimal Credito)
        {
            return BTPS.Insetar_Tarjeta_Prepaga(Cantidad_De_Tarjetas, Fecha_De_Vencimiento, ID_Empresa, Credito);
        }

        public int Logica_Actualizar_Tarjeta_Prepaga(int ID_Tarjeta, DateTime Fecha_De_Vencimiento, bool Activacion_De_La_Tarjeta)
        {
            return BTPS.Actualizar_Tarjeta_Prepaga(ID_Tarjeta, Fecha_De_Vencimiento, Activacion_De_La_Tarjeta);
        }

        public int Logica_Borrar_Tarjeta_Prepaga(int ID_Tarjeta)
        {
            return BTPS.Borrar_Tarjeta_Prepaga(ID_Tarjeta);
        }


    }
}
