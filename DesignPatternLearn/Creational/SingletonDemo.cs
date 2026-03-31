using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Creational
{
    // Singleton 模式（單例模式）
    // 核心思想：確保一個類別只有一個實例，並提供一個全域存取點。
    // 使用情境：當系統中某個物件只應存在一份，且需要被多處共用時。
    // 真實案例：
    //   1. 日誌記錄器（Logger）——整個應用程式共用同一個 Logger 實例，避免重複建立。
    //   2. 資料庫連線池（Connection Pool）——確保只有一個連線池管理所有連線。
    //   3. 應用程式組態管理（Configuration Manager）——讀取設定檔只需一份實例。

    // atomic: 原子性 (Atomicity) 是指一個操作要麼完全執行，要麼完全不執行，不會被中斷。
    // 這裡的 Singleton 實現是原子性的，因為靜態初始化在 .NET 中是執行緒安全的。

    // internal: 這個類別只能在同一個程序集 (Assembly) 中訪問，
    // 也就是說, 如果其他專案引入了這個專案, 就無法訪問這個類別。
    // internal對於同一個專案屬於public, 但是對於其他專案來說是private

    // 沒有建構子: 預設會有一個public的建構子
    internal class SingletonDemo : IPatternDemo
    {
        // =>語法: 這裡是屬性 (Property) 的寫法，等同於以下的寫法：
        // public string Name
        // {
        //     get { return "Singleton (eager, thread safe)"; }
        // }
        public string Name => "Singleton (eaget, thread safe)";
        public void Run()
        {
            SingletonEager testa = SingletonEager.Instance;
            SingletonEager testb = SingletonEager.Instance;
            Console.WriteLine("Same instance: {0}", object.ReferenceEquals(testa, testb));

            SingletonLazy testc = SingletonLazy.Instance;
            SingletonLazy testd = SingletonLazy.Instance;
            // object.ReferenceEquals: 這個方法用於比較兩個對象是否引用同一個實例。
            // 也可以使用 == 操作符，但在某些情況下，== 可能被重載，導致比較的行為不同。
            Console.WriteLine("Same instance: {0}", object.ReferenceEquals(testc, testd));
        }
    }

    // sealed: 這個類別不能被繼承
    internal sealed class SingletonEager
    {
        private static readonly SingletonEager _instance = new SingletonEager();
    
        // ctor: constructor 的縮寫，建構子 (Constructor) 是一個特殊的方法，
        // 用於在創建類的實例時初始化對象。這裡的建構子是私有的，
        // 這意味著外部無法直接創建 Singleton 類的實例。
        private SingletonEager() 
        {
            Console.WriteLine("SingletonEager constructor called.");
        }
        public static SingletonEager Instance => _instance;
    }

    // Lazy 是延遲初始化，即延遲建立實例，只在第一次存取時才建立物件。
    internal sealed class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> _instance = new Lazy<SingletonLazy>(() => new SingletonLazy());
        private SingletonLazy()
        {
            Console.WriteLine("SingletonLazy constructor called.");
        }
        public static SingletonLazy Instance => _instance.Value;
    }
}
