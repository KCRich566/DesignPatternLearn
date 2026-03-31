using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // Strategy（策略模式）
    // 核心思想：定義一系列演算法，將它們分別封裝起來，並讓它們可以互相替換。
    //   Context 依賴於抽象的 IStrategy 介面，在執行時期動態切換具體策略。
    // 使用情境：當有多種演算法可以完成同一件事，且希望在執行時期選擇或切換時。
    // 真實案例：
    //   1. 計算機運算——如本範例，根據運算符切換 Add / Sub / Multiply 策略。
    //   2. 排序演算法——依場景選擇 QuickSort、MergeSort、BubbleSort。
    //   3. 支付方式——結帳時動態選擇 CreditCard、PayPal、BankTransfer 等支付策略。
    internal class StrategyDemo : IPatternDemo
    {
        public string Name => "Strategy";
        public void Run()
        {
            Context context = new Context(new AddStrategy());
            Console.WriteLine("10 + 5 = " + context.ExecuteStrategy(10, 5));
            context.SetStrategy(new SubStrategy());
            Console.WriteLine("10 - 5 = " + context.ExecuteStrategy(10, 5));
            context.SetStrategy(new MultiplyStrategy());
            Console.WriteLine("10 * 5 = " + context.ExecuteStrategy(10, 5));
        }
        private interface IStrategy
        {
            int DoOperation(int a, int b);
        }

        private class AddStrategy : IStrategy
        {
            public int DoOperation(int a, int b) => a + b;
        }
        private class SubStrategy : IStrategy
        {
            public int DoOperation(int a, int b) => a - b;
        }
        private class MultiplyStrategy : IStrategy
        {
            public int DoOperation(int a, int b) => a * b;
        }

        private class Context
        {
            private IStrategy _strategy;
            public Context(IStrategy strategy)
            {
                _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            }
            public void SetStrategy(IStrategy strategy)
            {
                _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            }
            public int ExecuteStrategy(int a, int b)
            {
                return _strategy.DoOperation(a, b);
            }
        }
    }
}
