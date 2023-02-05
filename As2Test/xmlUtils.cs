using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace As2Test
{
    class xmlUtils
    {
        public XDocument xd;
        static string _fileName;
        private int myVar;

        public string FileName
        {
            get { return _fileName; }
        }


        public xmlUtils(string xmlfile)
        {
            _fileName = xmlfile;
            xd = XDocument.Load(_fileName);

        }
        public static string elementAxisOfXpath(String xpathWithAttribute, out string attribute)
        {
            string[] strings = xpathWithAttribute.Split("/@", StringSplitOptions.RemoveEmptyEntries);
            string s = "";
            for (int i = 0; i < strings.Length - 1; i++)
            {
                s += strings[i];
                s += i < strings.Length - 2 ? "@" : "";
            }
            attribute = strings[1];
            return s.TrimEnd('/');
        }
        private void setAttribute(string xpath, string value)
        {
            string a = "";
            string sXpathElement = elementAxisOfXpath(xpath, out a);
            XElement xe = xd.XPathSelectElement(sXpathElement);
            xe.SetAttributeValue(a, value);
        }
        public void setXpathContent(string xpath, string v)
        {
            if (xpath.Contains("@"))
            {
                setAttribute(xpath, v);
                return;
            }
            XElement xe = xd.XPathSelectElement(xpath);

            xd.XPathSelectElement(xpath).Value = v;
        }

        public void Save()
        {
            xd.Save(_fileName);
        }



    }
    class XPNav
    {
        XPathNavigator nav;
        XmlDocument docNav = new XmlDocument();
        XPathExpression expr;
        XPathNodeIterator ni;
        readonly string _filename = "";
        public string FileName
        {
            get { return _filename; }
        }
        private void Log(string msg, [CallerLineNumber] int ln = 0, [CallerMemberName] string mn = "", [CallerFilePath] string fp = "")
        {

            var sf = new StackTrace().GetFrame(2);
            Debug.WriteLine($"{ln}:{mn}:{msg}:\t {fp}");
            Debug.WriteLine("-".PadRight(80, '='));

        }
        public XPNav(string fileName)
        {
            Trace.Listeners.RemoveAt(0);
            DefaultTraceListener dlistner = new DefaultTraceListener();
            Trace.Listeners.Add(dlistner);
            _filename = fileName;
            docNav.Load(fileName);
            nav = docNav.CreateNavigator();
            nav.MoveToRoot();
            Log($"_filename= {_filename}");
        }
        public XPathNavigator Root {
            get {  nav.MoveToRoot();
                return nav;
                } }
        public XPathNodeIterator IteratorAtRoot { 
            get {
                nav.MoveToRoot();
                return nav.Select("//."); }
        }
        public XPathNodeIterator GetIteratorAt(string xpath)
        {
            try
            {
                expr = nav.Compile(xpath); return nav.Select(expr);
            }
            catch (Exception ex)
            {
                Log($"{ex.Message}\n{ex.StackTrace}"); return null;
            }
        }
        public XPathNavigator GetNavigatorForNewElement(string xpath, out string sElementname)
        {
            string[] p = xpath.Split("/", StringSplitOptions.RemoveEmptyEntries);
            sElementname = p[p.Length - 1];
            foreach (string s in p) nav.MoveToChild(s, "");
            return nav;
        }
        public void SetXpathContent(string xpath, string value)
        {
            ni = GetIteratorAt(xpath);
            while (ni.MoveNext())
            {
                try
                {
                    ni.Current.SetValue(value); Log(ni.Current.ToString());
                }
                catch (Exception ex)
                {
                    Log($"{ex.Message}\n{ex.StackTrace}"); throw ex;
                }
            }
        }
        public void AddOrReplaceAfter(string xpath, string value)
        {
            string newElement;
            XmlWriter nElment = GetNavigatorForNewElement(xpath, out newElement).AppendChild();
            nElment.WriteElementString(newElement, value);
            nElment.Close();
        }
        public string OuterXml()
        {
            return docNav.OuterXml;
        }
        public void Save()
        {
            docNav.Save(_filename);
        }

        /// <summary>
        /// deleteIfExist is the XPath axis located in the parenfile xml
        /// </summary>
        /// <param name="parentfilePath"></param>
        /// <param name="deleteIfExist"></param>
        /// <param name="autoSave"></param>
        /// <returns>PARNTERSHIPS outerXml </returns>
        public string MergeToParentDocument(string parentfilePath,string deleteIfExist,bool autoSave=true)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(parentfilePath);
            XmlNodeList deletenodes=  doc.SelectNodes(deleteIfExist);
            if (deletenodes.Count > 0)  deletenodes[0].ParentNode.RemoveChild(deletenodes[0]);
            XmlDocumentFragment documentFragment = doc.CreateDocumentFragment();
            documentFragment.InnerXml = OuterXml();// outerxml() is the this instances outerxml which is the child of parentfile
            doc.DocumentElement.AppendChild(documentFragment);
            if (autoSave) doc.Save(parentfilePath);
            return doc.OuterXml;
        }
    }
}
