using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Web.Services;

namespace Supervisor
{
    public partial class index : System.Web.UI.Page
    {
        Logica_Bloque_Consola_De_Control LBLDU = new Logica_Bloque_Consola_De_Control();

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // se carga la primera vez al abrir la pagina
            {
                ViewState["Ingreso"] = 0; // variable para contar los ingresos y es la que bloquea al administrador
                Iniciar_Session(); // ejecutar el page_load
            }   
        }
        #endregion

        #region Caducidad_Session_Y_Page_Load
        public void Iniciar_Session()
        {
            string Tipo;

            if (Request.Cookies["Administrador_Recordado"] != null) // cargar las coockies si es que existen y ya arranca logueado
            {
                Session["Administrador"] = Request.Cookies["Administrador_Recordado"]["Administrador"]; // cargar la coockie como administrador  
                ViewState["Contrasena"] = Request.Cookies["Administrador_Recordado"]["Contrasena"]; // cargar la coockie como administrador 
                Session["Empresa"] = Request.Cookies["Administrador_Recordado"]["Empresa"]; // cargar la coockie como administrador 
                
                Session["Variable_ID_Administrador"] = LBLDU.Logica_Ingresar_Como_Administrador((string)Session["Administrador"], (string)ViewState["Contrasena"], (string)Session["Empresa"], (int)ViewState["Ingreso"], "cockie").Identificador_Administrador; // cargar identificador del administrador desde la cookie luego de buscarlo en la base de datos

                if (Session["Variable_ID_Administrador"] == null)
                {
                    Eliminar_Cookie();
                    return;
                }
                
                Session["Variable_ID_Empresa"] = LBLDU.Logica_Ingresar_Como_Administrador((string)Session["Administrador"], (string)ViewState["Contrasena"], (string)Session["Empresa"], (int)ViewState["Ingreso"], "cockie").Identificador_Empresa; // cargar el identificador de la empresa



                int? A1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).A1; // cargar la cartegoria del usuario
                int? A2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).A2; // cargar la cartegoria del usuario
                int? A3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).A3; // cargar la cartegoria del usuario

                int? B1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).B1; // cargar la cartegoria del usuario
                int? B2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).B2; // cargar la cartegoria del usuario
                int? B3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).B3; // cargar la cartegoria del usuario

                int? C1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).C1; // cargar la cartegoria del usuario

                int? D1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).D1; // cargar la cartegoria del usuario
                int? D2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).D2; // cargar la cartegoria del usuario

                int? E1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).E1; // cargar la cartegoria del usuario
                int? E2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).E2; // cargar la cartegoria del usuario
                int? E3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).E3; // cargar la cartegoria del usuario

                int? F1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).F1; // cargar la cartegoria del usuario
                int? F2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).F2; // cargar la cartegoria del usuario
                int? F3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).F3; // cargar la cartegoria del usuario

                int? G1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).G1; // cargar la cartegoria del usuario
                int? G2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).G2; // cargar la cartegoria del usuario
                int? G3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).G3; // cargar la cartegoria del usuario

                if (A1 == 10)
                {
                    Tipo = "10";
                }
                else
                {
                    Tipo = "0";
                }

                if (Session["Variable_ID_Administrador"] == null) // error en la comprobacion de usuario y contraseña
                {
                    Eliminar_Cookie(); // borra todo vestijio de cookie

                }
                else
                {
                    LBLDU.Logica_Control_De_Ingreso((int)Session["Variable_ID_Administrador"], Request.UserHostAddress.ToString()); // ingresar en la tabla de administradores
                    Session["URL"] = "Consola_De_Control.aspx?Categoria_A1=" + A1.ToString() + "&Categoria_A2=" + A2.ToString() + "&Categoria_A3=" + A3.ToString() +
                    "&Categoria_B1=" + B1.ToString() + "&Categoria_B2=" + B2.ToString() + "&Categoria_B3=" + B3.ToString() +
                    "&Categoria_C1=" + C1.ToString() + "&Categoria_D1=" + D1.ToString() + "&Categoria_D2=" + D2.ToString() +
                    "&Categoria_E1=" + E1.ToString() + "&Categoria_E2=" + E2.ToString() + "&Categoria_E3=" + E3.ToString() +
                    "&Categoria_F1=" + F1.ToString() + "&Categoria_F2=" + F2.ToString() + "&Categoria_F3=" + E3.ToString() +
                    "&Categoria_G1=" + G1.ToString() + "&Categoria_G2=" + G2.ToString() + "&Categoria_G3=" + G3.ToString() + "&Tipo=" + Tipo;

                    Response.Redirect((string)Session["URL"]);
            
                }
                
            }
            
        }

       //#region Recordarme

        public void Guardar_Cookie(string Administrador, string Password, string Empresa) // metodo generado para crear las cookies
        {
            HttpCookie Variable_Cookie = new HttpCookie("Administrador_Recordado"); // coockie definida como Usuario Recordado
            Variable_Cookie.Values.Add("Administrador", Administrador); // dentro de la coockie Usuario Recordado carga el usuario
            Variable_Cookie.Values.Add("Contrasena", Password); // dentro de la coockie Usuario Recordado carga el Password            
            Variable_Cookie.Values.Add("Empresa", Empresa); // dentro de la coocke Usuario Recordado carga el ID_Usuario 
            Variable_Cookie.Expires = DateTime.Now.AddDays(90); // tiempo de vida de la coockie en la maquina del usuario 90 dias
            Response.Cookies.Add(Variable_Cookie);
        }

        public void Eliminar_Cookie() // metodo para eliminar la coockies
        {
            HttpCookie Variable_Cookie = new HttpCookie("Administrador_Recordado"); // coockie definida como Usuario Recordado
            Variable_Cookie.Expires = DateTime.Now.AddDays(-1d); // eliminamos la coockie diciendo que su vida en la maquina del usuario es hasta ayer 
            Response.Cookies.Add(Variable_Cookie);
        }

        [WebMethod()] // metodod de ajax para no abandonar la session y mantenerse logueado
        public static void Abandonar_Session() // se ejecuta si no esta tildado el checkbox de mantener el usuario, es una llamada desde aspx con javascript
        {
            HttpContext.Current.Session.Remove("Administrador"); // borro variable de usuario de la coockie
            HttpContext.Current.Session.Remove("Contrasena"); // borro la contraseña de la coockie          
            HttpContext.Current.Session.Remove("Empresa"); // borro la contraseña de la coockie

        }

        #endregion


        protected void Boton_Acceso_Click(object sender, EventArgs e)
        {
            string Tipo;

            if (Empresa.Text.IndexOf("@", 0) == -1) // no tiene forma de empresa usado para bloquear el ascceso a la base de datos
            {
                return;
            }
            
            Session["Administrador"] = Administrador.Text; // cargo el usuario y lo guardo en el servidor (se usa mas adelante en otros procedimientos)
            ViewState["Password"] = Password.Text; // cargo la contraseña y la guardo en la maquina del cliente
            Session["Empresa"] = Empresa.Text; // cargo la empresa
            
            Session["Variable_ID_Administrador"] = LBLDU.Logica_Ingresar_Como_Administrador((string)Session["Administrador"], (string)ViewState["Password"], (string)Session["Empresa"], (int)ViewState["Ingreso"], Request.UserHostAddress.ToString()).Identificador_Administrador; // cargar la cartegoria del usuario
                       

            if (Session["Variable_ID_Administrador"] == null)
            {             
                ViewState["Ingreso"] = (int)ViewState["Ingreso"] + 1;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "alert('Datos Ingresados Erroneos');", true);
                if ((int)ViewState["Ingreso"] >= 5)
                {
                    Boton_Acceso.Enabled = false;
                    Boton_Acceso.Text = "Usuario Bloqueado";                   
                    return;
                }
                return;
            
            }

            int? A1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).A1; // cargar la cartegoria del usuario
            int? A2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).A2; // cargar la cartegoria del usuario
            int? A3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).A3; // cargar la cartegoria del usuario

            int? B1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).B1; // cargar la cartegoria del usuario
            int? B2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).B2; // cargar la cartegoria del usuario
            int? B3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).B3; // cargar la cartegoria del usuario

            int? C1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).C1; // cargar la cartegoria del usuario

            int? D1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).D1; // cargar la cartegoria del usuario
            int? D2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).D2; // cargar la cartegoria del usuario

            int? E1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).E1; // cargar la cartegoria del usuario
            int? E2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).E2; // cargar la cartegoria del usuario
            int? E3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).E3; // cargar la cartegoria del usuario

            int? F1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).F1; // cargar la cartegoria del usuario
            int? F2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).F2; // cargar la cartegoria del usuario
            int? F3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).F3; // cargar la cartegoria del usuario

            int? G1 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).G1; // cargar la cartegoria del usuario
            int? G2 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).G2; // cargar la cartegoria del usuario
            int? G3 = LBLDU.Logica_Ingresar_Como_Categoria((int)Session["Variable_ID_Administrador"]).G3; // cargar la cartegoria del usuario

            if (A1 == 10)
            {
                Tipo = "10";
            }
            else
            {
                Tipo = "0";
            }

            Session["Variable_ID_Empresa"] = LBLDU.Logica_Ingresar_Como_Administrador((string)Session["Administrador"], (string)ViewState["Password"], (string)Session["Empresa"], (int)ViewState["Ingreso"], Request.UserHostAddress.ToString()).Identificador_Empresa; // cargar la cartegoria del usuario
            


            if (Check_Session.Checked) // esta chequeado el recordarme para saber si queda la session almacenada en el usuario con ajax
            {
                Guardar_Cookie((string)Session["Administrador"], (string)ViewState["Password"],(string)Session["Empresa"]); // mantiene la session activa
            }
            else
            {
                Eliminar_Cookie(); // expirar session activa
            }
            
            LBLDU.Logica_Control_De_Ingreso((int)Session["Variable_ID_Administrador"], Request.UserHostAddress.ToString()); // ingresar en la tabla de administradores

            Session["URL"] = "Consola_De_Control.aspx?Categoria_A1=" + A1.ToString() + "&Categoria_A2=" + A2.ToString() + "&Categoria_A3=" + A3.ToString() +
            "&Categoria_B1=" + B1.ToString() + "&Categoria_B2=" + B2.ToString() + "&Categoria_B3=" + B3.ToString() +
            "&Categoria_C1=" + C1.ToString() + "&Categoria_D1=" + D1.ToString() + "&Categoria_D2=" + D2.ToString() +
            "&Categoria_E1=" + E1.ToString() + "&Categoria_E2=" + E2.ToString() + "&Categoria_E3=" + E3.ToString() +
            "&Categoria_F1=" + F1.ToString() + "&Categoria_F2=" + F2.ToString() + "&Categoria_F3=" + E3.ToString() +
            "&Categoria_G1=" + G1.ToString() + "&Categoria_G2=" + G2.ToString() + "&Categoria_G3=" + G3.ToString() + "&Tipo=" + Tipo;

            Response.Redirect((string)Session["URL"]);
            }
                    
        }

    }
