using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // Memento（備忘錄模式）
    // 核心思想：在不破壞封裝的前提下，捕捉並儲存物件的內部狀態，
    //   以便日後將物件復原到先前的狀態。
    // 使用情境：當需要實作復原（Undo）功能，且不希望暴露物件內部細節時。
    // 真實案例：
    //   1. 文字編輯器復原——每次編輯儲存一個 Memento，Ctrl+Z 時復原。
    //   2. 遊戲存檔——儲存遊戲進度的快照，以便讀取還原。
    //   3. 資料庫交易回滾——儲存交易前的狀態，失敗時 Rollback。
    internal class MementoDemo : IPatternDemo
    {
        public string Name => "Memento";
        public void Run()
        {

        }
    }
}
