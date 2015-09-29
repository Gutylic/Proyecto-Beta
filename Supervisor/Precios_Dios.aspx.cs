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
    public partial class Precios_Dios : System.Web.UI.Page
    {
        Logica_Bloque_Precios_Dios LBPD = new Logica_Bloque_Precios_Dios();

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
                Condiciones_Paginacion_Dios();
                Mostrar_Datos_Dios(0);

            }
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        #region Paginacion_Supervisor
        public void Condiciones_Paginacion_Dios() // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {

            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = LBPD.Logica_Contar_Precios(); // cuenta la cantidad de datos
            ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Datos"] / 20; // cantidad de paginas segun la cantidad de datos            
            ViewState["Resto"] = (int)ViewState["Cantidad_De_Datos"] % 20; // me dice cuantos datos faltan para completar una pagina completa
            if ((int)ViewState["Resto"] == 0) // sin resto hay una cantidad de paginas completas y le debo restar uno para asegurarme que como inicio de cero la ultima pagina no se encuentre vacia
            {
                ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Paginas"] - 1;
            }
            if ((int)ViewState["Cantidad_De_Datos"] <= 20) // para saber si hay menos de 20 datos no aparezca el boton de siguiente
            {
                Siguiente_Dios_Primero.Visible = false;
            }
        }

        protected void Siguiente_Dios_Click(object sender, EventArgs e)
        {

            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                Mostrar_Datos_Dios((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Dios.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Dios_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                Mostrar_Datos_Dios((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Dios_Click(object sender, EventArgs e)
        {

            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                Mostrar_Datos_Dios((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Dios.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Dios_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                Mostrar_Datos_Dios((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

        #region GridView_Dios
        public void Mostrar_Datos_Dios(int Pagina)
        {
            GridView_Dios.DataSource = LBPD.Logica_Mostrar_Precios().Skip(Pagina * 20).Take(20);
            GridView_Dios.DataBind();
        }
        #endregion
        protected void Boton_Excel_Dios_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();
            GridView_Dios.DataSourceID = string.Empty;
            GridView_Dios.EnableViewState = false;
            GridView_Dios.AllowPaging = false;
            GridView_Dios.DataSource = LBPD.Logica_Mostrar_Precios();
            GridView_Dios.DataBind();
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView_Dios);
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