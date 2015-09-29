using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Net;
using Logica;
using Datos;


namespace Supervisor
{
    public partial class Cargar_Credito_Automatico_Supervisor : System.Web.UI.Page
    {
        Logica_Bloque_Carga_Automatica_Supervisor LBCAS = new Logica_Bloque_Carga_Automatica_Supervisor();
        decimal? Premio_1;
        decimal? Premio_2;

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
                       

        }

        public class valores
        {

            public string fecha { get; set; }
            public decimal? monto { get; set; }
            public string comision { get; set; }
            public string usuario { get; set; }
            public string tipo { get; set; }
            public int identidad { get; set; }

        }

        protected void Volver_A_Consola_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["URL"]);
        }

        protected void Boton_PayPal_Supervisor_Click(object sender, EventArgs e)
        {
            if (PayPal_Supervisor.Text == string.Empty || Conversion_Dolares_A_Pesos.Text == string.Empty)
            {
                return;
            }

            try
            {
                decimal.Parse(Conversion_Dolares_A_Pesos.Text);
            }
            catch
            {
                string confirmacion = @"<script type='text/javascript'>
                                alert('Los datos no pudieron ser cargados verifique los valores ingresados');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", confirmacion, false);
                return;
            }


            List<string> lista = new List<string>();

            lista.Add("fecha");
            lista.Add("monto_bruto");
            lista.Add("usuario");


            XElement xml = new XElement("pagos");

            string url = "http://www.colegioeba.com/pagos/paypal/" + PayPal_Supervisor.Text + ".html";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);




            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            HttpWebResponse resp;

            try
            {
                resp = req.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                resp = ex.Response as HttpWebResponse;

                string script = @"<script type='text/javascript'>
                                alert('No existe el identificador requerido');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }
            

                StreamReader reader = new StreamReader(resp.GetResponseStream());

                string HTML = reader.ReadToEnd();

                string[] nombre_de_archivo = HTML.Split('&');


                string[] etiqueta_1 = nombre_de_archivo[0].Split('=');
                string[] etiqueta_2 = nombre_de_archivo[4].Split('=');

                string[] fecha = etiqueta_2[1].Split('+');
                string[] dia = fecha[2].Split('%');

                switch (fecha[1])
                {

                    case "Jan":
                        fecha[1] = "01";
                        break;

                    case "Feb":

                        fecha[1] = "02";
                        break;

                    case "Mar":
                        fecha[1] = "03";
                        break;

                    case "Apr":

                        fecha[1] = "04";
                        break;

                    case "May":
                        fecha[1] = "05";
                        break;

                    case "Jun":

                        fecha[1] = "06";
                        break;

                    case "Jul":
                        fecha[1] = "07";
                        break;

                    case "Agu":

                        fecha[1] = "08";
                        break;

                    case "Sep":
                        fecha[1] = "09";
                        break;

                    case "Oct":

                        fecha[1] = "10";
                        break;

                    case "Nov":
                        fecha[1] = "11";
                        break;

                    case "Dec":

                        fecha[1] = "12";
                        break;
                }


                string[] etiqueta_3 = nombre_de_archivo[26].Split('=');

                string[] moneda = etiqueta_1[1].Split('.');

                XElement pago = new XElement("pago");

                XElement etiqueta_secundaria = new XElement("fecha");
                etiqueta_secundaria.Add(dia[0] + fecha[1] + fecha[3]);
                pago.Add(etiqueta_secundaria);

                XElement etiqueta_tercearia = new XElement("monto_bruto");
                etiqueta_tercearia.Add(moneda[0]);
                pago.Add(etiqueta_tercearia);

                XElement etiqueta_cuartaria = new XElement("usuario");
                etiqueta_cuartaria.Add(etiqueta_3[1]);
                pago.Add(etiqueta_cuartaria);

                xml.Add(pago);

                if (!File.Exists("c:\\pagos/PayPal/" + PayPal_Supervisor.Text + ".xml"))
                {

                    xml.Save("c:\\pagos/PayPal/" + PayPal_Supervisor.Text + ".xml");

                }
                else
                {

                    string script = @"<script type='text/javascript'>
                                alert('El identificador que usted requiere ya fue cargado');
                                </script>";

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                    return;


                }

                XDocument doc = XDocument.Load("c:\\pagos/PayPal/" + PayPal_Supervisor.Text + ".xml");

                var query = from m in doc.Descendants("pago")
                            select new valores
                            {
                                fecha = m.Element("fecha").Value,
                                monto = Convert.ToDecimal(m.Element("monto_bruto").Value),
                                usuario = m.Element("usuario").Value,
                            };

                List<valores> Tabla = query.ToList<valores>();

                foreach (valores m in Tabla)
                {

                    int? ID_Usuario = LBCAS.Logica_Conversion_Uausrio_A_Identificador(m.usuario);
                    if (LBCAS.Logica_Ofertas_Habilitadas_7_O_2((int)Session["Variable_ID_Empresa"], "Oferta_7") == 1)
                    {
                        Premio_1 = LBCAS.Logica_Oferta_Proxima_Recarga(ID_Usuario, (int)Session["Variable_ID_Empresa"], m.monto, true, "Automatico");

                    }
                    if (LBCAS.Logica_Ofertas_Habilitadas_7_O_2((int)Session["Variable_ID_Empresa"], "Oferta_2") == 1)
                    {
                        Premio_2 = LBCAS.Logica_Oferta_Por_Carga(ID_Usuario, (int)Session["Variable_ID_Empresa"], m.monto, "Automatico");

                    }
                    else
                    {
                        Premio_2 = 0;
                    }

                    LBCAS.Logica_Insetar_Carga_Automatica(m.monto * decimal.Parse(Conversion_Dolares_A_Pesos.Text), ID_Usuario, 15, Premio_1, Premio_2);

                }

                string confirmacion_1 = @"<script type='text/javascript'>
                                alert('Los datos fueron cargados satisfactoriamente');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", confirmacion_1, false);

                PayPal_Supervisor.Text = "";

                return;
            
            
        }

        protected void Button_MercadoPago_Supervisor_Click(object sender, EventArgs e)
        {
            if (MercadoPago_Supervisor.Text == string.Empty)
            {
                return;
            }

            List<string> lista = new List<string>();

            lista.Add("fecha");
            lista.Add("monto_bruto");
            lista.Add("usuario");


            XElement xml = new XElement("pagos");

            string url = "http://www.colegioeba.com/pagos/mercadopago/" + MercadoPago_Supervisor.Text + ".html";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);


            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            HttpWebResponse resp;

            try
            {
                resp = req.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                resp = ex.Response as HttpWebResponse;

                string script = @"<script type='text/javascript'>
                                alert('No existe el identificador requerido');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;
            }

            StreamReader reader = new StreamReader(resp.GetResponseStream());

            string HTML = reader.ReadToEnd();

            string[] nombre_de_archivo = HTML.Split(',');


            string[] etiqueta_1 = nombre_de_archivo[20].Split(':');
            string[] etiqueta_2 = nombre_de_archivo[4].Split(':');

            string[] fecha = etiqueta_2[1].Split('T');
            string[] datos = fecha[0].Split('-');

            string ano = datos[0].Trim();




            string[] etiqueta_3 = nombre_de_archivo[18].Split(':');

            string moneda = etiqueta_1[1].Trim();

            XElement pago = new XElement("pago");

            XElement etiqueta_secundaria = new XElement("fecha");
            etiqueta_secundaria.Add(datos[2] + datos[1] + ano);
            pago.Add(etiqueta_secundaria);

            XElement etiqueta_tercearia = new XElement("monto_bruto");
            etiqueta_tercearia.Add(moneda);
            pago.Add(etiqueta_tercearia);

            XElement etiqueta_cuartaria = new XElement("usuario");
            etiqueta_cuartaria.Add(etiqueta_3[1].Trim());
            pago.Add(etiqueta_cuartaria);

            xml.Add(pago);

            if (!File.Exists("c:\\pagos/MercadoPago/" + MercadoPago_Supervisor.Text + ".xml"))
            {

                xml.Save("c:\\pagos/MercadoPago/" + MercadoPago_Supervisor.Text + ".xml");

            }
            else
            {

                string script = @"<script type='text/javascript'>
                                alert('El identificador requerido ya fue cargado en la base de datos');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;


            }

            XDocument doc = XDocument.Load("c:\\pagos/MercadoPago/" + MercadoPago_Supervisor.Text + ".xml");

            var query = from m in doc.Descendants("pago")
                        select new valores
                        {
                            fecha = m.Element("fecha").Value,
                            monto = Convert.ToDecimal(m.Element("monto_bruto").Value),
                            usuario = m.Element("usuario").Value,
                        };

            List<valores> Tabla = query.ToList<valores>();

            foreach (valores m in Tabla)
            {

                int? ID_Usuario = LBCAS.Logica_Conversion_Uausrio_A_Identificador(m.usuario);
                if (LBCAS.Logica_Ofertas_Habilitadas_7_O_2((int)Session["Variable_ID_Empresa"], "Oferta_7") == 1)
                {
                    Premio_1 = LBCAS.Logica_Oferta_Proxima_Recarga(ID_Usuario, (int)Session["Variable_ID_Empresa"], m.monto, true, "Automatico");

                }
                else
                {
                    Premio_1 = LBCAS.Logica_Oferta_Proxima_Recarga(ID_Usuario, (int)Session["Variable_ID_Empresa"], m.monto, false, "Automatico");

                }
                if (LBCAS.Logica_Ofertas_Habilitadas_7_O_2((int)Session["Variable_ID_Empresa"], "Oferta_2") == 1)
                {
                    Premio_2 = LBCAS.Logica_Oferta_Por_Carga(ID_Usuario, (int)Session["Variable_ID_Empresa"], m.monto, "Automatico");

                }
                else
                {
                    Premio_2 = 0;
                }

                LBCAS.Logica_Insetar_Carga_Automatica(m.monto * decimal.Parse(Conversion_Dolares_A_Pesos.Text), ID_Usuario, 15, Premio_1, Premio_2);


            }

            string confirmacion = @"<script type='text/javascript'>
                                alert('Los datos fueron cargados satisfactoriamente');
                                </script>";

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", confirmacion, false);

            MercadoPago_Supervisor.Text = "";

            return;
        }
        

        protected void Boton_Cuenta_Digital_Supervisor_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDateTime(Cuenta_Digital_Supervisor.Text);
            }
            catch
            { 
                string confirmacion1 = @"<script type='text/javascript'>
                                alert('Algunos datos ingresados no tienen la forma permitida');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", confirmacion1, false);
                              
                return;
            }
            string fecha = Cuenta_Digital_Supervisor.Text;
            if (fecha == string.Empty)
            {
                return;
            }

            List<string> lista = new List<string>();

            lista.Add("fecha");
            lista.Add("monto_bruto");
            lista.Add("comision");
            lista.Add("usuario");
            lista.Add("tipo_pago");
            lista.Add("identidad");

            XElement xml = new XElement("pagos");

            string registro = "";
            if (fecha != string.Empty)
            {

                string[] dato = fecha.Split('/');

                registro = "&fecha=" + dato[2] + dato[0] + dato[1];

            }

            string url = LBCAS.Obtener_URL_Cuenta_Digital((int)Session["Variable_ID_Empresa"]) + registro;
           

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader reader = new StreamReader(resp.GetResponseStream());

            string HTML = reader.ReadToEnd();

            if (HTML == "")
            {

                string alerta = @"<script type='text/javascript'>
                                alert('No existen datos de la fecha solicitada');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", alerta, false);

                Cuenta_Digital_Supervisor.Text = "";

                return;

            }

            string[] nombre_de_archivo = HTML.Split('|');


            string[] etiqueta_primaria = HTML.Split('\n');


            foreach (string ep in etiqueta_primaria)
            {
                if (ep == "")
                {

                    break;
                }

                XElement pago = new XElement("pago");
                string[] subcadena = ep.Split('|');
                int pos = 0;

                foreach (string es in subcadena)
                {

                    XElement etiqueta_secundaria = new XElement(string.Format(lista[pos]));
                    etiqueta_secundaria.Add(es);
                    pago.Add(etiqueta_secundaria);
                    pos += 1;

                }

                xml.Add(pago);

            }

            if (!File.Exists("c:\\pagos/Cuenta_Digital/" + (string)Session["Empresa"] + nombre_de_archivo[0] + ".xml"))
            {

                xml.Save("c:\\pagos/Cuenta_Digital/" + (string)Session["Empresa"] +  nombre_de_archivo[0] + ".xml");

            }
            else
            {

                string script = @"<script type='text/javascript'>
                                alert('Esta fecha ya fue cargada a la base de datos');
                                </script>";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", script, false);

                return;

            }

            XDocument doc = XDocument.Load("c:\\pagos/Cuenta_Digital/" + (string)Session["Empresa"] + nombre_de_archivo[0] + ".xml");

            var query = from m in doc.Descendants("pago")
                        select new valores
                        {
                            fecha = m.Element("fecha").Value,
                            monto = Convert.ToDecimal(m.Element("monto_bruto").Value),
                            comision = m.Element("comision").Value,
                            usuario = m.Element("usuario").Value,
                            tipo = m.Element("tipo_pago").Value,
                            identidad = int.Parse(m.Element("identidad").Value),
                        };

            List<valores> Tabla = query.ToList<valores>();

            foreach (valores m in Tabla)
            {
                int? ID_Usuario = LBCAS.Logica_Conversion_Uausrio_A_Identificador(m.usuario);
                if (LBCAS.Logica_Ofertas_Habilitadas_7_O_2((int)Session["Variable_ID_Empresa"], "Oferta_7") == 1)
                {
                    Premio_1 = LBCAS.Logica_Oferta_Proxima_Recarga(ID_Usuario, (int)Session["Variable_ID_Empresa"], m.monto, true, "Automatico");

                }
                else
                {
                    Premio_1 = LBCAS.Logica_Oferta_Proxima_Recarga(ID_Usuario, (int)Session["Variable_ID_Empresa"], m.monto, false, "Automatico");

                }
                if (LBCAS.Logica_Ofertas_Habilitadas_7_O_2((int)Session["Variable_ID_Empresa"], "Oferta_2") == 1)
                {
                    Premio_2 = LBCAS.Logica_Oferta_Por_Carga(ID_Usuario, (int)Session["Variable_ID_Empresa"], m.monto, "Automatico");

                }
                else
                {
                    Premio_2 = 0;
                }

                LBCAS.Logica_Insetar_Carga_Automatica(m.monto, ID_Usuario, 17, Premio_1, Premio_2);

            }

            string confirmacion = @"<script type='text/javascript'>
                                alert('Los datos fueron cargados satisfactoriamente');
                                </script>";

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alerta", confirmacion, false);

            Cuenta_Digital_Supervisor.Text = "";

            return;
        }
    }
}