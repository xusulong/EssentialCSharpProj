namespace EssentialCSharp.Chapter18.Listing18_05
{
    using System;
    using System.Threading.Tasks;
    public class Program
    {
        //任务延续
        public static void Main()
        {
            Console.WriteLine("Before");
            // Use Task.Factory.StartNew<string>() for
            // TPL prior to .NET 4.5
            Task taskA =
                Task.Run(() => Console.WriteLine("Continuing A...")).ContinueWith(antecedent => Console.WriteLine("Continuing 2...")).ContinueWith(antecedent => Console.WriteLine("Continuing 3..."));
            Task taskB = taskA.ContinueWith(antecedent => Console.WriteLine("Continuing B..."));
            Task taskC = taskB.ContinueWith(antecedent => Console.WriteLine("Continuing C..."));
            //阻塞控制流，等待任务B,C完成
            Task.WaitAll(taskB,taskC);
            Console.WriteLine("Finished!");
            
        }
    }
}
