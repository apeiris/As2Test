using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;



public static class xtElement
{
    public static XAttribute XPathSelectAttribute(this XElement element, string xPath)
    {
        return ((IEnumerable<object>)element.XPathEvaluate(xPath)).OfType<XAttribute>().First();
        
    }
}
public static class xtattribs
{
    public static Dictionary<string, string> XElementAttributes(this XElement element, string xpath)
    {
        XElement x = element.XPathSelectElement(xpath);
        
        if(x == null ) { return null; };
        List<Dictionary<string,string>> l= new List<Dictionary<string,string>>();
        Dictionary<string, string> dict;
       
            dict = x.Attributes().ToDictionary(k => k.Name.ToString(), k => k.Value);
            
                
        return dict;
    }
}


