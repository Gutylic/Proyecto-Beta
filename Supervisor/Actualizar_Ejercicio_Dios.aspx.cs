using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;
using System.IO;
using System.Data;
using System.Data.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Supervisor
{
    public partial class Actualizar_Ejercicio_Dios : System.Web.UI.Page
    {

        Logica_Bloque_Actualizar_Ejercicio_Dios LBAED = new Logica_Bloque_Actualizar_Ejercicio_Dios();

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

        protected void Boton_Actualizar_Dios_Click(object sender, EventArgs e)
        {
            
            if (Subir_Ejercicio_Dios.HasFile)
            {
                string Valor_A_Analizar = Subir_Ejercicio_Dios.FileName.Substring(9,Subir_Ejercicio_Dios.FileName.Length - 13);
                try
                {
                    int Identidad = int.Parse(Valor_A_Analizar);
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

                    LBAED.Logica_Cargar_Tema(Var1_Tema, Var2_Tema, Var3_Tema);
                    LBAED.Logica_Cargar_Sinonimo_Tema(Var1_Tema_Sinonimo, Var2_Tema_Sinonimo, Var3_Tema_Sinonimo);
                    LBAED.Logica_Cargar_Materia(Var1_Materia, Var2_Materia, Var3_Materia);
                    LBAED.Logica_Cargar_Colegio(Var1_Colegio_Sinonimo, Var2_Colegio_Sinonimo, Var3_Colegio_Sinonimo);
                    LBAED.Logica_Cargar_Ano(Var1_Ano_Sinonimo, Var2_Ano_Sinonimo, Var3_Ano_Sinonimo);
                    LBAED.Logica_Cargar_Profesor(Var1_Profesor, Var2_Profesor, Var3_Profesor);

                    if (LBAED.Logica_Actualizar_Ejercicio(Titulo, int.Parse(Tipo_De_Ejercicio), int.Parse(Tipo_De_Institucion), bool.Parse(Explicacion_Realizada), Enunciado_MATH, Enunciado_Limpio, Ubicacion_Imprimible_Respuesta, Ubicacion_Ejercicio_Respuesta, Ubicacion_Video, Etiqueta_Busqueda_Ano, Etiqueta_Busqueda_Colegio, Etiqueta_Busqueda_Materia, Etiqueta_Busqueda_Profesor, Etiqueta_Busqueda_Tema, Identidad) == 1)
                    {
                        Ejercicio_Dios.Text = "Usted ha actualizado el ejercicio número:" + Identidad.ToString();
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Actualizado');", true);
                        return;
                    }

                }
                catch (FormatException)
                {
                    return;
                
                }



            }
            else
            {
                return;
            }
        }

        public class Tabla
        { 
            public string ID;
            public string Dato;
            public string Etiqueta;
        }

        DataClassesDataContext db = new DataClassesDataContext();

        protected void Guardar_Ano_Click(object sender, EventArgs e)
        {

            if (Subir_Ejercicio_Dios.HasFile)
            {
                string fileName = Path.GetFileNameWithoutExtension(Subir_Ejercicio_Dios.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), Subir_Ejercicio_Dios.FileName);
                Subir_Ejercicio_Dios.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Anos.xml"));
                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Ano").Value,
                                         Dato = item.Element("Ano").Value,
                                         Etiqueta = item.Element("Etiqueta_Ano").Value,

                                     }).ToList();

                LBAED.Logica_Borrar_Anos();

                for (int I = 0; I <= Lista.Count - 1; I++)
                {
                    Tabla_De_Anos Etiqueta_Final = new Tabla_De_Anos();
                    Etiqueta_Final.Ano = Lista[I].Dato;
                    Etiqueta_Final.Etiqueta_Ano = int.Parse(Lista[I].Etiqueta);
                    db.Tabla_De_Anos.InsertOnSubmit(Etiqueta_Final);
                    db.SubmitChanges();

                }

                string alerta = @"alert('Acción realizada correctamente');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
            else
            {
                string alerta = @"alert('Error al insertar la tabla');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }



        }

        protected void Guardar_Materia_Click(object sender, EventArgs e)
        {
            if (Subir_Ejercicio_Dios.HasFile)
            {
                string fileName = Path.GetFileNameWithoutExtension(Subir_Ejercicio_Dios.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), Subir_Ejercicio_Dios.FileName);
                Subir_Ejercicio_Dios.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Materias.xml"));
                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Materia").Value,
                                         Dato = item.Element("Materia").Value,
                                         Etiqueta = item.Element("Etiqueta_Materia").Value,

                                     }).ToList();

                LBAED.Logica_Borrar_Materias();

                for (int I = 0; I <= Lista.Count - 1; I++)
                {
                    Tabla_De_Materias Etiqueta_Final = new Tabla_De_Materias();
                    Etiqueta_Final.Materia = Lista[I].Dato;
                    Etiqueta_Final.Etiqueta_Materia = int.Parse(Lista[I].Etiqueta);
                    db.Tabla_De_Materias.InsertOnSubmit(Etiqueta_Final);
                    db.SubmitChanges();

                }

                string alerta = @"alert('Acción realizada correctamente');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
            else
            {
                string alerta = @"alert('Error al insertar la tabla');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

        protected void Guardar_Profesor_Click(object sender, EventArgs e)
        {
            if (Subir_Ejercicio_Dios.HasFile)
            {
                string fileName = Path.GetFileNameWithoutExtension(Subir_Ejercicio_Dios.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), Subir_Ejercicio_Dios.FileName);
                Subir_Ejercicio_Dios.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Profesores.xml"));
                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Profesor").Value,
                                         Dato = item.Element("Profesor").Value,
                                         Etiqueta = item.Element("Etiqueta_Profesor").Value,

                                     }).ToList();

                LBAED.Logica_Borrar_Profesores();

                for (int I = 0; I <= Lista.Count - 1; I++)
                {
                    Tabla_De_Profesores Etiqueta_Final = new Tabla_De_Profesores();
                    Etiqueta_Final.Profesor = Lista[I].Dato;
                    Etiqueta_Final.Etiqueta_Profesor = int.Parse(Lista[I].Etiqueta);
                    db.Tabla_De_Profesores.InsertOnSubmit(Etiqueta_Final);
                    db.SubmitChanges();

                }

                string alerta = @"alert('Acción realizada correctamente');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
            else
            {
                string alerta = @"alert('Error al insertar la tabla');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

        protected void Guardar_Colegio_Click(object sender, EventArgs e)
        {
            if (Subir_Ejercicio_Dios.HasFile)
            {
                string fileName = Path.GetFileNameWithoutExtension(Subir_Ejercicio_Dios.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), Subir_Ejercicio_Dios.FileName);
                Subir_Ejercicio_Dios.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Colegios.xml"));
                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Colegio").Value,
                                         Dato = item.Element("Colegio").Value,
                                         Etiqueta = item.Element("Etiqueta_Colegio").Value,

                                     }).ToList();

                LBAED.Logica_Borrar_Colegios();

                for (int I = 0; I <= Lista.Count - 1; I++)
                {
                    Tabla_De_Colegios Etiqueta_Final = new Tabla_De_Colegios();
                    Etiqueta_Final.Colegio = Lista[I].Dato;
                    Etiqueta_Final.Etiqueta_Colegio = int.Parse(Lista[I].Etiqueta);
                    db.Tabla_De_Colegios.InsertOnSubmit(Etiqueta_Final);
                    db.SubmitChanges();

                }

                string alerta = @"alert('Acción realizada correctamente');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
            else
            {
                string alerta = @"alert('Error al insertar la tabla');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

        protected void Guardar_Tema_Click(object sender, EventArgs e)
        {
            if (Subir_Ejercicio_Dios.HasFile)
            {
                string fileName = Path.GetFileNameWithoutExtension(Subir_Ejercicio_Dios.FileName);

                string saveXML = Path.Combine(Server.MapPath("~/xml"), Subir_Ejercicio_Dios.FileName);
                Subir_Ejercicio_Dios.SaveAs(saveXML);

                XElement doc = XElement.Load(Server.MapPath("xml/Temas.xml"));
                List<Tabla> Lista = (from item in doc.Elements("Elementos")
                                     select new Tabla()
                                     {
                                         ID = item.Element("ID_Tema").Value,
                                         Dato = item.Element("Tema").Value,
                                         Etiqueta = item.Element("Etiqueta_Tema").Value,

                                     }).ToList();

                LBAED.Logica_Borrar_Temas();

                for (int I = 0; I <= Lista.Count - 1; I++)
                {
                    Tabla_De_Temas Etiqueta_Final = new Tabla_De_Temas();
                    Etiqueta_Final.Tema = Lista[I].Dato;
                    Etiqueta_Final.Etiqueta_Tema = int.Parse(Lista[I].Etiqueta);
                    db.Tabla_De_Temas.InsertOnSubmit(Etiqueta_Final);
                    db.SubmitChanges();

                }

                string alerta = @"alert('Acción realizada correctamente');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
            else
            {
                string alerta = @"alert('Error al insertar la tabla');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }



    }
}