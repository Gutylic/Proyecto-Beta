using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;

namespace Supervisor
{
    public partial class Respuestas_Dios : System.Web.UI.Page
    {
        Logica_Bloque_Respuesta LBR = new Logica_Bloque_Respuesta();

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

        protected void Boton_Ejercicio_Click(object sender, EventArgs e)
        {
            if (Numero_de_Ejercicio.Text == string.Empty)
            {
                return;
            }

            List<Buscar_Respuestas_Ejercicios_SupervisoresResult> Datos = LBR.Logica_Buscar_Respuestas_Ejercicios(int.Parse(Numero_de_Ejercicio.Text), (string)Session["Administrador"], (int)Session["Variable_ID_Empresa"]);

            try
            {
                string Cadena = @"window.open('Respuesta_De_Ejercicios.aspx?Ejercicio=" + Datos[0].Ubicacion_Respuesta_Imprimible + "','_blank');"; // busca por ficha y bloquea el boton de buscar por enunciado
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);

                return;

            }
            catch (Exception)
            {

                string Fallo = @"<script type='text/javascript'>   
                                   alert('El ejercicio no existe, revise su pedido gracias');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", Fallo, false);

                return;
            }
        }

        protected void Boton_Videos_Click(object sender, EventArgs e)
        {
            if (Palabras_Claves.Text == string.Empty)
            {
                return;
            }

            if (Palabras_Claves.Text.Contains("\r"))
            {
                return;
            }



            string Cadena = @"window.open('Respuesta_De_Videos.aspx?Videos=" + Palabras_Claves.Text.Trim().ToLower() + "','_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", Cadena, true);
        }
    }
}