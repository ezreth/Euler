using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EulerCalculo;

namespace EulerTest
{
    [TestClass]
    public class uiEulerTest
    {


        [TestMethod]
        public void EulerTest()
        {

            long expected = 23;
            long result = new Problema18().Calcular();

            Assert.AreEqual(expected, result, 1, "No se calculo correctamente");



        }
    }
}
