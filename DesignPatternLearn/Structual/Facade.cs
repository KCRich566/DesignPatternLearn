using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Structual
{
    // Facade（外觀模式）
    // 核心思想：為子系統的一組介面提供一個統一的高層介面，
    //   讓子系統更容易使用，降低客戶端與子系統之間的耦合。
    // 使用情境：當子系統複雜，希望對外提供簡單的操作介面時。
    // 真實案例：
    //   1. 家庭劇院系統——一鍵播放：將開投影機、關燈、開音響等操作封裝成單一方法。
    //   2. 電商訂單——下單時 Facade 協調庫存檢查、支付、物流等子系統。
    //   3. 編譯器前端——提供統一的 Compile() 方法，內部協調詞法分析、語法分析、程式碼生成等步驟。
    internal class Facade : IPatternDemo
    {
        public string Name => "Facade";
        public void Run()
        {
        }
    }
}
