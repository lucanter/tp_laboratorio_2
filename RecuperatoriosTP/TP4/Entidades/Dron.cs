using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dron : Armamento
    {
        public Dron()
        {

        }

        public Dron(string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : base(nombre, tipoArmamento, origen, precio, stock)
        {

        }

        public Dron(int id, string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : base(id, nombre, tipoArmamento, origen, precio, stock)
        {

        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dron (vehículo aéreo no tripulado)");
            sb.AppendLine(base.MostrarDatos());

            return sb.ToString();
        }

    }
}
