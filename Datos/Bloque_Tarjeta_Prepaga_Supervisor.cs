using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Tarjeta_Prepaga_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Tarjeta_Prepaga_SupervisorResult> Mostrar_Tarjetas_Prepagas(string Datos, string Empresa, int Opcion)
        {
            return db.Mostrar_Tarjeta_Prepaga_Supervisor(Datos, Empresa, Opcion).ToList();
        }

        public int? Contar_Tarjetas_Prepagas(string Datos, string Empresa, int Opcion)
        {
            db.Contar_Tarjeta_Prepaga_Supervisor(Datos, Empresa, Opcion, ref Cantidad);
            return Cantidad;
        }

        public List<Seleccionar_Tarjeta_Prepaga_SupervisorResult> Seleccionar_Tarjetas_Prepagas(int Identificador)
        {
            return db.Seleccionar_Tarjeta_Prepaga_Supervisor(Identificador).ToList();
        }

        public int Insetar_Tarjeta_Prepaga(int Cantidad_De_Tarjetas, DateTime Fecha_De_Vencimiento, int ID_Empresa, decimal Credito)
        {

            Tabla_De_Tarjetas_Prepagas Tarjeta = new Tabla_De_Tarjetas_Prepagas();
            bool Resultado;

            for (int I = 1; I <= Cantidad_De_Tarjetas; I++)
            {
                do
                {
                    Random Numero_De_Tarjeta = new Random();
                    int Numero = Numero_De_Tarjeta.Next(1000000, 999999999);

                    Resultado = db.Tabla_De_Tarjetas_Prepagas.Any(p => p.Codigo == Numero);
                    if (!Resultado)
                    {
                        db.Insertar_Tarjeta_Prepaga_Supervisor(Numero, Fecha_De_Vencimiento, ID_Empresa, Credito);
                    }

                } while (Resultado);

            }
            return 1;
            
        }

        public int Actualizar_Tarjeta_Prepaga(int ID_Tarjeta, DateTime Fecha_De_Vencimiento, bool Activacion_De_La_Tarjeta)
        {
            return db.Actualizar_Tarjeta_Prepaga_Supervisor(ID_Tarjeta, Fecha_De_Vencimiento, Activacion_De_La_Tarjeta);
        }

        public int Borrar_Tarjeta_Prepaga(int ID_Tarjeta)
        {
            return db.Borrar_Tarjeta_Prepaga_Supervisor(ID_Tarjeta);
        }
    }
}
