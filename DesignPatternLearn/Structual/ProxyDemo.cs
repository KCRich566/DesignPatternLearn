using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Structual
{
    // Proxy（代理模式）
    // 核心思想：為另一個物件提供一個替身或佔位符，以控制對原始物件的存取。
    //   常見種類：遠端代理、虛擬代理（延遲載入）、保護代理（權限控制）、快取代理。
    // 使用情境：當需要在存取物件前後加入額外控制（如權限檢查、快取、延遲載入）時。
    // 真實案例：
    //   1. 圖片延遲載入——圖片 Proxy 在真正需要顯示時才從磁碟載入大圖。
    //   2. 遠端服務代理——WCF / gRPC Client Proxy 封裝網路呼叫細節。
    //   3. 存取控制——在存取機密檔案前檢查使用者權限。
    internal class ProxyDemo : IPatternDemo
    {
        public string Name => "Proxy";
        public void Run()
        {
        }
    }
}
