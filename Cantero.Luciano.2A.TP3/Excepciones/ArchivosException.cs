using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {

        /// <summary>
        /// Constructor excepcion con mensjae default
        /// </summary>
        public ArchivosException()
            : base("Ha ocurrido un error con los archivos.")
        {

        }

        /// <summary>
        /// Constructor excepción con parametros (recibe mensaje de error)
        /// </summary>
        /// <param name="mensaje">string</param>
        public ArchivosException(string mensaje) 
            : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor con parámetro (innerException)
        /// </summary>
        /// <param name="innerException">Excepcion</param>
        public ArchivosException(Exception innerException)
            : base(innerException.Message)
        {

        }
    }
}
