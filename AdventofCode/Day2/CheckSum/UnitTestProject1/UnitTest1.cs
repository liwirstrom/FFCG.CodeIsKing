using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckSum;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWholeDivision()
        {
            //FileReader fileReader = new FileReader();
            //List<List<int>> inputList = fileReader.ReadFile(@"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\AdventofCode\Day2\inputData.txt");
            List<List<double>> inputList = new List<List<double>>();
            List<double> row1 = new List<double>(new double[] { 5.0, 9.0, 2.0, 8.0 });
            inputList.Add(row1);
            List<double> row2 = new List<double>(new double[] { 9, 4, 7, 3});
            inputList.Add(row2);
            List<double> row3 = new List<double>(new double[] { 3, 8, 6, 5});
            inputList.Add(row3);
            Calculator calculator = new CheckSum.Calculator();
            double answer = calculator.FindWholeDivision(inputList);

            Assert.AreEqual(9, answer);
        }
    }
}
