using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleUIExchangeRates.Models.Helpers
{
    public class Message
    {
        public static string enterDate = "Please enter the date to check for the changes of the currency rates (i.e. 2010-01-08) \n" +
            "(Note that dates up to the end of the year 2014): \n";

        public static int validDateNumber = 20140000;

        public static void EnterMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string UserMessageOutput()
        {
            var output = Console.ReadLine();
            ValidateDate(output);
            return output;
        }

        public static void ValidateDate(string output)
        {
            var outputString = Regex.Replace(output, "-", "");
            var outputNumber = Parsing.ParseToInt(outputString);

            if (outputNumber > validDateNumber)
            {
                throw new DataMisalignedException("Dates up to the end of the year 2014");               
            }

        }
    }
}
