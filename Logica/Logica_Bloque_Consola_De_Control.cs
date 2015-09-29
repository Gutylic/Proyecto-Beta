using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Consola_De_Control
    {

        Bloque_Consola_De_Control BCDC = new Bloque_Consola_De_Control();

        public class Tres_Datos_Int_Para_Loguearse // clase extra utilizada para que alguna clase me devuelva dos valores
        {
            public int? Identificador_Administrador { get; set; }
            public int? Identificador_Empresa { get; set; }
            public int? A1 { get; set; }
            public int? A2 { get; set; }
            public int? A3 { get; set; }
            public int? B1 { get; set; }
            public int? B2 { get; set; }
            public int? B3 { get; set; }
            public int? C1 { get; set; }
            public int? D1 { get; set; }
            public int? D2 { get; set; }
            public int? E1 { get; set; }
            public int? E2 { get; set; }
            public int? E3 { get; set; }
            public int? F1 { get; set; }
            public int? F2 { get; set; }
            public int? F3 { get; set; }
            public int? G1 { get; set; }
            public int? G2 { get; set; }
            public int? G3 { get; set; }
        }


        public Tres_Datos_Int_Para_Loguearse Logica_Ingresar_Como_Administrador(string Administrador, string Password, string Empresa, int Ingreso, string IP_Address)
        {
            Tres_Datos_Int_Para_Loguearse Datos = new Tres_Datos_Int_Para_Loguearse();

            Datos.Identificador_Administrador = BCDC.Ingresar_Como_Administrador(Administrador, Empresa, Password, Ingreso, IP_Address).Identificador_Administrador;
            Datos.Identificador_Empresa = BCDC.Ingresar_Como_Administrador(Administrador, Empresa, Password, Ingreso, IP_Address).Identificador_Empresa;
            
            return Datos;

        }

        public Tres_Datos_Int_Para_Loguearse Logica_Ingresar_Como_Categoria(int ID_Administrador)
        {
            Tres_Datos_Int_Para_Loguearse Datos = new Tres_Datos_Int_Para_Loguearse();
            
            Datos.A1 = BCDC.Ingresar_Como_Categoria(ID_Administrador).A1;
            Datos.A2 = BCDC.Ingresar_Como_Categoria(ID_Administrador).A2;
            Datos.A3 = BCDC.Ingresar_Como_Categoria(ID_Administrador).A3;
            Datos.B1 = BCDC.Ingresar_Como_Categoria(ID_Administrador).B1;
            Datos.B2 = BCDC.Ingresar_Como_Categoria(ID_Administrador).B2;
            Datos.B3 = BCDC.Ingresar_Como_Categoria(ID_Administrador).B3;
            Datos.C1 = BCDC.Ingresar_Como_Categoria(ID_Administrador).C1;
            Datos.D1 = BCDC.Ingresar_Como_Categoria(ID_Administrador).D1;
            Datos.D2 = BCDC.Ingresar_Como_Categoria(ID_Administrador).D2;
            Datos.E1 = BCDC.Ingresar_Como_Categoria(ID_Administrador).E1;
            Datos.E2 = BCDC.Ingresar_Como_Categoria(ID_Administrador).E2;
            Datos.E3 = BCDC.Ingresar_Como_Categoria(ID_Administrador).E3;
            Datos.F1 = BCDC.Ingresar_Como_Categoria(ID_Administrador).F1;
            Datos.F2 = BCDC.Ingresar_Como_Categoria(ID_Administrador).F2;
            Datos.F3 = BCDC.Ingresar_Como_Categoria(ID_Administrador).F3;
            Datos.G1 = BCDC.Ingresar_Como_Categoria(ID_Administrador).G1;
            Datos.G2 = BCDC.Ingresar_Como_Categoria(ID_Administrador).G2;
            Datos.G3 = BCDC.Ingresar_Como_Categoria(ID_Administrador).G3;

            return Datos;
        }

        public void Logica_Control_De_Ingreso(int ID_Administrador, string IP_Address) // ingresa el administrador a la tabla de control
        {
            BCDC.Contro_De_Ingreso(ID_Administrador, IP_Address);
        }

        public void Logica_Egresar_Administrador(int ID_Administrador, string IP_Address) // egresar el administrador a la tabla de control
        {
            BCDC.Egresar_Administrador(ID_Administrador, IP_Address);
        }

    }
}
