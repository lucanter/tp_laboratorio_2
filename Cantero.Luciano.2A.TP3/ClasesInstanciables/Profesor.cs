using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> clasesDelDia;
        static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor (static) Profesor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor Profesor
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Constructor Profesor con parámetros
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">enumerado</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre,apellido, dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>(); 
            this._randomClases();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Asignación de un numero random al queue.
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((EClases)Profesor.random.Next(0, 3)); 
            }
        }

        /// <summary>
        /// Imprime datos de Profesor
        /// </summary>
        /// <returns>string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// ToString clasesDelDia de Profesor
        /// </summary>
        /// <returns>string</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA :");
            foreach (EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Operador ==
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">enumerado</param>
        /// <returns>bool</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool areEqual = false;

            foreach (EClases item in i.clasesDelDia)
            {
                if (item == clase)                   
                {
                    areEqual = true;
                    break;
                }
            }

            return areEqual;
        }

        /// <summary>
        /// Operador !=
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">enumerado</param>
        /// <returns>bool</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Retorna datos del Profesor
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
