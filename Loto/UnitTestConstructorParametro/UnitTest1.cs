using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LotoClassNS;

namespace UnitTestConstructorParametro
{
    [TestClass]
    public class UnitTest1
    {        
        [DataTestMethod]
        [DataRow(0, false)]
        public void ConstructorParametroMisNumMenorA1(int[] numeros, bool esValida)
        {
            BMS2223 bMS2223 = new BMS2223(numeros);

            Assert.AreEqual(esValida, false, "Error");
        }

        [DataTestMethod]
        [DataRow(1, 2, 3, 4, 5, 6, 7, false)]
        [DataRow(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, false)]
        public void ConstructorParametroMisNumMayor6(int[] numeros, bool esValida)
        {
            BMS2223 bMS2223 = new BMS2223(numeros);

            Assert.AreEqual(esValida, false, "Error");
        }
    }
}
