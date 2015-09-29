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
    public partial class Permisos_Supervisor : System.Web.UI.Page
    {
        Logica_Bloque_Permisos_Supervisor LBPS = new Logica_Bloque_Permisos_Supervisor();

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

        protected void Boton_De_Buscar_Click(object sender, EventArgs e)
        {

            if (Nik_Del_Administrador.Text == (string)Session["Administrador"])
            {
                Nik_Del_Administrador.Text = string.Empty;
                string alerta = @"alert('No puede modificar sus propios permisos');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
            
            int Valor = LBPS.Logica_Existencia_Del_Administrador(Nik_Del_Administrador.Text, (int)Session["Variable_ID_Empresa"]);
            if (Valor == 1)
            {

                List<Vista_Categoria> Datos = LBPS.Logica_Mostrar_Administrador(Nik_Del_Administrador.Text, (int)Session["Variable_ID_Empresa"]);
                DropDownList_Permisos.SelectedValue = Datos[0].Categoria_C1.ToString();
                DropDownList_Precios.SelectedValue = Datos[0].Categoria_B1.ToString();
                DropDownList_Activar_Ofertas.SelectedValue = Datos[0].Categoria_B2.ToString();
                DropDownList_Valor_De_Ofertas.SelectedValue = Datos[0].Categoria_B3.ToString();
                DropDownList_Panel_De_Control_Administrador.SelectedValue = Datos[0].Categoria_A1.ToString();
                DropDownList_Comentario_Administrador.SelectedValue = Datos[0].Categoria_A2.ToString();
                DropDownList_Control_Administrador.SelectedValue = Datos[0].Categoria_A3.ToString();
                DropDownList_Panel_Usuarios.SelectedValue = Datos[0].Categoria_D1.ToString();
                DropDownList_Comentario_Usuario.SelectedValue = Datos[0].Categoria_D2.ToString();
                DropDownList_Movimiento.SelectedValue = Datos[0].Categoria_E1.ToString();
                DropDownList_Comprar_Ejercicios.SelectedValue = Datos[0].Categoria_E2.ToString();
                DropDownList_Comprar_Explicaciones.SelectedValue = Datos[0].Categoria_E3.ToString();
                DropDownList_Ejercicios.SelectedValue = Datos[0].Categoria_F1.ToString();
                DropDownList_Explicaciones.SelectedValue = Datos[0].Categoria_F2.ToString();
                DropDownList_Respuestas.SelectedValue = Datos[0].Categoria_F3.ToString();
                DropDownList_Tarjetas.SelectedValue = Datos[0].Categoria_G1.ToString();
                DropDownList_Carga_Manual.SelectedValue = Datos[0].Categoria_G2.ToString();
                DropDownList_Carga_Automatica.SelectedValue = Datos[0].Categoria_G3.ToString();
            }
            else 
            {
                string alerta = @"alert('El administrador seleccionado no existe');";               
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }

        }

        protected void Boton_De_Actualizar_Click(object sender, EventArgs e)
        {
            

                if (Nik_Del_Administrador.Text == string.Empty)
                {
                    return;
                }

                int Valor = LBPS.Logica_Actualizar_Categoria_De_Administradores(Nik_Del_Administrador.Text, (int)Session["Variable_ID_Empresa"], int.Parse(DropDownList_Panel_De_Control_Administrador.SelectedValue),
                    int.Parse(DropDownList_Comentario_Administrador.SelectedValue), int.Parse(DropDownList_Control_Administrador.SelectedValue), int.Parse(DropDownList_Precios.SelectedValue),
                    int.Parse(DropDownList_Activar_Ofertas.SelectedValue), int.Parse(DropDownList_Valor_De_Ofertas.SelectedValue), int.Parse(DropDownList_Permisos.SelectedValue),
                    int.Parse(DropDownList_Panel_Usuarios.SelectedValue), int.Parse(DropDownList_Comentario_Usuario.SelectedValue), int.Parse(DropDownList_Movimiento.SelectedValue),
                    int.Parse(DropDownList_Comprar_Ejercicios.SelectedValue), int.Parse(DropDownList_Comprar_Explicaciones.SelectedValue), int.Parse(DropDownList_Ejercicios.SelectedValue),
                    int.Parse(DropDownList_Explicaciones.SelectedValue), int.Parse(DropDownList_Respuestas.SelectedValue), int.Parse(DropDownList_Tarjetas.SelectedValue),
                    int.Parse(DropDownList_Carga_Manual.SelectedValue), int.Parse(DropDownList_Carga_Automatica.SelectedValue));
                if (Valor == 1)
                {
                    string alerta = @"alert('Los permisos fueron modificados');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                    return;
                }
                else
                {
                    string alerta = @"alert('Los permisos no pudieron modificarse intentelo más tarde');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                    return;
                }
            }

            
        

    }

}
