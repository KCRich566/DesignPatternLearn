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
    // Simple Factory (簡單工廠) demo
    // - 將物件建立邏輯集中在一個地方 (factory)
    // - 客戶端透過 factory 請求產品，而不直接 new 具體類別
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
