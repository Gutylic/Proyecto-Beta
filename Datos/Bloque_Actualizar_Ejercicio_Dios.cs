using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Actualizar_Ejercicio_Dios
    {

        DataClassesDataContext db = new DataClassesDataContext();
       

        public int Actualizar_Ejercicio(string Titulo, int ID_Tipo_De_Ejercicio, int ID_Tipo_De_Institucion,
bool Explicacion_Realizada, string Enunciado_MATH, string Enunciado_Limpio, string Ubicacion_Respuesta_De_Ejercicio_Imprimible,
string Ubicacion_Respuesta_De_Ejercicio_Visible, string Ubicacion_Videos_Explicaciones, string Etiqueta_Busqueda_Ano,
string Etiqueta_Busqueda_Colegio, string Etiqueta_Busqueda_Materia, string Etiqueta_Busqueda_Profesor,
string Etiqueta_Busqueda_Tema, int Identificador)
        {
            return db.Actualizar_Cargar_Ejercicio_Dios(Titulo, ID_Tipo_De_Ejercicio, ID_Tipo_De_Institucion, Explicacion_Realizada, Enunciado_MATH, Enunciado_Limpio, Ubicacion_Respuesta_De_Ejercicio_Imprimible, Ubicacion_Respuesta_De_Ejercicio_Visible, Ubicacion_Videos_Explicaciones, Etiqueta_Busqueda_Ano, Etiqueta_Busqueda_Colegio, Etiqueta_Busqueda_Materia, Etiqueta_Busqueda_Profesor, Etiqueta_Busqueda_Tema, Identificador);
        
        }

        public int Ejercicio_A_Modificar(int Identificador)
        {
            return db.Identificador_Del_Ejercicio_A_Modificar(Identificador);
        }

        public void Cargar_Tema(string var1, string var2, string var3)
        {
            db.Temas(var1, var2, var3);
        }

        public void Cargar_Sinonimo_Tema(string var1, string var2, string var3)
        {
            db.Sinonimos_Temas(var1, var2, var3);
        }

        public void Cargar_Materia(string var1, string var2, string var3)
        {
            db.Materia(var1, var2, var3);
        }

        public void Cargar_Colegio(string var1, string var2, string var3)
        {
            db.Colegios(var1, var2, var3);
        }

        public void Cargar_Profesor(string var1, string var2, string var3)
        {
            db.Profesor(var1, var2, var3);
        }

        public void Cargar_Ano(string var1, string var2, string var3)
        {
            db.Anos(var1, var2, var3);
        }



        public int Borrar_Anos()
        {
            return db.Borrar_Tabla_De_Anos();
        }

        public int Borrar_Temas()
        {
            return db.Borrar_Tabla_De_Temas();
        }

        public int Borrar_Materias()
        {
            return db.Borrar_Tabla_De_Materias();
        }

        public int Borrar_Profesores()
        {
            return db.Borrar_Tabla_De_Profesores();
        }

        public int Borrar_Colegios()
        {
            return db.Borrar_Tabla_De_Colegios();
        }

        
    }
}
