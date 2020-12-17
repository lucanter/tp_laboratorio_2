using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Entidades
{
    /// <summary>
    /// Clase estática, encargada de manejar el proceso de venta
    /// </summary>
    public class Inventario
    {

        #region Atributos

        static List<Venta> ventas;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor default
        /// </summary>
        static Inventario()
        {
            ventas = new List<Venta>();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Retorna toda la lista de armas cargadas en la base de datos
        /// </summary>
        public static List<Armamento> Armas
        {
            get
            {
                List<Armamento> armas = new List<Armamento>();
                ArmamentoBD armament = new ArmamentoBD();

                return armas = armament.Leer();
            }
        }

        /// <summary>
        /// Propiedad de lista de Ventas
        /// </summary>
        public static List<Venta> Ventas 
        {
            get
            {
                return ventas;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guarda la lista de ventas en un archivo en formato XML
        /// </summary>
        /// <param name="ventas"></param>
        /// <returns>Retorna booleano (true) si se guardo o (false) si no.</returns>
        public static bool Guardar(List<Venta> ventas)
        {
            string archivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "inventario.xml");
            Xml<List<Venta>> save = new Xml<List<Venta>>();

            return save.Guardar(archivo, ventas);
        }

        /// <summary>
        /// Lee el listado de ventas en un archivo en formato XML
        /// </summary>
        /// <returns></returns>
        public static List<Venta> Leer()
        {
            List<Venta> datos = new List<Venta>();
            string archivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "inventario.xml");
            Xml<List<Venta>> read = new Xml<List<Venta>>();

            read.Leer(archivo, out datos);

            return datos;
        }

        /// <summary>
        /// Imprime listado de armas cargadas en la base de datos
        /// </summary>
        /// <returns></returns>
        public static string MostrarArmas()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Listado de armas:");

            foreach (Armamento item in Inventario.Armas)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("__________________________");

            return sb.ToString();
        }


        /// <summary>
        /// Carga una venta a la lista de ventas del inventario
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>Retorna booleano (true) si se añadió o (false) si no.</returns>
        public static bool cargarVenta(Venta venta)
        {
            bool added = false;

            if (venta != null)
            {
                Inventario.ventas.Add(venta);
                added = true;
            }

            return added;
        }

        /// <summary>
        /// Descuenta el stock del arma que se vende.
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>Retorna booleano (true) si logró descontar el stock o (false) si no.</returns>
        public static bool restarStock(Venta venta)
        {
            if (venta != null)
            {
                Armamento arma;
                for (int i = 0; i < venta.Armas.Count; i++)
                {
                    for (int j = 0; j < Inventario.Armas.Count; j++)
                    {
                        if (venta.Armas[i].Id == Inventario.Armas[j].Id)
                        {
                            arma = Inventario.Armas[j];
                            arma.Stock -= 1;
                            arma.Modificar();
                            break;
                        }
                    }
                }
                //utilizo varios return para forzar la salida
                return true;
            }
            return false;
        }

        #endregion
    }
}
