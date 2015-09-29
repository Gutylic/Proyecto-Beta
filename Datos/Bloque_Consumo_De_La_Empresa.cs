using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Consumo_De_La_Empresa
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Consumo_SupervisoresResult> Mostrar_Consumo_De_Supervisores(string Dato, int Opcion)
        {
            return db.Mostrar_Consumo_Supervisores(Dato, Opcion).ToList();
        }

        public int? Contar_Consumo_De_Supervisores(string Dato, int Opcion)
        {
            db.Contar_Consumo_Supervisores(Dato, Opcion, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Consumo_SupervisoresResult> Seleccionar_Consumo_De_Supervisores(int Identificador)
        {
            return db.Seleccionar_Consumo_Supervisores(Identificador).ToList();
        }

        public int Borrar_Consumo_De_Supervisores(int Identificador)
        {
            return db.Borrar_Consumo_Supervisores(Identificador);
        }

    }
}
