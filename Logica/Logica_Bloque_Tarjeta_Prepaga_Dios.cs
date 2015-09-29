using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Tarjeta_Prepaga_Dios
    {

        Bloque_Tarjeta_Prepaga_Dios BTPD = new Bloque_Tarjeta_Prepaga_Dios();

        public List<Mostrar_Tarjeta_Prepaga_DiosResult> Logica_Mostrar_Tarjetas_Prepagas(string Datos, int Opcion)
        {
            return BTPD.Mostrar_Tarjetas_Prepagas(Datos, Opcion).ToList();
        }

        public int? Logica_Contar_Tarjetas_Prepagas(string Datos, int Opcion)
        {
            return BTPD.Contar_Tarjetas_Prepagas(Datos, Opcion);
           
        }

        public List<Seleccionar_Tarjeta_Prepaga_DiosResult> Logica_Seleccionar_Tarjetas_Prepagas(int Identificador)
        {
            return BTPD.Seleccionar_Tarjetas_Prepagas(Identificador).ToList();
        }

       
        public int Logica_Borrar_Tarjeta_Prepaga(int ID_Tarjeta)
        {
            return BTPD.Borrar_Tarjeta_Prepaga(ID_Tarjeta);
        }


    }
}

