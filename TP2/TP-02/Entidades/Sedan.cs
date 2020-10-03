using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Enumerador
        /// <summary>
        /// Enumerados de ETipo
        /// </summary>
        public enum ETipo { CuatroPuertas, CincoPuertas }
        #endregion

        #region Atributo
        private ETipo tipo; //solo lectura
        #endregion

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">EMarca</param>
        /// <param name="chasis">string</param>
        /// <param name="color">ConsoleColor</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Constructor con todos los parametros marca, chasis, color, tipo.
        /// </summary>
        /// <param name="marca">EMarca</param>
        /// <param name="chasis">string</param>
        /// <param name="color">ConsoleColor</param>
        /// <param name="tipo">ETipo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        #endregion

        #region Metodo
        /// <summary>
        /// Imprime datos del Sedan
        /// </summary>
        /// <returns>string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar()); //Vehiculo.Mostrar() para imprimir los datos del vehiculo
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio); //AppendFormat, ya que ninguna sobrecarga para el método 'AppendLine' toma 2 argumentos
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //ToString(), ya que no se puede convertir implícitamente el tipo 'System.Text.StringBuilder' en 'string'
        }
        #endregion
    }
}
