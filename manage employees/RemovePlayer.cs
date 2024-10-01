using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manage_employees
{
    internal class RemovePlayer
    {
        public void RemovePlayerForTeam(List<Player> listPlayer, List<Team> listTeam)
        {
            if (!ListItems.IsList(listPlayer) || !ListItems.IsList(listTeam)) return;

            Player player = Player.GetPlayer(listPlayer);
            if (player == null) return;

            Team team = Team.GetTeam(listTeam);
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
