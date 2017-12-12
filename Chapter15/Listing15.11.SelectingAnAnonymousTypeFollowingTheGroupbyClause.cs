﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCSharp.Chapter15.Listing15_11
{
    class Program
    {
        public static void Main()
        {
            GroupKeywords1();
        }

        private static void GroupKeywords1()
        {
            //对于Keywords中的所有元素，按照是否含有'*'分组
            IEnumerable<IGrouping<bool, string>> keywordGroups =
                from word in Keywords
                group word by word.Contains('*');

            foreach (var group in keywordGroups)
            {
                Console.WriteLine("Group Key:{0}", group.Key);
                foreach (var item in group)
                {
                    Console.Write(item);
                }
            }


            /*
            var selection =
                from groups in keywordGroups
                select new
                {
                    IsContextualKeyword = groups.Key,
                    Items = groups
                };

            foreach (var wordGroup in selection)
            {
                Console.WriteLine(Environment.NewLine + "{0}:",
                    wordGroup.IsContextualKeyword ?
                        "Contextual Keywords" : "Keywords");

                foreach (var keyword in wordGroup.Items)
                {
                    Console.Write(" " + keyword.Replace("*", null));
                }
            }*/
            Console.ReadKey();
        }
        //用查询延续子句扩展查询
        private static void GroupKeywords()
        {
            var selection =
                from word in Keywords
                group word by word.Contains('*')
                into groups
                select new
                {
                    IsContextualKeyword = groups.Key,
                    Items = groups
                };
        }
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
            "unchecked", "void", "volatile", "where*", "while", "yield*"
        };
    }
}
