using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;
using System.Web.UI.WebControls.WebParts;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace Supervisor
{
    public partial class Pedido_Ejercicio_Administrador : System.Web.UI.Page
    {

        Logica_Bloque_Pedido_Ejercicio_Administrador LBPEA = new Logica_Bloque_Pedido_Ejercicio_Administrador();
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

            Condiciones_Paginacion_Administrador();
            Mostrar_Datos_Administrador(0);
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        #region Paginacion_Supervisor
        public void Condiciones_Paginacion_Administrador() // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {

            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Administrador.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Administrador_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Administrador_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = LBPEA.Logica_Contar_Cantidad_Ejercicios((string)Session["Empresa"]); // cuenta la cantidad de datos
            ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Datos"] / 20; // cantidad de paginas segun la cantidad de datos            
            ViewState["Resto"] = (int)ViewState["Cantidad_De_Datos"] % 20; // me dice cuantos datos faltan para completar una pagina completa
            if ((int)ViewState["Resto"] == 0) // sin resto hay una cantidad de paginas completas y le debo restar uno para asegurarme que como inicio de cero la ultima pagina no se encuentre vacia
            {
                ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Paginas"] - 1;
            }
            if ((int)ViewState["Cantidad_De_Datos"] <= 20) // para saber si hay menos de 20 datos no aparezca el boton de siguiente
            {
                Siguiente_Administrador_Primero.Visible = false;
            }
        }

        protected void Siguiente_Administrador_Click(object sender, EventArgs e)
        {
            Formulario_Administrador.Visible = false;
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                Mostrar_Datos_Administrador((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Administrador.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Administrador.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Administrador_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Administrador_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                Mostrar_Datos_Administrador((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Administrador.Visible = true; // estoy en las paginas del centro
                Extremo_Administrador.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Administrador_Click(object sender, EventArgs e)
        {
            Formulario_Administrador.Visible = false;
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                Mostrar_Datos_Administrador((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Administrador.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Administrador.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Administrador_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Administrador_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                Mostrar_Datos_Administrador((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Administrador.Visible = true; // estoy en las paginas del centro
                Extremo_Administrador.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

        #region GridView_Supervisor
        public void Mostrar_Datos_Administrador(int Pagina)
        {
            GridView_Administrador.DataSource = LBPEA.Logica_Mostrar_Ejercicio((string)Session["Empresa"]).Skip(Pagina * 20).Take(20);
            GridView_Administrador.DataBind();
        }
        #endregion


        #region Seleccionar_El_Administrador_Supervisor

        protected void Identificador_Administrador(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Administrador.Visible = true;
            GridViewRow row = GridView_Administrador.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Pedido"] = GridView_Administrador.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado
            List<Seleccionar_Ejercicio_Pedido_AdministradorResult> Datos = LBPEA.Logcia_Seleccionar_Ejercicicio((int)Session["ID_Pedido"]); // carga los datos del administrador elegido por el supervisor
            CheckBox_Ejercicio_Administrador.Checked = (bool)Datos[0].Ejercicio_Pedido;
            CheckBox_Explicacion_Administrador.Checked = (bool)Datos[0].Explicacion_Pedida;
            Session["Adjunto"] = Datos[0].Archivo_Adjunto;
            Session["Ficha"] = Datos[0].Archivo_Ficha;
            Session["Enunciado"] = Datos[0].Archivo_Enunciado;

            Etiqueta_Usuario_Administrador.Text = Datos[0].Usuario;
            Etiqueta_Fecha_Administrador.Text = Datos[0].Fecha_De_Pedido.ToString();
            TextBox_Administrador_Administrador.Text = Datos[0].Administrador; // carga el administrador de la base          

           

            CheckBox_Realizado_Administrador.Checked = (bool)Datos[0].Realizado; // carga de la base si el administrador esta bloqueado

            if (CheckBox_Realizado_Administrador.Checked)
            {
                Formulario_Administrador.Visible = false;
                CheckBox_Realizado_Administrador.Enabled = false;
                TextBox_Administrador_Administrador.Enabled = false;
                Boton_No_Resolver_Administrador.Enabled = false;
                Boton_Resolver_El_Ejercicio_Administrador.Enabled = false;
                Boton_Resuelto_Administrador.Enabled = false;
                return;
            }

            if (TextBox_Administrador_Administrador.Text == string.Empty)
            {
                CheckBox_Realizado_Administrador.Enabled = false;
                TextBox_Administrador_Administrador.Enabled = true;
                Boton_No_Resolver_Administrador.Enabled = true;
                Boton_Resolver_El_Ejercicio_Administrador.Enabled = true;
                Boton_Resuelto_Administrador.Enabled = false;
                return;
            }

            if (TextBox_Administrador_Administrador.Text == (string)Session["Administrador"])
            {
                CheckBox_Realizado_Administrador.Enabled = true;
                TextBox_Administrador_Administrador.Enabled = true;
                Boton_No_Resolver_Administrador.Enabled = true;
                Boton_Resolver_El_Ejercicio_Administrador.Enabled = false;
                Boton_Resuelto_Administrador.Enabled = true;
                return;
            }
            else
            {
                CheckBox_Realizado_Administrador.Enabled = false;
                TextBox_Administrador_Administrador.Enabled = false;
                Boton_No_Resolver_Administrador.Enabled = false;
                Boton_Resolver_El_Ejercicio_Administrador.Enabled = false;
                Boton_Resuelto_Administrador.Enabled = false;
                return;
            }

        }

        #endregion
        #region Botonera_De_Supervisor
        protected void Boton_No_Resolver_Administrador_Click(object sender, EventArgs e)
        {
            TextBox_Administrador_Administrador.Text = string.Empty;

            int Valor = LBPEA.Logica_Actualizar_Ejercicio((string)Session["Administrador"], CheckBox_Realizado_Administrador.Checked, (int)Session["ID_Pedido"]);

            if (Valor == 1) // captura el error de que existe en la empresa un usuario con ese nick
            {
                string alerta = @"alert('Usted libero el ejercico para que otro administrador pueda resolverlo'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }    
        }

        protected void Boton_Resuelto_Administrador_Click(object sender, EventArgs e)
        {

            int Valor = LBPEA.Logica_Actualizar_Ejercicio(TextBox_Administrador_Administrador.Text, true, (int)Session["ID_Consulta"]);

            if (Valor == 1) // captura el error de que existe en la empresa un usuario con ese nick
            {

                string alerta = @"alert('Usted resolvio correctamente el ejercicio'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }

        }

        protected void Boton_Resolver_El_Ejercicio_Administrador_Click(object sender, EventArgs e)
        {
            int Valor = LBPEA.Logica_Actualizar_Ejercicio((string)Session["Administrador"], false, (int)Session["ID_Pedido"]);
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Usted pidio resolver este ejercicio'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

        protected void Boton_Archivo_Adjunto_Administrador_Click(object sender, EventArgs e)
        {
            if (Session["Adjunto"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('No hay archivo adjunto');", true);
                return;

            }
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Adjunto"]);
            Response.TransmitFile("C:\\archivo/" + (string)Session["Adjunto"]);
            Response.End();
        }

        protected void Boton_Archivo_Ficha_Administrador_Click(object sender, EventArgs e)
        {
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Ficha"]);
            Response.TransmitFile("C:\\archivo/" + (string)Session["Ficha"]);
            Response.End();
        }

        protected void Boton_Archivo_Enunciado_Administrador_Click(object sender, EventArgs e)
        {
            if (Session["Enunciado"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('No hay enunciado');", true);
                return;

            }
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (string)Session["Enunciado"]);
            Response.TransmitFile("C:\\archivo/" + (string)Session["Enunciado"]);
            Response.End();
        }
        #endregion
    }
}