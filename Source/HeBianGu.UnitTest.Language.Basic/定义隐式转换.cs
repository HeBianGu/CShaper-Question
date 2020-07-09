using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 定义隐式转换
    {
        [TestMethod]
        public void TestMethod1()
        {
            A a = new A(100.0f);
            B b = (B)a;

            Debug.WriteLine("A类中的p是：" + a.p + "\n");
            Debug.WriteLine("B类中的p是：" + b.p + "\n");

        }

        [TestMethod]
        public void TestMethod2()
        {
            double f = 200.0;
            C c = (C)f;
            Debug.WriteLine("C类中的p是：" + c.p + "\n");
           
        }
    }


    class A
    {
        public A(float f)
        {
            p = f;
        }

        public float p { get; }

        /// <summary> 定义从A转换成B类型 </summary>
        public static explicit operator B(A a)
        {
            return new B(a.p * 2);
        }
    }


    class B
    {
        public B(float f)
        {
            p = f;
        }

        public float p { get; }

        /// <summary> 定义从B转换成A类型 </summary>

        public static explicit operator A(B b)
        {
            return new A(b.p * 10f);
        }
    }

    class C
    {
        public C(float f)
        {
            p = f;
        }

        public float p { get; }

        /// <summary> 定义从字符串转换成C类型 </summary>
        public static explicit operator C(float f)
        {
            return new C(f*2);
        }

        /// <summary> 定义从字符串转换成C类型 </summary>
        public static implicit operator float(C c)
        {
            return c.p / 2 ;
        }
    }

}
