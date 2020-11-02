using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor con mensaje default
        /// </summary>
        public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el número de DNI")
        {

        }

        /// <summary>
        /// Constructor excepción con parametros (recibe mensaje de error)
        /// </summary>
        /// <param name="mensaje">string</param>
        public NacionalidadInvalidaException(string mensaje)
           : base(mensaje)
        {

        }


    }
}
