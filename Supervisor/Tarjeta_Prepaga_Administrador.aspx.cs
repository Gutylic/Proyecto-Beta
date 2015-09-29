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
    public partial class Tarjeta_Prepaga_Administrador : System.Web.UI.Page
    {
        Logica_Bloque_Tarjeta_Prepaga_Administrador LBTPA = new Logica_Bloque_Tarjeta_Prepaga_Administrador();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Administrador"] == null || Session["www"] == null)
            {
                Response.Redirect("sefue.aspx");
            }
          
            switch (int.Parse(Request.QueryString["Variable"]))
            {
                case 0:
                    Boton_Buscar_Administrador.Enabled = false;                   
                    break;
                case 1:
                    Boton_Buscar_Administrador.Enabled = true;                    
                    break;
                
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

        protected void Boton_Buscar_Administrador_Click(object sender, EventArgs e)
        {
            Formulario.Visible = false;
            if (Buscar_Administrador.Text == string.Empty)
            {
                Formulario.Visible = false;
                return;
            }
                       
           

            List<Mostrar_Tarjeta_Prepaga_AdministradorResult> Datos = LBTPA.Logica_Mostrar_Tarjeta_Prepaga(int.Parse(Buscar_Administrador.Text) , (string)Session["Empresa"]); // carga los datos del administrador elegido por el supervisor

            try
            {
                Formulario.Visible = true;
                Codigo_Administrador.Text = Datos[0].Codigo.ToString();
                Credito_Administrador.Text = Datos[0].Credito.ToString();
                Vencimiento_Administrador.Text = Datos[0].Fecha_De_Vencimiento.ToString("dd/MM/yyyy");
                CheckBox_Activacion_Administrador.Checked = Datos[0].Activacion_De_La_Tarjeta;
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('No existe la tarjeta solicitada');", true);
                Formulario.Visible = false;
                

            }
        }

    }
}