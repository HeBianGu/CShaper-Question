using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 利用反射创建实例方法
    {
        [TestMethod]
        public void TestMethod1()
        {
            FMyClass myClass = Assembly.GetExecutingAssembly().CreateInstance("HeBianGu.UnitTest.Language.Basic.MyClass") as FMyClass;

            myClass.Method();

        }
    }

    class FMyClass
    {

        public void Method()
        {
            Debug.WriteLine("执行了方法");

        }
    }
}
