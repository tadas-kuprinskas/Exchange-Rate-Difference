using ConsoleUIExchangeRates.Models;
using ConsoleUIExchangeRates.Models.Helpers;
using HtmlAgilityPack;
using Newtonsoft.Json;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleUIExchangeRates
{
    class Program
    {
        static void Main(string[] args)
        {            
            try
            {
                Message.EnterMessage(Message.enterDate);

                var output = Message.UserMessageOutput();

                XmlDocument doc = Factory.GetXmlDocument();
                XmlDocument doc1 = Factory.GetXmlDocument();

                var nodes = ExchangeRateNodes.GetXmlNodeList(doc, output);
                var nodesPrevious = ExchangeRateNodes.GetPreviousDayXmlNodeList(doc1, output);

                PrintNodes.PrintNodesToConsole(nodes, nodesPrevious);

                PrintNodes.PrintNodesToFile(nodes, nodesPrevious);
                  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }
    }

   
}
