using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor con mensaje default
        /// </summary>
        public SinProfesorException()
            : base("No hay Profesor para la clase.")
        {

        }

        /// <summary>
        /// Constructor excepción con parametros (recibe mensaje de error)
        /// </summary>
        /// <param name="mensaje">string</param>
        public SinProfesorException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
