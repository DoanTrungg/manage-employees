using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manage_employees
{
    internal class AddPlayer
    {
        public void AddPlayerForTeam(List<Player> listPlayer, List<Team> listTeam)
        {
            if (!ListItems.IsList(listPlayer) || !ListItems.IsList(listTeam)) return;

            Player player = Player.GetPlayer(listPlayer);
            if (player == null) return;

            Team team = Team.GetTeam(listTeam);
            if(team == null) return;

            if (team.ListOfPlayer.Contains(player))
            {
                Console.WriteLine("* Player existed in team *");
                return;
            }
            team.ListOfPlayer.Add(player);
            player.Team.ListOfPlayer.Remove(player);
            player.Team = team;
            Console.WriteLine("--------------- ");

            Console.WriteLine("Has been added : " + "\n" + team.ToString());
        }
        
        
        
    }
}
