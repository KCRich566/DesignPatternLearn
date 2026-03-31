using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Structual
{
    internal class DecoratorDemo : IPatternDemo
    {
        // Decorator（裝飾者模式）
        // 核心思想：動態地將行為添加到物件上，而不需修改原始物件的程式碼。
        //   Decorator 與被裝飾物件實作相同介面，可以多層巢狀疊加功能。
        // 使用情境：當你想在不修改原有類別的情況下，為物件添加額外的功能或行為時。
        // 真實案例：
        //   1. 咸啡啡配料——如本範例，在基本 Coffee 上疊加 Milk、Sugar、Whip 等裝飾。
        //   2. I/O Stream 包裝——BufferedStream、GZipStream 等對基本 Stream 加上緩衝、壓縮行為。
        //   3. 日誌增強——在基本 Logger 上疊加 TimestampDecorator、EncryptionDecorator 等。
        public string Name => "Decorator";
        public void Run()
        {
            IComponent coffee = new Coffee();
            Print(coffee);

            IComponent milkCoffee = new MilkDecorator(coffee);
            Print(coffee);

            IComponent sugarAndMilk = new SugarDecorator(milkCoffee);
            Print(sugarAndMilk);

            IComponent doubleMilk = new MilkDecorator(sugarAndMilk);
            IComponent doubleMilkAndWhip = new WhipDecorator(doubleMilk);
            Print(doubleMilkAndWhip);

            Console.WriteLine("Decorator demo finished");
        }

        private void Print(IComponent component)
        {
            // C2: 表示貨幣格式，保留兩位小數
            Console.WriteLine($"Item: {component.GetDescription()} | Cost: {component.GetCost():C2}");
        }

        internal interface IComponent
        {
            string GetDescription();
            double GetCost();
        }

        internal class Coffee : IComponent
        {
            public string GetDescription() => "Plain Coffee";
            public double GetCost() => 1.5;
        }
        // const vs readonly: const 是編譯時常數，必須在宣告時初始化，且值不能改變；
        // readonly 是執行時常數，可以在宣告時或建構子中初始化，但之後不能修改。也就是說，readonly 可以賦值一次。
        internal abstract class ComponentDecorator : IComponent
        {
            protected readonly IComponent _component;
            protected ComponentDecorator(IComponent component)
            {
                // ??: 是 C# 中的 null 合併運算子，用於簡化 null 檢查與賦值操作。
                // nameof: 表示取得參數 component 的名稱，作為例外訊息的一部分，以便更清晰地指出哪個參數為 null。
                _component = component ?? throw new ArgumentNullException(nameof(component));
            }
            public virtual string GetDescription()
            {
                return _component.GetDescription();
            }
            
            public virtual double GetCost()
            {
                return _component.GetCost();
            }

            
        }
        
        internal class MilkDecorator : ComponentDecorator
        {
            private const double MilkCost = 0.40;
            public MilkDecorator(IComponent component): base(component)
            {
                
            }
            public override string GetDescription()
            {
                return $"{_component.GetDescription()}, + Milk";
            }

            public override double GetCost()
            {
                return _component.GetCost() + MilkCost;
            }
        }

        internal class SugarDecorator : ComponentDecorator
        {
            private const double SugarCost = 0.20;
            public SugarDecorator(IComponent component): base(component)
            {
                
            }
            public override string GetDescription()
            {
                return $"{_component.GetDescription()}, + Sugar";
            }
            public override double GetCost()
            {
                return _component.GetCost() + SugarCost;
            }
        }
        internal class WhipDecorator : ComponentDecorator
        {
            private const double WhipCost = 0.50;
            public WhipDecorator(IComponent component) : base(component) { }
            public override string GetDescription()
            {
                return $"{_component.GetDescription()}, + Whip";
            }
            public override double GetCost()
            {
                return _component.GetCost() + WhipCost;
            }
        }



    }
}
