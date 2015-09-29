using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comprar_Ejercicios_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Ejercicios_SupervisorResult> Mostrar_Ejercicios(string Datos, int Opcion, string Empresa)
        {
            return db.Mostrar_Ejercicios_Supervisor(Datos, Opcion, Empresa).ToList();
        }

        public List<Vista_Mis_Ejercicios> Seleccionar_Ejercicio(int Identificador)
        {
            return db.Seleccionar_Ejercicio_Supervisor(Identificador).ToList();
        }

        public int? Contar_Ejercicios(string Datos, int Opcion, string Empresa)
        {
            db.Contar_Ejercicios_Supervisor(Datos, Opcion, Empresa, ref Cantidad);
            return Cantidad;
        }

        public int Actualizar_Ejercicios(int Identificador, int Dias_Que_Restan_Para_El_Producto)
        {
            return db.Actualizar_Ejercicio_Supervisor(Identificador, Dias_Que_Restan_Para_El_Producto);
        }

        public int Borrar_Ejercicios(int Identificador)
        {
            return db.Borrar_Ejercicio_Supervisor(Identificador);
        }

        public int Insertar_Ejercicio(string Usuario, int ID_Ejercicio, bool Ejercicio, bool Explicacion, int Dias_Que_Restan_Para_El_Producto)
        {
            return db.Insertar_Ejercicio_Supervisor(Usuario, ID_Ejercicio, Ejercicio, Explicacion, Dias_Que_Restan_Para_El_Producto);
        }

    }

    
}
