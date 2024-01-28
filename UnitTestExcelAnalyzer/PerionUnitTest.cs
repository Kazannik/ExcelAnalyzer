using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExcelAnalyzer.Arm;

namespace UnitTestExcelAnalyzer
{
    [TestClass]
    public class PerionUnitTest
    {
        [TestMethod]
        public void TestPerionValue()
        {
            Period period = Period.MaxValue;
            Assert.AreEqual(period.Month, 12, 0, "Месяц не является максимальным значением");
            Assert.AreEqual(period.Year, 2199, 0, "Год не является максимальным значением");
        }


        [TestMethod]
        public void TestPerionParse()
        {
            Period period = Period.Parse("202401");
            Assert.AreEqual(period, Period.Create(2024,01), "Период не соответствует заданному");
            try
            {
                period = Period.Parse("2024-1");
            }
            catch (ArgumentException e)
            {
               
               
            }
        }
    }
}
