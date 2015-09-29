using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Empresas_Dios
    {

        Bloque_Empresas_Dios BED = new Bloque_Empresas_Dios();
        
        public List<Mostrar_Empresas_DiosResult> Logica_Mostrar_Empresa()
        {
            return BED.Mostrar_Empresa().ToList();
        }

        public List<Seleccionar_Empresas_DiosResult> Logica_Seleccionar_Empresa(int Identidad)
        {
            return BED.Seleccionar_Empresa(Identidad).ToList();
        }

        public int? Logica_Contar_Empresa()
        {
            return BED.Contar_Empresa();
        }

        public int Logica_Borrar_Empresa(int Identidad)
        {
            return BED.Borrar_Empresa(Identidad);
        }

        public int Logica_Insertar_Empresa(string Empresa, int Cantidad_De_Consultas_Ejercicios, int Cantidad_De_Consultas_Videos)
        {
            return BED.Insertar_Empresa(Empresa,Cantidad_De_Consultas_Ejercicios, Cantidad_De_Consultas_Videos);
        }


    }
}
