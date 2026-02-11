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
        /*
        int comparison = 0;
        List<int> unsortedList = new List<int> { 5, 2, 4, 1, 3, 6 };
        List<int> sortedList = new List<int> { 1, 2, 3, 4, 5, 6 };
        List<int> reverseSortedList = new List<int> { 6, 5, 4, 3, 2, 1 };
        List<int> emptyList = new List<int>();
        */

        /*
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            int comparison = 0;
            var unsortedList = new List<int> { 5, 2, 4, 1, 3, 6 };
            var sortedList = new List<int> { 1, 2, 3, 4, 5, 6 };

            // Act
            MyList<int>.InsertSort(unsortedList, Comparer<int>.Default, ref comparison);

            // Assert
            CollectionAssert.AreEqual(sortedList, unsortedList);

        }
        */

        [TestMethod]
        public void TestMethod2() 
        {
            int comparison = 0;
            var emptyList = new List<int>();

            MyList<int>.InsertSort(emptyList, Comparer<int>.Default, ref comparison);

            Assert.IsNull(emptyList);
        }

    }
}
