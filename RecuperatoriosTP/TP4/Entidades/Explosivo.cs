using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Explosivo : Armamento
    {
        public Explosivo()
        {

        }

        public Explosivo(string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : base(nombre, tipoArmamento, origen, precio, stock)
        {

        }

        public Explosivo(int id, string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : base(id, nombre, tipoArmamento, origen, precio, stock)
        {

        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Explosivo (CUIDADO: compuesto químico explosivo. Contiene Amatol, Hexógeno-C1 y/u Octógeno)");
            sb.AppendLine(base.MostrarDatos());

            return sb.ToString();
        }

    }
}
