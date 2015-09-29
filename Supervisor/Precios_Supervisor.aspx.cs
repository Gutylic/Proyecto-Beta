using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;


namespace Supervisor
{
    public partial class Precios_Supervisor : System.Web.UI.Page
    {
        Logica_Bloque_Precios_Supervisor LBPS = new Logica_Bloque_Precios_Supervisor();

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

            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                List<Seleccionar_Precios_SupervisorResult> Datos = LBPS.Logica_Seleccionar_Precios((int)Session["Variable_ID_Empresa"]); // carga los datos del administrador elegido por el supervisor
                Valor_Ejercicio_Supervisor.Text = Datos[0].Valor_Ejercicio.ToString(); // carga el administrador de la base
                Valor_Explicacion_Supervisor.Text = Datos[0].Valor_Explicacion.ToString();
                Valor_Video_Supervisor.Text = Datos[0].Valor_Video.ToString();
                Valor_Conjunto_De_Videos_Supervisor.Text = Datos[0].Valor_Conjunto_De_Videos.ToString();
                Valor_Explicacion_Personalizada_Supervisor.Text = Datos[0].Valor_Explicacion_Personalizada.ToString();
                Valor_Ejercicio_Personalizado_Supervisor.Text = Datos[0].Valor_Ejercicio_Personalizado.ToString();
                Valor_Video_Personalizado_Supervisor.Text = Datos[0].Valor_Video_Personalizado.ToString();
                Valor_Impresion_Supervisor.Text = Datos[0].Valor_Impresion.ToString();
                Valor_Prestamo_SOS_Supervisor.Text = Datos[0].Valor_Prestamo_SOS.ToString();
                Duracion_De_Los_Ejercicios_Y_Las_Explicaciones_Supervisor.Text = Datos[0].Duracion_De_Los_Ejercicios_Y_Las_Explicaciones.ToString();
                Duracion_De_Los_Videos_Supervisor.Text = Datos[0].Duracion_De_Los_Videos.ToString(); // carga de la base si el administrador esta bloqueado
            }
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }


        #region Botonera_De_Supervisor
        protected void Boton_Actualizar_Supervisor_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valor_Conjunto_De_Videos_Supervisor.Text == string.Empty || Valor_Ejercicio_Personalizado_Supervisor.Text == string.Empty || Valor_Ejercicio_Supervisor.Text == string.Empty || Valor_Video_Personalizado_Supervisor.Text == string.Empty || Valor_Video_Supervisor.Text == string.Empty ||
                    Valor_Explicacion_Personalizada_Supervisor.Text == string.Empty || Valor_Explicacion_Supervisor.Text == string.Empty || Valor_Impresion_Supervisor.Text == string.Empty ||
                    Valor_Prestamo_SOS_Supervisor.Text == string.Empty || Duracion_De_Los_Ejercicios_Y_Las_Explicaciones_Supervisor.Text == string.Empty || Duracion_De_Los_Videos_Supervisor.Text == string.Empty)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en los precios');", true);
                    return;
                }

                LBPS.Logica_Actualizar_Precios((int)Session["Variable_ID_Empresa"], decimal.Parse(Valor_Ejercicio_Supervisor.Text),
                    decimal.Parse(Valor_Explicacion_Supervisor.Text), decimal.Parse(Valor_Video_Supervisor.Text),
                    decimal.Parse(Valor_Conjunto_De_Videos_Supervisor.Text),
                    decimal.Parse(Valor_Explicacion_Personalizada_Supervisor.Text), decimal.Parse(Valor_Video_Personalizado_Supervisor.Text),
                    decimal.Parse(Valor_Ejercicio_Personalizado_Supervisor.Text), decimal.Parse(Valor_Impresion_Supervisor.Text),
                    decimal.Parse(Valor_Prestamo_SOS_Supervisor.Text), int.Parse(Duracion_De_Los_Videos_Supervisor.Text), int.Parse(Duracion_De_Los_Ejercicios_Y_Las_Explicaciones_Supervisor.Text));

                string alerta = @"alert('Precios insertados correctamente'); 

                        window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
            catch
            {
                string alerta = @"alert('Los precios no pudieron modificarse intentelo más tarde');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;


            }

        }

       

        #endregion


    }
}