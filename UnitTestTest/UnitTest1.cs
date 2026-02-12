using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.CompilerServices;
using Test;

namespace UnitTestTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            Program p = new Program();

            MyList<int> ranList = new MyList<int>();
            MyList<int> conList = new MyList<int>();
            List<int> random = new List<int>() { 3, 2, 4, 1, 5 };
            List<int> control = new List<int>() { 1, 2, 3, 4, 5 };

            foreach (var item in random)
            {
                ranList.Add(item);
            }
            foreach (var item in control)
            {
                conList.Add(item);
            }

            //Act
            int comparisonCount = 0;
            ranList.InsertSort(Comparer<int>.Default, ref comparisonCount);

            var actual = new List<int>();
            for (int i = 0; i < ranList.Count; i++)
            {
                actual.Add(ranList[i]);
            }

            //Assert
            CollectionAssert.AreEqual(control, actual);
        }
    }
}
