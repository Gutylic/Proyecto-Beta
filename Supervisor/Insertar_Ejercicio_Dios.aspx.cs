using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.IO;

namespace Supervisor
{
    public partial class Insertar_Ejercicio_Dios : System.Web.UI.Page
    {

        Logica_Bloque_Insertar_Ejercicio_Dios LBIED = new Logica_Bloque_Insertar_Ejercicio_Dios();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Administrador"] == null || Session["www"] == null)
            {
                Response.Redirect("sefue.aspx");
            }

            Etiqueta_Administrador_Chico.Text = ((string)Session["Administrador"]).ToUpper();
            Etiqueta_Administrador_Grande.Text = ((string)Session["Administrador"]).ToUpper();
            Etiqueta_Hora_Grande.Text = DateTime.Now.ToString();
            Etiqueta_Hora_Chica.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            Etiqueta_Localizador_Grande.Text = Request.UserHostAddress.ToString();
            Etiqueta_Localizador_Chico.Text = Request.UserHostAddress.ToString();

        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        protected void Boton_Insertar_Dios_Click(object sender, EventArgs e)
        {

            string fileName = Path.GetFileNameWithoutExtension(Subir_Ejercicio_Dios.FileName);

            string saveXML = Path.Combine(Server.MapPath("~/ejercicios"), Subir_Ejercicio_Dios.FileName);
            Subir_Ejercicio_Dios.SaveAs(saveXML);



            string TextXML;
            StreamReader sr = new StreamReader(saveXML);
            TextXML = sr.ReadToEnd();
            sr.Close();




            string[] Contenido_Del_Archivo = TextXML.Split('╝');

            string Enunciado_MATH = Contenido_Del_Archivo[0];
            string Enunciado_Limpio = Contenido_Del_Archivo[1];
            string Titulo = Contenido_Del_Archivo[2];
            string Tipo_De_Institucion = Contenido_Del_Archivo[3];
            string Tipo_De_Ejercicio = Contenido_Del_Archivo[4];
            string Ubicacion_Imprimible_Respuesta = Contenido_Del_Archivo[5];
            string Ubicacion_Ejercicio_Respuesta = Contenido_Del_Archivo[6];
            string Ubicacion_Video = Contenido_Del_Archivo[7];
            string Explicacion_Realizada = Contenido_Del_Archivo[8];

            string Var1_Tema = Contenido_Del_Archivo[9];
            string Var2_Tema = Contenido_Del_Archivo[10];
            string Var3_Tema = Contenido_Del_Archivo[11];
            string Var1_Tema_Sinonimo = Contenido_Del_Archivo[12];
            string Var2_Tema_Sinonimo = Contenido_Del_Archivo[13];
            string Var3_Tema_Sinonimo = Contenido_Del_Archivo[14];
            string Var1_Materia = Contenido_Del_Archivo[15];
            string Var2_Materia = Contenido_Del_Archivo[16];
            string Var3_Materia = Contenido_Del_Archivo[17];
            string Var1_Colegio_Sinonimo = Contenido_Del_Archivo[18];
            string Var2_Colegio_Sinonimo = Contenido_Del_Archivo[19];
            string Var3_Colegio_Sinonimo = Contenido_Del_Archivo[20];
            string Var1_Ano_Sinonimo = Contenido_Del_Archivo[21];
            string Var2_Ano_Sinonimo = Contenido_Del_Archivo[22];
            string Var3_Ano_Sinonimo = Contenido_Del_Archivo[23];
            string Var1_Profesor = Contenido_Del_Archivo[24];
            string Var2_Profesor = Contenido_Del_Archivo[25];
            string Var3_Profesor = Contenido_Del_Archivo[26];

            string Etiqueta_Busqueda_Ano = Contenido_Del_Archivo[27];
            string Etiqueta_Busqueda_Colegio = Contenido_Del_Archivo[28];
            string Etiqueta_Busqueda_Materia = Contenido_Del_Archivo[29];
            string Etiqueta_Busqueda_Profesor = Contenido_Del_Archivo[30];
            string Etiqueta_Busqueda_Tema = Contenido_Del_Archivo[31];

            LBIED.Logica_Cargar_Tema(Var1_Tema, Var2_Tema, Var3_Tema);
            LBIED.Logica_Cargar_Sinonimo_Tema(Var1_Tema_Sinonimo, Var2_Tema_Sinonimo, Var3_Tema_Sinonimo);
            LBIED.Logica_Cargar_Materia(Var1_Materia, Var2_Materia, Var3_Materia);
            LBIED.Logica_Cargar_Colegio(Var1_Colegio_Sinonimo, Var2_Colegio_Sinonimo, Var3_Colegio_Sinonimo);
            LBIED.Logica_Cargar_Ano(Var1_Ano_Sinonimo, Var2_Ano_Sinonimo, Var3_Ano_Sinonimo);
            LBIED.Logica_Cargar_Profesor(Var1_Profesor, Var2_Profesor, Var3_Profesor);

            if (LBIED.Logica_Insertar_Ejercicio(Titulo, int.Parse(Tipo_De_Ejercicio), int.Parse(Tipo_De_Institucion), bool.Parse(Explicacion_Realizada), Enunciado_MATH, Enunciado_Limpio, Ubicacion_Imprimible_Respuesta, Ubicacion_Ejercicio_Respuesta, Ubicacion_Video, Etiqueta_Busqueda_Ano, Etiqueta_Busqueda_Colegio, Etiqueta_Busqueda_Materia, Etiqueta_Busqueda_Profesor, Etiqueta_Busqueda_Tema) == 1)
            {
                Ejercicio_Dios.Text ="Ejercicio nº: " + LBIED.Logica_Numero_De_Ejercicio_Insertado().ToString() + " insertado";
                string alerta = @"alert('Ejercicio insertado correctamente'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }
    }
}