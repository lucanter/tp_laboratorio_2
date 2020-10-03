using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Constructor (inicializador)
        /// </summary>
        /// <param name="marca">EMarca</param>
        /// <param name="chasis">string</param>
        /// <param name="color">ConsoleColor</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis, marca, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio //protected override para realizar otra implementación de la propiedad virtual heredada de la clase base.
        {
            get
            {
                return ETamanio.Chico; 
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Imprime datos de ciclomotor
        /// </summary>
        /// <returns>string</returns>
        public override sealed string Mostrar() //de privado a publico para que se pueda acceder
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio); //AppendFormat, ya que ninguna sobrecarga para el método 'AppendLine' toma 2 argumentos
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //ToString(), ya que no se puede convertir implícitamente el tipo 'System.Text.StringBuilder' en 'string'
        }
        #endregion
    }
}
