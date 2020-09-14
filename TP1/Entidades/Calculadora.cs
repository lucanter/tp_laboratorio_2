using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Validará que el operador recibido sea +, -, / o *. Caso contrario retornará +.
        /// </summary>
        /// <param name="operador">Operador</param>
        /// <returns>String</returns>
        private static string ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '/' && operador != '*')
                operador = '+';

            return operador.ToString();
        }

        /// <summary>
        /// Realiza la operacion recibida entre los dos numeros, toma + por defecto
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Double</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador[0])) //recurso para leer el string como char
            {
                case "-":
                    resultado = num1 - num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                default:
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }
    }
}
