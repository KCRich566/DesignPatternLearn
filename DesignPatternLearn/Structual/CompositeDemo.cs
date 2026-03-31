using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Structual
{
    internal class CompositeDemo : IPatternDemo
    {
        // Composite（組合模式）
        // 核心思想：將物件組合成樹狀結構來表示「部分–整體」的層次關係。
        //   Composite 模式讓客戶端以統一的方式對待個別物件和物件集合。
        //
        // 要點：
        //   - Leaf 與 Composite 實作相同的抽象（Component），客戶端不需分辨。
        //   - 只有 Composite 節點持有 List<Component>；Leaf 不會有子集合。
        //   - 共用操作放在 Component，Composite 覆寫管理子節點的行為。
        //
        // 使用情境：需要以樹狀結構遍歷或操作一組物件時。
        // 真實案例：
        //   1. 檔案系統——資料夾當 Composite、檔案當 Leaf，遞迴操作與列印樹狀結構（如本範例）。
        //   2. GUI 元件樹——Panel 包含 Button、TextBox 等子元件，Panel 也可巢狀包含其他 Panel。
        //   3. 組織架構——部門（Composite）包含子部門和員工（Leaf），統一計算薪資、人數等。
        public string Name => "Composite";
        public void Run()
        {
            Composite root = new Composite("Root");

            Composite folderA = new Composite("Folder A");
            folderA.Add(new Leaf("File A1"));
            folderA.Add(new Leaf("File A2"));

            Composite folderB = new Composite("Folder B");

            Composite subB1 = new Composite("Sub B1");
            subB1.Add(new Leaf("File B1.1"));
            subB1.Add(new Leaf("File B1.2"));
            folderB.Add(subB1);
            folderB.Add(new Leaf("folder B-root"));

            root.Add(folderA);
            root.Add(folderB);
            root.Add(new Leaf("Readme.md"));

            Console.WriteLine("Composite structure:");
            root.Display(0);

            Console.WriteLine();
            Console.WriteLine("After removing File A2 from Folder A: ");
            Component fileA2 = folderA.Children.FirstOrDefault(c => c.Name == "File A2");
            if (fileA2 != null) folderA.Remove(fileA2);

            root.Display(0);
        }

        internal abstract class Component
        {
            public string Name { get; }

            protected Component(string name)
            {
                Name = name;
            }
            public virtual void Add(Component c)
            {
                throw new NotSupportedException("Add not Supported for this component.");
            }
            public virtual void Remove(Component c)
            {
                throw new NotSupportedException("Remove not supported for this component.");
            }
            public abstract void Display(int depth);

        }

        internal class Leaf : Component
        {
            // base(name) 是呼叫父類別 Component 的建構子，將 name 參數傳遞給父類別來初始化 Name 屬性。
            // 相當於定義如{base(name);}
            // 為什麼會有這種寫法? 
            public Leaf(string name) : base(name) { }
            public override void Display(int depth)
            {
                Console.WriteLine(new string(' ', depth * 2) + "- " + Name);
            }
        }

        internal class Composite : Component
        {
            private readonly List<Component> _children = new List<Component>();
            public Composite(string name) : base(name) { }
            public IReadOnlyList<Component> Children => _children;

            public override void Add(Component c)
            {
                if (c == null)
                {
                    throw new ArgumentNullException(nameof(c));
                }
                _children.Add(c);
            }
            public override void Remove(Component c)
            {
                if (c == null) throw new ArgumentNullException(nameof(c));
                _children.Remove(c);
            }

            public override void Display(int depth)
            {
                Console.WriteLine(new string(' ', depth * 2) + "+ " + Name);
                foreach (var child in _children)
                {
                    child.Display(depth + 1);
                }
            }
        }
    }
}
