using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Bloque_Consola_De_Control
    {
        DataClassesDataContext db = new DataClassesDataContext();
               
        int? Categoria;
        int? ID_Administrador;
        int? ID_Empresa;

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

        public Tres_Datos_Int_Para_Loguearse Ingresar_Como_Administrador(string Administrador, string Empresa, string Password, int Ingreso, string IP_Address)
        {
            Tres_Datos_Int_Para_Loguearse Datos = new Tres_Datos_Int_Para_Loguearse();
            db.Logueo_Administrador(Administrador, Password, Empresa,IP_Address, Ingreso, ref ID_Administrador, ref ID_Empresa);
            Datos.Identificador_Administrador = ID_Administrador;
            Datos.Identificador_Empresa = ID_Empresa;
            
            return Datos;

        }

        public Tres_Datos_Int_Para_Loguearse Ingresar_Como_Categoria(int ID_Administrador)
        {
            Tres_Datos_Int_Para_Loguearse Datos = new Tres_Datos_Int_Para_Loguearse();
            List<Logueo_CategoriaResult> Valor = db.Logueo_Categoria(ID_Administrador).ToList();
            Datos.A1 = Valor[0].Categoria_A1;
            Datos.A2 = Valor[0].Categoria_A2;
            Datos.A3 = Valor[0].Categoria_A3;
            Datos.B1 = Valor[0].Categoria_B1;
            Datos.B2 = Valor[0].Categoria_B2;
            Datos.B3 = Valor[0].Categoria_B3;
            Datos.C1 = Valor[0].Categoria_C1;
            Datos.D1 = Valor[0].Categoria_D1;
            Datos.D2 = Valor[0].Categoria_D2;
            Datos.E1 = Valor[0].Categoria_E1;
            Datos.E2 = Valor[0].Categoria_E2;
            Datos.E3 = Valor[0].Categoria_E3;
            Datos.F1 = Valor[0].Categoria_F1;
            Datos.F2 = Valor[0].Categoria_F2;
            Datos.F3 = Valor[0].Categoria_F3;
            Datos.G1 = Valor[0].Categoria_G1;
            Datos.G2 = Valor[0].Categoria_G2;
            Datos.G3 = Valor[0].Categoria_G3;

            return Datos;
        }

        public void Contro_De_Ingreso(int ID_Administrador, string IP_Address)
        {
            db.Control_Ingreso_Administrador(ID_Administrador, IP_Address);
        }

        public void Egresar_Administrador(int ID_Administrador, string IP_Address)
        {
            db.Control_Egreso_Administrador(ID_Administrador, IP_Address);
        }
        

    }
}
