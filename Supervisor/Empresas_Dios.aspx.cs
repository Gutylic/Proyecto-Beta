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
    public partial class Empresas_Dios : System.Web.UI.Page
    {
        Logica_Bloque_Empresas_Dios LBED = new Logica_Bloque_Empresas_Dios();

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

        #region Paginacion_Dios
        public void Condiciones_Paginacion_Dios() // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {            
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina

            ViewState["Cantidad_De_Datos"] = LBED.Logica_Contar_Empresa(); // cuenta la cantidad de datos

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
            Formulario_Dios.Visible = false; 
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
            GridView_Dios.DataSource = LBED.Logica_Mostrar_Empresa().Skip(Pagina * 20).Take(20);
            GridView_Dios.DataBind();
        }
        #endregion
            

        #region Seleccionar_El_Administrador_Dios

        protected void Identificador_Dios(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Dios.Visible = true;
            GridViewRow row = GridView_Dios.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Empresa"] = GridView_Dios.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado
            List<Seleccionar_Empresas_DiosResult> Datos = LBED.Logica_Seleccionar_Empresa((int)Session["ID_Empresa"]); // carga los datos del administrador elegido por el supervisor

            Empresa_Dios.Text = Datos[0].Empresa; // carga el administrador de la base
            Consultas_Ejercicios.Text = Datos[0].Consultas_Permitidas_Ejercicios.ToString();
            Consultas_Videos.Text = Datos[0].Consultas_Permitidas_Videos.ToString();
            
        }

        #endregion

        #region Botonera_De_Dios

        protected void Boton_Borrar_Dios_Click(object sender, EventArgs e)
        {
            int Valor = LBED.Logica_Borrar_Empresa((int)Session["ID_Empresa"]); // Borrar el administrador
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Empresa borrada correctamente'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                
                return;
            }
        }

        protected void Boton_Nuevo_Dios_Click(object sender, EventArgs e)
        {
            if (Boton_Nuevo_Dios.Text == "Insertar")
            {
                int Valor = LBED.Logica_Insertar_Empresa(Empresa_Dios.Text, int.Parse(Consultas_Ejercicios.Text), int.Parse(Consultas_Videos.Text)); // analiza la insercion
                
                if (Valor == 0) // captura el error de que el nick ya existe
                {
                    string alerta = @"alert('Error al crear la empresa'); 

                    window.location.reload();";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                    return;
                }
                
                Formulario_Dios.Visible = true;
                Boton_Nuevo_Dios.Text = "Nuevo";
                string OK = @"alert('Empresa creada correctamente'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", OK, true);
                
                return;
               
            }
            if (Boton_Nuevo_Dios.Text == "Nuevo")
            {
                Boton_Nuevo_Dios.Text = "Insertar";
                Formulario_Dios.Visible = true;
                Empresa_Dios.Text = string.Empty;
                Consultas_Ejercicios.Text = string.Empty;
                Consultas_Videos.Text = string.Empty;               
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
            GridView_Dios.DataSource = LBED.Logica_Mostrar_Empresa();
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