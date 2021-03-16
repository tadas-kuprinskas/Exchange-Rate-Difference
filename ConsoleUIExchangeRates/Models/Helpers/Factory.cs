using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleUIExchangeRates.Models.Helpers
{
    public class Factory
    {
        public static XmlDocument GetXmlDocument()
        {
            return new XmlDocument();
        }
    }
}
