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
                    AddPlayer add = new AddPlayer();
                    add.AddPlayerForTeam(listPlayer, listTeam);
                    break;
                case 4:
                    RemovePlayer remove = new RemovePlayer();
                    remove.RemovePlayerForTeam(listPlayer, listTeam);
                    break;
                default:
                    Console.WriteLine("exit application.....");
                    break;
            }
        }

        
        
        public static Player CreatePlayer()
        {
            Player player = new Player();
            player.EnterInforPlayer();
            return player;
        }
        public static Team CreateTeam()
        {
            Team team = new Team();
            team.EnterInforTeam();
            return team;
        }
        
        




    }

}
