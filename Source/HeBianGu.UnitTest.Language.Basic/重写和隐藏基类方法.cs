using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 重写和隐藏基类方法
    {
        [TestMethod]
        public void Overrider()
        {
            Overrider over = new Overrider();
            BaseClass b1 = over;
            over.Foo(); // Overrider.Foo 
            b1.Foo();   // Overrider.Foo  
        }

        [TestMethod]
        public void Hider()
        {
            Hider h = new Hider();
            BaseClass b2 = h;
            h.Foo();  // Hider.Foo 
            b2.Foo(); // BaseClass.Foo
        }
    }

    public class BaseClass
    {
        public virtual void Foo() { Debug.WriteLine("BaseClass.Foo"); }
    }
    public class Overrider : BaseClass
    {
        public override void Foo() { Debug.WriteLine("Overrider.Foo"); }
    }
    public class Hider : BaseClass
    {
        public new void Foo() { Debug.WriteLine("Hider.Foo"); }
    }
}
