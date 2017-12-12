 namespace EssentialCSharp.Chapter15.Listing15_05
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        private static string[] Keywords = {
            "abstract", "add*", "alias*", "as", "ascending*",
            "async*", "await*", "base","bool", "break",
            "by*", "byte", "case", "catch", "char", "checked",
            "class", "const", "continue", "decimal", "default",
            "delegate", "descending*", "do", "double",
            "dynamic*", "else", "enum", "event", "equals*",
            "explicit", "extern", "false", "finally", "fixed",
            "from*", "float", "for", "foreach", "get*", "global*",
            "group*", "goto", "if", "implicit", "in", "int",
            "into*", "interface", "internal", "is", "lock", "long",
            "join*", "let*", "nameof*", "namespace", "new", "null",
            "on*", "operator", "orderby*", "out", "override",
            "object", "params", "partial*", "private", "protected",
            "public", "readonly", "ref", "remove*", "return", "sbyte",
            "sealed", "select*", "set*", "short", "sizeof",
            "stackalloc", "static", "string", "struct", "switch",
            "this", "throw", "true", "try", "typeof", "uint", "ulong",
            "unsafe", "ushort", "using", "value*", "var*", "virtual",
            "unchecked", "void", "volatile", "where*", "while", "yield*" };
        public static void Main()
        {
            CountContextualKeywords();
        }
        private static void CountContextualKeywords()
        {
            int delegateInvocations = 0;
			//相当于一个方法，参数为string，返回值是string
            Func<string,string> func = (text) => {
                delegateInvocations++;
                return text;
            };
            IEnumerable<string> selection =
                from keyword in Keywords
                where keyword.Contains('*')
                select func(keyword);
            Console.WriteLine(
                $"1. delegateInvocations={ delegateInvocations }");//0

            // Executing count should invoke func once for 
            // each item selected.
            Console.WriteLine(
                $"2. Contextual keyword count={ selection.Count() }");//27;执行一次Count(),delegateInvocations计数器增加一次

            Console.WriteLine(
                $"3. delegateInvocations={ delegateInvocations }");//27

            // Executing count should invoke func once for 
            // each item selected.
            Console.WriteLine(
                $"4. Contextual keyword count={ selection.Count() }");//27

            Console.WriteLine(
                $"5. delegateInvocations={ delegateInvocations }");//54

            // Cache the value so future counts will not trigger
            // another invocation of the query.
            List<string> selectionCache = selection.ToList();

            Console.WriteLine(
                $"6. delegateInvocations={ delegateInvocations }");//81

            // Retrieve the count from the cached collection.
            Console.WriteLine(
                $"7. selectionCache count={ selectionCache.Count() }");//selectionCache而不是selection，不影响delegateInvocations

            Console.WriteLine(
                $"8. delegateInvocations={ delegateInvocations }");//81
        }
    }
}
