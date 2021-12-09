using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;


  
    public static class XElementExtensions
    {
        public static XAttribute XPathSelectAttribute(this XElement element, string xPath)
        {
            return ((IEnumerable<object>)element.XPathEvaluate(xPath)).OfType<XAttribute>().First();
        }
    }
 
