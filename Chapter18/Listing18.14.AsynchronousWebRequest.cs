namespace EssentialCSharp.Chapter18.Listing18_14
{
    using System;
    using System.IO;
    using System.Net;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Runtime.ExceptionServices;
    //通过TPL来使用基于任务的异步模式
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = "http://www.IntelliTect.com";
            if (args.Length > 0)
            {
                url = args[0];
            }
            Console.Write(url);
            Task task = WriteWebRequestSizeAsync(url);
            try
            {
                //如果在分配的时间内 true 完成执行，则为 Task；否则为 false
                while (!task.Wait(1000))
                {
                    Console.Write(".");
                }
            }
            catch (AggregateException exception)
            {
                try
                {
                    exception.Handle(innerException =>
                    {
                        // Rethrowing rather than using
                        // if condition on the type.
                        ExceptionDispatchInfo.Capture(
                                              exception.InnerException)
                                              .Throw();
                        return true;
                    });
                }
                catch (WebException)
                {
                    // ...
                }
                catch (IOException)
                {
                    // ...
                }
                catch (NotSupportedException)
                {
                    // ...
                }
            }
        }
        //定义了这个任务（Task）会做哪些事情，执行这个任务，使异步执行
        private static Task WriteWebRequestSizeAsync(string url)
        {
            StreamReader reader = null;
            WebRequest webRequest = WebRequest.Create(url);
            //异步方式，并定义任务延续（ContinueWith）
            Task task = webRequest.GetResponseAsync().ContinueWith(anteccedent =>
            {
                WebResponse response = anteccedent.Result;
                reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEndAsync();
            }).Unwrap().ContinueWith(antecedent =>
            {
                if (reader != null)
                    reader.Dispose();
                string text = antecedent.Result;
                Console.WriteLine(FormatBytes(text.Length));
            });
            return task;
        }
        static public string FormatBytes(long bytes)
        {
            string[] magnitudes =
                new string[] { "GB", "MB", "KB", "Bytes" };
            long max =
                (long)Math.Pow(1024, magnitudes.Length);

            return string.Format("{1:##.##} {0}",
                magnitudes.FirstOrDefault(
                    magnitude =>
                        bytes > (max /= 1024)) ?? "0 Bytes",
                    (decimal)bytes / (decimal)max).Trim();
        }
    }
}
