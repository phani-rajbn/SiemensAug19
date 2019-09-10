using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Reference of UnitTesting
namespace UnitTestingDll
{
    public class MathClass
    {
        public double AddFunc(double v1, double v2) => v1 + v2;
        public double SubFunc(double v1, double v2) => v1 - v2;
        public double MulFunc(double v1, double v2) => v1 * v2;
        public double DivFunc(double v1, double v2)
        {
            if (v2 == 0)
                throw new Exception("Division by zero");
            return v1 / v2;
        }

        public int GetCount(string v)
        {
            var words = v.Split(' ');
            return words.Length;
        }
    }

        [TestClass]
        public class MyTestClass
        {
            MathClass obj;

            [TestInitialize]
            public void Initialize()
            {
            
              obj = new MathClass();
            }

            [TestCleanup]
            public void clean()
            {
                obj = null; 
                GC.Collect();
            }

            [TestMethod]
            public void testForAddition()
            {
                var res = obj.AddFunc(12, 13);
                Assert.AreEqual(25, res);
            }
            [TestMethod]
            public void testForSubtract()
            {
                var res = obj.SubFunc(12, 13);
                Assert.AreEqual(-1, res);
            }
        [TestMethod]
            public void testForWords()
            {
                int no = obj.GetCount("Apple a Day keeps the Doctor away");
                Assert.AreEqual(7, no);
            }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestForException()
        {
            obj.DivFunc(123, 0);
        }
        }
    }
       