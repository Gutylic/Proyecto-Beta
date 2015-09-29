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
    public partial class Panel_De_Control_Usuario_Supervisor : System.Web.UI.Page
    {
        Logica_Bloque_Panel_De_Control_Usuario_Supervisor LBPDCUS = new Logica_Bloque_Panel_De_Control_Usuario_Supervisor();

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
            Session["Buscar"] = string.Empty;

            if (DropDownList_Supervisor.SelectedValue == "5")
            {
                Buscar_Supervisor_Fecha.Visible = true;
                DropDownList_Buscar_Supervisor.Visible = false;
                Buscar_Supervisor.Visible = false;
            }
            if (DropDownList_Supervisor.SelectedValue == "2" || DropDownList_Supervisor.SelectedValue == "3")
            {
                Buscar_Supervisor_Fecha.Visible = false;
                DropDownList_Buscar_Supervisor.Visible = false;
                Buscar_Supervisor.Visible = true;
            }
            if (DropDownList_Supervisor.SelectedValue == "4")
            {
                Buscar_Supervisor_Fecha.Visible = false;
                DropDownList_Buscar_Supervisor.Visible = true;
                Buscar_Supervisor.Visible = false;
            }


            switch (int.Parse(Request.QueryString["Variable"]))
            {
                case 5:
                    Boton_Excel_Supervisor.Enabled = false;
                    Boton_Borrar_Supervisor.Enabled = false;
                    Boton_Actualizar_Supervisor.Enabled = false;
                    Boton_Nuevo_Supervisor.Enabled = false;
                    break;

                case 6:
                    Boton_Excel_Supervisor.Enabled = false;
                    Boton_Borrar_Supervisor.Enabled = false;
                    Boton_Actualizar_Supervisor.Enabled = false;
                    Boton_Nuevo_Supervisor.Enabled = true;
                    break;


                case 9:
                    Boton_Excel_Supervisor.Enabled = true;
                    Boton_Borrar_Supervisor.Enabled = true;
                    Boton_Actualizar_Supervisor.Enabled = true;
                    Boton_Nuevo_Supervisor.Enabled = true;
                    break;

            }

            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                Session["Opcion"] = 1;
                Condiciones_Paginacion_Supervisor(string.Empty);
                Mostrar_Datos_Supervisor(string.Empty, 0);
            }

        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }


        #region Paginacion_Supervisor
        public void Condiciones_Paginacion_Supervisor(string Datos) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            Formulario_Supervisor.Visible = false;
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = LBPDCUS.Logica_Contar_Usuarios(Datos, (int)Session["Variable_ID_Empresa"], (int)Session["Opcion"]); // cuenta la cantidad de datos
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
        public void Mostrar_Datos_Supervisor(string Datos, int Pagina)
        {
            GridView_Supervisor.DataSource = LBPDCUS.Logica_Mostrar_Usuario(Datos, (int)Session["Variable_ID_Empresa"], (int)Session["Opcion"]).Skip(Pagina * 20).Take(20);
            GridView_Supervisor.DataBind();
        }
        #endregion

        #region Buscar_Supervisor
        protected void Boton_Buscar_Supervisor_Click(object sender, EventArgs e)
        {
            Formulario_Supervisor.Visible = false;
            Session["Opcion"] = int.Parse(DropDownList_Supervisor.SelectedValue);
            //Session["Buscar"] = Buscar_Supervisor.Text;
            if (DropDownList_Supervisor.SelectedValue == "5")
            {
                Session["Buscar"] = Buscar_Supervisor_Fecha.Text;
            }
            if (DropDownList_Supervisor.SelectedValue == "2" || DropDownList_Supervisor.SelectedValue == "3")
            {
                Session["Buscar"] = Buscar_Supervisor.Text;
            }
            if (DropDownList_Supervisor.SelectedValue == "4")
            {
                Session["Buscar"] = DropDownList_Buscar_Supervisor.SelectedValue;
            }

            Condiciones_Paginacion_Supervisor((string)Session["Buscar"]);
            Mostrar_Datos_Supervisor((string)Session["Buscar"], 0);
        }

        protected void Identificador_Supervisor(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Supervisor.Visible = true;


            GridViewRow row = GridView_Supervisor.SelectedRow; // declaro una variable del tipo de gridview
            Session["ID_Usuario"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // capturo el identificador del dato presionado
            List<Seleccionar_Usuario_SupervisorResult> Datos = LBPDCUS.Logica_Seleccionar_Usuario(int.Parse(Session["ID_Usuario"].ToString()));
            Usuario_Supervisor.Text = Datos[0].Usuario.ToString();
            Correo_Supervisor.Text = Datos[0].Correo.ToString();
            if (Datos[0].Usuario_De_Skype != null) { Skype_Supervisor.Text = Datos[0].Usuario_De_Skype.ToString(); }

            if (Datos[0].Numero_De_Celular != null) { Celular_Supervisor.Text = Datos[0].Numero_De_Celular.ToString(); }

            if (Datos[0].Modelo_De_Celular != null) { Modelo_Supervisor.Text = Datos[0].Modelo_De_Celular.ToString(); }

            Credito_Supervisor.Text = Datos[0].Credito_De_Usuario.ToString();
            Session["Comparar_Correo"] = Correo_Supervisor.Text;
            CheckBox_Pedido_Supervisor.Checked = Datos[0].Pedido_De_Prestamo;
            CheckBox_Activacion_Supervisor.Checked = Datos[0].Activacion_De_Usuarios;

        }


        #endregion

        #region Botonera_De_Supervisor
        protected void Boton_Actualizar_Supervisor_Click(object sender, EventArgs e)
        {

            if (Session["Comparar_Correo"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el correo');", true);
                return;
            }


            int Valor = LBPDCUS.Logica_Actualizar_Usuario(Session["Comparar_Correo"].ToString(), CheckBox_Activacion_Supervisor.Checked, (int)Session["ID_Usuario"], (int)Session["Variable_ID_Empresa"], Correo_Supervisor.Text.ToLower(), Skype_Supervisor.Text, Celular_Supervisor.Text, Modelo_Supervisor.Text, Usuario_Supervisor.Text);

            switch (Valor)
            {
                case 0:
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el correo');", true);
                    break;
                case 1:
                    string alerta = @"alert('Usuario correctamente actualizado'); 
                    window.location.reload();";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                    return;
                case -1:
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en la creación del usuario');", true);
                    break;
            }
        }

        protected void Boton_Nuevo_Supervisor_Click(object sender, EventArgs e)
        {


            if (Boton_Nuevo_Supervisor.Text == "Insertar")
            {

                int Valor = LBPDCUS.Logica_Insertar_Usuario(Usuario_Supervisor.Text, Correo_Supervisor.Text, (int)Session["Variable_ID_Empresa"], (string)Session["Administrador"]); // analiza la insercion

                switch (Valor)
                {
                    case 0:
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el usuario');", true);
                        return;
                    case 1:
                        Formulario_Supervisor.Visible = true;
                        Usuario_Supervisor.Enabled = false;
                        Boton_Nuevo_Supervisor.Text = "Nuevo";
                        break;
                    case -1:
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el correo');", true);
                        return;
                    case -2:
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el usuario');", true);
                        return;
                    case -3:
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error en el correo');", true);
                        return;
                }
                string alerta = @"alert('Usuario correctamente creado'); 
                    window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);

                return;

            }
            if (Boton_Nuevo_Supervisor.Text == "Nuevo")
            {
                Boton_Nuevo_Supervisor.Text = "Insertar";
                Formulario_Supervisor.Visible = true;
                Usuario_Supervisor.Enabled = true;
                Usuario_Supervisor.Text = string.Empty;
                Correo_Supervisor.Text = string.Empty;
                Skype_Supervisor.Text = string.Empty;
                Celular_Supervisor.Text = string.Empty;
                Modelo_Supervisor.Text = string.Empty;
                Credito_Supervisor.Text = string.Empty;
                CheckBox_Pedido_Supervisor.Checked = false;
                CheckBox_Activacion_Supervisor.Checked = false;

            }

        }

        protected void Boton_Borrar_Supervisor_Click(object sender, EventArgs e)
        {

            if (LBPDCUS.Logica_Borrar_Usuario(int.Parse(Session["ID_Usuario"].ToString())) == 1) // Borrar el administrador               
            {
                string alerta = @"alert('Usuario correctamente borrado'); 
                    window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
            }
        }

        protected void Boton_Excel_Supervisor_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();
            GridView_Supervisor.DataSourceID = string.Empty;
            GridView_Supervisor.EnableViewState = false;
            GridView_Supervisor.AllowPaging = false;
            GridView_Supervisor.DataSource = LBPDCUS.Logica_Mostrar_Usuario((string)Session["Buscar"], (int)Session["Variable_ID_Empresa"], (int)Session["Opcion"]);
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