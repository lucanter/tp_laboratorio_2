using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fusil : Armamento
    {
        
        public Fusil()
        {

        }

        public Fusil(string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : base(nombre, tipoArmamento, origen, precio, stock)
        {

        }

        public Fusil(int id, string nombre, ETipo tipoArmamento, string origen, int precio, int stock) 
            : base(id, nombre,tipoArmamento,origen,precio,stock)
        {

        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Fusil (calibre mayor a 9mm)");
            sb.AppendLine(base.MostrarDatos());

            return sb.ToString();
        }

    }
}
