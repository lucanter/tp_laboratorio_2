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
    public class Dron : Armamento
    {
        #region Constructores

        /// <summary>
        /// Constructor default
        /// </summary>
        public Dron()
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
        public Dron(string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
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
        public Dron(int id, string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : base(id, nombre, tipoArmamento, origen, precio, stock)
        {

        }

        #endregion

        #region Método

        /// <summary>
        /// Muestra, mediante reutilización de código, los datos de un dron
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dron (vehículo aéreo no tripulado)");
            sb.AppendLine(base.MostrarDatos());

            return sb.ToString();
        }

        #endregion

    }
}
