using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using System.Web.UI.WebControls.WebParts;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace Supervisor
{
    public partial class Precios_Administrador : System.Web.UI.Page
    {
        Logica_Bloque_Precios_Administrador LBPA = new Logica_Bloque_Precios_Administrador();

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

                List<Mostrar_Precios_AdministradorResult> Datos = LBPA.Logica_Mostrar_Precios((int)Session["Variable_ID_Empresa"]); // carga los datos del administrador elegido por el supervisor
                Valor_Ejercicio_Administrador.Text = Datos[0].Valor_Ejercicio.ToString(); // carga el administrador de la base
                Valor_Explicacion_Administrador.Text = Datos[0].Valor_Explicacion.ToString();
                Valor_Video_Administrador.Text = Datos[0].Valor_Video.ToString();
                Valor_Conjunto_De_Videos_Administrador.Text = Datos[0].Valor_Conjunto_De_Videos.ToString();
                Valor_Explicacion_Personalizada_Administrador.Text = Datos[0].Valor_Explicacion_Personalizada.ToString();
                Valor_Ejercicio_Personalizado_Administrador.Text = Datos[0].Valor_Ejercicio_Personalizado.ToString();
                Valor_Video_Personalizado_Administrador.Text = Datos[0].Valor_Video_Personalizado.ToString();
                Valor_Impresion_Administrador.Text = Datos[0].Valor_Impresion.ToString();
                Valor_Prestamo_SOS_Administrador.Text = Datos[0].Valor_Prestamo_SOS.ToString();
                Duracion_De_Los_Ejercicios_Y_Las_Explicaciones_Administrador.Text = Datos[0].Duracion_De_Los_Ejercicios_Y_Las_Explicaciones.ToString();
                Duracion_De_Los_Videos_Administrador.Text = Datos[0].Duracion_De_Los_Videos.ToString(); // carga de la base si el administrador esta bloqueado
            }
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }


       

    }
}