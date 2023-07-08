using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class Vector2Test
    {
        [TestMethod]
        public void VectorUnitTestOK()
        {
            int x = 2;
            int y = 5;

            var vector = new Game.Vector2(x, y);

            var resultado = vector.ToString();

            var resultadoEsperado = $"X: {x} / Y: {y}";

            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
}