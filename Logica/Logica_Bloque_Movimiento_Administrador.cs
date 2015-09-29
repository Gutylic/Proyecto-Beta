using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Logica_Bloque_Movimiento_Administrador
    {
        Bloque_Movimiento_Administrador BMA = new Bloque_Movimiento_Administrador();
        public List<Mostrar_Movimiento_AdministradorResult> Logica_Mostrar_Movimientos(string Usuario, string Empresa)
        {
            return BMA.Mostrar_Movimiento(Usuario,Empresa).ToList();
        }

        public int? Logica_Contar_Movimientos(string Usuario, string Empresa)
        {
            return BMA.Contar_Movimientos(Usuario,Empresa);           
        }
    }
}
