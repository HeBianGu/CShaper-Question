using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq.Expressions;

namespace HeBianGu.UnitTest.Language.Basic
{
    [TestClass]
    public class UnitTest2
    {
        /// <summary>
        /// https://docs.microsoft.com/zh-cn/dotnet/csharp/expression-trees-building
        /// </summary>
        [TestMethod]
        public void 动态生成表达式树()
        {
            //Expression<Func<int>> sum = () => 1 + 2;

            //  Do ：若要构造该表达式树，必须构造叶节点。 叶节点是常量，因此可以使用 Expression.Constant 方法创建节点
            ConstantExpression one = Expression.Constant(1, typeof(int));
            ConstantExpression two = Expression.Constant(2, typeof(int));

            //  Do ：接下来，将生成加法表达式：
            var addition = Expression.Add(one, two);

            //  Do ：一旦获得了加法表达式，就可以创建 lambda 表达式 
            var lambda = Expression.Lambda(addition);


            //  Do ：说明 
            //var lambda = Expression.Lambda(Expression.Add(Expression.Constant(1, typeof(int)),Expression.Constant(2, typeof(int))));

            var action = lambda.Compile();
        }

        /// <summary>
        /// https://docs.microsoft.com/zh-cn/dotnet/csharp/expression-trees-building
        /// </summary>
        [TestMethod]
        public void 参数节点和方法调用节点()
        {
            //  Do ：示例动态生成如下表达式
            Expression<Func<double, double, double>> distanceCalc =
            (x, y) => Math.Sqrt(x * x + y * y);

            //  Do ：首先，创建 x 和 y 的参数表达式：
            var xParameter = Expression.Parameter(typeof(double), "x");
            var yParameter = Expression.Parameter(typeof(double), "y");

            //  Do ：按照你所看到的模式创建乘法和加法表达式 
            var xSquared = Expression.Multiply(xParameter, xParameter);
            var ySquared = Expression.Multiply(yParameter, yParameter);
            var sum = Expression.Add(xSquared, ySquared);

            //  Do ：接下来，需要为调用 Math.Sqrt 创建方法调用表达式
            var sqrtMethod = typeof(Math).GetMethod("Sqrt", new[] { typeof(double) });
            var distance = Expression.Call(sqrtMethod, sum);

            //  Do ：最后，将方法调用放入 lambda 表达式，并确保定义 lambda 表达式的参数：

            var distanceLambda = Expression.Lambda(distance, xParameter, yParameter);

            var action = distanceLambda.Compile();

            var result = action.DynamicInvoke(3, 4);

            System.Diagnostics.Debug.WriteLine(result);
        }

        /// <summary>
        /// https://docs.microsoft.com/zh-cn/dotnet/csharp/expression-trees-execution
        /// </summary>
        [TestMethod]
        public void 执行表达式树()
        {
            //  Do ：表达式树 是表示一些代码的数据结构。 它不是已编译且可执行的代码。 如果想要执行由表达式树表示的 .NET 代码，则必须将其转换为可执行的 IL 指令

            //  Do ：可以将任何 LambdaExpression 或派生自 LambdaExpression 的任何类型转换为可执行的 IL

            //  Do ：Lambda 表达式是你可通过转换为可执行的中间语言 (IL) 来执行的唯一表达式类型 若要执行需要先转换成LambdaExpression

            //  Do ：LambdaExpression 或派生自 LambdaExpression 的类型的任何表达式树均可转换为 IL

            //  Do ：表达式类型 Expression<TDelegate> 是 .NET Core 库中的唯一具体示例。 它用于表示映射到任何委托类型的表达式。 由于此类型映射到一个委托类型，因此 .NET 可以检查表达式，并为匹配 lambda 表达式签名的适当委托生成 IL。

            //Expression<Func<string,bool>> 继承至LambdaExpression 所以可以执行

            //  Do ：LambdaExpression 类型包含用于将表达式树转换为可执行代码的 Compile 和 CompileToMethod 成员
            Expression<Func<int>> add = () => 1 + 2;
            var func = add.Compile(); // Create Delegate
            var answer = func(); // Invoke Delegate

            System.Diagnostics.Debug.WriteLine(answer);

        }

        [TestMethod]
        public void 字符串表达式解析()
        {
            var result = 1 + 2 * 3;

            string function = "1+2";


            //function.Split(new char[] {'+','-', })


            ConstantExpression one = Expression.Constant(1, typeof(int));
            ConstantExpression two = Expression.Constant(2, typeof(int));
            ConstantExpression third = Expression.Constant(3, typeof(int));

            //  Do ：接下来，将生成加法表达式：
            var addition = Expression.Add(one, two);

            var multiply = Expression.Multiply(addition, two);

            var rrr = Expression.Lambda(multiply).Compile().DynamicInvoke();


        }

        class Node
        {
            public List<Node> Children { get; set; } = new List<Node>();

            public void Create(string expressionText)
            {
                //  Do ：解析括号
                var OpenParens = expressionText.Split(new char[] { '(', ')' });

                foreach (var item in OpenParens)
                {
                    Node child = new Node(); 

                    child.Create(item);

                    this.Children.Add(child);
                  
                }

                //var left = OpenParens[0];

                //left.Split(new char[] { '*', '/' });
            }
        }

        /// <summary>
        /// https://docs.microsoft.com/zh-cn/dotnet/csharp/expression-trees-translating
        /// </summary>
        [TestMethod]
        public void 转换表达式树()
        {
            Expression ReplaceNodes(Expression original)
            {
                if (original.NodeType == ExpressionType.Constant)
                {
                    return Expression.Multiply(original, Expression.Constant(10));
                }
                else if (original.NodeType == ExpressionType.Add)
                {
                    var binaryExpression = (BinaryExpression)original;
                    return Expression.Add(
                        ReplaceNodes(binaryExpression.Left),
                        ReplaceNodes(binaryExpression.Right));
                }
                return original;
            }

            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var addition = Expression.Add(one, two);
            var sum = ReplaceNodes(addition);
            var executableFunc = Expression.Lambda(sum);

            var func = (Func<int>)executableFunc.Compile();
            var answer = func();
            Console.WriteLine(answer);
        }

        [TestMethod]
        public void 遍历并执行加法()
        {
            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var three = Expression.Constant(3, typeof(int));
            var four = Expression.Constant(4, typeof(int));
            var addition = Expression.Add(one, two);
            var add2 = Expression.Add(three, four);
            var sum = Expression.Add(addition, add2);

            // Declare the delegate, so we can call it
            // from itself recursively:
            Func<Expression, int> aggregate = null;
            // Aggregate, return constants, or the sum of the left and right operand.
            // Major simplification: Assume every binary expression is an addition.
            aggregate = (exp) =>
                exp.NodeType == ExpressionType.Constant ?
                (int)((ConstantExpression)exp).Value :
                aggregate(((BinaryExpression)exp).Left) + aggregate(((BinaryExpression)exp).Right);

            var theSum = aggregate(sum);
            Console.WriteLine(theSum);
        }

    }
}
