using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos en un archivo en formato de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retornará booleano (true) si se guardaron los datos o (false) si no.</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool saved = false;

            try
            {
                if (!String.IsNullOrEmpty(archivo) && !String.IsNullOrEmpty(datos))
                {
                    using (StreamWriter sw = new StreamWriter(archivo, false))
                    {
                        sw.WriteLine(datos);
                    }
                    saved = true;
                }
            }
            catch (Exception)
            {

                throw new ArchivosException("Error: No se pudo guardar el archivo.");
            }

            return saved;
        }

        /// <summary>
        /// Lee los datos de un archivo en formato de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retornará booleano (true) si se leyeron los datos o (false) si no.</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool read = false;
            datos = String.Empty;

            try
            {
                if (File.Exists(archivo))
                {
                    using (StreamReader sr = new StreamReader(archivo))
                    {
                        datos = sr.ReadToEnd();
                        read = true;                        
                    }
                }
            }
            catch (ArchivosException)
            {
                throw new ArchivosException("Error: No se pudo leer el archivo.");
            }

            return read;
        }
    }
}
