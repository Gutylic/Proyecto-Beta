using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Empresas_Dios
    {

        DataClassesDataContext db = new DataClassesDataContext();
        int? Cantidad;

        public List<Mostrar_Empresas_DiosResult> Mostrar_Empresa()
        {
            return db.Mostrar_Empresas_Dios().ToList();
        }

        public List<Seleccionar_Empresas_DiosResult> Seleccionar_Empresa(int Identidad)
        {
            return db.Seleccionar_Empresas_Dios(Identidad).ToList();
        }

        public int? Contar_Empresa()
        {
            db.Contar_Empresas_Dios(ref Cantidad);
            return Cantidad;
        }

        public int Borrar_Empresa(int Identidad) 
        {
            return db.Borrar_Empresas_Dios(Identidad);
        }

        public int Insertar_Empresa(string Empresa, int Cantidad_De_Consultas_Ejercicios, int Cantidad_De_Consultas_Videos)
        {
            return db.Insertar_Empresa_Dios(Empresa,Cantidad_De_Consultas_Ejercicios,Cantidad_De_Consultas_Videos);
        }

    }
}
