using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manage_employees
{
    internal class RemovePlayer
    {
        public static void RemovePlayerForTeam(List<Player> listPlayer, List<Team> listTeam)
        {
            if (!ListItems.IsList(listPlayer) || !ListItems.IsList(listTeam)) return;

            Player player = ListItems.GetPlayer(listPlayer);
            if (player == null) return;

            Team team = ListItems.GetTeam(listTeam);
            if (team == null) return;

            if (!team.ListOfPlayer.Contains(player))
            {
                Console.WriteLine("Remove fail - Team dont contain player");
                return;
            }
            team.ListOfPlayer.Remove(player);
            player.Team = null;
            Console.WriteLine("--------------- ");
            Console.WriteLine("Has been removed : " + "\n" + team.ToString());
        }
    }
}
