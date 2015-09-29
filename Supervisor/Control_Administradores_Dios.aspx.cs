using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

namespace Supervisor
{
    public partial class Control_Administradores_Dios : System.Web.UI.Page
    {
        Logica_Bloque_Control_Administrador_Dios LBCAD = new Logica_Bloque_Control_Administrador_Dios();
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


            if (LBCAD.Logica_Contar_Control_Administradores((string)Session["Administrador"], string.Empty) == null)
            {
                Extremo_Dios.Visible = false;
                Interno_Dios.Visible = false;
                return;
                
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
            if (Administrador == null) { Administrador = string.Empty; }
            if (Empresa == null) { Empresa = string.Empty; }
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Dios.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Dios_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Dios_Ultimo.Visible = false; // anterior de la ultima pagina

            ViewState["Cantidad_De_Datos"] = LBCAD.Logica_Contar_Control_Administradores(Administrador, Empresa); // cuenta la cantidad de datos

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
        public void Mostrar_Datos_Dios(string Administrador, string Empresa, int Pagina)
        {
            GridView_Dios.DataSource = LBCAD.Logica_Control_Administradores(Administrador, Empresa).Skip(Pagina * 20).Take(20);
            GridView_Dios.DataBind();
        }
        #endregion

        #region Buscar_Dios
        protected void Boton_Buscar_Dios_Click(object sender, EventArgs e)
        {
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
                Mostrar_Datos_Dios(Buscar_Dios.Text, string.Empty, 0); // envia el grid solo la empresa el 0 es la pagina a empezar
            }
            if (int.Parse(DropDownList_Dios.SelectedValue) == 3) // seleccionada la empresa
            {
                Condiciones_Paginacion_Dios(Buscar_Dios.Text, string.Empty); // envio la empresa al paginado no el administrador
                Session["Buscar_1"] = null; // variable de session de administrador vacia
                Session["Buscar_2"] = Buscar_Dios.Text;// carga una variable de session con la empresa que es utilizada al aplicar el paginado
                Mostrar_Datos_Dios(string.Empty, Buscar_Dios.Text, 0);
            }
        }
        #endregion

        #region Seleccionar_El_Administrador_Dios

        protected void Identificador_Dios(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Dios.Visible = true;
            GridViewRow row = GridView_Dios.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Ingreso_Egreso"] = GridView_Dios.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado
            List<Seleccionar_Control_Administrador_DiosResult> Datos = LBCAD.Logica_Seleccionar_Control_Administradores((int)Session["ID_Ingreso_Egreso"]); // carga los datos del administrador elegido por el supervisor

            Administrador_Dios.Text = Datos[0].Administrador; // carga el administrador de la base
            Fecha_De_Ingreso_Dios.Text = Datos[0].Fecha_De_Ingreso.ToString(); // carga el password de la base
            Fecha_De_Egreso_Dios.Text = Datos[0].Fecha_De_Egreso.ToString(); // carga la categoria de la base          

        }

        #endregion

        #region Botonera_De_Dios




        protected void Boton_Borrar_Dios_Click(object sender, EventArgs e)
        {
            int Valor = LBCAD.Logica_Borrar_Control_Administrador((int)Session["ID_Comentario"]); // Borrar el administrador
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('Control administrador / supervisor borrado'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }



        #endregion



    }
}