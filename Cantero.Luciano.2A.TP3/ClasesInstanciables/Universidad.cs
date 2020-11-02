using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Enumerados
        public enum EClases
        {
            Programacion, 
            Laboratorio, 
            Legislacion, 
            SPD
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// get o set Alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = new List<Alumno>(value); //la nueva expresión requiere lista de argumentos o () después del tipo
            }
        }

        /// <summary>
        /// get o set Pofesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = new List<Profesor>(value);
            }
        }

        /// <summary>
        /// get o set Jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = new List<Jornada>(value);
            }
        }

        /// <summary>
        /// get o set (indexador) Jornada 
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Universidad
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>(); 
            this.jornada = new List<Jornada>(); 
            this.profesores = new List<Profesor>(); 
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Imprime datos
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>string</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda datos en un archivo
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>bool</returns>
        public static bool Guardar(Universidad uni)
        {
            bool saved;

            Xml<Universidad> serializador = new Xml<Universidad>();

            saved = serializador.Guardar("Universidad.xml", uni);

            return saved;
        }

        /// <summary>
        /// Lee datos de un archivo
        /// </summary>
        /// <returns>Universidad</returns>
        public Universidad Leer()
        {
            Xml<Universidad> ser = new Xml<Universidad>();
            Universidad read = new Universidad();

            ser.Leer("Universidad.xml", out read);

            return read;
        }
        
        /// <summary>
        /// Datos de Universidad en string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Operador ==
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool areEqual = false;

            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    areEqual = true;
                }
            }

            return areEqual;
        }

        /// <summary>
        /// Operador !=
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Operador ==
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool areEqual = false;

            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
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
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Operador ==
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">enumerado</param>
        /// <returns>Profesor</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor professor = null;

            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    professor = item;
                    break;
                }
            }
            if (professor is null) 
            {
                throw new SinProfesorException();
            }

            return professor;
        }

        /// <summary>
        /// Operador !=
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">enumerado</param>
        /// <returns>Profesor</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor professor = null;

            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    professor = item;
                    break;
                }
            }

            if (professor is null)
            {
                throw new SinProfesorException("Todos los profesores pueden dar la clase.");
            }

            return professor;
        }

        /// <summary>
        /// Operador +
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">enumerado</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase); 

            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
                {
                    jornada.Alumnos.Add(item);
                }
            }
            
            g.Jornadas.Add(jornada);            

            return g;
        }

        /// <summary>
        /// Operador +
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Operador +
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        #endregion
    }
}
