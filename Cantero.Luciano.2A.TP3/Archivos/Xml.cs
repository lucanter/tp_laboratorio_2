using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{   
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda datos en un archivo
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">interface</param>
        /// <returns>bool</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool saved = true;
            try
            {
                using (XmlTextWriter write = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(write, datos);                    
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
        /// <param name="datos">interface</param>
        /// <returns>bool</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool read = true;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(reader);                    
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
