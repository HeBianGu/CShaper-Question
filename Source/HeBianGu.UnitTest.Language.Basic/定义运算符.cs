using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 定义运算符
    {
        [TestMethod]
        public void TestMethod1()
        {
            Student s1 = new Student();

            s1.Name = "Jack";
            s1.Age = 11;

            Student s2 = new Student();
            s2.Name = "Tom";
            s2.Age = 21;

            Student s = s1 + s2;

            Debug.WriteLine(s);

        }
    }

 


    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        // 必须在当前类中定义
        public static Student operator +(Student a, Student b)
        {
            return new Student() { Name = a.Name + b.Name, Age = a.Age + b.Age };
        }
        public static string operator -(Student a, Student b)
        {
            return null;
        }

        public static Boolean operator ==(Student a, Student b)
        {
            return true;
        }
        public static Boolean operator !=(Student a, Student b)
        {
            return false;
        }

        public override string ToString()
        {
            return $"Student:{this.Name}  {this.Age}";
        }
    }
}

 
