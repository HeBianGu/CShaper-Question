using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class 自定义可等待器
    {
        [TestMethod]
        public async void TestMethod1()
        {
            Awaitable awaitable=new Awaitable();
            await awaitable;
        }

        [TestMethod]
        public async void TestMethod2()
        {
            await true;
        }
    }

    public class Awaitable
    {
        public TaskAwaiter GetAwaiter()
        {
            return Task.Delay(1000).GetAwaiter();
        }
    }

    public static class AwaitableExtension
    {
        public static TaskAwaiter GetAwaiter(this bool b)
        {
            return Task.Delay(1000).GetAwaiter();
        }
    }

}


