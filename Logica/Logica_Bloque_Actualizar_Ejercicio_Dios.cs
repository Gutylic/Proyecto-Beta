using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Actualizar_Ejercicio_Dios
    {

        Bloque_Actualizar_Ejercicio_Dios BAED = new Bloque_Actualizar_Ejercicio_Dios();
        

        public int Logica_Actualizar_Ejercicio(string Titulo, int ID_Tipo_De_Ejercicio, int ID_Tipo_De_Institucion,
bool Explicacion_Realizada, string Enunciado_MATH, string Enunciado_Limpio, string Ubicacion_Respuesta_De_Ejercicio_Imprimible,
string Ubicacion_Respuesta_De_Ejercicio_Visible, string Ubicacion_Videos_Explicaciones, string Etiqueta_Busqueda_Ano,
string Etiqueta_Busqueda_Colegio, string Etiqueta_Busqueda_Materia, string Etiqueta_Busqueda_Profesor,
string Etiqueta_Busqueda_Tema, int Identificador)
        {
            return BAED.Actualizar_Ejercicio(Titulo, ID_Tipo_De_Ejercicio, ID_Tipo_De_Institucion, Explicacion_Realizada, Enunciado_MATH, Enunciado_Limpio, Ubicacion_Respuesta_De_Ejercicio_Imprimible, Ubicacion_Respuesta_De_Ejercicio_Visible, Ubicacion_Videos_Explicaciones, Etiqueta_Busqueda_Ano, Etiqueta_Busqueda_Colegio, Etiqueta_Busqueda_Materia, Etiqueta_Busqueda_Profesor, Etiqueta_Busqueda_Tema, Identificador);

        }

        public int Logica_Ejercicio_A_Modificar(int Identificador)
        {
            return BAED.Ejercicio_A_Modificar(Identificador);
        }

        public void Logica_Cargar_Tema(string var1, string var2, string var3)
        {
            BAED.Cargar_Tema(var1, var2, var3);
        }

        public void Logica_Cargar_Sinonimo_Tema(string var1, string var2, string var3)
        {
            BAED.Cargar_Sinonimo_Tema(var1, var2, var3);
        }

        public void Logica_Cargar_Materia(string var1, string var2, string var3)
        {
            BAED.Cargar_Materia(var1, var2, var3);
        }

        public void Logica_Cargar_Colegio(string var1, string var2, string var3)
        {
            BAED.Cargar_Colegio(var1, var2, var3);
        }

        public void Logica_Cargar_Profesor(string var1, string var2, string var3)
        {
            BAED.Cargar_Profesor(var1, var2, var3);
        }

        public void Logica_Cargar_Ano(string var1, string var2, string var3)
        {
            BAED.Cargar_Ano(var1, var2, var3);
        }

        

        public int Logica_Borrar_Anos()
        {
            return BAED.Borrar_Anos();
        }

        public int Logica_Borrar_Temas()
        {
            return BAED.Borrar_Temas();
        }

        public int Logica_Borrar_Materias()
        {
            return BAED.Borrar_Materias();
        }

        public int Logica_Borrar_Profesores()
        {
            return BAED.Borrar_Profesores();
        }

        public int Logica_Borrar_Colegios()
        {
            return BAED.Borrar_Colegios();
        }
    }
}
