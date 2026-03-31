using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // Iterator（迭代器模式）
    // 核心思想：提供一種方法來依序存取集合中的元素，而不暴露集合的內部結構。
    //   將遍歷的責任從集合中抽離出來，交給獨立的迭代器物件。
    // 使用情境：當集合內部結構複雜（如樹、圖），但希望客戶端以統一的方式遍歷時。
    // 真實案例：
    //   1. C# 的 IEnumerable / IEnumerator——foreach 背後就是 Iterator 模式。
    //   2. 資料庫查詢結果集——DataReader 逐筆讀取查詢結果。
    //   3. 檔案系統遍歷——依序走訪目錄中所有檔案與子目錄。
    internal class IteratorDemo : IPatternDemo
    {
        public string Name => "Iterator";
        public void Run()
        {

        }
    }
}
