using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 隐藏接口方法
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyCloneable myCloneable = new MyCloneable();
            MyCloneable c = myCloneable.Clone();
        }

        [TestMethod]
        public void TestMethod2()
        {
            ICloneable myCloneable = new MyCloneable();
            object c = myCloneable.Clone();
        }

        [TestMethod]
        public void TestMethod3()
        {
            MyCloneableT myCloneable = new MyCloneableT();

            if (myCloneable is ICloneable cloneable)
                cloneable.Clone();

            MyCloneableT c = myCloneable.Clone();
        }
    }

    class MyCloneable : ICloneable
    {
        //  Do ：隐藏接口中方法，只有显示调用接口方法才会调用
        object ICloneable.Clone() => this.Clone();

        public MyCloneable Clone()
        {
            return new MyCloneable();
        }
    }

    //  Do ：泛型Clone接口
    public interface ICloneable<T> : ICloneable
    {
        new T Clone();
    }

    class MyCloneableT : ICloneable<MyCloneableT>
    {
        object ICloneable.Clone() => this.Clone();

        public MyCloneableT Clone()
        {
            return new MyCloneableT();
        }
    }

    class MyCloneableT1 : ICloneable<MyCloneableT1>
    {
        object ICloneable.Clone()
        {
            return new MyCloneableT1();
        }

        MyCloneableT1 ICloneable<MyCloneableT1>.Clone()
        {
            return new MyCloneableT1();
        }
    }
}
