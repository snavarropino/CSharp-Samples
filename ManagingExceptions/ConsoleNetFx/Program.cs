using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleNetFx
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("CatchAndThrow:");
                CatchAndThrow();
            }
            catch (Exception ex)
            {
                ex.ToConsole();
            }

            try
            {

                Console.WriteLine("==============================================");
                Console.WriteLine("==============================================");
                Console.WriteLine("CatchAndThrowEx:");
                CatchAndThrowEx();
            }
            catch (Exception ex)
            {
                ex.ToConsole();
            }

            try
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("==============================================");
                Console.WriteLine("CatchAndThrowNewEx:");
                CatchAndThrowNewEx();
            }
            catch (Exception ex)
            {
                ex.ToConsole();
            }
        }

        public static void CatchAndThrow()
        {
            try
            {
                var result = FaultyCode(5);
            }
            catch (Exception ex)
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
            int divisor = 0;
            return number / divisor;
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
