namespace EssentialCSharp.Chapter18.Listing18_25
{
    using System;
    using System.Threading.Tasks;
    using EssentialCSharp.Shared;
    class Program
    {
        const int TotalDigits = 100;
        const int BatchSize = 10;
        public static void Main()
        {
            string pi = null;
            const int iterations = TotalDigits / BatchSize;
            string[] sections = new string[iterations];
            //TPL提供了一个辅助方法，并行迭代
            Parallel.For(0,iterations,(i)=>
            {
                sections[i] = PiCalculator.Calculate(BatchSize, i * BatchSize);
            });
            pi = string.Join("",sections);
            Console.WriteLine(pi);
        }
    }
}
