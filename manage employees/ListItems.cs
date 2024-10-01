using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manage_employees
{
    internal class ListItems
    {
        public static bool IsList<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine(list is List<Player> ? "* List Player Empty *" : "* List Team Empty *");
                return false;
            }
            else return true;
        }
        public static void PrintList<T>(List<T> list)
        {
            Console.WriteLine(list is List<Player> ? "List Player :" : "--------------- \nList Team :");

            for (int i = 0; list.Count > i; i++)
            {
                Console.WriteLine("INDEX : " + i + " - " + list[i].ToString());
            }
        }
    }
}
