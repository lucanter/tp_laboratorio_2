using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase excepcion
    /// </summary>
    public class CargarVentaException : Exception
    {
        /// <summary>
        /// Constructor parametrizado default
        /// </summary>
        /// <param name="mensaje"></param>
        public CargarVentaException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor parametrizado con la inner exception anidada
        /// </summary> 
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public CargarVentaException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
