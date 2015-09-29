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
    public partial class Panel_De_Control_Usuario_Administrador : System.Web.UI.Page
    {
        Logica_Bloque_Panel_De_Control_Usuario_Administrador LBPDCUA = new Logica_Bloque_Panel_De_Control_Usuario_Administrador();

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
                    DropDownList_Administrador.Enabled = false;
                    break;

                case 1:
                    Boton_Buscar_Administrador.Enabled = true;
                    DropDownList_Administrador.Enabled = true;
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

            if(Buscar_Administrador.Text == string.Empty || DropDownList_Administrador.SelectedValue == "1")
            {
                Formulario.Visible = false;
                return;
            }

            Session["Opcion"] = int.Parse(DropDownList_Administrador.SelectedValue);
            Session["Buscar"] = Buscar_Administrador.Text;

            List<Mostrar_Usuario_AdministradorResult> Datos = LBPDCUA.Logica_Mostrar_Datos((string)Session["Buscar"], (int)Session["Variable_ID_Empresa"], (int)Session["Opcion"]); // carga los datos del administrador elegido por el supervisor

            try
            {
                Formulario.Visible = true;
                Session["ID_Usuario"] = Datos[0].ID_Usuario;
                Usuario_Administrador.Text = Datos[0].Usuario.ToString();
                Correo_Administrador.Text = Datos[0].Correo.ToString();
                if (Datos[0].Usuario_De_Skype != null) { Skype_Administrador.Text = Datos[0].Usuario_De_Skype.ToString(); }

                if (Datos[0].Numero_De_Celular != null) { Celular_Administrador.Text = Datos[0].Numero_De_Celular.ToString(); }

                if (Datos[0].Modelo_De_Celular != null) { Modelo_Administrador.Text = Datos[0].Modelo_De_Celular.ToString(); }
                Credito_Administrador.Text = Datos[0].Credito_De_Usuario.ToString();
                CheckBox_Prestamo_Administrador.Checked = Datos[0].Pedido_De_Prestamo;
                CheckBox_Activacion_Administrador.Checked = Datos[0].Activacion_De_Usuarios;
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('El usuario buscado no existe');", true);
                Formulario.Visible = false;

            }
        }

    }
}