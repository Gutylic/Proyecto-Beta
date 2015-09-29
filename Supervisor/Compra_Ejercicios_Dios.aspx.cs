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
    public partial class Compra_Ejercicios_Dios : System.Web.UI.Page
    {
        Logica_Bloque_Comprar_Ejercicios_Dios LBCED = new Logica_Bloque_Comprar_Ejercicios_Dios();

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

            if (LBCED.Logica_Contar_Ejercicios(string.Empty, 1) == null)
            {
                Extremo_Dios.Visible = false;
                Interno_Dios.Visible = false;
                return;
            
            }


                Session["Opcion"] = 1;
                Condiciones_Paginacion_Dios(string.Empty);
                Mostrar_Datos_Dios(string.Empty, 0);
            
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        #region Paginacion_Supervisor
        public void Condiciones_Paginacion_Dios(string Dato) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            if (Dato == null) { Dato = string.Empty; } // limpia de problemas si administrador llega vacio
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina

            ViewState["Cantidad_De_Datos"] = LBCED.Logica_Contar_Ejercicios(Dato, (int)Session["Opcion"]);// cuenta la cantidad de datos

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
            Formulario_Dios.Visible = false;
            if (Session["Buscar"] == null) { Session["Buscar"] = string.Empty; }
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                Mostrar_Datos_Dios((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Dios.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Dios_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                Mostrar_Datos_Dios((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Dios_Click(object sender, EventArgs e)
        {
            Formulario_Dios.Visible = false;
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                Mostrar_Datos_Dios((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview

                Interno_Dios.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Dios.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Dios_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                Mostrar_Datos_Dios((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

        #region GridView_Supervisor
        public void Mostrar_Datos_Dios(string Datos, int Pagina)
        {
            GridView_Dios.DataSource = LBCED.Logica_Mostrar_Ejercicios(Datos, (int)Session["Opcion"]).Skip(Pagina * 20).Take(20);
            GridView_Dios.DataBind();
        }
        #endregion

        #region Buscar_Supervisor
        protected void Boton_Buscar_Dios_Click(object sender, EventArgs e)
        {
            Formulario_Dios.Visible = false;
            Session["Opcion"] = int.Parse(DropDownList_Dios.SelectedValue);
            Session["Buscar"] = Buscar_Dios.Text; // carga la variable de session para enviar a la paginacion
            Condiciones_Paginacion_Dios(Buscar_Dios.Text); // paginacion       
            Mostrar_Datos_Dios(Buscar_Dios.Text, 0); // llama al gridview
        }
        #endregion

        #region Seleccionar_El_Administrador_Supervisor

        protected void Identificador_Dios(object sender, EventArgs e) // convierto al datalist en editable 
        {


            if (LBCED.Logica_Contar_Ejercicios(string.Empty, 1) == null)
            {
                Mostrar_Datos_Dios(string.Empty, 0);
                Formulario_Dios.Visible = false;
                return;

            }


            Formulario_Dios.Visible = true;
            GridViewRow row = GridView_Dios.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Compra"] = GridView_Dios.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado
            List<Seleccionar_Ejercicio_DiosResult> Datos = LBCED.Logica_Seleccionar_Ejercicio((int)Session["ID_Compra"]); // carga los datos del administrador elegido por el supervisor

            Usuario_Dios.Text = Datos[0].Usuario; // administrador traido de la base de datos
            Titulo_Dios.Text = Datos[0].Titulo; // password traido de la base de datos
            Correo_Dios.Text = Datos[0].Correo; // Empresa traida de la base de datos
            Duracion_Dios.Text = Datos[0].Dias_Que_Restan_Para_Usar_El_Producto.ToString(); // Categoria traida de la base de datos
            Empresa_Dios.Text = Datos[0].Empresa.ToString();


        }

        #endregion

        #region Botonera_De_Supervisor

        protected void Boton_Borrar_Dios_Click(object sender, EventArgs e)
        {
            int Valor = LBCED.Logica_Borrar_Ejercicios((int)Session["ID_Compra"]); // Borrar el administrador
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Ejercicio correctamente borrado'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

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
            GridView_Dios.DataSource = LBCED.Logica_Mostrar_Ejercicios((string)Session["Buscar"], (int)Session["Opcion"]);
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

        #endregion


    }
}