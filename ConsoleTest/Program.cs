using LikestCore.Abstract;
using LikestCore.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ILikestApi api = new RestSharpLikestApi();

            var loadObservable = api.Load;

            var subscription = loadObservable.Subscribe((t) => Console.WriteLine($"Current: {t.current}. Slowdown: {t.slowdown}"));

            Console.ReadLine();

            subscription.Dispose();
        }
    }
}
