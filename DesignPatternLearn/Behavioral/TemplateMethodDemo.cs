using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // Template Method（模板方法模式）
    // 核心思想：在父類別中定義演算法的骨架，將某些步驟延遲到子類別實作。
    //   子類別可以重新定義某些步驟，但不能改變整體流程。
    // 使用情境：當多個子類別有相同的流程但部分步驟實作不同時。
    // 真實案例：
    //   1. 資料化流程——Parse → Validate → Process 的骨架固定，各步驟由子類別實作。
    //   2. 單元測試框架——SetUp → RunTest → TearDown 的執行順序固定。
    //   3. 飲料製作——煮水 → 泡製 → 倒入杯中 的流程相同，但泡茶與泡咖啡的泡製步驟不同。
    internal class TemplateMethodDemo : IPatternDemo
    {
        public string Name => "Template Method";
        public void Run()
        {

        }
    }
}
