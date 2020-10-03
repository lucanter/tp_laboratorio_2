using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades 
{
    public class Suv : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Constructor SUV (inicializador marca, chasis, color)
        /// </summary>
        /// <param name="marca">EMarca</param>
        /// <param name="chasis">string</param>
        /// <param name="color">ConsoleColor</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Imprime datos del SUV
        /// </summary>
        /// <returns>string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar()); //Vehiculo.Mostrar() para imprimir los datos del vehiculo
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio); //AppendFormat, ya que ninguna sobrecarga para el método 'AppendLine' toma 2 argumentos
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //ToString(), ya que no se puede convertir implícitamente el tipo 'System.Text.StringBuilder' en 'string'
        }
        #endregion
    }
}
