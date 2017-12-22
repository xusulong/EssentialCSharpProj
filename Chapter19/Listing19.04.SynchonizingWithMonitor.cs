namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter19.Listing19_04
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    class Program
    {
        readonly static object _Sync = new object();
        const int _Total = int.MaxValue;
        static long _Count = 0;
        public static void Main(string[] args)
        {
            Task task = Task.Run(() =>Decrement());

            for (int i = 0; i < _Total; i++)
            {
                //Monitor配合try/finally使用
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(_Sync,ref lockTaken);
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(_Sync);
                    }
                }
            }
        }
        static void Decrement()
        {
            for (int i = 0; i < _Total; i++)
            {
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(_Sync, ref lockTaken);
                    _Count--;
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(_Sync);
                    }
                }
            }
        }
    }
}
