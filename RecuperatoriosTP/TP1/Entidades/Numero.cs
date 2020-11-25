using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        
        /// <summary>
        /// Constructor por defecto (sin parámetros) asignará valor 0 al atributo numero.
        /// </summary>
        public Numero()
        {
            this.numero=0;
        }

        /// <summary>
        /// Construnctor con parametro double
        /// </summary>
        /// <param name="numero">double</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Validará que el string strNumero sea un numero, caso contrario devolverá un 0
        /// </summary>
        /// <param name="strNumero">string</param>
        /// <returns>double</returns>
        private double ValidarNumero(string strNumero)
        {
            double num =0;
            double.TryParse(strNumero, out num);
            return num;
        }

        /// <summary>
        /// Seteará un numero, propiedad sólo escritura
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Construnctor con parametro string
        /// </summary>
        /// <param name="strNumero">string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }


        /// <summary>
        /// Sobrecarga operador +
        /// </summary>
        /// <param name="n1">Numero</param>
        /// <param name="n2">Numero</param>
        /// <returns>double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga operador -
        /// </summary>
        /// <param name="n1">Numero</param>
        /// <param name="n2">Numero</param>
        /// <returns>double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga operador *
        /// </summary>
        /// <param name="n1">Numero</param>
        /// <param name="n2">Numero</param>
        /// <returns>oduble</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga operador /
        /// </summary>
        /// <param name="n1">Numero</param>
        /// <param name="n2">Numero</param>
        /// <returns>double</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = double.MinValue;

            if (n2.numero != 0) resultado = n1.numero / n2.numero;
            
            return resultado;
        }

        /// <summary>
        /// Validará que el numero (string) sea binario.
        /// </summary>
        /// <param name="binario">string</param>
        /// <returns>boolean</returns>
        private static bool EsBinario(string binario)
        {
            bool isBinary = false;

            foreach (char element in binario)
            {
                if(element == '0' || element == '1')
                    isBinary = true;
            }

            return isBinary;
        }

        /// <summary>
        /// Convertirá un numero (double) a binario
        /// </summary>
        /// <param name="numero">double</param>
        /// <returns>string</returns>
        public static string DecimalBinario(double numero)
        {
            string resultado = "Error: valor inválido!";

            long entero = (long)numero;

            if (entero < 0) 
                entero *= -1;

            resultado = Convert.ToString(entero, 2);

            return resultado;
        }

        /// <summary>
        /// Convertirá un numero decimal (string) a binario
        /// </summary>
        /// <param name="numero">string</param>
        /// <returns>string</returns>
        public static string DecimalBinario(string numero)
        {
            string resultado = "Error: valor inválido!";
            double num;

            if (double.TryParse(numero, out num))
                resultado = DecimalBinario(num);            

            return resultado;
        }


        /// <summary>
        /// Convertirá numero en binario (string) a decimal (string)
        /// </summary>
        /// <param name="binario">string</param>
        /// <returns>string</returns>
        public static string BinarioDecimal(string binario)
        {
            int dec;
            string resultado = "Error: valor inválido!";

            if (EsBinario(binario))
            {
                dec = Convert.ToInt32(binario, 2);
                resultado = dec.ToString();
            }
            
            return resultado;
        }
    }
}
