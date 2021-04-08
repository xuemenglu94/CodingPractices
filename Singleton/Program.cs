using System;
using System.Threading;

namespace Singleton
{
    public class Program
    {
        public static void Main()
        {
            //var s1 = Singleton.GetInstance("s1");
            //var s2 = Singleton.GetInstance("s2");

            //Console.WriteLine("Singleton with the same thread: " + ReferenceEquals(s1, s2));

            //var t1 = new Thread(() =>
            //{
            //    SetSingletonValue("thread1");
            //});
            //var t2 = new Thread(() =>
            //{
            //    SetSingletonValue("thread2");
            //});
            //Console.WriteLine("Multi thread situations:");
            //t1.Start();
            //t2.Start();

            var f1 = new Thread(() =>
            {
                GermanSingleton.SetName("John");
                var f = GermanSingleton.Instance;
                Console.WriteLine($"German president is {f.Name}");
            });
            var f2 = new Thread(() =>
            {
                FrenchSingleton.SetName("Sam");
                var f = FrenchSingleton.Instance;
                Console.WriteLine($"French president is {f.Name}");
            });
            f1.Start();
            f2.Start();
        }

        //private static void SetSingletonValue(string value)
        //{
        //    var s = President.GetInstance(value);
        //    Console.WriteLine($"- Created by:{s.Value}");
        //}
    }
}
