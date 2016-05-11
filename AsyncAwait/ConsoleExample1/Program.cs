using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            FooAsync();
            Console.WriteLine("Main continues execution...");
            Console.ReadLine();            
        }

        public static async void FooAsync()
        {            
            Console.WriteLine("Foo is going to call ExecuteLongRunningTask...");
            Task<string> t = ExecuteLongRunningTask();

            Console.WriteLine("Foo continues execution...");
            Thread.Sleep(1000);
            Console.WriteLine("Foo is going to wait for ExecuteLongRunningTask response...");

            var s = await t;
            Console.WriteLine("Foo got the response: {0}", s);
        }

        public static Task<string> ExecuteLongRunningTask()
        {            
            return (Task.Factory.StartNew(() => 
                    { 
                        Thread.Sleep(5000); 
                        return "Hi all!!"; 
                    }));
        }        
    }
}
