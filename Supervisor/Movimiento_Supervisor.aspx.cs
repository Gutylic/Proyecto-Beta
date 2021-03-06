﻿using System;
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
    public partial class Movimiento_Supervisor : System.Web.UI.Page
    {
        Logica_Bloque_Movimiento_Supervisor LBMS = new Logica_Bloque_Movimiento_Supervisor();
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

            Session["Buscar"] = string.Empty;

            if (DropDownList_Supervisor.SelectedValue == "3")
            {
                Buscar_Supervisor_Fecha.Visible = true;
                DropDownList_Buscar_Supervisor.Visible = false;
                Buscar_Supervisor.Visible = false;
            }
            if (DropDownList_Supervisor.SelectedValue == "2")
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
                    break;
                case 8:
                    Boton_Excel_Supervisor.Enabled = true;
                    Boton_Borrar_Supervisor.Enabled = false;
                    break;
                case 9:
                    Boton_Excel_Supervisor.Enabled = true;
                    Boton_Borrar_Supervisor.Enabled = true;
                    break;
               

            }

            if (LBMS.Logica_Contar_Movimientos(string.Empty,(string)Session["Empresa"], 1) == null)
            {
                Extremo_Supervisor.Visible = false;
                Interno_Supervisor.Visible = false;
                return;

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
            ViewState["Cantidad_De_Datos"] = LBMS.Logica_Contar_Movimientos(Datos, (string)Session["Empresa"], (int)Session["Opcion"]); // cuenta la cantidad de datos
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

        #region GridView_Supervisor
        public void Mostrar_Datos_Supervisor(string Datos, int Pagina)
        {
            GridView_Supervisor.DataSource = LBMS.Logica_Mostrar_Movimientos(Datos, (string)Session["Empresa"], (int)Session["Opcion"]).Skip(Pagina * 20).Take(20);
            GridView_Supervisor.DataBind();
        }
        #endregion

        #region Buscar_Supervisor
        protected void Boton_Buscar_Supervisor_Click(object sender, EventArgs e)
        {
            Formulario_Supervisor.Visible = false;
            Session["Opcion"] = int.Parse(DropDownList_Supervisor.SelectedValue);
            //Session["Buscar"] = Buscar_Supervisor.Text;
            if (DropDownList_Supervisor.SelectedValue == "3")
            {
                Session["Buscar"] = Buscar_Supervisor_Fecha.Text;
            }
            if (DropDownList_Supervisor.SelectedValue == "2")
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

            if (LBMS.Logica_Contar_Movimientos(string.Empty, (string)Session["Empresa"], 1) == null)
            {
                Formulario_Supervisor.Visible = false;
                Mostrar_Datos_Supervisor(string.Empty, 0);
                return;

            }


            Formulario_Supervisor.Visible = true;
            GridViewRow row = GridView_Supervisor.SelectedRow; // declaro una variable del tipo de gridview
            Session["ID_Movimiento"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // capturo el identificador del dato presionado
            List <Seleccionar_Movimiento_SupervisorResult> Datos = LBMS.Logica_Seleccionar_Movimientos((int)Session["ID_Movimiento"]);
            Usuario_Supervisor.Text = Datos[0].Usuario.ToString();
            Fecha_Supervisor.Text = Datos[0].Fecha_Del_Movimiento.ToString();
            Descripcion_Supervisor.Text = Datos[0].Descripcion_De_Movimiento.ToString();
            Debe_Supervisor.Text = Datos[0].Plata_Debe.ToString();
            Haber_Supervisor.Text = Datos[0].Plata_Haber.ToString();          
        }


        #endregion

        #region Botonera_De_Supervisor
       

       

        protected void Boton_Borrar_Supervisor_Click(object sender, EventArgs e)
        {
            if (LBMS.Logica_Borrar_Movimiento((int)Session["ID_Movimiento"]) == 1) // Borrar el administrador               
            {
                string alerta = @"alert('Movimiento borrado correctamente'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
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
            GridView_Supervisor.DataSource = LBMS.Logica_Mostrar_Movimientos((string)Session["Buscar"], (string)Session["Empresa"], (int)Session["Opcion"]);
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