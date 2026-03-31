using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Structual
{
    internal class BridgeDemo : IPatternDemo
    {
        // Bridge（橋接模式）
        // 核心思想：將「抽象（Shape）」與「實作（IRenderer）」分離，使兩者可以獨立變化。
        //   可在執行時期切換實作。
        //   沒有 Bridge 的話你要建立很多個類別（CircleRaster、CircleVector、SquareRaster...）。
        //   有了 Bridge 你只要建立 Circle、Square，然後在執行時決定用 RasterRenderer 還是 VectorRenderer。
        // 使用情境：當抽象和實作都可能有多種變化，且希望避免類別爆炸時。
        // 真實案例：
        //   1. 圖形繪製引擎——Shape（抽象）× Renderer（實作），如本範例。
        //   2. 跨平台 UI 框架——Window（抽象）× Platform（Windows / macOS / Linux）。
        //   3. 訊息發送系統——Message（抽象）× Channel（Email / SMS / Push Notification）。
        public string Name => "Bridge";
        public void Run()
        {
            IRenderer raster = new RasterRenderer();
            IRenderer vector = new VectorRenderer();

            Shape circle = new Circle(raster, 5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();

            Shape square = new Square(vector, 3);
            square.Draw();

            //switch implementor at runtime
            circle.Renderer = vector;
            circle.Draw();
        }

        internal interface IRenderer
        {
            string WhatToRenderAs { get; }
            void RenderCircle(float radius);
            void RenderSquare(float side);
        }

        // Raster: 中文翻譯為「點陣」，是由像素（pixels）組成的圖像。
        // Raster Renderer 是一種渲染器，將圖形轉換為像素點來顯示在屏幕上。 
        internal class RasterRenderer : IRenderer
        {
            public string WhatToRenderAs => "pixels";
            public void RenderCircle(float radius)
            {
                Console.WriteLine($"Drawing a circle of radius {radius} as pixels");
            }
            public void RenderSquare(float side)
            {
                Console.WriteLine($"Drawing a square of side {side} as pixels");
            }
            
        }

        internal class VectorRenderer : IRenderer
        {
            public string WhatToRenderAs => "vectors";
            public void RenderCircle(float radius)
            {
                Console.WriteLine($"Drawing a circle of radius {radius} as vectors");
            }
            public void RenderSquare(float side)
            {
                Console.WriteLine($"Drawing a square of side {side} as vectors");
            }
        }

        // abstract與virtual的區別:
        // 1. abstract方法沒有實現，必須在非抽象子類中覆寫；virtual方法有默認實現，可以選擇性覆寫。

        // 說白了就是在Shape方法中, 再組合一個IRenderer, 這樣Shape就不需要知道具體的渲染方式, 就可以獨立變化了. 這就是Bridge的核心思想.
        internal abstract class Shape
        {
            public IRenderer Renderer { get; set; }
            protected Shape(IRenderer renderer)
            {
                Renderer = renderer;
            }
            public abstract void Draw();
            public abstract void Resize(float factor);
        }
        internal class Circle : Shape
        {
            private float radius;
            public Circle(IRenderer renderer, float radius):base (renderer)
            {
                this.radius = radius;
            }
            public override void Draw() => Renderer.RenderCircle(radius);
            public override void Resize(float factor) => radius *= factor;
        }

        internal class Square : Shape
        {
            private float side;
            public Square(IRenderer renderer, float side): base(renderer)
            {
                this.side = side;
            }
            public override void Draw() => Renderer.RenderSquare(side);
            public override void Resize(float factor) => side *= factor;
        }
    }
}
