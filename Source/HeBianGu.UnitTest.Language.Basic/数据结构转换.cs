using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 数据结构转换
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> list = new List<int>();
            list.ToArray();
            list.ToDictionary(x => x, x => x);
            list.ToLookup(x => x / 2);
            list.AsReadOnly();
            list.AsEnumerable();
            list.AsQueryable();
            list.AsParallel().AsOrdered().AsSequential();
            list.AsParallel().AsUnordered();
        }
    }
}
