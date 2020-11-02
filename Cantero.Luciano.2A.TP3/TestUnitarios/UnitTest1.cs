using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using ClasesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        #region Test Unitarios a Excepciones
        /// <summary>
        /// Test: se debe llamar a DniInvalidoException cuando el DNI sea incorrecto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DNI_Invalido()
        {
            Alumno subject = new Alumno(7, "Nombne", "Apellido", "dni", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
        }

        /// <summary>
        /// Test: se debe llamar a AlumnoRepetidoException cuando el alumno se encuentre repetido.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void Alumno_Repetido()
        {
            Universidad university = new Universidad();

            Alumno subject = new Alumno(1, "Nombre", "Apellido", "46486963", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            university += subject;
            university += subject;
        }

        /// <summary>
        /// Test: se debe llamar a NacionalidadInvalidaException cuando la nacionalidad sea invalida.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void Nacionalidad_Invalida()
        {
            Alumno subject = new Alumno(1, "Nombre", "Apellido", "46486963", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
        }
        #endregion

        #region Test Unitarios b Colecciones
        /// <summary>
        /// Test: se debe validar que se haya instanciado alumnos
        /// </summary>
        [TestMethod]
        public void Instancia_Correcta_Alumnos()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
        }

        /// <summary>
        /// Test: se debe validar que se haya instanciado profesores
        /// </summary>
        [TestMethod]
        public void Instancia_Correcta_Instructores()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Instructores);
        }

        #endregion
    }
}
