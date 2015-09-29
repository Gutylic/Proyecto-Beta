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
    public partial class Cargar_Credito_Manual_Supervisor : System.Web.UI.Page
    {

        Logica_Bloque_Carga_Manual_Credito_Supervisor LBCMCS = new Logica_Bloque_Carga_Manual_Credito_Supervisor();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null || Session["www"] == null)
            {
                Response.Redirect("sefue.aspx");
            }
            
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                Etiqueta_Administrador_Chico.Text = ((string)Session["Administrador"]).ToUpper();
                Etiqueta_Administrador_Grande.Text = ((string)Session["Administrador"]).ToUpper();
                Etiqueta_Hora_Grande.Text = DateTime.Now.ToString();
                Etiqueta_Hora_Chica.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                Etiqueta_Localizador_Grande.Text = Request.UserHostAddress.ToString();
                Etiqueta_Localizador_Chico.Text = Request.UserHostAddress.ToString();
            }
            
            switch(int.Parse(Request.QueryString["Variable"]))
            {
                case 5:
                    Boton_Actualizar_Supervisor.Enabled = true;
                    Boton_Buscar_Supervisor.Enabled = true;
                    Boton_Excel_Supervisor.Enabled = false;
                    break;
                case 6:
                     Boton_Actualizar_Supervisor.Enabled = true;
                    Boton_Buscar_Supervisor.Enabled = true;
                    Boton_Excel_Supervisor.Enabled = true;
                    break;
            }


            
                
                Session["Opcion"] = 1;
                Condiciones_Paginacion_Supervisor(string.Empty);
                Mostrar_Datos_Supervisor(string.Empty, 0);
            
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        #region Paginacion_Supervisor
        public void Condiciones_Paginacion_Supervisor(string Datos) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {

            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = LBCMCS.Logica_Contar_Carga_Credito_Supervisor(Datos, (int)Session["Opcion"], (string)Session["Empresa"]); // cuenta la cantidad de datos
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
                Mostrar_Datos_Supervisor((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Supervisor.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Supervisor_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Supervisor_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                Mostrar_Datos_Supervisor((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
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
                Mostrar_Datos_Supervisor((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Supervisor.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Supervisor_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Supervisor_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                Mostrar_Datos_Supervisor((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = true; // estoy en las paginas del centro
                Extremo_Supervisor.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

        #region GridView_Administrador
        public void Mostrar_Datos_Supervisor(string Datos, int Pagina)
        {
            GridView_Supervisor.DataSource = LBCMCS.Logica_Mostrar_Carga_Credito_Supervisor(Datos, (int)Session["Opcion"], (string)Session["Empresa"]).Skip(Pagina * 20).Take(20);
            GridView_Supervisor.DataBind();
        }
        #endregion

        #region Buscar_Supervisor
        protected void Boton_Buscar_Supervisor_Click(object sender, EventArgs e)
        {
            Formulario_Supervisor.Visible = false;
            Session["Opcion"] = int.Parse(DropDownList_Supervisor.SelectedValue);
            Session["Buscar"] = Buscar_Supervisor.Text;

            Condiciones_Paginacion_Supervisor((string)Session["Buscar"]);
            Mostrar_Datos_Supervisor((string)Session["Buscar"], 0);


        }




        #endregion


        protected void Identificador_Supervisor(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Supervisor.Visible = true;
            GridViewRow row = GridView_Supervisor.SelectedRow; // declaro una variable del tipo de gridview
            Session["ID_Usuario"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // capturo el identificador del dato presionado
            List<Seleccionar_Carga_De_Credito_SupervisorResult> Datos = LBCMCS.Logica_Seleccionar_Carga_Credito_Manual(int.Parse(Session["ID_Usuario"].ToString()));
            Usuario_Supervisor.Text = Datos[0].Usuario;
            Correo_Supervisor.Text = Datos[0].Correo;

            Credito_Supervisor.Text = Datos[0].Credito_De_Usuario.ToString();
            

        }

        protected void Boton_Actualizar_Supervisor_Click(object sender, EventArgs e)
        {
            try
            {


                if (LBCMCS.Logica_Actualizar_Carga_Credito_Supervisor((int)Session["ID_Usuario"], decimal.Parse(Credito_Supervisor.Text), int.Parse(DropDownList_Carga.SelectedValue), (string)Session["Administrador"]) == 1)
                {

                    string alerta = @"alert('Crédito cargado correctamente'); 

                window.location.reload();";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                    return;

                }

                string error = @"alert('El crédito no se cargo correctamente'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", error, true);
                return;
            }
            catch
            {
                string error = @"alert('El crédito no puede contener letras'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", error, true);
                return;
            }
        }

        protected void Boton_Excel_Supervisor_Click(object sender, EventArgs e)
        {
            if (Session["Buscar"] == null) { Session["Buscar"] = string.Empty; } // limpia las variables por las dudaspor si llegan vacios

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();
            GridView_Supervisor.DataSourceID = string.Empty;
            GridView_Supervisor.EnableViewState = false;
            GridView_Supervisor.AllowPaging = false;
            GridView_Supervisor.DataSource = LBCMCS.Logica_Mostrar_Carga_Credito_Supervisor((string)Session["Buscar"], (int)Session["Opcion"], (string)Session["Empresa"]);
            GridView_Supervisor.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Supervisor);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "applicattion/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }
        


    }
}