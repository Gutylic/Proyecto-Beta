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
    public partial class Compra_Ejercicios_Supervisor : System.Web.UI.Page
    {
        Logica_Bloque_Comprar_Ejercicios_Supervisor LBCES = new Logica_Bloque_Comprar_Ejercicios_Supervisor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null || Session["www"] == null)
            {
                Response.Redirect("sefue.aspx");
            }
            
            switch (int.Parse(Request.QueryString["Variable"]))
            {
                case 5:
                    Boton_Actualizar_Supervisor.Enabled = false;
                    Boton_Excel_Supervisor.Enabled = false;
                    Boton_Nuevo_Supervisor.Enabled = true;
                    Boton_Borrar_Supervisor.Enabled = true;
                    break;               
                case 8:
                    Boton_Actualizar_Supervisor.Enabled = true;
                    Boton_Excel_Supervisor.Enabled = true;
                    Boton_Nuevo_Supervisor.Enabled = true;
                    Boton_Borrar_Supervisor.Enabled = true;
                    break;
               
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

            if (LBCES.Logica_Contar_Ejercicios(string.Empty, 1, (string)Session["Empresa"]) == null)
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
        public void Condiciones_Paginacion_Supervisor(string Dato) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {

            if (Dato == null) { Dato = string.Empty; } // limpia de problemas si administrador llega vacio
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina

            ViewState["Cantidad_De_Datos"] = LBCES.Logica_Contar_Ejercicios(Dato, (int)Session["Opcion"],(string) Session["Empresa"]);// cuenta la cantidad de datos

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
                Mostrar_Datos_Supervisor((string)Session["Buscar"],(int)ViewState["Pagina"]); // carga cada presion el gridview
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
                Mostrar_Datos_Supervisor((string)Session["Buscar"],(int)ViewState["Pagina"]); // carga cada presion el gridview

                Interno_Supervisor.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Supervisor.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Supervisor_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Supervisor_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                Mostrar_Datos_Supervisor((string)Session["Buscar"],(int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = true; // estoy en las paginas del centro
                Extremo_Supervisor.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

        #region GridView_Supervisor
        public void Mostrar_Datos_Supervisor(string Datos, int Pagina)
        {
            GridView_Supervisor.DataSource = LBCES.Logica_Mostrar_Ejercicios(Datos, (int)Session["Opcion"], (string)Session["Empresa"]).Skip(Pagina * 20).Take(20);
            GridView_Supervisor.DataBind();
        }
        #endregion

        #region Buscar_Supervisor
        protected void Boton_Buscar_Supervisor_Click(object sender, EventArgs e)
        {
            Formulario_Supervisor.Visible = false;
            Session["Opcion"] = int.Parse(DropDownList_Supervisor.SelectedValue);
            Session["Buscar"] = Buscar_Supervisor.Text; // carga la variable de session para enviar a la paginacion
            Condiciones_Paginacion_Supervisor(Buscar_Supervisor.Text); // paginacion       
            Mostrar_Datos_Supervisor(Buscar_Supervisor.Text, 0); // llama al gridview
        }
        #endregion

        #region Seleccionar_El_Administrador_Supervisor

        protected void Identificador_Supervisor(object sender, EventArgs e) // convierto al datalist en editable 
        {

            if (LBCES.Logica_Contar_Ejercicios(string.Empty, 1, (string)Session["Empresa"]) == null)
            {
                Mostrar_Datos_Supervisor(string.Empty, 0);
                Formulario_Supervisor.Visible = false;
                return;
            }

            Formulario_Supervisor.Visible = true;
            GridViewRow row = GridView_Supervisor.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Compra"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado
            List<Vista_Mis_Ejercicios> Datos = LBCES.Logica_Seleccionar_Ejercicio(int.Parse(Session["ID_Compra"].ToString())); // carga los datos del administrador elegido por el supervisor
          
            Usuario_Supervisor.Text = Datos[0].Usuario; // administrador traido de la base de datos
            Titulo_Supervisor.Text = Datos[0].Titulo; // password traido de la base de datos
            Correo_Supervisor.Text = Datos[0].Correo; // Empresa traida de la base de datos
            Duracion_Supervisor.Text = Datos[0].Dias_Que_Restan_Para_Usar_El_Producto.ToString(); // Categoria traida de la base de datos
           
            

        }

        #endregion

        #region Botonera_De_Supervisor

        protected void Boton_Nuevo_Supervisor_Click(object sender, EventArgs e)
        {
            try
            {

                if (Boton_Nuevo_Supervisor.Text == "Insertar")
                {

                    int Valor = LBCES.Logica_Insertar_Ejercicio(Nombre_Supervisor.Text, int.Parse(ID_Ejercicio_Supervisor.Text), Ejercicio_Supervisor.Checked, Explicacion_Supervisor.Checked, int.Parse(Dias_Que_restan_Para_El_Producto_Supervisor.Text)); // analiza la insercion

                    switch (Valor)
                    {

                        case 1:

                            Formulario_Supervisor.Visible = true;
                            cuerpo_insertar_supervisor.Visible = false;
                            cuerpo_inicial_supervisor.Visible = true;
                            Usuario_Supervisor.Enabled = false;
                            Boton_Nuevo_Supervisor.Text = "Nuevo";
                            break;
                        case -6:

                            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Error al insertar el ejercicio');", true);
                            return;

                    }

                    string alerta = @"alert('Ejercicio correctamente insertado'); 

                window.location.reload();";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                    return;


                }
                if (Boton_Nuevo_Supervisor.Text == "Nuevo")
                {
                    Boton_Nuevo_Supervisor.Text = "Insertar";
                    Formulario_Supervisor.Visible = true;
                    cuerpo_inicial_supervisor.Visible = false;
                    cuerpo_insertar_supervisor.Visible = true;
                    Nombre_Supervisor.Text = string.Empty;
                    ID_Ejercicio_Supervisor.Text = string.Empty;
                    Ejercicio_Supervisor.Checked = false;
                    Explicacion_Supervisor.Checked = false;
                    Dias_Que_restan_Para_El_Producto_Supervisor.Text = string.Empty;


                }


            }

            catch
            {
                string alerta = @"alert('Los datos no pudieron insertarse intentelo más tarde');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;

            }

        }
        protected void Boton_Borrar_Supervisor_Click(object sender, EventArgs e)
        {
            int Valor = LBCES.Logica_Borrar_Ejercicio((int)Session["ID_Compra"]); // Borrar el administrador
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Ejercicio correctamente borrado'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }

        protected void Boton_Actualizar_Supervisor_Click(object sender, EventArgs e)
        {
            try
            {
                int Valor = LBCES.Logica_Actualizar_Ejercicio((int)Session["ID_Compra"], int.Parse(Duracion_Supervisor.Text)); // Borrar el administrador
                if (Valor == 1) // todo ok
                {
                    string alerta = @"alert('Ejercicio correctamente actualizado'); 

                window.location.reload();";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                    return;
                }
            }
            catch
            {
                string alerta = @"alert('Los datos no pudieron modificarse intentelo más tarde');";
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
            GridView_Supervisor.DataSource = LBCES.Logica_Mostrar_Ejercicios((string)Session["Buscar"], (int)Session["Opcion"], (string)Session["Empresa"]);
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