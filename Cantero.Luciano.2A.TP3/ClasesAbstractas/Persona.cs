using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        #endregion


        #region Enumerado
        /// <summary>
        /// Enumerado nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, 
            Extranjero
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// get o set Nombre
        /// </summary>
        public string Nombre
        {
            get 
            { 
                return this.nombre; 
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// get o set Apellido
        /// </summary>
        public string Apellido
        {
            get 
            { 
                return this.apellido; 
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// get o set Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// get o set DNI
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// set string DNI
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor Persona
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor Persona con parámetros
        /// </summary>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="nacionalidad">enumerado</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor Persona con parámetros (integer dni)
        /// </summary>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">int</param>
        /// <param name="nacionalidad">enumerados</param>
        /// 
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor Persona con parámetros (string dni)
        /// </summary>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">enumerado</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Valida DNI
        /// </summary>
        /// <param name="nacionalidad">enumerado</param>
        /// <param name="dato">int</param>
        /// <returns>int</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            //dato - DNI
            int validated;

            if ((nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) ||
                nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                validated = dato;
            }
            else if (dato > 99999999 || dato < 1)
            {
                throw new DniInvalidoException();
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }

            return validated;
        }

        /// <summary>
        /// Valida DNI (string)
        /// </summary>
        /// <param name="nacionalidad">enumerado</param>
        /// <param name="dato">string</param>
        /// <returns>int</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = -1;
            int validated;

            if (!(int.TryParse(dato, out dni)))
            {
                throw new DniInvalidoException("El DNI no coincide con el formato establecido (solo digitos)");
            }
            else
            { 
                validated = ValidarDni(nacionalidad, dni);
            }

            return validated;
        }

        /// <summary>
        /// Validar nombre y apellido
        /// </summary>
        /// <param name="dato">string</param>
        /// <returns>string</returns>
        private string ValidarNombreApellido(string dato)
        {
            //bool validated = false;

            foreach (char item in dato)
            {
                if (!(char.IsLetter(item)))
                {
                    return null;
                }
            }

            return dato;
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Nombre, apellido y nacionalidad a string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.apellido, this.nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.nacionalidad);

            return sb.ToString();
        }
        #endregion
    }

}
