using System;
using System.Collections.Generic;

namespace ConsoleAppCore
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("CatchAndThrow:");
                CatchAndThrow();
            }
            catch(Exception ex)
            {
                ex.ToConsole();
            }

            try
            {

                Console.WriteLine("==============================================");
                Console.WriteLine("CatchAndThrowEx:");
                CatchAndThrowEx();
            }
            catch (Exception ex)
            {
                ex.ToConsole();
            }

            //try
            //{
            //    Console.WriteLine("==============================================");
            //    Console.WriteLine("==============================================");
            //    Console.WriteLine("CatchAndThrowNewEx:");
            //    CatchAndThrowNewEx();
            //}
            //catch (Exception ex)
            //{
            //    ex.ToConsole();
            //}
        }

        public static void CatchAndThrow()
        {
            try
            {
                var result = FaultyCode(5);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public static void CatchAndThrowEx()
        {
            try
            {
                var result = FaultyCode(5);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CatchAndThrowNewEx()
        {
            try
            {
                var result = FaultyCode(5);
            }
            catch (Exception ex)
            {
                throw new Exception("Didide by zero error", ex);
            }
        }

        public static int FaultyCode(int number)
        {
            DoStuff1();
            DoStuff2();

            int divisor = 0;
            return GetNumber() / divisor;
        }

        private static void DoStuff1()
        {
            for (int i = 0; i < 3; i++)
                Console.Write(".");
            Console.WriteLine();
        }

        private static void DoStuff2()
        {
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            Console.WriteLine($"DoStuff2:{string.Join(" ",list)}");
        }

        private static int GetNumber()
        {
            int sum = 5;

            for (int i = 5; i <= 10; i++)
                sum += i;

            return sum;
        }
        public static void ToConsole(this Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner exception:");
                Console.WriteLine(ex.InnerException.StackTrace);
            }
        }
    }
}
