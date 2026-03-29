using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Creational
{
    // 與Simple Factory不同的是, Abstract Factory進一步將工廠抽象化
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
        // 客戶指使用抽象工廠建立抽象產品
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
