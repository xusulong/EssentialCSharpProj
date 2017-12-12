 namespace EssentialCSharp.Chapter15.Listing15_15
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            
        }
        //从查询表达式获取不重复的成员
        public static void ListMemberNames()
        {
            IEnumerable<string> enumerableMmethodNames = (
                 from method in typeof(Enumerable).GetMembers(
                  System.Reflection.BindingFlags.Static | 
                    System.Reflection.BindingFlags.Public)
                 orderby method.Name
                 select method.Name).Distinct();
            foreach (string method in enumerableMmethodNames)
            {
                Console.Write($"{method},");
            }
        }
    }
}
