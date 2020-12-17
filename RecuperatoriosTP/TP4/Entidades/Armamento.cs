using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace Entidades
{
    /// <summary>
    /// Serializable
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Fusil))]
    [XmlInclude(typeof(Pistola))]
    [XmlInclude(typeof(Dron))]
    [XmlInclude(typeof(Explosivo))]
    public class Armamento
    {
        #region Atributos

        ETipo tipo;
        public int id;
        public string nombre;
        public string origen;
        public int precio;
        public int stock;

        #endregion

        #region Enumerados

        /// <summary>
        /// Enumerado
        /// </summary>
        public enum ETipo
        {
            fusil,
            pistola,
            dron,
            explosivo
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Getter y Setter de Id (al ser autoincremental, la propiedad de escritura no se utiliza)
        /// </summary>
        public int Id 
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Getter y Setter de Nombre
        /// </summary>
        public string Nombre 
        {
            get
            { 
                return this.nombre; 
            }

            set
            {
                this.nombre = value; 
            } 
        }

        /// <summary>
        /// Getter y Setter de TipoArmamento
        /// </summary>
        public ETipo TipoArmamento
        {
            get 
            { 
                return this.tipo; 
            }

            set 
            { 
                this.tipo = value; 
            }
        }

        /// <summary>
        /// Getter y Setter de Origen
        /// </summary>
        public string Origen
        {
            get
            {
                return this.origen;
            }

            set
            {
                this.origen = value;
            }
        }

        /// <summary>
        /// Getter y Setter de Precio (se valida negativos en la propiedad de escritura)
        /// </summary>
        public int Precio
        {
            get
            {
                return this.precio;
            }

            set
            {
                this.precio = value;
            }
        }
        
        /// <summary>
        /// Getter y Setter de Stock (se valida negativos en la propiedad de escritura)
        /// </summary>
        public int Stock
        {
            get
            {
                return this.stock;
            }

            set
            {
                this.stock = value;
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parámetros (default)
        /// </summary>
        public Armamento()
        {
        }

        /// <summary>
        /// Constructor parametrizado (sin id)
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="tipoArmamento"></param>
        /// <param name="origen"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>        
        public Armamento(string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
        {
            this.nombre = nombre;
            this.tipo = tipoArmamento;
            this.origen = origen;
            this.precio = precio;
            this.stock = stock;
        }

        /// <summary>
        /// Constructor parametrizado (con id)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="tipoArmamento"></param>
        /// <param name="origen"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Armamento(int id, string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : this(nombre, tipoArmamento, origen, precio, stock)
        {
            this.id = id;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Igualdad entre lista de objeto y objeto, verifica si el objeto ya está en la lista (si el id se encuentra en la lista)
        /// </summary>
        /// <param name="armas"></param>
        /// <param name="arma"></param>
        /// <returns>Retorna booleano (true) si el id se encuentra en la lista o (false) si no.</returns>
        public static bool operator ==(List<Armamento> armas, Armamento arma)
        {
            bool areEqual = false;

            foreach (Armamento item in armas)
            {
                if (item.id == arma.id)
                {
                    areEqual = true;
                }
            }

            return areEqual;
        }

        /// <summary>
        /// Desigualdad entre lista de objeto y objeto, verifica si el objeto no está en la lista (si el id no se encuentra en la lista)
        /// </summary>
        /// <param name="armas"></param>
        /// <param name="arma"></param>
        /// <returns>Retorna booleano (false) si el id se encuentra en la lista o (true) si no.</returns>
        public static bool operator !=(List<Armamento> armas, Armamento arma)
        {
            return !(armas == arma);
        }

        /// <summary>
        /// Suma de lista de objeto y objeto, verifica si el objeto no esta cargado en la lista. Si no está, lo agrega.
        /// </summary>
        /// <param name="armas"></param>
        /// <param name="arma"></param>
        /// <returns>Retorna booleano (true) si el arma se guarda o (false) si ya se encontró una igual en la lista (por id).</returns>
        public static bool operator +(List<Armamento> armas, Armamento arma)
        {
            bool added = false;

            if (armas != arma)
            {
                arma.Guardar();
                added = true;
            }
            else
            {
                throw new ArmamentosException("Aviso: el arma ya está cargada en la base de datos.");
            }

            return added;
        }

        /// <summary>
        /// Verifica si un producto no esta cargado en la base de datos y lo elimina
        /// Resta de lista de objeto y objeto, verifica que el objeto esté cargado en la lista. Si es así, lo elimina.
        /// </summary>
        /// <param name="armas"></param>
        /// <param name="arma"></param>
        /// <returns>el objeto de tipo inventario con el producto borrado, si no se encontraba en la lista lanza ProductosException</returns>
        public static bool operator -(List<Armamento> armas, Armamento arma)
        {
            bool removed = false;

            if (armas == arma)
            {
                arma.Eliminar();
                removed = true;
            }
            else
            {
                throw new ArmamentosException("Error: el arma no está en la base de datos.");
            }

            return removed;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Imprime y retorna los datos de un arma en formato string
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Origen: {this.origen}");
            sb.AppendLine($"Precio: {this.precio}");
            sb.AppendLine($"Stock: {this.stock}");

            return sb.ToString();
        }

        /// <summary>
        /// Override de MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Valida si un numero es negativo
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Retorna booleano (true) si es negativo o (false) si es positivo.</returns>
        public static bool ValidarNegativo(int num)
        {
            bool isNegative = false;

            if (num < 0)
                isNegative = true;

            return isNegative;
        }

        /// <summary>
        /// Guarda (insert) el objeto Armamento en la base de datos
        /// </summary>
        /// <returns>Retora booleano (true) si se guardó en la basde de datos o (false) si no.</returns>
        public bool Guardar()
        {
            ArmamentoBD arma = new ArmamentoBD();
            return arma.InsertarArma(this);
        }

        /// <summary>
        /// Modificar (update) el objeto Armamento en la base de datos
        /// </summary>
        /// <returns>Retora booleano (true) si se modificó en la basde de datos o (false) si no.</returns>
        public bool Modificar()
        {
            ArmamentoBD arma = new ArmamentoBD();
            return arma.ModificarArma(this);
        }


        /// <summary>
        /// Elimina (delete) el objeto Armamento de la base de datos.
        /// </summary>
        /// <returns>Retora booleano (true) si se eliminó de la basde de datos o (false) si no.</returns>
        public bool Eliminar()
        {
            ArmamentoBD arma = new ArmamentoBD();
            return arma.EliminarArma(this);
        }
        #endregion
    }
}
