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
    public partial class Activar_Oferta_Supervisor : System.Web.UI.Page
    {

        Logica_Bloque_Activar_Oferta_Supervisor LBAOS = new Logica_Bloque_Activar_Oferta_Supervisor();

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
                List<Mostrar_Activar_Oferta_SupervisorResult> Datos = LBAOS.Logica_Mostrar_Activar_Oferta((int)Session["Variable_ID_Empresa"]); // carga los datos del administrador elegido por el supervisor
                bool Oferta_16 = true;

                if (Datos[0].Oferta_2)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "2";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_3)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "3";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_5)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "5";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_7)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "7";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_8)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "8";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_9)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "9";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_10)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "10";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_11)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "11";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_12)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "12";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_13)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "13";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_14)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "14";
                    Oferta_16 = false;
                }
                if (Datos[0].Oferta_15)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "15";
                    Oferta_16 = false;
                }
                if (Oferta_16)
                {
                    RadioButtonList_Ofertas_Supervisor.SelectedValue = "16";                    
                }
                if (Datos[0].Oferta_1)
                {
                    Bonificacion_Registro.Checked = true;
                }
                if (Datos[0].Oferta_4)
                {
                    Bonificacion_Por_Cantidad.Checked = true;
                }

            }
        }


       

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        bool Oferta_1;
        bool Oferta_2;
        bool Oferta_3;
        bool Oferta_4;
        bool Oferta_5;
        bool Oferta_7;
        bool Oferta_8;
        bool Oferta_9;
        bool Oferta_10;
        bool Oferta_11;
        bool Oferta_12;
        bool Oferta_13;
        bool Oferta_14;
        bool Oferta_15;
        bool Oferta_16;

        protected void Boton_Actualizar_Supervisor_Click(object sender, EventArgs e)
        {
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "2")
            {
                 Oferta_2 = true;
                 Oferta_3 = false;
                 Oferta_5 = false;
                 Oferta_7 = false;
                 Oferta_8 = false;
                 Oferta_9 = false;
                 Oferta_10 = false;
                 Oferta_11 = false;
                 Oferta_12 = false;
                 Oferta_13 = false;
                 Oferta_14 = false;
                 Oferta_15 = false;
                 Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "3")
            {
                 Oferta_2 = false;
                 Oferta_3 = true;
                 Oferta_5 = false;
                 Oferta_7 = false;
                 Oferta_8 = false;
                 Oferta_9 = false;
                 Oferta_10 = false;
                 Oferta_11 = false;
                 Oferta_12 = false;
                 Oferta_13 = false;
                 Oferta_14 = false;
                 Oferta_15 = false;
                 Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "5")
            {
                Oferta_2 = false;
                Oferta_3 = false;
                Oferta_5 = true;
                Oferta_7 = false;
                Oferta_8 = false;
                Oferta_9 = false;
                Oferta_10 = false;
                Oferta_11 = false;
                Oferta_12 = false;
                Oferta_13 = false;
                Oferta_14 = false;
                Oferta_15 = false;
                Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "7")
            {
                Oferta_2 = false;
                Oferta_3 = false;
                Oferta_5 = false;
                Oferta_7 = true;
                Oferta_8 = false;
                Oferta_9 = false;
                Oferta_10 = false;
                Oferta_11 = false;
                Oferta_12 = false;
                Oferta_13 = false;
                Oferta_14 = false;
                Oferta_15 = false;
                Oferta_16 = false; ;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "8")
            {
                  Oferta_2 = false;
                  Oferta_3 = false;
                  Oferta_5 = false;
                  Oferta_7 = false;
                  Oferta_8 = true;
                  Oferta_9 = false;
                  Oferta_10 = false;
                  Oferta_11 = false;
                  Oferta_12 = false;
                  Oferta_13 = false;
                  Oferta_14 = false;
                  Oferta_15 = false;
                  Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "9")
            {
                  Oferta_2 = false;
                  Oferta_3 = false;
                  Oferta_5 = false;
                  Oferta_7 = false;
                  Oferta_8 = false;
                  Oferta_9 = true;
                  Oferta_10 = false;
                  Oferta_11 = false;
                  Oferta_12 = false;
                  Oferta_13 = false;
                  Oferta_14 = false;
                  Oferta_15 = false;
                  Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "10")
            {
                  Oferta_2 = false;
                  Oferta_3 = false;
                  Oferta_5 = false;
                  Oferta_7 = false;
                  Oferta_8 = false;
                  Oferta_9 = false;
                  Oferta_10 = true;
                  Oferta_11 = false;
                  Oferta_12 = false;
                  Oferta_13 = false;
                  Oferta_14 = false;
                  Oferta_15 = false;
                  Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "11")
            {
                  Oferta_2 = false;
                  Oferta_3 = false;
                  Oferta_5 = false;
                  Oferta_7 = false;
                  Oferta_8 = false;
                  Oferta_9 = false;
                  Oferta_10 = false;
                  Oferta_11 = true;
                  Oferta_12 = false;
                  Oferta_13 = false;
                  Oferta_14 = false;
                  Oferta_15 = false;
                  Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "12")
            {
                  Oferta_2 = false;
                  Oferta_3 = false;
                  Oferta_5 = false;
                  Oferta_7 = false;
                  Oferta_8 = false;
                  Oferta_9 = false;
                  Oferta_10 = false;
                  Oferta_11 = false;
                  Oferta_12 = true;
                  Oferta_13 = false;
                  Oferta_14 = false;
                  Oferta_15 = false;
                  Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "13")
            {
                  Oferta_2 = false;
                  Oferta_3 = true;
                  Oferta_5 = false;
                  Oferta_7 = false;
                  Oferta_8 = false;
                  Oferta_9 = false;
                  Oferta_10 = false;
                  Oferta_11 = false;
                  Oferta_12 = false;
                  Oferta_13 = true;
                  Oferta_14 = false;
                  Oferta_15 = false;
                  Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "14")
            {
                  Oferta_2 = false;
                  Oferta_3 = false;
                  Oferta_5 = false;
                  Oferta_7 = false;
                  Oferta_8 = false;
                  Oferta_9 = false;
                  Oferta_10 = false;
                  Oferta_11 = false;
                  Oferta_12 = false;
                  Oferta_13 = false;
                  Oferta_14 = true;
                  Oferta_15 = false;
                  Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "15")
            {
                  Oferta_2 = false;
                  Oferta_3 = false;
                  Oferta_5 = false;
                  Oferta_7 = false;
                  Oferta_8 = false;
                  Oferta_9 = false;
                  Oferta_10 = false;
                  Oferta_11 = false;
                  Oferta_12 = false;
                  Oferta_13 = false;
                  Oferta_14 = false;
                  Oferta_15 = true;
                  Oferta_16 = false;
            }
            if (RadioButtonList_Ofertas_Supervisor.SelectedItem.Value == "16")
            {
                Oferta_2 = false;
                Oferta_3 = false;
                Oferta_5 = false;
                Oferta_7 = false;
                Oferta_8 = false;
                Oferta_9 = false;
                Oferta_10 = false;
                Oferta_11 = false;
                Oferta_12 = false;
                Oferta_13 = false;
                Oferta_14 = false;
                Oferta_15 = false;
                Oferta_16 = true;
            }

            if (Bonificacion_Registro.Checked)
            {
                  Oferta_1 = true;
            }
            else
            {
                  Oferta_1 = false;
            }
            if (Bonificacion_Por_Cantidad.Checked)
            {
                  Oferta_4 = true;
            }
            else
            {
                  Oferta_4 = false;
            }

            LBAOS.Logica_Actualizar_Activar_Oferta((int)Session["Variable_ID_Empresa"], Oferta_1,Oferta_2, Oferta_3, Oferta_4, Oferta_5, true,Oferta_7, Oferta_8, Oferta_9, Oferta_10, Oferta_11,Oferta_12, Oferta_13, Oferta_14, Oferta_15);
                
            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Ofertas Actualizadas');", true);
            return;

        }

    }
}