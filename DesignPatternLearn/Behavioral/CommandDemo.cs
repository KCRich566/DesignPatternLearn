using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // Command（命令模式）
    // 核心思想：將「請求」封裝成物件，使得可以用不同的請求參數化客戶端，
    //   並支援復原（Undo）、重做（Redo）、佇列、日誌等操作。
    // 使用情境：當需要將操作物件化，以便儲存、傳遞、排程或復原時。
    // 真實案例：
    //   1. 文字編輯器的 Undo/Redo——每個編輯操作封裝成 Command 物件。
    //   2. GUI 按鈕事件——按鈕點擊後執行對應的 Command。
    //   3. 工作佇列（Job Queue）——將任務封裝成 Command 放入佇列依序執行。
    internal class CommandDemo : IPatternDemo
    {
        public string Name => "Command";
        public void Run()
        {

        }
    }
}
