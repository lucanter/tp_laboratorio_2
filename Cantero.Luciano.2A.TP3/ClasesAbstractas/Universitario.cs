using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributo
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor Universitario
        /// </summary>
        public Universitario()
            : base()
        {

        }

        /// <summary>
        /// Constructor Universitario con parámetros
        /// </summary>
        /// <param name="legajo">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">enumerado</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Firma
        /// </summary>
        /// <returns>string</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Imprime datos de Universitario
        /// </summary>
        /// <returns>string</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}\n",this.legajo);

            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Operador ==, retorna booleano: true si son iguales(mismo legajo o dni), false si son distintos
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool areEqual = false;

            if ( (object)pg1 != null && (object)pg2 != null)
            {
                if( (pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI) )
                {
                    areEqual = true;
                }
            }

            return areEqual;
        }

        /// <summary>
        /// Operador !=
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Retorna booleano (true si son de igual objeto, false si son distintos)
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            bool areEqual = false;

            if (obj is Universitario)
            {
                areEqual = this == (Universitario)obj;
            }

            return areEqual;
        }
        #endregion
    }

}