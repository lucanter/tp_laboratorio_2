using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;
using Archivos;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test: debe lazar excepcion al intentar eliminar un producto que no está en la base de datos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArmamentosException))]
        public void Test_Eliminar_Arma_No_Cargada()
        {
            bool retorno;

            Armamento arma = new Dron("Blablabla", Armamento.ETipo.dron, "americano", 62, 30);

            retorno = Inventario.Armas - arma;
        }

        /// <summary>
        /// Test: se debe validar que se haya instanciado Venta
        /// </summary>
        [TestMethod]
        public void Test_Instancia_Correcta_Venta()
        {
            Venta venta = new Venta();

            Assert.IsNotNull(venta.Armas);
        }
    }
}
