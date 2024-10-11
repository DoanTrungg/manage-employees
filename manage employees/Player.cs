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
   
        public Player(string fullName, string dateOfBirth, int squadNumber, string position)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            SquadNumber = squadNumber;
            Position = position;
            _team = new Team();
        }

        public Player() { _team = new Team(); }

        public Player EnterInforPlayer()
        {
            Console.Write("enter full name : ");
            string inputName = Console.ReadLine();
            bool isName = ValidInput.ValidStringName(inputName);
            if(isName) _fullName = inputName;

            Console.Write("enter date of birthday (m/d/y) : ");
            string inputDate = Console.ReadLine();
            bool isDate = ValidInput.ValidStringDate(inputDate);
            if(isDate) _dateOfBirth = inputDate;

            Console.Write("enter squad number : ");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out int result);
            ValidInput.ValidNumber(isNumber);
            if(isNumber) _squadNumber = result;

            Console.Write("enter position (”GK”, “CB” , “WB” , ”CM” , “CF”) : ");
            string inputPosition = Console.ReadLine();
            bool isPosition = ValidInput.ValidPosition(inputPosition);
            if(isPosition) _position = inputPosition;

            return this;
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
                result += " - Position : " + _position.ToUpper();

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
