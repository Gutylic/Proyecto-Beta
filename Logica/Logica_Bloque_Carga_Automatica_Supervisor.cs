using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Carga_Automatica_Supervisor
    {
        Bloque_Carga_Automatica_Supervisor BCAS = new Bloque_Carga_Automatica_Supervisor();

        public int Logica_Ofertas_Habilitadas_7_O_2(int ID_Empresa, string Oferta)
        {
            return BCAS.Ofertas_Habilitadas_7_O_2(ID_Empresa, Oferta);
        }

        public decimal? Logica_Oferta_Proxima_Recarga(int? ID_Usuario, int ID_Empresa, decimal? Plata, bool Oferta, string IP_Address)
        {
            return BCAS.Oferta_Proxima_Recarga(ID_Usuario, ID_Empresa, Plata, Oferta, IP_Address);
           
        }

        public decimal? Logica_Oferta_Por_Carga(int? ID_Usuario, int ID_Empresa, decimal? Plata, string IP_Address)
        {
            return BCAS.Oferta_Por_Carga(ID_Usuario, ID_Empresa, Plata, IP_Address);
           
        }


        public int Logica_Insetar_Carga_Automatica(decimal? Plata, int? ID_Usuario, int Descripcion, decimal? Premio_1, decimal? Premio_2)
        {
            return BCAS.Insetar_Carga_Automatica(Plata, ID_Usuario, Descripcion, Premio_1, Premio_2);

        }

        public int? Logica_Conversion_Uausrio_A_Identificador(string Usuario)
        {
            return BCAS.Conversion_Uausrio_A_Identificador(Usuario);
     
        }

        public string Obtener_URL_Cuenta_Digital(int ID_Empresa)
        {
            return BCAS.Obtener_URL_Cuenta_Digital(ID_Empresa);
        }

    }
}

