using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // Interpreter（解譯器模式）
    // 核心思想：定義一個語言的文法表示，並提供一個解譯器來處理該語言的句子。
    //   每個文法規則用一個類別表示，透過組合這些類別來解譯表達式。
    // 使用情境：當有一個簡單且重複出現的文法需要解析時（如數學運算式、規則引擎）。
    // 真實案例：
    //   1. 數學運算式解析——將 "1 + 2 * 3" 拆解為表達式樹並求值。
    //   2. SQL 解析器——將 SQL 語句解析成可執行的查詢計畫。
    //   3. 正則表達式引擎——將 Regex 模式解析為狀態機來比對字串。
    internal class InterpreterDemo : IPatternDemo
    {
        public string Name => "Interpreter";
        public void Run()
        {

        }
    }
}
