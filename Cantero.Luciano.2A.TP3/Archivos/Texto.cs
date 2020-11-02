using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda datos en un archivo
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">string</param>
        /// <returns>bool</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool saved = true;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    sw.WriteLine(datos);                    
                }                
            }
            catch (Exception excepcion)
            {
                saved = false;
                throw new ArchivosException(excepcion);
            }

            return saved;
        }

        /// <summary>
        /// Lee datos de un archivo
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">string</param>
        /// <returns>bool</returns>

        public bool Leer(string archivo, out string datos)
        {
            bool read = true;

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();                    
                }                
            }
            catch (Exception excepcion)
            {
                read = false;
                throw new ArchivosException(excepcion);
            }

            return read;
        }
    }
}
