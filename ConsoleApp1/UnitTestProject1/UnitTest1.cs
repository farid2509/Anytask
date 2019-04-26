using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleTest()
        {
            var check = new HashTable.HashTable(3);
            for (var i = 0; i < 3; i++)
            {
                check.PutPair(i, i + 1);
                Assert.AreEqual(i + 1, check.GetValueByKey(i));
            }
        }

        [TestMethod]
        public void SameKeyTest()
        {
            var check = new HashTable.HashTable(3);
            check.PutPair(1, 1);
            check.PutPair(1, 2);
            Assert.AreEqual(2, check.GetValueByKey(1));
        }

        [TestMethod]
        public void OneInTenThousandsTest()
        {
            var dict = new HashTable.HashTable(10000);
            for (var i = 0; i < 10000; i++)
            {
                dict.PutPair(i, i);
            }
            Assert.AreEqual(42, dict.GetValueByKey(42));
        }

        [TestMethod]
        public void ThousandInTenThousandsTest()
        {
            var dict = new HashTable.HashTable(10000);
            for (var i = 1001; i < 11001; i++)
            {
                dict.PutPair(i, i);
            }
            for (var i = 0; i < 1000; i++)
            {
                Assert.IsNull(dict.GetValueByKey(i));
            }
        }
    }
}