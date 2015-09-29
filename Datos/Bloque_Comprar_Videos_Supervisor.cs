using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Comprar_Videos_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Videos_SupervisorResult> Mostrar_Videos(string Datos, int Opcion, string Empresa)
        {
            return db.Mostrar_Videos_Supervisor(Datos, Opcion, Empresa).ToList();
        }

        public List<Seleccionar_Video_SupervisorResult> Seleccionar_Video(int Identificador)
        {
            return db.Seleccionar_Video_Supervisor(Identificador).ToList();
        }

        public int? Contar_Video(string Datos, int Opcion, string Empresa)
        {
            db.Contar_Videos_Supervisor(Datos, Opcion, Empresa, ref Cantidad);
            return Cantidad;
        }

        public int Actualizar_Video(int Identificador, int Dias_Que_Restan_Para_El_Producto)
        {
            return db.Actualizar_Video_Supervisor(Identificador, Dias_Que_Restan_Para_El_Producto);
        }

        public int Borrar_Videos(int Identificador)
        {
            return db.Borrar_Video_Supervisor(Identificador);
        }

        public int Insertar_Video(string Usuario, int ID_Ejercicio, int Dias_Que_Restan_Para_El_Producto)
        {
            return db.Insertar_Videos_Supervisor(Usuario, ID_Ejercicio, Dias_Que_Restan_Para_El_Producto);
        }
    }
}
