using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // Mediator（中介者模式）
    // 核心思想：用一個中介物件來封裝一組物件之間的互動，
    //   使物件之間不直接引用彼此，而是透過中介者通訊，降低耦合。
    // 使用情境：當多個物件之間存在複雜的相互依賴，希望集中管理互動邏輯時。
    // 真實案例：
    //   1. 聊天室——ChatRoom 作為中介者，使用者之間不直接通訊。
    //   2. 機場塔台——控制塔協調多架飛機的起降。
    //   3. UI 表單驗證——Mediator 協調多個控制項之間的聯動（如勾選 A 後啟用 B）。
    internal class MediatorDemo : IPatternDemo
    {
        public string Name => "Mediator";
        public void Run()
        {

        }
    }
}
