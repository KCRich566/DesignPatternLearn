using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Creational
{
    // Abstract Factory（抽象工廠）
    // 核心思想：提供一個介面來建立「一系列相關物件」，而不需指定具體類別。
    //   與 Simple Factory 不同，Abstract Factory 進一步將工廠本身抽象化，
    //   每個具體工廠負責建立同一「家族」的產品組合。
    // 使用情境：當系統需要同時建立多個相互配套的產品，且希望在不修改客戶端的情況下切換產品家族時。
    // 真實案例：
    //   1. UI 主題工廠——建立 DarkTheme / LightTheme 對應的按鈕、文字框、捲軸等一系列元件。
    //   2. 跨平台資料庫存取——SqlServerFactory / MySqlFactory 分別建立對應的 Connection、Command、Reader。
    //   3. 遊戲角色裝備工廠——WarriorEquipmentFactory / MageEquipmentFactory 建立對應的武器、盔甲、飾品。
    internal class AbstractFactoryDemo : IPatternDemo
    {
        public string Name => "Abstract Factory";
        public void Run()
        {
            Console.WriteLine("Using Modern Furniture Factory:");
            ClientCode(new ModernFurnitureFactory());

            Console.WriteLine();

            Console.WriteLine("Using Victorian Furniture Factory:");
            ClientCode(new VictorianFurnitureFactory());
        }
        // 客戶端使用抽象工廠建立抽象產品
        private void ClientCode(IFurnitureFactory factory)
        {
            IChair chair = factory.CreateChair();
            ISofa sofa = factory.CreateSofa();

            Console.WriteLine($" Chair: {chair.SitOn()}");
            Console.WriteLine($" Sofa: {sofa.LieOn()}");
        }

        private interface IFurnitureFactory
        {
            IChair CreateChair();
            ISofa CreateSofa();
        }
        private interface IChair
        {
            string SitOn();
        }
        private interface ISofa
        {
            string LieOn();
        }
        private class ModernFurnitureFactory : IFurnitureFactory
        {
            public IChair CreateChair() => new ModernChair();
            public ISofa CreateSofa() => new ModernSofa();
        }
        private class ModernChair : IChair
        {
            public string SitOn() => "Sitting on a minimalist Modern Chair (metal + leather).";
        }
        private class ModernSofa : ISofa
        {
            public string LieOn() => "Lying on a low-profile Modern Sofa (neutral fabric).";
        }

        private class VictorianFurnitureFactory : IFurnitureFactory
        {
            public IChair CreateChair() => new VictorianChair();
            public ISofa CreateSofa() => new VictorianSofa();
        }

        private class VictorianChair : IChair
        {
            public string SitOn() => "Sitting on an ornate Victorian Chair (wood + velvet).";
        }
        private class VictorianSofa : ISofa
        {
            public string LieOn() => "Lying on a tufted Victorian Sofa (rich upholstery).";
        }
    }
}
