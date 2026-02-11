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
            //int comparison = 0;
            var emptyList = new MyList<int>(0);

            //MyList<int>.InsertSort(emptyList, Comparer<int>.Default, ref comparison);

            Assert.AreEqual(0, emptyList.Count);
        }
    }
}
