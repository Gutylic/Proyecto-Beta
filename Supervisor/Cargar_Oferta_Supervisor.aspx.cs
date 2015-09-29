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
    public partial class Cargar_Oferta_Supervisor : System.Web.UI.Page
    {

        Logica_Bloque_Cargar_Oferta_Supervisor LBCOS = new Logica_Bloque_Cargar_Oferta_Supervisor();
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
                List<Mostrar_Cargar_Ofertas_SupervisorResult> Datos = LBCOS.Logica_Mostrar_Cargar_Oferta((int)Session["Variable_ID_Empresa"]); // carga los datos del administrador elegido por el supervisor
                Bonificacion_Por_Registro_Supervisor.Text = Datos[0].Bonificacion_Por_Registrarse.ToString(); // carga el administrador de la base
                Bonificacion_Por_Cargar_Supervisor.Text = Datos[0].Bonificacion_Por_Carga.ToString();
                Porcentaje_De_Descuento_Segundo_Producto_Supervisor.Text = Datos[0].Descuento_2_Compra.ToString();
                Bonificacion_Por_Cantidad_Supervisor.Text = Datos[0].Bonificacion_Por_X_Consulta.ToString();
                Bonificacion_Proxima_Recarga_Supervisor.Text = Datos[0].Bonificacion_En_La_Proxima_Recarga.ToString();
                Descuento_En_La_Compra_Del_Producto_Supervisor.Text = Datos[0].Descuento_Por_Compra.ToString();
                Duracion_De_Todas_Las_Compras_Supervisor.Text = Datos[0].Aumenta_Duracion_Todo_Lo_Comprado.ToString();
                Duracion_De_La_Compra_Supervisor.Text = Datos[0].Aumenta_Duracion_De_La_Compra_Actual.ToString();
                Cantidad_Supervisor.Text = Datos[0].Cantidad_X_Para_Bonificacion_Por_Consultas.ToString();
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
                if (Bonificacion_Por_Registro_Supervisor.Text == string.Empty || Bonificacion_Por_Cargar_Supervisor.Text == string.Empty || Porcentaje_De_Descuento_Segundo_Producto_Supervisor.Text == string.Empty ||
                    Bonificacion_Por_Cantidad_Supervisor.Text == string.Empty || Bonificacion_Proxima_Recarga_Supervisor.Text == string.Empty ||
                    Descuento_En_La_Compra_Del_Producto_Supervisor.Text == string.Empty || Duracion_De_Todas_Las_Compras_Supervisor.Text == string.Empty
                    || Duracion_De_La_Compra_Supervisor.Text == string.Empty)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el precio');", true);
                    return;
                }

                if (!(decimal.Parse(Bonificacion_Por_Cargar_Supervisor.Text) >= 0 && decimal.Parse(Bonificacion_Por_Cargar_Supervisor.Text) <= 1))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el precio');", true);
                    return;

                }
                if (!(decimal.Parse(Porcentaje_De_Descuento_Segundo_Producto_Supervisor.Text) >= 0 && decimal.Parse(Porcentaje_De_Descuento_Segundo_Producto_Supervisor.Text) <= 1))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el precio');", true);
                    return;

                }
                if (!(decimal.Parse(Descuento_En_La_Compra_Del_Producto_Supervisor.Text) >= 0 && decimal.Parse(Descuento_En_La_Compra_Del_Producto_Supervisor.Text) <= 1))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el precio');", true);
                    return;
                }

                if (Cantidad_Supervisor.Text == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el precio');", true);
                    return;
                }

                LBCOS.Logica_Actualizar_Cargar_Ofertas((int)Session["Variable_ID_Empresa"], decimal.Parse(Bonificacion_Por_Registro_Supervisor.Text),
                    decimal.Parse(Bonificacion_Por_Cargar_Supervisor.Text), decimal.Parse(Porcentaje_De_Descuento_Segundo_Producto_Supervisor.Text),
                    int.Parse(Bonificacion_Por_Cantidad_Supervisor.Text), decimal.Parse(Descuento_En_La_Compra_Del_Producto_Supervisor.Text),
                    int.Parse(Bonificacion_Proxima_Recarga_Supervisor.Text),
                    int.Parse(Duracion_De_Todas_Las_Compras_Supervisor.Text), int.Parse(Duracion_De_La_Compra_Supervisor.Text), int.Parse(Cantidad_Supervisor.Text));

                string alerta = @"alert('Ofertas Correctamente realizadas'); 

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
        #endregion
         }

    }
}
        