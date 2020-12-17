using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase excepción
    /// </summary>
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor parametrizado default
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor parametrizado con la inner exception anidada
        /// </summary> 
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public ArchivosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}