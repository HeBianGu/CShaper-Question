using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 动态调用方法
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyClass myClass = new MyClass();

            MethodInfo method = myClass.GetType().GetMethod("Method");

            method.Invoke(myClass, new object[] { });

        }


        class MyClass
        {
            public void Method()
            {
                Debug.WriteLine("执行了方法");
            }

        }
    }
}
