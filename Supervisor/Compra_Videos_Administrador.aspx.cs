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
    public partial class Compra_Videos_Administrador : System.Web.UI.Page
    {
        Logica_Bloque_Comprar_Videos_Administrador LBCVA = new Logica_Bloque_Comprar_Videos_Administrador();
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

                GridView_Administrador.Visible = false;
                Interno_Administrador.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Administrador.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
            }
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        protected void Boton_Buscar_Administrador_Click(object sender, EventArgs e)
        {
            if (Buscar_Administrador.Text == string.Empty)
            {
                GridView_Administrador.Visible = false;
                Interno_Administrador.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Administrador.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                return;
            }

            GridView_Administrador.Visible = true;
            Condiciones_Paginacion_Administrador(Buscar_Administrador.Text.ToLower()); // paginacion
            Session["Buscar"] = Buscar_Administrador.Text.ToLower(); // carga la variable de session para enviar a la paginacion
            Mostrar_Datos_Administrador(Buscar_Administrador.Text.ToLower(), 0); // llama al gridview

        }


        public void Condiciones_Paginacion_Administrador(string Usuario) // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            if (Usuario == null) { Usuario = string.Empty; } // limpia de problemas si administrador llega vacio
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Administrador.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Administrador_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Administrador_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = LBCVA.Logica_Contar_Videos(Usuario); // cuenta la cantidad de datos
            ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Datos"] / 20; // cantidad de paginas segun la cantidad de datos            
            ViewState["Resto"] = (int)ViewState["Cantidad_De_Datos"] % 20; // me dice cuantos datos faltan para completar una pagina completa
            if ((int)ViewState["Resto"] == 0) // sin resto hay una cantidad de paginas completas y le debo restar uno para asegurarme que como inicio de cero la ultima pagina no se encuentre vacia
            {
                ViewState["Cantidad_De_Paginas"] = (int)ViewState["Cantidad_De_Paginas"] - 1;
            }
            if ((int)ViewState["Cantidad_De_Datos"] <= 20) // para saber si hay menos de 20 datos no aparezca el boton de siguiente
            {
                Siguiente_Administrador_Primero.Visible = false;
            }
        }

        protected void Siguiente_Administrador_Click(object sender, EventArgs e)
        {
            if (Session["Buscar"] == null) { Session["Buscar"] = string.Empty; }
            ViewState["Pagina"] = (int)ViewState["Pagina"] + 1;// sumo una pagina
            if ((int)ViewState["Pagina"] == (int)ViewState["Cantidad_De_Paginas"]) // mira si la pagina en la que estoy es igual a la pagina final (estoy en la ultima pagina)
            {
                Mostrar_Datos_Administrador((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Administrador.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Administrador.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Administrador_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Administrador_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                Mostrar_Datos_Administrador((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Administrador.Visible = true; // estoy en las paginas del centro
                Extremo_Administrador.Visible = false; // no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        protected void Anterior_Administrador_Click(object sender, EventArgs e)
        {
            if (Session["Buscar"] == null) { Session["Buscar"] = string.Empty; }
            ViewState["Pagina"] = (int)ViewState["Pagina"] - 1; // resto una pagina
            if ((int)ViewState["Pagina"] == 0) // mira si esta en la primera pagina
            {
                Mostrar_Datos_Administrador((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Administrador.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Administrador.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Administrador_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Administrador_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                Mostrar_Datos_Administrador((string)Session["Buscar"], (int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Administrador.Visible = true; // estoy en las paginas del centro
                Extremo_Administrador.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }



        #region GridView_Supervisor
        public void Mostrar_Datos_Administrador(string Usuario, int Pagina)
        {

            if (Usuario == null) { Usuario = string.Empty; } // limpia las impurezas de la variabla Administrador si llega vacia
            GridView_Administrador.DataSource = LBCVA.Logica_Mostrar_Videos(Usuario).Skip(Pagina * 20).Take(20);
            GridView_Administrador.DataBind();
        }
        #endregion
    }
}