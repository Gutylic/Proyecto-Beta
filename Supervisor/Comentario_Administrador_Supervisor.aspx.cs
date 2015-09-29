using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;

namespace Supervisor
{
    public partial class Comentario_Administrador_Supervisor : System.Web.UI.Page
    {
        Logica_Bloque_Comentario_Administrador_Supervisor LBCAS = new Logica_Bloque_Comentario_Administrador_Supervisor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null || Session["www"] == null)
            {
                Response.Redirect("sefue.aspx");
            }

            switch (int.Parse(Request.QueryString["Variable"]))
            {
                case 5:
                    Boton_Borrar_Supervisor.Enabled = false;
                    break;
                case 8:
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
            if (LBCAS.Logica_Contar_Comentarios((int)Session["Variable_ID_Empresa"]) == null)
            {
                Extremo_Supervisor.Visible = false;
                Interno_Supervisor.Visible = false;
                return;
            }

            Condiciones_Paginacion_Supervisor();
            Mostrar_Datos_Supervisor(0);
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        #region Paginacion_Supervisor
        public void Condiciones_Paginacion_Supervisor() // pregunta en que momento tomo las condiciones del paginado si cuando arranca la pagina o cuando presiono el boton de buscar
        {
            ViewState["Pagina"] = 0; // posiciono por las dudas la pagina en cero siempre
            Interno_Supervisor.Visible = false; // contiene siguiente y anterior de las paginaciones centrales
            Siguiente_Supervisor_Primero.Visible = true; // siguiente de la primera pagina
            Anterior_Supervisor_Ultimo.Visible = false; // anterior de la ultima pagina
            ViewState["Cantidad_De_Datos"] = LBCAS.Logica_Contar_Comentarios((int)Session["Variable_ID_Empresa"]); // cuenta la cantidad de datos
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
                Mostrar_Datos_Supervisor((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Extremo_Supervisor.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo (contiene anterior ultimo y siguiente primero)
                Siguiente_Supervisor_Primero.Visible = false; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
                Anterior_Supervisor_Ultimo.Visible = true; // como estoy en la ultima pagina solo debe mostrar el anterior ultimo 
            }
            else // sin no estoy en la ultima pagina
            {
                Mostrar_Datos_Supervisor((int)ViewState["Pagina"]); // carga cada presion el gridview
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
                Mostrar_Datos_Supervisor((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero 
                Extremo_Supervisor.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero (contiene anterior ultimo y siguiente primero)
                Siguiente_Supervisor_Primero.Visible = true;// como estoy en la primera pagina solo debe mostrar el siguiente primero
                Anterior_Supervisor_Ultimo.Visible = false;// como estoy en la primera pagina solo debe mostrar el siguiente primero
            }
            else// sin no estoy en la primera pagina
            {
                Mostrar_Datos_Supervisor((int)ViewState["Pagina"]); // carga cada presion el gridview
                Interno_Supervisor.Visible = true; // estoy en las paginas del centro
                Extremo_Supervisor.Visible = false;// no muestra ni siguiente ni anterior de las paginas ultima e inicial
            }
        }

        #endregion

        #region GridView_Supervisor
        public void Mostrar_Datos_Supervisor(int Pagina)
        {
            GridView_Supervisor.DataSource = LBCAS.Logica_Comentario_Administradores((int)Session["Variable_ID_Empresa"]).Skip(Pagina * 20).Take(20);
            GridView_Supervisor.DataBind();
        }
        #endregion
        
        #region Seleccionar_El_Administrador_Supervisor

        protected void Identificador_Supervisor(object sender, EventArgs e) // convierto al datalist en editable 
        {
            Formulario_Supervisor.Visible = true;
            GridViewRow row = GridView_Supervisor.SelectedRow; // defiene la variable row del tipo gridview
            Session["ID_Comentario"] = GridView_Supervisor.DataKeys[row.RowIndex].Value; // captura el identificador del Administrador seleccionado
            List<Seleccionar_Comentario_Administrador_SupervisorResult> Datos = LBCAS.Logica_Seleccionar_Comentario((int)Session["ID_Comentario"]); // carga los datos del administrador elegido por el supervisor

            Administrador_Supervisor.Text = Datos[0].Administrador; // carga el administrador de la base
            Comentarios_Supervisor.Text = Datos[0].Comentario; // carga el password de la base
            Fecha_Supervisor.Text = Datos[0].Fecha_Comentario_Realizado.ToString("dd/MM/yyyy HH:mm"); // carga la categoria de la base
        }

        #endregion

        #region Botonera_De_Supervisor

        protected void Boton_Borrar_Supervisor_Click(object sender, EventArgs e)
        {
            int Valor = LBCAS.Logica_Borrar_Comentario((int)Session["ID_Comentario"]); // Borrar el administrador
            if (Valor == 1) // todo ok
            {
                string alerta = @"alert('El comentario fué correctamente borrado'); 

                window.location.reload();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "", alerta, true);
                return;
            }
        }



        #endregion

    }
}