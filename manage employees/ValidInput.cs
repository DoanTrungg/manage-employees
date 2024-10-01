using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace manage_employees
{
    internal class ValidInput
    {
        public static bool ValidStringName(String name)
        {
            Regex regex = new Regex("[@_!#$%^&*()<>?/|}{~:0123456789]");

            try
            {
                if (regex.IsMatch(name)) throw new IncorrectFormatException("* incorrect name format *");
                return true;
            }
            catch (IncorrectFormatException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool ValidStringDate(String dateTime)
        {
            string[] formats = { "MM/dd/yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy" };
            DateTime expectedDate;
            try
            {
                if (!DateTime.TryParseExact(dateTime, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate)) 
                { 
                    throw new IncorrectFormatException("* incorrect datetime format *"); 
                }
                return true;
            }
            catch (IncorrectFormatException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
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
        public static bool ValidPosition(string position)
        {
            try
            {
                if (!Enum.TryParse(position.ToUpper(), out Position type))
                {
                    throw new IncorrectFormatException("* incorrect position format *");
                }
                return true;
            }
            catch (IncorrectFormatException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static int IsNumberChoice<T>(string input, List<T> list)
        {
            if (!Int32.TryParse(input, out int choice)) return -1;
            if (choice >= list.Count) return -1;
            return choice;
        }
    }
    public class IncorrectFormatException : Exception
    {
        public IncorrectFormatException() { }
        public IncorrectFormatException(string message) : base(message) { }
    }

}
