using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase excepción
    /// </summary>
    public class ArmamentosException : Exception
    {
        /// <summary>
        /// Constructor parametrizado default
        /// </summary>
        /// <param name="mensaje"></param>
        public ArmamentosException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor parametrizado con la inner exception anidada
        /// </summary> 
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public ArmamentosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}