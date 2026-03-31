using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    internal class StateDemo : IPatternDemo
    {
        // State（狀態模式）
        // 核心思想：允許一個物件在其內部狀態改變時改變其行為。
        //   將狀態相關的行為封裝在不同的狀態類別中，
        //   使得物件的行為隨著狀態的變化而變化，而不需修改物件本身的程式碼。
        // 使用情境：當物件有多種狀態，且各狀態下的行為差異顮大時，可以用 State 模式取代大量的 if/switch 判斷。
        // 真實案例：
        //   1. 旋轉門（Turnstile）——如本範例，有 Locked / Unlocked 兩種狀態。
        //   2. 訂單流程——訂單狀態從 NewOrder → Paid → Shipped → Delivered 依序轉換。
        //   3. 遊戲角色——角色在 Idle、Walking、Attacking、Dead 等狀態之間切換。
        public string Name => "State";
        public void Run()
        {
            Turnstile turnstile = new Turnstile();
            Console.WriteLine($"Initial State: {turnstile.CurrentStateName}");

            turnstile.Push();
            turnstile.InsertCoin();
            turnstile.Push();
            turnstile.InsertCoin();
            turnstile.InsertCoin();
            turnstile.Push();

            Console.WriteLine("\n State demo finished");
        }
        internal interface IState
        {
            void InsertCoin(Turnstile turnstile);
            void Push(Turnstile trnstile);
            string Name { get; }
        }

        // Turnstile: 中文叫做“旋转门”，是一种常见的门禁系统，通常用于地铁站、体育场馆等公共场所。它的设计允许人们通过旋转门进入或离开，同时控制人员流动和安全。
        internal class Turnstile
        {
            private IState _state;
            public Turnstile()
            {
                _state = new LockedState();
            }
            public string CurrentStateName => _state.Name;

            public void SetState(IState state)
            {
                _state = state;
            }

            public void InsertCoin()
            {
                Console.WriteLine("-- Action: Insert Coin");
                _state.InsertCoin(this);
            }

            public void Push()
            {
                Console.WriteLine("-- Action: Push");
                _state.Push(this);
            }
        }

        internal class LockedState: IState
        {
            public string Name => "Locked";
            public void InsertCoin(Turnstile turnstile) 
            {
                Console.WriteLine("Coin accepted. Unlocking turnstile.");
                turnstile.SetState(new UnlockedState());
            }

            public void Push(Turnstile turnstile)
            {
                Console.WriteLine("Turnstile is locked. Please insert a coin.");
            }
        }

        internal class UnlockedState : IState
        {
            public string Name => "Unlocked";
            public void InsertCoin(Turnstile turnstile)
            {
                Console.WriteLine("Turnstile is already unlocked. No need to insert another coin.");
            }

            public void Push(Turnstile turnstile)
            {
                Console.WriteLine("Pass through the turnstile. Locking it again.");
                turnstile.SetState(new LockedState());
            }
        }
    }
}
