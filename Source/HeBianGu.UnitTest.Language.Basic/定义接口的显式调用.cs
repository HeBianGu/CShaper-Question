using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 定义接口的显式调用
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyViewCloneable myCloneable = new MyViewCloneable();
            //  Do :主体声明的是显示接口调用，只有转换成接口才可以调用
            MyCloneable c = myCloneable.Clone();
            if (myCloneable is ICloneable cloneable)
                cloneable.Clone();
        }

        [TestMethod]
        public void TestMethod2()
        {
            ICloneable myCloneable = new MyViewCloneable();
            object c = myCloneable.Clone();
        }

    }

    class MyViewCloneable : ICloneable
    {
        object ICloneable.Clone()
        {
            return new MyCloneableT1();
        }
    }
}
