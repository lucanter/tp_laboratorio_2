using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia, 
            Deudor, 
            Becado
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor Alumno
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor Alumno con parámetros
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">enumerado</param>
        /// <param name="claseQueToma">enumerado</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id,nombre, apellido, dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor Alumno con parámetros, estadoCuenta
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">enumerado</param>
        /// <param name="claseQueToma">enumerado</param>
        /// <param name="estadoCuenta">enumerado</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id,nombre, apellido, dni,nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Imprime datos Alumno, claseQueToma
        /// </summary>
        /// <returns>string</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("TOMA CLASES DE {0}\n", this.claseQueToma);

            return sb.ToString();
        }

        /// <summary>
        /// Imprime datos Alumno, estadoCuenta
        /// </summary>
        /// <returns>string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// ToString los datos de Alumno
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Operador ==
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">enumerado</param>
        /// <returns>bool</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Operador !=
        /// </summary>
        /// <param name="a">object</param>
        /// <param name="clase">enumerado</param>
        /// <returns>bool</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }

        #endregion
    }
}
