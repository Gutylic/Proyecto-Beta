using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Consumo_De_La_Empresa
    {
        Bloque_Consumo_De_La_Empresa BCDLE = new Bloque_Consumo_De_La_Empresa();

        public List<Mostrar_Consumo_SupervisoresResult> Logica_Mostrar_Consumo_De_Supervisores(string Dato, int Opcion)
        {
            return BCDLE.Mostrar_Consumo_De_Supervisores(Dato, Opcion).ToList();
        }

        public int? Logica_Contar_Consumo_De_Supervisores(string Dato, int Opcion)
        {
            return BCDLE.Contar_Consumo_De_Supervisores(Dato, Opcion);
            
        }

        public List<Seleccionar_Consumo_SupervisoresResult> Logica_Seleccionar_Consumo_De_Supervisores(int Identificador)
        {
            return BCDLE.Seleccionar_Consumo_De_Supervisores(Identificador).ToList();
        }

        public int Logica_Borrar_Consumo_De_Supervisores(int Identificador)
        {
            return BCDLE.Borrar_Consumo_De_Supervisores(Identificador);
        }
    }
}
