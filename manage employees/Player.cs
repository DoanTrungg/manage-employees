using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace manage_employees
{
    internal class Player
    {
        private string _fullName;
        private string _dateOfBirth;
        private int _squadNumber;
        private string _position;
        private Team _team;

        public string FullName { get => _fullName; set => _fullName = value; }
        public string DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public int SquadNumber { get => _squadNumber; set => _squadNumber = value; }
        public string Position { get => _position; set => _position = value; }
        internal Team Team { get => _team; set => _team = value; }
        public Player() { _team = new Team();  }
        public Player(string fullName, string dateOfBirth, int squadNumber, string position)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            SquadNumber = squadNumber;
            Position = position;
            _team = new Team();
        }

        public override string ToString()
        {
            string result = ""; 

            if (!string.IsNullOrEmpty(_fullName))
                result += "Full Name : " + _fullName;

            if (!string.IsNullOrEmpty(_dateOfBirth))
                result += " - Date : " + _dateOfBirth;

            if (_squadNumber > 0)
                result += " - Squad Number : " + _squadNumber;

            if (!string.IsNullOrEmpty(_position))
                result += " - Position : " + _position;

            if (_team != null && !string.IsNullOrEmpty(_team.TeamName))
                result += " - 'Team' : " + _team.TeamName;

            return result;
        }
    }
    public enum Position
    {
        GK,
        CB,
        WB,
        CM,
        CF,
    }


    
}
