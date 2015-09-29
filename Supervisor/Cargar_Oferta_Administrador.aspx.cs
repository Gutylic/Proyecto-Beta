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
    public partial class Cargar_Oferta_Administrador : System.Web.UI.Page
    {

        Logica_Bloque_Cargar_Oferta_Administrador LBCOA = new Logica_Bloque_Cargar_Oferta_Administrador();
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
                List<Mostrar_Cargar_Ofertas_AdministradorResult> Datos = LBCOA.Logica_Mostrar_Cargar_Ofertas((int)Session["Variable_ID_Empresa"]); // carga los datos del administrador elegido por el supervisor
                Bonificacion_Por_Registro_Administrador.Text = Datos[0].Bonificacion_Por_Registrarse.ToString(); // carga el administrador de la base
                Bonificacion_Por_Cargar_Administrador.Text = Datos[0].Bonificacion_Por_Carga.ToString();
                Porcentaje_De_Descuento_Segundo_Producto_Administrador.Text = Datos[0].Descuento_2_Compra.ToString();
                Bonificacion_Por_Cantidad_Administrador.Text = Datos[0].Bonificacion_Por_X_Consulta.ToString();
                Bonificacion_Proxima_Recarga_Administrador.Text = Datos[0].Bonificacion_En_La_Proxima_Recarga.ToString();
                Descuento_En_La_Compra_Del_Producto_Administrador.Text = Datos[0].Descuento_Por_Compra.ToString();
                Duracion_De_Todas_Las_Compras_Administrador.Text = Datos[0].Aumenta_Duracion_Todo_Lo_Comprado.ToString();
                Duracion_De_La_Compra_Administrador.Text = Datos[0].Aumenta_Duracion_De_La_Compra_Actual.ToString();
            }
        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }
    }
}