using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados
        //public enumerados para que los tipos de propiedad 'Vehiculo.EMarca' y 'Vehiculo.ETamanio' sea accesible como la propiedad 'Vehiculo.Tamanio':
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region Atributos
        EMarca marca;
        string chasis;
        ConsoleColor color;
        #endregion

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio //al declarar protected el método abstracto, se podrán acceder desde las otras subclases.
        { 
            get;
        }

        #region Constructor
        /// <summary>
        /// Constructor vehiculo
        /// </summary>        
        /// <param name="chasis">string</param>
        /// <param name="marca">EMarca</param>
        /// <param name="color">ConsoleColor</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.color = color;
            this.marca = marca;
            this.chasis = chasis;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar() //hago publico y virtual para las clases derivadas
        {
            return (string)this; 
        }

        /// <summary>
        /// Imprime datos de un vehiculo
        /// </summary>
        /// <param name="p">Vehiculo</param>
        /// <returns>string</returns>
        public static explicit operator string(Vehiculo p) //public static ya que una declaración de operador debe incluir un modificador público estático.
        {
            StringBuilder sb = new StringBuilder();
            //AppendFormat, ya que ninguna sobrecarga para el método 'AppendLine' toma 2 argumentos:
            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);         
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString(); //ToString(), ya que no se puede convertir implícitamente el tipo 'System.Text.StringBuilder' en 'string'
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        #endregion
    }
}
