using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Hereda de Armamento
    /// </summary>
    public class Explosivo : Armamento
    {
        #region Constructores

        /// <summary>
        /// Constructor default
        /// </summary>
        public Explosivo()
            : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado (sin id)
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="tipoArmamento"></param>
        /// <param name="origen"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Explosivo(string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : base(nombre, tipoArmamento, origen, precio, stock)
        {

        }

        /// <summary>
        /// Constructor parametrizado (con id)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="tipoArmamento"></param>
        /// <param name="origen"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Explosivo(int id, string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : base(id, nombre, tipoArmamento, origen, precio, stock)
        {

        }

        #endregion

        #region Método

        /// <summary>
        /// Muestra, mediante reutilización de código, los datos de un explosivo
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Explosivo (CUIDADO: compuesto químico explosivo. Contiene Amatol, Hexógeno-C1 y/u Octógeno)");
            sb.AppendLine(base.MostrarDatos());

            return sb.ToString();
        }

        #endregion
    }
}
