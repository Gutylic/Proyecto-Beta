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
    public partial class Panel_De_Control_Dios : System.Web.UI.Page
    {
        Logica_Bloque_Panel_De_Control_Dios LBPDCD = new Logica_Bloque_Panel_De_Control_Dios();

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

            
            Condiciones_Paginacion_Dios(string.Empty, string.Empty);
            Mostrar_Datos_Dios(string.Empty, string.Empty, 0);            
          
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }


        #region Paginacion_Dios
        public void Condiciones_Paginacion_Dios(string Empresa, string Administrador) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            if (Administrador == null) { Administrador = string.Empty; } // limpia la variable administrador si viene vacia
            if (Empresa == null) { Empresa = string.Empty; } // limpia la variable empresa si viene vacia
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = LBPDCD.Logica_Contar_Administradores(Empresa, Administrador); // cuenta la cantidad de datos
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
            if (Session["Buscar_1"] == null) { Session["Buscar_1"] = string.Empty; } // este dato trae la empresa y lo limpio por si viene vacio
            if (Session["Buscar_2"] == null) { Session["Buscar_2"] = string.Empty; } // este dato trae al administrador y lo limpio por si viene vacio
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                Mostrar_Datos_Dios((string)Session["Buscar_2"], (string)Session["Buscar_1"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Dios.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Dios_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                Mostrar_Datos_Dios((string)Session["Buscar_2"], (string)Session["Buscar_1"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Dios_Click(object sender, EventArgs e)
        {
            Formulario_Dios.Visible = false;
            if (Session["Buscar_1"] == null) { Session["Buscar_1"] = string.Empty; } // este dato trae la empresa y lo limpio por si viene vacio
            if (Session["Buscar_2"] == null) { Session["Buscar_2"] = string.Empty; } // este dato trae al administrador y lo limpio por si viene vacio
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                Mostrar_Datos_Dios((string)Session["Buscar_2"], (string)Session["Buscar_1"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Dios.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Dios_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Dios_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                Mostrar_Datos_Dios((string)Session["Buscar_2"], (string)Session["Buscar_1"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Dios.Visible = true; // estoy en las paginas del centro
                Extremo_Dios.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

        #region GridView_Dios
        public void Mostrar_Datos_Dios(string Empresa, string Administrador, int Pagina)
        {
            if (Administrador == null) { Administrador = string.Empty; } // vacio la variable administrador por las dudas que llegue vacia
            if (Empresa == null) { Empresa = string.Empty; } // vacio la variable empresa por las dudas que llegue vacia
            GridView_Dios.DataSource = LBPDCD.Logica_Mostrar_Administradores(Empresa, Administrador).Skip(Pagina * 20).Take(20);
            GridView_Dios.DataBind();
        }
        #endregion

        #region Buscar_Supervisor
        protected void Boton_Buscar_Dios_Click(object sender, EventArgs e)
        {
            Formulario_Dios.Visible = false;
            if (int.Parse(DropDownList_Dios.SelectedValue) == 1) // selecionada vacio
            {
                Condiciones_Paginacion_Dios(string.Empty, string.Empty); // envio al paginado todo vacio
                Mostrar_Datos_Dios(string.Empty, string.Empty, 0); // envio al grid todo vacio el cero es la pagina a empezar
            }
            if (int.Parse(DropDownList_Dios.SelectedValue) == 2) // seleccionada el administrador
            {
                Condiciones_Paginacion_Dios(string.Empty, Buscar_Dios.Text); // envio el administrador y no la empresa al paginado
                Session["Buscar_1"] = Buscar_Dios.Text; // carga una variable de session con el administrador que es utilizada al aplicar el paginado
                Session["Buscar_2"] = null; // envia la variable empresa vacia
                Mostrar_Datos_Dios(string.Empty, Buscar_Dios.Text, 0); // envia el grid solo la empresa el 0 es la pagina a empezar
            }
            if (int.Parse(DropDownList_Dios.SelectedValue) == 3) // seleccionada la empresa
            {
                Condiciones_Paginacion_Dios(Buscar_Dios.Text, string.Empty); // envio la empresa al paginado no el administrador
                Session["Buscar_1"] = null; // variable de session de administrador vacia
                Session["Buscar_2"] = Buscar_Dios.Text;// carga una variable de session con la empresa que es utilizada al aplicar el paginado
                Mostrar_Datos_Dios(Buscar_Dios.Text, string.Empty, 0);
            }
        }
        #endregion

        #region Seleccionar_Administrador_Dios

        protected void Identificador_Dios(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Dios.Visible = true;
            GridViewRow row = GridView_Dios.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Administrador"] = GridView_Dios.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado
            List<Seleccionar_Administradores_DiosResult> Datos = LBPDCD.Logica_Seleccionar_Administradores((int)Session["ID_Administrador"]); // carga los datos del administrador elegido por el supervisor
            Administrador_Dios.Text = Datos[0].Administrador; // carga el administrador de la base
            Password_Dios.Text = Datos[0].Password; // carga el password de la base
            Empresa_Dios.Text = Datos[0].Empresa;            
            IP_Dios.Text = Datos[0].IP_Address; // carga el IP de la base este ip corresponde desde la ubicacion que se bloqueo el administrador
            CheckBox_Bloqueo_Dios.Checked = Datos[0].Administrador_Bloqueado; // carga de la base si el administrador esta bloqueado
        }

        #endregion

        #region Botonera_De_Supervisor
        protected void Boton_Actualizar_Dios_Click(object sender, EventArgs e)
        {
            if (Password_Dios.Text.Length < 5) // error de cantidad de caracteres en el password
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en algunos datos insertados');", true);
                return;
            }            
            int Valor = LBPDCD.Logica_Actualizar_Administradores((int)Session["ID_Administrador"], Empresa_Dios.Text, Administrador_Dios.Text, Password_Dios.Text, IP_Dios.Text, CheckBox_Bloqueo_Dios.Checked);
            if (Valor == 0) // captura el error de que existe en la empresa un usuario con ese nick
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en algunos datos insertados');", true);
                return;
            }
            if (Valor == 2) // controla la existencia de la empresa
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en algunos datos insertados');", true);
                return;
            }
            string alerta = @"alert('Administrador / Supervisor actualizado correctamente'); 

                window.location.reload();";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
            return;
        }

        protected void Boton_Nuevo_Dios_Click(object sender, EventArgs e)
        {

            if (Boton_Nuevo_Dios.Text == "Insertar")
            {
                if (Password_Dios.Text.Length < 5) // capta el error de la cantidad de caracteres del password
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en algunos datos insertados');", true);
                    return;
                }                
                int Valor = LBPDCD.Logica_Insertar_Administradores(Administrador_Dios.Text, Password_Dios.Text, Empresa_Dios.Text); // analiza la insercion
                if (Valor == 0) // captura el error de que el nick ya existe
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en algunos datos insertados');", true);
                    return;
                }
                if (Valor == 2) // controla si existe la empresa
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en algunos datos insertados');", true);
                    return;
                }
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Administrador / Supervisor creado correctamente');", true); // todo ok
                Formulario_Dios.Visible = true;
                Boton_Nuevo_Dios.Text = "Nuevo";
                return;
            }

            if (Boton_Nuevo_Dios.Text == "Nuevo")
            {
                Boton_Nuevo_Dios.Text = "Insertar";
                Formulario_Dios.Visible = true;
                Administrador_Dios.Text = string.Empty;
                Password_Dios.Text = string.Empty;
                Empresa_Dios.Text = string.Empty;
               
                IP_Dios.Text = string.Empty;
                CheckBox_Bloqueo_Dios.Checked = false;
            }

        }
     
        protected void Boton_Borrar_Dios_Click(object sender, EventArgs e)
        {
            int Valor = LBPDCD.Logica_Borrar_Administradores((int)Session["ID_Administrador"]); // Borrar el administrador
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Administrador / Supervisor borrado correctamente'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

        protected void Boton_Excel_Dios_Click(object sender, EventArgs e)
        {
            if (Session["Buscar_1"] == null) { Session["Buscar_1"] = string.Empty; } // limpia las variables por las dudaspor si llegan vacios
            if (Session["Buscar_2"] == null) { Session["Buscar_2"] = string.Empty; } // limpia las variables por las dudas por si llegan vacios
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();
            GridView_Dios.DataSourceID = string.Empty;
            GridView_Dios.EnableViewState = false;
            GridView_Dios.AllowPaging = false;
            GridView_Dios.DataSource = LBPDCD.Logica_Mostrar_Administradores((string)Session["Buscar_1"], (string)Session["Buscar_2"]);
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



