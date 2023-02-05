using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace As2Test
{

    public static class XmlDocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
        private static void Log(string msg, [CallerLineNumber] int ln = 0, [CallerMemberName] string mn = "", [CallerFilePath] string fp = "")
        {
            var sf = new StackTrace().GetFrame(2);
            string[] fn = fp.Split("\\", StringSplitOptions.RemoveEmptyEntries);
            Debug.WriteLine($"{msg}:\t{ln}:{fn[fn.Length - 1]}");
            Debug.WriteLine("-".PadRight(80, '='));
        }
        public static XDocument MergeXml(this XDocument xd1, XDocument xd2)
        {
            return new XDocument(
                new XElement(xd2.Root.Name,
                    xd2.Root.Attributes()
                        .Concat(xd1.Root.Attributes())
                        .GroupBy(g => g.Name)
                        .Select(s => s.First()),
                    xd2.Root.Elements()
                        .Concat(xd1.Root.Elements())
                        .GroupBy(g => g.Name)
                        .Select(s => s.First())));
        }
        public static void IterateThroughAllNodes(  this XmlDocument doc,       Action<XmlNode> elementVisitor)
        {
            if (doc != null && elementVisitor != null)
            {
                foreach (XmlNode node in doc.ChildNodes)
                {
                    doIterateNode(node, elementVisitor);
                }
            }
        }

        private static void doIterateNode(  XmlNode node,          Action<XmlNode> elementVisitor)
        {
            elementVisitor(node);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                Log($"child{childNode.NodeType}");
                
                doIterateNode(childNode, elementVisitor);
            }
        }
    }

}
