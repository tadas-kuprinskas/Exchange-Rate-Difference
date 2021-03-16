using ConsoleUIExchangeRates.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleUIExchangeRates.Models
{
    
    public class ExchangeRate
    {
        public static XmlNodeList GetXmlNodeList(XmlDocument doc, string output)
        { 
            doc.Load("http://www.lb.lt//webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=" + output);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/ExchangeRates/item");
            return nodes;
        }

        public static XmlNodeList GetPreviousDayXmlNodeList(XmlDocument doc, string output)
        {
            var outputNumber = Parsing.ParseToIntAndSubstract(output);
            var outputStringDate = Parsing.ParseToStringAndInsert(outputNumber-1);            
            doc.Load("http://www.lb.lt//webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=" + outputStringDate);   
            
            XmlElement root = doc.DocumentElement;
           
            XmlNodeList nodes = root.SelectNodes("/ExchangeRates/item");
            return nodes;
        }
    }
}
