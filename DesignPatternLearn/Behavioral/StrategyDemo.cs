using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
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
