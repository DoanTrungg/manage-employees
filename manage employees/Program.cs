using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace manage_employees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GK,CB,WB,CM,CF
            List<Team> listTeam = new List<Team>();
            List<Player> listPlayer = new List<Player>();
            bool flag = false;

            listPlayer.Add(new Player("Voi", "12/2/2004", 8, "CF"));
            listPlayer.Add(new Player("Kien", "2/1/2000", 3, "GK"));
            listPlayer.Add(new Player("Tho", "10/9/2007", 7, "WB"));
            listPlayer.Add(new Player("Hong", "4/5/2002", 4, "CM"));

            listTeam.Add(new Team("1A", "Dog", "HCM"));
            listTeam.Add(new Team("2A", "Cat", "HN"));
            listTeam.Add(new Team("1A", "Rabbit", "DN"));



            Console.WriteLine("1. Create Player");
            Console.WriteLine("2. Create Team");
            Console.WriteLine("3. Add Player For Team");
            Console.WriteLine("4. Remove Player For Team");
            Console.WriteLine("0. Exit");
            Console.WriteLine("--------------");
            Console.Write("Choice Option: ");
            int choiceNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("--------------");
            while (choiceNumber != 0)
            {
                if (flag)
                {
                    Console.WriteLine("--------------");
                    Console.Write("Choice Option: ");
                    choiceNumber = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("--------------");
                }
                ChoiceOfUser(listTeam, listPlayer, choiceNumber);
                flag = true;
            }





            Console.ReadKey();
        }
        public static void ChoiceOfUser(List<Team> listTeam, List<Player> listPlayer, int choiceNumber)
        {
            switch (choiceNumber)
            {
                case 1:
                    //Create Player;
                    listPlayer.Add(CreatePlayer());
                    break;
                case 2:
                    // create team
                    listTeam.Add(CreateTeam());
                    break;
                case 3:
                    if (!IsList(listPlayer) || !IsList(listTeam)) return;
                    PrintList(listPlayer);
                    Console.Write("Player Index : ");
                    string inputAdd = Console.ReadLine();
                    if (IsNumberChoice(inputAdd, listPlayer) == -1)
                    {
                        Console.WriteLine("* incorrect input *");
                        return;
                    }
                    int choiceAdd = IsNumberChoice(inputAdd, listPlayer);
                    Console.WriteLine("--------------- ");
                    Console.WriteLine("Make Your Choice : \n" + listPlayer[choiceAdd].ToString());
                    var member = listPlayer[choiceAdd];

                    
                    PrintList(listTeam);
                    Console.Write("Team Index : ");
                    inputAdd = Console.ReadLine();
                    if (IsNumberChoice(inputAdd, listPlayer) == -1)
                    {
                        Console.WriteLine("* incorrect input *");
                        return;
                    }
                    choiceAdd = IsNumberChoice(inputAdd, listPlayer);
                    listTeam[choiceAdd].ListOfPlayer.Add(member);
                    member.Team.ListOfPlayer.Remove(member);
                    member.Team = listTeam[choiceAdd];
                    Console.WriteLine("--------------- ");
                    Console.WriteLine("Has been added : " + "\n" + listTeam[choiceAdd].ToString());

                    break;
                case 4:
                    if (!IsList(listPlayer) || !IsList(listTeam)) return;
                    PrintList(listPlayer);
                    Console.Write("Player Index : ");
                    string inputRemove = Console.ReadLine();
                    if (IsNumberChoice(inputRemove, listPlayer) == -1) 
                    {
                        Console.WriteLine("* incorrect input *");
                        return;
                    }
                    int choiceRemove = IsNumberChoice(inputRemove, listPlayer);
                    Console.WriteLine("--------------- ");
                    Console.WriteLine("Make Your Choice : \n" + listPlayer[choiceRemove].ToString());
                    var playerRemove = listPlayer[choiceRemove];


                    PrintList(listTeam);
                    Console.Write("Team Index : ");
                    inputRemove = Console.ReadLine();
                    if (IsNumberChoice(inputRemove, listPlayer) == -1)
                    {
                        Console.WriteLine("* incorrect input *");
                        return;
                    }
                    choiceRemove = IsNumberChoice(inputRemove, listPlayer);
                    if (!listTeam[choiceRemove].ListOfPlayer.Contains(playerRemove))
                    {
                        Console.WriteLine("Remove fail - Team dont contain player");
                        return;
                    }
                    listTeam[choiceRemove].ListOfPlayer.Remove(playerRemove);
                    playerRemove.Team = null;
                    Console.WriteLine("--------------- ");
                    Console.WriteLine("Has been removed : " + "\n" + listTeam[choiceRemove].ToString());
                    break;
                default:
                    Console.WriteLine("enter wrong number");
                    break;
            }
        }

        public static int IsNumberChoice<T>(string input, List<T> list)
        {
            if (!Int32.TryParse(input, out int choice)) return -1;
            if (choice >= list.Count) return -1;
            return choice;
        }
        public static bool IsList<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine(list is List<Player> ? "* List Player Empty *" : "* List Team Empty *");
                return false;
            }else return true;
        }
        public static void PrintList<T>(List<T> list) 
        {
            Console.WriteLine(list is List<Player> ? "List Player :" : "--------------- \nList Team :");

            for (int i = 0; list.Count > i; i++)
            {
                Console.WriteLine("INDEX : " + i + " - " + list[i].ToString());
            }
        }
        public static Player CreatePlayer()
        {
            Player player = new Player();
            EnterInforPlayer(player);
            return player;
        }
        public static Team CreateTeam()
        {
            Team team = new Team();
            EnterInforTeam(team);
            return team;
        }
        public static void EnterInforTeam(Team team) 
        {
            Console.Write("enter team id : ");
            team.TeamId = Console.ReadLine();

            Console.Write("enter team name : ");
            team.TeamName = Console.ReadLine();

            Console.Write("enter ground : ");
            team.Ground = Console.ReadLine();
            ValidStringName(team.Ground);
        }
        public static void EnterInforPlayer(Player player) 
        {
            Console.Write("enter full name : ");
            player.FullName = Console.ReadLine();
            ValidStringName(player.FullName);

            Console.Write("enter date of birthday (m/d/y) : ");
            player.DateOfBirth = Console.ReadLine();
            ValidStringDate(player.DateOfBirth);

            Console.Write("enter squad number : ");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out int result);
            ValidNumber(isNumber);

            Console.Write("enter position (”GK”, “CB” , “WB” , ”CM” , “CF”) : ");
            player.Position = Console.ReadLine();
            ValidPosition(player.Position);
        }
        public static void ValidStringName(String name)
        {
            Regex regex = new Regex("[@_!#$%^&*()<>?/|}{~:0123456789]");

            try
            {
                if (regex.IsMatch(name)) throw new IncorrectFormatException("* incorrect name format *");
            }
            catch (IncorrectFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ValidStringDate(String dateTime)
        {
            string[] formats = { "MM/dd/yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy" };
            DateTime expectedDate;
            try
            {
                if (!DateTime.TryParseExact(dateTime, formats, new CultureInfo("en-US"),
                    DateTimeStyles.None, out expectedDate)) throw new IncorrectFormatException("* incorrect datetime format *");
            }
            catch (IncorrectFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ValidNumber(bool isNumer)
        {
            try
            {
                if (!isNumer)
                {
                    throw new IncorrectFormatException("* incorrect number format *");
                }
            }
            catch (IncorrectFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ValidPosition(string position)
        {
            try
            {
                if (!Enum.TryParse(position.ToUpper(), out Position type))
                {
                    throw new IncorrectFormatException("* incorrect position format *");
                }
            }
            catch (IncorrectFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public class IncorrectFormatException : Exception
        {
            public IncorrectFormatException() { }
            public IncorrectFormatException(string message) : base(message) { }
        }


    }

}
