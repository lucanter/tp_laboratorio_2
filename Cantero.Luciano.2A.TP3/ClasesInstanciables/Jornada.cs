using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;
using Archivos;
using System.CodeDom;
using System.ComponentModel;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// get o set Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get 
            { 
                return this.alumnos; 
            }
            set
            {
                this.alumnos = new List<Alumno>(value);
            }
        }

        /// <summary>
        /// get o set Clase 
        /// </summary>
        public EClases Clase
        {
            get
            { 
                return this.clase; 
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// get o setea Instructor
        /// </summary>
        public Profesor Instructor
        {
            get 
            { 
                return this.instructor; 
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor (privado) Jornada (inicializador de la lista de alumnos)
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor Jornada con parámetros
        /// </summary>
        /// <param name="clase">enumerado</param>
        /// <param name="instructor">Profesor</param>
        public Jornada(EClases clase, Profesor instructor) 
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Guarda datos en un archivo
        /// </summary>
        /// <param name="jornada">Jornada</param>
        /// <returns>bool</returns>
        public static bool Guardar(Jornada jornada)
        {            
            bool saved = false;

            Texto text = new Texto();
            
            saved = text.Guardar("Jornada.txt", jornada.ToString());

            return saved;
        }

        /// <summary>
        /// Lee datos de un archivo
        /// </summary>
        /// <returns>string</returns>
        public string Leer()
        {
            Texto text = new Texto();

            string read;

            text.Leer("Jornada.txt", out read);

            return read;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Operador ==. Si el alumno pertence a la clase, true; si no, false.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>bool</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool areEqual = false;

            if (a == j.clase)
            {
                areEqual= true;
            }

            return areEqual;
        }

        /// <summary>
        /// Operador !=. Si el alumno pertence a la clase, false; si no, true.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>bool</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Operador +
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>bool</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j !=a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        /// <summary>
        /// Imprime datos Jornada
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendFormat("CLASE DE {0} POR {1}\n",this.clase.ToString(),this.instructor.ToString());

            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("<--------------------------------------------------->");

            return sb.ToString();
        }
        #endregion
    }
}
