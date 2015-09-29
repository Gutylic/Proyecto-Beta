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
    public partial class Panel_De_Control_Administrador : System.Web.UI.Page
    {
        Logica_Bloque_Panel_De_Control_Administrador LBPDCA = new Logica_Bloque_Panel_De_Control_Administrador();

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

                List<Datos_AdministradorResult> Datos = LBPDCA.Logica_Lista_Datos_Del_Administrador((string)Session["Administrador"]);
                Etiqueta_Nombre.Text = (string)Session["Administrador"]; // carga el administrador que viene de una variable de session
                TextBox_Password.Text = Datos[0].Password; // carga la contraseña desde la base de datos                
            }
        }

        

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        protected void Boton_Actualizar_Administrador_Click(object sender, EventArgs e)
        {
            if (TextBox_Password.Text.Length < 6) // analisis del password con mas de 6 caracteres 
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en la contraseña');", true);
                return;
            }
            int Valor = LBPDCA.Logica_Actualizar_Perfil_Administrador(Etiqueta_Nombre.Text, TextBox_Password.Text); // actualiza el perfil del administrador desde el mismo administrador
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Administrador creado correctamente'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }
    }
}