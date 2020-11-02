using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor excepción
        /// </summary>
        public AlumnoRepetidoException()
            : base("Alumno repetido.")
        {

        }

        /// <summary>
        /// Constructor excepción con parametros (recibe mensaje de error)
        /// </summary>
        /// <param name="mensaje">string</param>
        public AlumnoRepetidoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
