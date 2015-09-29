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
    public partial class Pedido_Explicacion_Supervisor : System.Web.UI.Page
    {
        Logica_Bloque_Pedido_Explicacion_Supervisor LBPES = new Logica_Bloque_Pedido_Explicacion_Supervisor();
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

            Condiciones_Paginacion_Supervisor();
            Mostrar_Datos_Supervisor(0);
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        #region Paginacion_Supervisor
        public void Condiciones_Paginacion_Supervisor() // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {

            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = LBPES.Logica_Contar_Cantidad_Explicacion((string)Session["Empresa"]); // cuenta la cantidad de datos
            ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Datos"] / 20; // cantidad de paginas segun la cantidad de datos            
            ViewState["Resto"] = (int)ViewState["Cantidad_De_Datos"] % 20; // me dice cuantos datos faltan para completar una pagina completa
            if ((int)ViewState["Resto"] == 0) // sin resto hay una cantidad de paginas completas y le debo restar uno para asegurarme que como inicio de cero la ultima pagina no se encuentre vacia
            {
                ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Paginas"] - 1;
            }
            if ((int)ViewState["Cantidad_De_Datos"] <= 20) // para saber si hay menos de 20 datos no aparezca el boton de siguiente
            {
                Siguiente_Supervisor_Primero.Visible = false;
            }
        }

        protected void Siguiente_Supervisor_Click(object sender, EventArgs e)
        {
            Formulario_Supervisor.Visible = false;
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                Mostrar_Datos_Supervisor((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Supervisor.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Supervisor_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Supervisor_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                Mostrar_Datos_Supervisor((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = true; // estoy en las paginas del centro
                Extremo_Supervisor.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Supervisor_Click(object sender, EventArgs e)
        {
            Formulario_Supervisor.Visible = false;
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                Mostrar_Datos_Supervisor((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Supervisor.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Supervisor_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Supervisor_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                Mostrar_Datos_Supervisor((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = true; // estoy en las paginas del centro
                Extremo_Supervisor.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

        #region GridView_Supervisor
        public void Mostrar_Datos_Supervisor(int Pagina)
        {
            GridView_Supervisor.DataSource = LBPES.Logica_Mostrar_Explicacion((string)Session["Empresa"]).Skip(Pagina * 20).Take(20);
            GridView_Supervisor.DataBind();
        }
        #endregion


        #region Seleccionar_El_Supervisor_Supervisor

        protected void Identificador_Supervisor(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Supervisor.Visible = true;
            GridViewRow row = GridView_Supervisor.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Consulta"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // captura el identificador del Supervisor seleccionado
            List<Seleccionar_Explicacion_Pedida_SupervisorResult> Datos = LBPES.Logcia_Seleccionar_Explicacion((int)Session["ID_Consulta"]); // carga los datos del Supervisor elegido por el supervisor
            Etiqueta_Numero_De_Ejercicio_Supervisor.Text = Datos[0].ID_Ejercicio.ToString();
            Etiqueta_Usuario_Supervisor.Text = Datos[0].Usuario;
            Etiqueta_Fecha_Supervisor.Text = Datos[0].Fecha_De_Pedido.ToString();
            TextBox_Administrador_Supervisor.Text = Datos[0].Administrador;
            CheckBox_Realizado_Supervisor.Checked = (bool)Datos[0].Realizado;

        }

        #endregion
        #region Botonera_De_Supervisor
        protected void Boton_No_Resolver_Supervisor_Click(object sender, EventArgs e)
        {
            TextBox_Administrador_Supervisor.Text = string.Empty;

            int Valor = LBPES.Logica_Actualizar_Explicacion(string.Empty, false, (int)Session["ID_Consulta"]);

            if (Valor == 1) // captura el error de que existe en la empresa un usuario con ese nick
            {
                string alerta = @"alert('Usted libero el ejercico para que otro administrador pueda resolverlo'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }    

        }

        protected void Boton_Borrar_Supervisor_Click(object sender, EventArgs e)
        {
            int Valor = LBPES.Logica_Borrar_Explicacion((int)Session["ID_Consulta"]); // Borrar el administrador
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Usted borro corectamente la consulta'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

        protected void Boton_Resolver_El_Ejercicio_Supervisor_Click(object sender, EventArgs e)
        {
            int Valor = LBPES.Logica_Actualizar_Explicacion((string)Session["Administrador"], false, (int)Session["ID_Consulta"]);
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Usted pidio resolver este ejercicio'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

        protected void Boton_Resuelto_Supervisor_Click(object sender, EventArgs e)
        {
            int Valor = LBPES.Logica_Actualizar_Explicacion(TextBox_Administrador_Supervisor.Text, true, (int)Session["ID_Consulta"]);

            if (Valor == 1) // captura el error de que existe en la empresa un usuario con ese nick
            {

                string alerta = @"alert('Usted resolvio correctamente el ejercicio'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }

        }

        #endregion
    }
}
