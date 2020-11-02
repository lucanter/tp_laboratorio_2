using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{    
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos en un archivo
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">interface</param>
        /// <returns>bool</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee los datos de un archvio
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">interface</param>
        /// <returns>bool</returns>
        bool Leer(string archivo, out T datos);

    }
}
