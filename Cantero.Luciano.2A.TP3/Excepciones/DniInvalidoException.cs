using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor con mensaje default
        /// </summary>
        public DniInvalidoException()
            : base("Ha ocurrido un error: el DNI es invalido.")
        {

        }

        /// <summary>
        /// Consctructor excepcion
        /// </summary>
        /// <param name="excepcion">excepcion</param>
        public DniInvalidoException(Exception excepcion)
            : base(excepcion.Message)
        {

        }

        /// <summary>
        /// Constructor con mensaje y excepcion
        /// </summary>
        /// <param name="mensaje">string</param>
        /// <param name="excepcion">excepcion</param>
        public DniInvalidoException(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {

        }

        /// <summary>
        /// Constructor excepción con parametros (recibe mensaje de error)
        /// </summary>
        /// <param name="mensaje">string</param>
        public DniInvalidoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
