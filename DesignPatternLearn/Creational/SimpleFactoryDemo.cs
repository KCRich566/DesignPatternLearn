using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Creational
{
    // Simple Factory（簡單工廠）
    // 核心思想：將物件建立邏輯集中在一個工廠類別（Factory），
    //   客戶端透過工廠請求產品，而不直接 new 具體類別，
    //   達到建立與使用的解耦。
    // 使用情境：當產品種類有限且不會頻繁變動時，可用簡單工廠集中管理建立邏輯。
    // 真實案例：
    //   1. 資料庫驅動程式工廠——根據設定建立 SQL Server / MySQL / SQLite 的連線物件。
    //   2. 圖形編輯器——根據使用者選擇建立 Circle / Rectangle / Triangle 等圖形物件。
    //   3. 日誌輸出器——根據組態建立 FileLogger / ConsoleLogger / DatabaseLogger。
    internal class SimpleFactoryDemo : IPatternDemo
    {
        public string Name => "Factory Method (simple)";
        public void Run()
        {
            Creator creator = new ConcreteCreate();
            IProduct productA = creator.CreateProduct("A");
            Console.WriteLine(productA.Name);
            IProduct productB = creator.CreateProduct("B");
            Console.WriteLine(productB.Name);

        }

        private interface IProduct
        {
            string Name { get; }
        }
        // 產品A類別
        private class ConcreteProductA : IProduct
        {
            public string Name => "ConcreteProductA";
        }
        // 產品B類別

        private class  ConcreteProductB: IProduct
        {
            public string Name => "ConcreteProductB";
        }
        // 為什麼要一個抽象的Creator類別?
        // 因為這樣可以讓工廠方法的實現與產品的具體類別分離，從而提高系統的靈活性和可擴展性。
        private abstract class Creator
        {
            public abstract IProduct CreateProduct(string type);
        }
        private class ConcreteCreate: Creator
        {
            public override IProduct CreateProduct(string type)
            {
                switch (type)
                {
                    case "A":
                        return new ConcreteProductA();
                    case "B":
                        return new ConcreteProductB();
                    default:
                        throw new NotImplementedException();
                }

            }
        }

    }
}
