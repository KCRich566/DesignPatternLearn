using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // Visitor（訪問者模式）
    // 核心思想：將操作與物件結構分離，新增操作時不需修改現有類別，
    //   而是新增一個 Visitor 類別即可。元素透過 Accept(visitor) 讓 Visitor 存取自身。
    // 使用情境：當物件結構穩定但經常需要新增不同操作時。
    // 真實案例：
    //   1. 編譯器 AST 走訪——對語法樹執行型別檢查、程式碼生成等不同 Visitor。
    //   2. 報表創建——對同一組資料結構執行 HTML、PDF、Excel 等不同輸出 Visitor。
    //   3. 檔案系統掃描——對檔案樹執行病毒掃描、大小統計等不同 Visitor。
    internal class VisitorDemo : IPatternDemo
    {
        public string Name => "Visitor";
        public void Run()
        {

        }
    }
}
