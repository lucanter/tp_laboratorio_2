using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Entidades;

namespace Archivos
{
    /// <summary>
    /// Generics
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos en un archivo en formato XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retornará booleano (true) si se guardaron los datos o (false) si no.</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool saved = false;

            try
            {
                if (archivo != null)
                {
                    using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                    {
                        XmlSerializer serializador = new XmlSerializer(typeof(T));
                        serializador.Serialize(writer, datos);
                        saved = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error: No se pudo guardar el archivo.", e);
            }

            return saved;
        }

        /// <summary>
        /// Lee los datos de un archivo en formato XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retornará booleano (true) si se leyeron los datos o (false) si no.</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool read = false;
            datos = default(T);

            try
            {
                if (File.Exists(archivo))
                {
                    using (XmlTextReader reader = new XmlTextReader(archivo))
                    {
                        XmlSerializer serializador = new XmlSerializer(typeof(T));
                        datos = (T)serializador.Deserialize(reader);
                        read = true;
                    }
                }
            }
            catch (Exception)
            {
                throw new ArchivosException("Error al intentar leer archivo xml");
            }

            return read;
        }
    }
}
