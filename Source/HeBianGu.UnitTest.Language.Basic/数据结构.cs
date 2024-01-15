using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.UnitTest.Language.Basic
{
    /// <summary>
    /// ICollection集合，无序的
    /// IList列表，有顺序线性的
    /// ISet集合，交并补集合运算
    /// IEnumerble 迭代器foreach
    /// IReadOnlyCollection 只读的集合AsReadOnly
    /// IReadOnlyList 只读的列表AsReadOnly
    /// </summary>
    [TestClass]
    public class 数据结构
    {
        #region - 数组 内存连续储存，节约空间，可以索引访问，读取快，增删慢-

        [TestMethod]
        public void TestMethod1()
        {
            //  Do ：Collection 集合，无序，List列表，有序Sort
            //  Do ：是Array，内存上都是连续摆放，不定长度，泛型，保证类型安全，避免装箱拆箱 性能也比ArrayList高读取快，增删慢以上特点：读取快，增删相对慢
            List<int> list = new List<int>();

        }


        [TestMethod]
        public void TestMethod8()
        {
            // 集合 不关心排序 没有Sort
            Collection<int> ints = new Collection<int>();
            ints.Add(1);

        }

        [TestMethod]
        public void TestMethod2()
        {
            //  Do ：在以前的开发中使用不较多，不定长度，连续分配的元素没有限制，任何元素都是当成Object处理，如果是值类型，会有装箱操作读取快，增删慢
            ArrayList arrayList = new ArrayList();
        }



        [TestMethod]
        public void TestMethod4()
        {
            //  Do ：元素类型是一样的，定长
            //  Do ：在内存上连续分配的，而且元素类型是一样的可以坐标访问，读取快---增减慢，长度不变
            Array array = new Array[10];
        }

        [TestMethod]
        public void TestMethod13()
        {
            BitArray bitArray = new BitArray(5);
        }

        #endregion

        #region - 链表 非连续摆放，存储数据+地址，找数据的话就只能顺序查找，读取慢，增删快-

        [TestMethod]
        public void TestMethod3()
        {
            //  Do ：泛型的特点：链表，元素不连续分配，每个元素都有记录前后节点，节点值可以重复能不能以下标访问：不能没找元素只能遍历，查找不方便增删 就比较方便
            LinkedList<int> arrayList = new LinkedList<int>();
        }


        [TestMethod]
        public void TestMethod5()
        {
            //  Do ：就是链表  先进先出 放任务延迟执行，A不断写入日志任务   B不断获取任务去执行
            Queue<int> queue = new Queue<int>();
        }


        [TestMethod]
        public void TestMethod6()
        {
            //  Do ：就是链表  先进先出  解析表达式目录树，先产出的数据后使用
            Stack<int> queue = new Stack<int>();
        }

        #endregion

        #region - 集合 hash分布，元素间没有关系，动态增加容量，去重-
        [TestMethod]
        public void TestMethod10()
        {
            //  Do ：ISet 交并补等计算，不实现IList，所以不关心顺序
            HashSet<int> ints = new HashSet<int>();
        }


        [TestMethod]
        public void TestMethod12()
        {
            //  Do ：排序的集合，去重，排序
            SortedSet<int> ints = new SortedSet<int>();
        }


        #region - Hashtable/Dictionary/SortedDictionary/SortedList 读取，增删都快，key-value，一段连续有限空间放value，基于key散列计算得到地址索引，读取增删都快，开辟的空间比用到的多，hash是用空间换性能 -


        [TestMethod]
        public void TestMethod11()
        {
            //  Do ：哈希表，元素没有类型限制，任何元素都是当成object处理，存在装箱拆箱，无序
            Hashtable hashtable = new Hashtable();
        }


        [TestMethod]
        public void TestMethod7()
        {
            //  Do ：字典，支持泛型，有序的
            Dictionary<int, int> keyValues = new Dictionary<int, int>();
            //  Do ：字典，支持泛型，有序
            SortedDictionary<int, int> keyValues1 = new SortedDictionary<int, int>();

        }

        [TestMethod]
        public void TestMethod9()
        {
            //  Do ：排序列表是数组和哈希表的组合，使用索引访问各项，则它是一个动态数组，如果您使用键访问各项，则它是一个哈希表。集合中的各项总是按键值排序
            SortedList sortedList = new SortedList();
            sortedList.Add("First", "Hello");

            //使用键访问
            sortedList["Fourth"] = "!!!";
            //可以用索引访问
            Console.WriteLine(sortedList.GetByIndex(0));
            //获取所有key
            var keyList = sortedList.GetKeyList();
            //获取所有value
            var valueList = sortedList.GetValueList();
            //用于最小化集合的内存开销
            sortedList.TrimToSize();
            //删除元素
            sortedList.Remove("Third");
            sortedList.RemoveAt(0);
            //清空集合
            sortedList.Clear();
            SortedList<int, int> keyValuePairs = new SortedList<int, int>();
        }


        #endregion


        #endregion


        [TestMethod]
        public void TestMethod14()
        {
            //  Do ：线程安全
            ConcurrentStack<int> ints = new ConcurrentStack<int>();
        }

        [TestMethod]
        public void TestMethod15()
        {
            //  Do ：线程安全
            ConcurrentQueue<int> values = new ConcurrentQueue<int>();

           
        }

        [TestMethod]
        public void TestMethod16()
        {
            //  Do ：线程安全
            ConcurrentDictionary<int, int> keyValuePairs = new ConcurrentDictionary<int, int>();
        }

        [TestMethod]
        public void TestMethod17()
        {
            //  Do ：线程安全的无序集合
            ConcurrentBag<int> ints = new ConcurrentBag<int>();
        }

        [TestMethod]
        public void TestMethod18()
        {
            ReadOnlyCollection<int> ints = new ReadOnlyCollection<int>(new List<int>());
        }

        [TestMethod]
        public void TestMethod19()
        {
            ReadOnlyDictionary<int, int> keyValuePairs = new ReadOnlyDictionary<int, int>(new Dictionary<int, int>());
        }
    }

}


