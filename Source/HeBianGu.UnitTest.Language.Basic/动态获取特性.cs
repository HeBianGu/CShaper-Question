using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 动态获取特性
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyClass my = new MyClass();

            DisplayAttribute attribute = my.GetType().GetCustomAttributes(true)[0] as DisplayAttribute;

            Debug.WriteLine(attribute.PositionalString);

        }

        [DisplayAttribute("如何获取到我")]
        class MyClass
        {
            [DisplayAttribute("MyProperty")]
            public int MyProperty { get; set; }
        }
    }



    class DisplayAttribute : Attribute
    {
         string positionalString;

        // This is a positional argument
        public DisplayAttribute(string positionalString)
        {
            this.positionalString = positionalString;
        }

        public string PositionalString
        {
            get { return positionalString; }
        }
    }

}
