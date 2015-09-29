using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace Supervisor
{
    public partial class Consola_De_Control : System.Web.UI.Page
    {
        Logica_Bloque_Consola_De_Control LBCDC = new Logica_Bloque_Consola_De_Control();

        int[] Variable = new int[19];
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["www"] = "1";
            Cargar_Variables_De_URL(Request.QueryString["Categoria_A1"], Request.QueryString["Categoria_A2"], Request.QueryString["Categoria_A3"], Request.QueryString["Categoria_B1"], Request.QueryString["Categoria_B2"],
                                    Request.QueryString["Categoria_B3"], Request.QueryString["Categoria_C1"], Request.QueryString["Categoria_D1"], Request.QueryString["Categoria_D2"], Request.QueryString["Categoria_E1"],
                                    Request.QueryString["Categoria_E2"], Request.QueryString["Categoria_E3"], Request.QueryString["Categoria_F1"], Request.QueryString["Categoria_F2"], Request.QueryString["Categoria_F3"],
                                    Request.QueryString["Categoria_G1"], Request.QueryString["Categoria_G2"], Request.QueryString["Categoria_G3"], Request.QueryString["Tipo"]); // carga las variables de la URL                
            Caduco_Session();
            Etiqueta_Administrador_Chico.Text = ((string)Session["Administrador"]).ToUpper();
            Etiqueta_Administrador_Grande.Text = ((string)Session["Administrador"]).ToUpper();
            Etiqueta_Hora_Grande.Text = DateTime.Now.ToString();
            Etiqueta_Hora_Chica.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            Etiqueta_Localizador_Grande.Text = Request.UserHostAddress.ToString();
            Etiqueta_Localizador_Chico.Text = Request.UserHostAddress.ToString();

        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Session.Clear(); // limpiar todas las variables de sesion del usuario
            Session.Abandon(); // abandonar las variables de sesion (esto se realiza con el fin de asegurarme que borro la session del usuario  
            Eliminar_Cookie(); // cerrar las variables de coockie
            Response.Redirect("index.aspx");
        }

        public void Cargar_Variables_De_URL(string A1, string A2, string A3, string B1, string B2, string B3, string C1, string D1, string D2, string E1, string E2, string E3, string F1, string F2, string F3, string G1, string G2, string G3, string Tipo)
        {
            Variable[0] = int.Parse(A1);
            Variable[1] = int.Parse(A2);
            Variable[2] = int.Parse(A3);
            Variable[3] = int.Parse(B1);
            Variable[4] = int.Parse(B2);
            Variable[5] = int.Parse(B3);
            Variable[6] = int.Parse(C1);
            Variable[7] = int.Parse(D1);
            Variable[8] = int.Parse(D2);
            Variable[9] = int.Parse(E1);
            Variable[10] = int.Parse(E2);
            Variable[11] = int.Parse(E3);
            Variable[12] = int.Parse(F1);
            Variable[13] = int.Parse(F2);
            Variable[14] = int.Parse(F3);
            Variable[15] = int.Parse(G1);
            Variable[16] = int.Parse(G2);
            Variable[17] = int.Parse(G3);
            Variable[18] = int.Parse(Tipo);
        }

        public void Caduco_Session()
        {
            if (Session["Administrador"] == null) // verifica si termino la session
            {                
                Session.Clear(); // limpiar todas las variables de sesion del usuario
                Session.Abandon(); // abandonar las variables de sesion (esto se realiza con el fin de asegurarme que borro la session del usuario  
                Eliminar_Cookie(); // cerrar las variables de coockie
                Response.Redirect("sefue.aspx"); // me redirige a la pagina
            }
        }


        public void Eliminar_Cookie() // metodo para eliminar la coockies
        {
            HttpCookie Variable_Cookie = new HttpCookie("Administrador_Recordado"); // coockie definida como Usuario Recordado
            Variable_Cookie.Expires = DateTime.Now.AddDays(-1d); // eliminamos la coockie diciendo que su vida en la maquina del usuario es hasta ayer 
            Response.Cookies.Add(Variable_Cookie);
        }

        protected void Cerrar_Session_Click(object sender, EventArgs e)
        {
            LBCDC.Logica_Egresar_Administrador((int)Session["Variable_ID_Administrador"], Request.UserHostAddress.ToString()); // egresar en la tabla de administradores

            Session.Clear(); // limpiar todas las variables de sesion del usuario
            Session.Abandon(); // abandonar las variables de sesion (esto se realiza con el fin de asegurarme que borro la session del usuario  
            Eliminar_Cookie(); // cerrar las variables de coockie
            Response.Redirect("index.aspx");
        }

        protected void Panel_De_Control_Click(object sender, EventArgs e)
        {
            if (Variable[0] == 0) 
            {
                Response.Redirect("Panel_De_Control_Administrador.aspx");
                return;
            }
            if (Variable[0] == 5)
            {
                Response.Redirect("Panel_De_Control_Supervisor.aspx");
                return;
            }
            if (Variable[0] == 10)
            {
                Response.Redirect("Panel_De_Control_Dios.aspx");
                return;
            }
        }

        protected void Comentario_Administrador_Click(object sender, EventArgs e)
        {
            if (Variable[1] == 0)
            {
                Response.Redirect("Comentario_Administrador.aspx");
                return;
            }
            if (Variable[1] == 5 || Variable[1] == 8)
            {
                Response.Redirect("Comentario_Administrador_Supervisor.aspx?Variable=" + Variable[1]);
                return;
            }
            if (Variable[1] == 10)
            {
                Response.Redirect("Comentario_Administrador_Dios.aspx");
                return;
            }
        }

        protected void Control_Administrador_Click(object sender, EventArgs e)
        {
            if (Variable[2] == 0)
            {
                Response.Redirect("Control_Administradores.aspx");
                return;
            }
            if (Variable[2] == 5 )
            {
                Response.Redirect("Control_Administradores_Supervisor.aspx");
                return;
            }
            if (Variable[2] == 10)
            {
                Response.Redirect("Control_Administradores_Dios.aspx");
                return;
            }
        }

        protected void Panel_De_Usuario_Click(object sender, EventArgs e)
        {
            if (Variable[7] == 0 || Variable[7] == 1)
            {
                Response.Redirect("Panel_De_Control_Usuario_Administrador.aspx?Variable=" + Variable[7]);
                return;
            }
            if (Variable[7] == 5 || Variable[7] == 6 || Variable[7] == 9)
            {
                Response.Redirect("Panel_De_Control_Usuario_Supervisor.aspx?Variable=" + Variable[7]);
                return;
            }
            if (Variable[7] == 10)
            {
                Response.Redirect("Panel_De_Control_Usuario_Dios.aspx");
                return;
            }
        }

        protected void Comentario_De_Usuario_Click(object sender, EventArgs e)
        {
            if (Variable[8] == 0)
            {
                Response.Redirect("Comentario_Usuario_Administrador.aspx");
                return;
            }
            if (Variable[8] == 5)
            {
                Response.Redirect("Comentario_Usuario_Supervisor.aspx");
                return;
            }
            if (Variable[8] == 10)
            {
                Response.Redirect("Comentario_Usuario_Dios.aspx");
                return;
            }
        }

        protected void Empresas_Click(object sender, EventArgs e)
        {
            if (Variable[18] == 0)
            {
                Response.Redirect("Empresas_Administrador.aspx");
                return;
            }
            if (Variable[18] == 0)
            {
                Response.Redirect("Empresas_Supervisor.aspx");
                return;
            }
            if (Variable[18] == 10)
            {
                Response.Redirect("Empresas_Dios.aspx");
                return;
            }
        }

        protected void Precios_Click(object sender, EventArgs e)
        {
            if (Variable[3] == 0)
            {
                Response.Redirect("Precios_Administrador.aspx");
                return;
            }
            if (Variable[3] == 5)
            {
                Response.Redirect("Precios_Supervisor.aspx");
                return;
            }
            if (Variable[3] == 10)
            {
                Response.Redirect("Precios_Dios.aspx");
                return;
            }
        }

        protected void Activar_Ofertas_Click(object sender, EventArgs e)
        {
            if (Variable[4] == 0)
            {
                Response.Redirect("Activar_Oferta_Administrador.aspx");
                return;
            }
            if (Variable[4] == 5)
            {
                Response.Redirect("Activar_Oferta_Supervisor.aspx");
                return;
            }
            if (Variable[4] == 10)
            {
                Response.Redirect("Activar_Oferta_Dios.aspx");
                return;
            }
        }

        protected void Cargar_Ofertas_Click(object sender, EventArgs e)
        {
            if (Variable[5] == 0)
            {
                Response.Redirect("Cargar_Oferta_Administrador.aspx");
                return;
            }
            if (Variable[5] == 5)
            {
                Response.Redirect("Cargar_Oferta_Supervisor.aspx");
                return;
            }
            if (Variable[5] == 10)
            {
                Response.Redirect("Cargar_Oferta_Dios.aspx");
                return;
            }
        }

        protected void Tarjeta_Prepaga_Click(object sender, EventArgs e)
        {
            if (Variable[15] == 0 || Variable[15] == 1)
            {
                Response.Redirect("Tarjeta_Prepaga_Administrador.aspx?Variable=" + Variable[15]);
                return;
            }
            if (Variable[15] == 5 || Variable[15] == 6 || Variable[15] == 9)
            {
                Response.Redirect("Tarjeta_Prepaga_Supervisor.aspx?Variable=" + Variable[15]);
                return;
            }
            if (Variable[15] == 10)
            {
                Response.Redirect("Tarjeta_Prepaga_Dios.aspx");
                return;
            }
        }

        protected void Movimientos_De_Los_Usuarios_Click(object sender, EventArgs e)
        {
            if (Variable[9] == 0)
            {
                Response.Redirect("Movimiento_Administrador.aspx");
                return;
            }
            if (Variable[9] == 5 || Variable[9] == 8 || Variable[9] == 9)
            {
                Response.Redirect("Movimiento_Supervisor.aspx?Variable=" + Variable[9]);
                return;
            }
            if (Variable[9] == 10)
            {
                Response.Redirect("Movimiento_Dios.aspx");
                return;
            }
        }

        protected void Compras_De_Ejercicios_Click(object sender, EventArgs e)
        {
            if (Variable[10] == 0)
            {
                Response.Redirect("Compra_Ejercicios_Administrador.aspx");
                return;
            }
            if (Variable[10] == 5 || Variable[10] == 8)
            {
                Response.Redirect("Compra_Ejercicios_Supervisor.aspx?Variable=" + Variable[10]);
                return;
            }
            if (Variable[10] == 10)
            {
                Response.Redirect("Compra_Ejercicios_Dios.aspx");
                return;
            }
        }

        protected void Compras_De_Videos_Click(object sender, EventArgs e)
        {
            if (Variable[11] == 0)
            {
                Response.Redirect("Compra_Videos_Administrador.aspx");
                return;
            }
            if (Variable[11] == 5 || Variable[11] == 8)
            {
                Response.Redirect("Compra_Videos_Supervisor.aspx?Variable=" + Variable[11]);
                return;
            }
            if (Variable[11] == 10)
            {
                Response.Redirect("Compra_Videos_Dios.aspx");
                return;
            }
        }

        protected void Carga_Manual_De_Credito_Click(object sender, EventArgs e)
        {
            if (Variable[16] == 0)
            {
                Response.Redirect("Cargar_Credito_Manual_Administrador.aspx");
                return;
            }
            if (Variable[16] == 5 || Variable[16] == 6)
            {
                Response.Redirect("Cargar_Credito_Manual_Supervisor.aspx?Variable=" + Variable[16]);
                return;
            }
            if (Variable[16] == 10)
            {
                Response.Redirect("Cargar_Credito_Manual_Dios.aspx");
                return;
            }
        }

        protected void Carga_Automatica_De_Credito_Click(object sender, EventArgs e)
        {
            if (Variable[17] == 0)
            {
                Response.Redirect("Cargar_Credito_Automatico_Administrador.aspx");
                return;
            }
            if (Variable[17] == 5)
            {
                Response.Redirect("Cargar_Credito_Automatico_Supervisor.aspx");
                return;
            }
            if (Variable[17] == 10)
            {
                Response.Redirect("Cargar_Credito_Automatico_Dios.aspx");
                return;
            }
        }

        protected void Insertar_Ejercicio_Click(object sender, EventArgs e)
        {
            if (Variable[18] == 0)
            {
                Response.Redirect("Insertar_Ejercicio_Administrador.aspx");
                return;
            }
            if (Variable[18] == 0)
            {
                Response.Redirect("Insertar_Ejercicio_Supervisor.aspx");
                return;
            }
            if (Variable[18] == 10)
            {
                Response.Redirect("Insertar_Ejercicio_Dios.aspx");
                return;
            }
        }

        protected void Actualizar_Ejercicio_Click(object sender, EventArgs e)
        {
            if (Variable[18] == 0)
            {
                Response.Redirect("Actualizar_Ejercicio_Administrador.aspx");
                return;
            }
            if (Variable[18] == 0)
            {
                Response.Redirect("Actualizar_Ejercicio_Supervisor.aspx");
                return;
            }
            if (Variable[18] == 10)
            {
                Response.Redirect("Actualizar_Ejercicio_Dios.aspx");
                return;
            }
        }

        protected void Respuestas_Click(object sender, EventArgs e)
        {
            if (Variable[14] == 0)
            {
                Response.Redirect("Respuestas_Administrador.aspx");
                return;
            }
            if (Variable[14] == 5 || Variable[14] == 6 || Variable[14] == 8)
            {
                Response.Redirect("Respuestas_Supervisor.aspx?Variable=" + Variable[14]);
                return;
            }
            if (Variable[14] == 10)
            {
                Response.Redirect("Respuestas_Dios.aspx");
                return;
            }
        }

        protected void Pedido_De_Explicacion_Click(object sender, EventArgs e)
        {
            if (Variable[13] == 5)
            {
                Response.Redirect("Pedido_Explicacion_Administrador.aspx");
                return;
            }
            if (Variable[13] == 8)
            {
                Response.Redirect("Pedido_Explicacion_Supervisor.aspx");
                return;
            }
            if (Variable[13] == 10)
            {
                Response.Redirect("Pedido_Explicacion_Dios.aspx");
                return;
            }
        }

        protected void Pedido_De_Personalizado_Click(object sender, EventArgs e)
        {
            if (Variable[12] == 5)
            {
                Response.Redirect("Pedido_Ejercicio_Administrador.aspx");
                return;
            }
            if (Variable[12] == 8)
            {
                Response.Redirect("Pedido_Ejercicio_Supervisor.aspx");
                return;
            }
            if (Variable[12] == 10)
            {
                Response.Redirect("Pedido_Ejercicio_Dios.aspx");
                return;
            }
        }

        protected void Consumo_De_Empresa_Click(object sender, EventArgs e)
        {
            if (Variable[18] == 0)
            {
                Response.Redirect("Consumo_De_Empresa_Administrador.aspx");
                return;
            }
            if (Variable[18] == 0)
            {
                Response.Redirect("Consumo_De_Empresa_Supervisor.aspx");
                return;
            }
            if (Variable[18] == 10)
            {
                Response.Redirect("Consumo_De_Empresa_Dios.aspx");
                return;
            }
            
        }


        protected void Permisos_Administradores_Click(object sender, EventArgs e)
        {


            if (Variable[6] == 0)
            {
                Response.Redirect("Permisos_Administrador.aspx");
                return;
            }
            if (Variable[6] == 1)
            {
                Response.Redirect("Permisos_Supervisor.aspx");
                return;
            }
            if (Variable[6] == 10)
            {
                Response.Redirect("Permisos_Dios.aspx");
                return;
            }

        }

    }
}