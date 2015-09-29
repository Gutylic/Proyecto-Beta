using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Comprar_Videos_Supervisor
    {
        Bloque_Comprar_Videos_Supervisor BCVS = new Bloque_Comprar_Videos_Supervisor();
        public List<Mostrar_Videos_SupervisorResult> Logica_Mostrar_Videos(string Datos, int Opcion, string Empresa)
        {
            return BCVS.Mostrar_Videos(Datos, Opcion, Empresa).ToList();

        }
        public int? Logica_Contar_Videos(string Datos, int Opcion, string Empresa)
        {
            return BCVS.Contar_Video(Datos, Opcion, Empresa);

        }

        public List<Seleccionar_Video_SupervisorResult> Logica_Seleccionar_Videos(int Identificador)
        {
            return BCVS.Seleccionar_Video(Identificador).ToList();
        }

        public int Logica_Actualizar_Videos(int Identificador, int Dias_Que_Restan_Para_Usar_El_Producto)
        {
            return BCVS.Actualizar_Video(Identificador, Dias_Que_Restan_Para_Usar_El_Producto);
        }

        public int Logica_Borrar_Vdeos(int Identificador)
        {
            return BCVS.Borrar_Videos(Identificador);
        }

        public int Logica_Insertar_Video(string Usuario, int ID_Ejercicio, int Dias_Que_Restan_Para_El_Producto)
        {
            return BCVS.Insertar_Video(Usuario, ID_Ejercicio, Dias_Que_Restan_Para_El_Producto);
        }
    }
}
