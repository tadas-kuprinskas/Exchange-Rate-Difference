using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleUIExchangeRates.Models.Helpers
{
   
    public class PrintNodes
    {
        public const string CFr = "..\\..\\..\\Results.txt";

        public static void PrintNodesToConsole(XmlNodeList nodes, XmlNodeList nodesPrevious)
        { 
            
            foreach (XmlNode node in nodes)
            {
                foreach (XmlNode pNode in nodesPrevious)
                {
                    if (node["currency"].InnerText == pNode["currency"].InnerText)
                    {

                        string date = node["date"].InnerText;
                        string currency = node["currency"].InnerText;
                        string rateString = node["rate"].InnerText;
                        string ratePreviousString = pNode["rate"].InnerText;
                        decimal rateCurrent = Parsing.ParseToDecimal(rateString);
                        decimal ratePrevious = Parsing.ParseToDecimal(ratePreviousString);
                        var rate = ratePrevious - rateCurrent;

                        Console.WriteLine($"{date} {currency}\nChanged since yesterday: {rate}");
                    }
                }
            }
        }

        public static void PrintNodesToFile(XmlNodeList nodes, XmlNodeList nodesPrevious)
        {
            DeleteIfFIleExists();

            using (var fr = File.AppendText(CFr))
            {
                foreach (XmlNode node in nodes)
                {
                    foreach (XmlNode pNode in nodesPrevious)
                    {
                        if (node["currency"].InnerText == pNode["currency"].InnerText)
                        {
                            string date = node["date"].InnerText;
                            string currency = node["currency"].InnerText;
                            string rateString = node["rate"].InnerText;
                            string ratePreviousString = pNode["rate"].InnerText;
                            decimal rateCurrent = decimal.Parse(rateString);
                            decimal ratePrevious = decimal.Parse(ratePreviousString);
                            var rate = ratePrevious - rateCurrent;

                            fr.WriteLine($"{date} {currency}\nChanged since yesterday: {rate}" );                           
                        }
                    }
                }
            }
        }

        public static void DeleteIfFIleExists()
        {
            if (File.Exists(CFr))
                File.Delete(CFr);
        }
    }
}
