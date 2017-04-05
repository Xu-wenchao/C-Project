using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            learn01();
            Console.ReadKey();
        }
        /// <summary>
        /// 学习使用Linq
        /// </summary>
        private static void learn01()
        {
            List<string> l1 = new List<string> { "1", "2", "3", "4", "5", "6"};
            List<string> l2 = new List<string> { "7", "8", "9", "4", "5", "6" };
            var filtered = from string c1 in l1
                            join string c2 in l2
                            on c1 equals c2
                            where int.Parse(c1) > 4
                            orderby c1
                            select c1;
            Action<string> act = Console.WriteLine;
            foreach(var v in filtered)
            {
                act(v);
            }
        }
    }
}
