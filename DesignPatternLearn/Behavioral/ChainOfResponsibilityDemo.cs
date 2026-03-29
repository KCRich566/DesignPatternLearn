using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // 核心目標： 有許多可以處理的競爭者
    // 請求沿著責任鏈（Chain）傳遞，每個處理者都有機會處理它。
    // 處理者可以選擇處理請求、傳遞給下一個處理者，或中止傳遞（短路）。
    // 這能達到發送者與接收者的解耦、便於擴展與動態重組鏈路。
    //
    // 適用情境：
    // - 多個物件可能處理同一請求，且不想將請求者與特定處理者耦合。
    // - 需要能動態改變處理順序或在運行時插入/移除處理節點。
    internal class ChainOfResponsibilityDemo : IPatternDemo
    {
        public string Name => "Chain of Responsibility";
        public void Run()
        {
            var manager = new ApprovalHandler("Manager", 1000m);
            var director = new ApprovalHandler("Director", 10000m);
            var ceo = new ApprovalHandler("CEO", decimal.MaxValue);

            manager.SetNext(director).SetNext(ceo);

            var request = new[]
            {
                new ApprovalRequest(250m, "Office supplies"),
                new ApprovalRequest(2500m, "New laptops"),
                new ApprovalRequest(7500m, "Team training"),
                new ApprovalRequest(25000m, "new server cluster")
            };

            foreach (var req in request)
            {
                Console.WriteLine($"Request: {req.Amount:C} - {req.Description}");
                var handler = manager.Handle(req);
                if (handler != null)
                {
                    Console.WriteLine($" Approved by: {handler.Name}\n");
                }
                else
                {
                    Console.WriteLine(" Request could not be approved\n");
                }
            }
        }

        private class ApprovalRequest
        {
            public decimal Amount { get; }
            public string Description { get; }
            public ApprovalRequest(decimal amount, string description)
            {
                Amount = amount;
                Description = description;
            }
        }

        private class ApprovalHandler
        {
            public string Name { get; }
            private readonly decimal _approvalLimit;
            private ApprovalHandler _next;

            public ApprovalHandler(string name, decimal approvaLimit)
            {
                Name = name;
                _approvalLimit = approvaLimit;
            }

            public ApprovalHandler SetNext(ApprovalHandler next)
            {
                _next = next;
                return next;
            }

            public ApprovalHandler Handle(ApprovalRequest request)
            {
                if (request.Amount <= _approvalLimit)
                {
                    return this;
                }
                if(_next != null)
                {
                    return _next.Handle(request);
                }
                return null;
            }
        }
    }
}
