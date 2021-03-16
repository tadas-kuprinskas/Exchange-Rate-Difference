using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUIExchangeRates.Models.Helpers
{
    public class Parsing
    {
        public static int ParseToInt(string outputString)
        {
            
            var outputNUmber = int.Parse(outputString);
            return outputNUmber;
        }

        public static string ParseToStringAndInsert(int outputNUmber)
        {
            var outputNumberString = outputNUmber.ToString().Insert(4, "-").Insert(7, "-");
            return outputNumberString;
        }

        public static decimal ParseToDecimal(string rateString)
        {
            decimal rateCurrent = decimal.Parse(rateString);
            return rateCurrent;
        }

        public static int ParseToIntAndSubstract(string output)
        {
            var outputString = output.Replace("-", "");
            var outputNumber = ParseToInt(outputString);
            return outputNumber;
        }
    }
}
