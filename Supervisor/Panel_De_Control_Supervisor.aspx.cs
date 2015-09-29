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
    public partial class Panel_De_Control_Supervisor : System.Web.UI.Page
    {
        Logica_Bloque_Panel_De_Control_Supervisor LBPDCS = new Logica_Bloque_Panel_De_Control_Supervisor();

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
                       
            if (LBPDCS.Logica_Contar_Administradores((string)Session["Empresa"], (string)Session["Administrador"]) == null)
            {
                Extremo_Supervisor.Visible = false;
                Interno_Supervisor.Visible = false;
                return;
            }

            Condiciones_Paginacion_Supervisor(string.Empty);
            Mostrar_Datos_Supervisor(string.Empty, 0);

        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }


        #region Paginacion_Supervisor
        public void Condiciones_Paginacion_Supervisor(string Administrador) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            if (Administrador == null) { Administrador = string.Empty; } // limpia de problemas si administrador llega vacio
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = LBPDCS.Logica_Contar_Administradores((string)Session["Empresa"], Administrador); // cuenta la cantidad de datos
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
            if (Session["Buscar"] == null) { Session["Buscar"] = string.Empty; }
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
            Formulario_Supervisor.Visible = true;
            if (Session["Buscar"] == null) { Session["Buscar"] = string.Empty; }
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

        #region GridView_Supervisor
        public void Mostrar_Datos_Supervisor(string Administrador, int Pagina)
        {
            if (Administrador == null) { Administrador = string.Empty; } // limpia las impurezas de la variabla Administrador si llega vacia
            GridView_Supervisor.DataSource = LBPDCS.Logica_Mostrar_Administradores((string)Session["Empresa"], Administrador).Skip(Pagina * 20).Take(20);
            GridView_Supervisor.DataBind();
        }
        #endregion

        #region Buscar_Supervisor
        protected void Boton_Buscar_Supervisor_Click(object sender, EventArgs e)
        {
            Formulario_Supervisor.Visible = false;
            Condiciones_Paginacion_Supervisor(Buscar_Supervisor.Text); // paginacion
            Session["Buscar"] = Buscar_Supervisor.Text; // carga la variable de session para enviar a la paginacion
            Mostrar_Datos_Supervisor(Buscar_Supervisor.Text, 0); // llama al gridview
        }
        #endregion

        #region Seleccionar_El_Administrador_Supervisor

        protected void Identificador_Supervisor(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Supervisor.Visible = true;
            GridViewRow row = GridView_Supervisor.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Administrador"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado
            List<Seleccionar_Administradores_SupervisorResult> Datos = LBPDCS.Logica_Seleccionar_Administradores((int)Session["ID_Administrador"]); // carga los datos del administrador elegido por el supervisor
            Administrador_Supervisor.Text = Datos[0].Administrador; // carga el administrador de la base
            Password_Supervisor.Text = Datos[0].Password; // carga el password de la base

            IP_Supervisor.Text = Datos[0].IP_Address; // carga el IP de la base este ip corresponde desde la ubicacion que se bloqueo el administrador
            CheckBox_Bloqueo_Supervisor.Checked = Datos[0].Administrador_Bloqueado; // carga de la base si el administrador esta bloqueado
        }

        #endregion

        #region Botonera_De_Supervisor
        protected void Boton_Actualizar_Supervisor_Click(object sender, EventArgs e)
        {
            if (Password_Supervisor.Text.Length < 5) // error de cantidad de caracteres en el password
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en algunos datos insertados');", true);
                return;
            }
            int Valor = LBPDCS.Logica_Actualizar_Administradores((int)Session["ID_Administrador"], (string)Session["Empresa"], Administrador_Supervisor.Text, Password_Supervisor.Text, IP_Supervisor.Text, CheckBox_Bloqueo_Supervisor.Checked);
            if (Valor == 0) // captura el error de que existe en la empresa un usuario con ese nick
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el administrador / supervisor');", true);
                return;
            }
            string alerta = @"alert('Administrador / Supervisor actualizado correctamente'); 
                window.location.reload();";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
            return;
        }

        protected void Boton_Nuevo_Supervisor_Click(object sender, EventArgs e)
        {

            if (Boton_Nuevo_Supervisor.Text == "Insertar")
            {

                if (Password_Supervisor.Text.Length < 5) // capta el error de la cantidad de caracteres del password
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en algunos datos insertados');", true);
                    return;
                }

                int Valor = LBPDCS.Logica_Insertar_Administradores(Administrador_Supervisor.Text, Password_Supervisor.Text, (string)Session["Empresa"]); // analiza la insercion
                if (Valor == 0) // captura el error de que el nick ya existe
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el administrador / supervisor');", true);
                    return;
                }
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Administrador / Supervisor creado correctamente');", true); // todo ok
                Formulario_Supervisor.Visible = true;
                Boton_Nuevo_Supervisor.Text = "Nuevo";
                return;

            }

            if (Boton_Nuevo_Supervisor.Text == "Nuevo")
            {
                Boton_Nuevo_Supervisor.Text = "Insertar";
                Administrador_Supervisor.Text = string.Empty;
                Password_Supervisor.Text = string.Empty;
                IP_Supervisor.Text = string.Empty;
                CheckBox_Bloqueo_Supervisor.Checked = false;
            }

        }

        protected void Boton_Borrar_Supervisor_Click(object sender, EventArgs e)
        {
            int Valor = LBPDCS.Logica_Borrar_Administradores((int)Session["ID_Administrador"]); // Borrar el administrador
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Administrador / Supervisor borrado correctamente'); 
                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

        protected void Boton_Excel_Supervisor_Click(object sender, EventArgs e)
        {
            if (Session["Buscar"] == null) { Session["Buscar"] = string.Empty; } // limpia las variables convirtiendolas si vienen vacias
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();
            GridView_Supervisor.DataSourceID = string.Empty;
            GridView_Supervisor.EnableViewState = false;
            GridView_Supervisor.AllowPaging = false;
            GridView_Supervisor.DataSource = LBPDCS.Logica_Mostrar_Administradores((string)Session["Empresa"], (string)Session["Buscar"]);
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

        #endregion

    }
}