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
    public class Pistola : Armamento
    {
        #region Constructores

        /// <summary>
        /// Constructor default
        /// </summary>
        public Pistola()
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
        public Pistola(string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
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
        public Pistola(int id, string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : base(id, nombre, tipoArmamento, origen, precio, stock)
        {

        }

        #endregion

        #region Método

        /// <summary>
        /// Muestra, mediante reutilización de código, los datos de una pistola
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Pistola (calibre 9mm)");
            sb.AppendLine(base.MostrarDatos());

            return sb.ToString();
        }

        #endregion
    }
}
