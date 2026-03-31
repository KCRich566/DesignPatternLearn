using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLearn.Behavioral
{
    // Observer（觀察者模式）
    // 核心思想：定義物件之間的一對多依賴關係，當主題（Subject）狀態改變時，
    //   所有註冊的觀察者（Observer）都會自動收到通知並更新。
    // 使用情境：當一個物件的狀態變化需要通知其他多個物件，且不希望緊密耦合時。
    // 真實案例：
    //   1. 氣象站與顯示面板——如本範例，WeatherStation 狀態改變時通知 PhoneDisplay、WindowDisplay。
    //   2. 事件系統（Event System）——GUI 按鈕點擊後通知所有註冊的事件處理器。
    //   3. 訂閱/發佈系統（Pub/Sub）——訊息佇列中的 Publisher 與 Subscriber 機制。
    internal class ObserverDemo : IPatternDemo
    {
        public string Name => "Observer";
        public void Run()
        {
            WeatherStation weatherStation = new WeatherStation();
            PhoneDisplay phoneDisplay = new PhoneDisplay("Phone");
            WindowDisplay windowDisplay = new WindowDisplay("Window");

            weatherStation.Attach(phoneDisplay);
            weatherStation.Attach(windowDisplay);

            weatherStation.SetMeasurements(25.0, 60.0, 1013.0);
            weatherStation.SetMeasurements(30.0, 55.0, 1010.0);

            weatherStation.Detach(phoneDisplay);
            
            weatherStation.SetMeasurements(23.0, 65.0, 1015.0);
            
            Console.WriteLine("Observer pattern demo completed.");

        }

        internal interface IObserver
        {
            void Update(double temperature, double humidty, double pressure);
        }

        internal interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify();
        }

        internal class WeatherStation : ISubject
        {
            private readonly List<IObserver> _observer = new List<IObserver>();
            private double _temperature;
            private double _humidity;
            private double _pressure;

            public void Attach(IObserver observer)
            {
                if (!_observer.Contains(observer))
                {
                    _observer.Add(observer);
                }
            }

            public void Detach(IObserver observer)
            {
                _observer.Remove(observer);
            }
            public void Notify()
            {
                foreach(var observer in _observer)
                {
                    observer.Update(_temperature, _humidity, _pressure);

                }
            }
            public void SetMeasurements(double temperature, double humidity, double pressure)
            {
                _temperature = temperature;
                _humidity = humidity;
                _pressure = pressure;

                Console.WriteLine("$Measurements changed: Temperature={temperature}, Humidity={humididy}, Pressure={pressure}");
                Notify();
            }
        }
        
        internal class PhoneDisplay : IObserver
        {
            private readonly string _name;
            public PhoneDisplay(string name)
            {
                _name = name;
            }

            public void Update(double temperature, double humidty, double pressure)
            {
                Console.WriteLine($"PhoneDisplay {_name} received update: Temperature={temperature}, Humidity={humidty}, Pressure={pressure}");
            }
        }

        internal class WindowDisplay : IObserver
        {
            private readonly string _name;
            public WindowDisplay(string name)
            {
                _name = name;

            }
            public void Update(double temperature, double humidty, double pressure)
            {
                Console.WriteLine($"WindowDisplay {_name} received update: Temperature={temperature}, Humidity={humidty}, Pressure={pressure}");
            }
        }
    }
}
