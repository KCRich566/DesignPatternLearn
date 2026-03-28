using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn
{
    internal class PatternRunner
    {
        private static readonly List<IPatternDemo> _demos = new List<IPatternDemo>();

        public static void Register(IPatternDemo demo)
        {
            if(demo == null)
            {
                // nameof 會顯示參數名稱，這裡會顯示 "demo"
                throw new ArgumentNullException(nameof(demo));
            }
            _demos.Add(demo);
        }

        public static void RunnAllDemo()
        {
            foreach (IPatternDemo demo in _demos)
            {
                Console.WriteLine($"--- {demo.Name} ---");
                try
                {
                    demo.Run();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Demo threw: {ex.GetType().Name}: {ex.Message}");
                }
                Console.WriteLine();
            }
        }
    }
}
