using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Respuesta
    {
        Bloque_Respuesta BR = new Bloque_Respuesta();
        
        public List<Buscar_Respuestas_Ejercicios_SupervisoresResult> Logica_Buscar_Respuestas_Ejercicios(int ID_Ejercicio, string Administrador, int ID_Empresa)
        {
            return BR.Buscar_Respuestas_Ejercicios(ID_Ejercicio, Administrador, ID_Empresa).ToList();
        }

        public List<Vista_Buscar_Videos>Logica_Buscar_Respuestas_Videos(string Enunciado_1,string Enunciado_2,string Enunciado_3,string Enunciado_4,string Enunciado_5,string Enunciado_6,string Enunciado_7,string Enunciado_8,string Enunciado_9,string Enunciado_10, string Administrador, int ID_Empresa)
        {
            return BR.Buscar_Respuestas_Videos(Enunciado_1, Enunciado_2, Enunciado_3, Enunciado_4, Enunciado_5, Enunciado_6, Enunciado_7, Enunciado_8, Enunciado_9, Enunciado_10, Administrador, ID_Empresa).ToList();
        }
        public int? Logica_Contar_La_Cantidad_De_Videos(string Enunciado_1, string Enunciado_2, string Enunciado_3, string Enunciado_4, string Enunciado_5, string Enunciado_6, string Enunciado_7, string Enunciado_8, string Enunciado_9, string Enunciado_10)
        {
            return BR.Contar_La_Cantidad_De_Videos(Enunciado_1, Enunciado_2, Enunciado_3, Enunciado_4, Enunciado_5, Enunciado_6, Enunciado_7, Enunciado_8, Enunciado_9, Enunciado_10);
           
        }
    }
}
