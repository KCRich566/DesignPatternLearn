using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn
{
    // 預設為internal
    internal interface IPatternDemo
    {
        // 預設為public
        string Name { get; }
        // 預設為public
        void Run();
    }
}
