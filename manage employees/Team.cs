using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manage_employees
{
    internal class Team
    {
        private string _teamId;
        private string _teamName;
        private string _ground;
        private HashSet<Player> _listOfPlayer;

        public string TeamId { get => _teamId; set => _teamId = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public string Ground { get => _ground; set => _ground = value; }
        internal HashSet<Player> ListOfPlayer { get => _listOfPlayer; set => _listOfPlayer = value; }

        public Team() { _listOfPlayer = new HashSet<Player>(); }

        public Team(string teamId, string teamName, string ground)
        {
            TeamId = teamId;
            TeamName = teamName;
            Ground = ground;
            _listOfPlayer = new HashSet<Player>();
        }

        public Team EnterInforTeam()
        {
            Console.Write("enter team id : ");
            _teamId = Console.ReadLine();

            Console.Write("enter team name : ");
            _teamName = Console.ReadLine();

            Console.Write("enter ground : ");
            _ground = Console.ReadLine();

            return this;
        }
        public override string ToString()
        {
            string result = "";

            if (!string.IsNullOrEmpty(_teamId))
                result += "Team ID : " + _teamId;

            if (!string.IsNullOrEmpty(_teamName))
                result += " - Team Name : " + _teamName;

            if (!string.IsNullOrEmpty(_ground))
                result += " - Squad Number : " + _ground;

            if (_listOfPlayer.Count > 0) 
            {
                result += " - 'Player' : ";
                foreach (var player in _listOfPlayer) result +=  player.FullName + " . ";
            }
                
            return result;
        }
    }
}
