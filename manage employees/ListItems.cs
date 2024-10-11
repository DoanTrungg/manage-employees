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

        public static Team GetTeam(List<Team> listTeam)
        {
            ListItems.PrintList(listTeam);
            Console.Write("Team Index : ");
            string inputAdd = Console.ReadLine();
            if (ValidInput.IsNumberChoice(inputAdd, listTeam) == -1)
            {
                Console.WriteLine("* incorrect input *");
                return null;
            }

            return listTeam[Int32.Parse(inputAdd)];
        }

        public static Player GetPlayer(List<Player> listPlayer)
        {
            ListItems.PrintList(listPlayer);
            Console.Write("Player Index : ");
            string inputAdd = Console.ReadLine();
            if (ValidInput.IsNumberChoice(inputAdd, listPlayer) == -1)
            {
                Console.WriteLine("* incorrect input *");
                return null;
            }
            int choiceAdd = Int32.Parse(inputAdd);
            Console.WriteLine("--------------- ");
            Console.WriteLine("Make Your Choice : \n" + listPlayer[choiceAdd].ToString());
            return listPlayer[choiceAdd];
        }
    }
}
