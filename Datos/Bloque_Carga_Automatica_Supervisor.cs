using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Carga_Automatica_Supervisor
    {
        DataClassesDataContext db = new DataClassesDataContext();
        decimal? Premio;
        int? ID_Usuario;
        string URL;

        public int Ofertas_Habilitadas_7_O_2(int ID_Empresa, string Oferta)
        {
            return db.Buscar_Ofertas_Supervisor(ID_Empresa, Oferta);
        }

        public decimal? Oferta_Proxima_Recarga(int? ID_Usuario, int ID_Empresa, decimal? Plata, bool Oferta, string IP_Address)
        {
            db.Bonificacion_Proxima_Recarga_Supervisor(ID_Usuario, ID_Empresa, Plata, IP_Address, Oferta, ref Premio);
            return Premio;
        }

        public decimal? Oferta_Por_Carga(int? ID_Usuario, int ID_Empresa, decimal? Plata, string IP_Address)
        {
            db.Bonificacion_Por_Carga_Supervisor(ID_Usuario, ID_Empresa, IP_Address, Plata, ref Premio);
            return Premio;
        }


        public int Insetar_Carga_Automatica(decimal? Plata, int? ID_Usuario, int Descripcion, decimal? Premio_1, decimal? Premio_2)
        {
            return db.Insertar_Credito_Automatico_Supervisor(Plata, ID_Usuario, Descripcion, Premio_1, Premio_2);

        }

        public int? Conversion_Uausrio_A_Identificador(string Usuario)
        {
            db.Conversion_De_Usuario_Supervisor(Usuario, ref ID_Usuario);
            return ID_Usuario;
        }

        public string Obtener_URL_Cuenta_Digital(int ID_Empresa)
        {
            db.URL_Cuenta_Digital_Supervisor(ID_Empresa, ref URL);
            return URL;

        }


    }
}
