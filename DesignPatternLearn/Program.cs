using DesignPatternLearn.Creational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatternRunner.Register(new SingletonDemo());
            PatternRunner.Register(new SimpleFactoryDemo());
            PatternRunner.Register(new AbstractFactoryDemo());
            PatternRunner.RunnAllDemo();

            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();
        }
    }
}
