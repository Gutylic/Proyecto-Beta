using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Respuesta
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Buscar_Respuestas_Ejercicios_SupervisoresResult> Buscar_Respuestas_Ejercicios(int ID_Ejercicio, string Administrador, int ID_Empresa)
        {
            return db.Buscar_Respuestas_Ejercicios_Supervisores(ID_Ejercicio, Administrador, ID_Empresa).ToList();        
        }

        public List<Vista_Buscar_Videos> Buscar_Respuestas_Videos(string Enunciado_1,string Enunciado_2,string Enunciado_3,string Enunciado_4,string Enunciado_5,string Enunciado_6,string Enunciado_7,string Enunciado_8,string Enunciado_9,string Enunciado_10, string Administrador, int ID_Empresa)
        {
            return db.Buscar_Respuestas_Videos_Supervisores(Enunciado_1, Enunciado_2, Enunciado_3, Enunciado_4, Enunciado_5, Enunciado_6, Enunciado_7, Enunciado_8, Enunciado_9, Enunciado_10, Administrador, ID_Empresa).ToList();
        }

        public int? Contar_La_Cantidad_De_Videos(string Enunciado_1,string Enunciado_2,string Enunciado_3,string Enunciado_4,string Enunciado_5,string Enunciado_6,string Enunciado_7,string Enunciado_8,string Enunciado_9,string Enunciado_10)
        {
            db.Contar_Respuestas_Videos_Supervisores(Enunciado_1, Enunciado_2, Enunciado_3, Enunciado_4, Enunciado_5, Enunciado_6, Enunciado_7, Enunciado_8, Enunciado_9, Enunciado_10,ref Cantidad);
            return Cantidad;
        }
   }
}
