using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.ConsoleTest.Language.Basic
{
    class Program
    {
        static void Main(string[] args)
        {

            MyClass myClass = Assembly.GetEntryAssembly().CreateInstance("HeBianGu.ConsoleTest.Language.Basic.MyClass") as MyClass;

            myClass.Method();

            Console.Read();
            
        }
    }

    class MyClass
    {
        public void Method()
        {
            Console.WriteLine("执行了方法");

        }
    }


}
