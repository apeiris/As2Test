using Org.BouncyCastle.Crmf;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Tls;
using RestSharp.Serializers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Net.NetworkInformation;

namespace As2Test
{
    public enum implementaionFlavour
    {
        IBMSterling = 0,
        IBMDataPower = 1,
        Mendelson = 2,
        Seeburger = 3,
        OracleB2B = 4,
        Amazon = 5,
        OpenAS2
    }
    public partial class frmPartnership : Form
    {

        string[] partners = null;
        string[] partnerships = null;
        static bool uiShown = false;
        XDocument partnershipXDoc = null;
        static Dictionary<string, string> pnlFieldsVars = new Dictionary<string, string>();
        static TableLayoutPanel container;


        public frmPartnership(ref XDocument partnershipsXDoc, ref List<string> partnerList, ref List<string> partnershipList, string nodeSelectorName)
        {
            InitializeComponent();
            this.partnershipXDoc = partnershipsXDoc;
            partners = new string[partnerList.Count]; partnerList.CopyTo(partners);
            partnerships = new string[partnershipList.Count];

            partnershipList.CopyTo(partnerships);


            cmbPartnershipSender.DataSource = partnerList;
            cmbPartnershipReceiver.DataSource = partners;
            cmbPartnershipSender.SelectedIndex = 0;
            cmbPartnershipReceiver.SelectedIndex = 1;
        }
        static void setupDynamicControls(object sender, string ps)
        {
            var a = Assembly.GetExecutingAssembly();
            string resname = $"{a.GetName().Name}.Resources.controlsfrmPartnerships.xml";
            var d = XDocument.Load(a.GetManifestResourceStream(resname));
            var cn = d.Root.Attribute("panel").Value; //container name where elements are added
            var container = (Control)sender;
            IEnumerable<XElement> children =
                from e in d.XPathSelectElements("//c") // all rows 
                select e;
            int row = 0;
            int col = 0;
            int rowCount = children.Count();
            string controlXpath = "";
            Control p = container.Controls[0];
            foreach (XElement child in children)
            {
                col = col % 2;
                controlXpath = $"//c[@r={row}][@c={col}]";

                Dictionary<string, string> cdic = xtattribs.XElementAttributes(child, controlXpath);
                if ((col % 2) == 1) { row++; };
                col++;
                if (cdic != null)
                    addControl(container, cn, cdic, sender, p);
            }

        }

        private static void addControl(Control parentControls, string containerName, Dictionary<string, string> ctlDef, object sender, object p)
        {
            container = (TableLayoutPanel)parentControls.Controls.Find(containerName, true).FirstOrDefault();
            container.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            container.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            container.ControlAdded += dynaControlAdded;
            string sControlType = ctlDef["t"].ToLower();
            ctlDef.Remove(sControlType);

            int col = int.Parse(ctlDef["c"]);
            int row = int.Parse(ctlDef["r"]);
            var control = new Control(); //  dictControls[sControlType];
            switch (sControlType)
            {
                case "label":
                    control = (Label)new Label();
                    if (ctlDef.ContainsKey("a"))
                        switch (ctlDef["a"])
                        {
                            case "r": ((Label)control).TextAlign = System.Drawing.ContentAlignment.MiddleLeft; break;
                            default:
                                ((Label)control).TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                                ((Label)control).AutoSize = true;
                                ((Label)control).Dock = DockStyle.Fill;
                                ((Label)control).MaximumSize = new Size(1000, 30);
                                break;
                        }
                    break;
                case "textbox":
                    control = (TextBox)new TextBox();
                    ((TextBox)control).AutoSize = true;
                    if (ctlDef.ContainsKey("l")) ((TextBox)control).Size = new Size(int.Parse(ctlDef["l"]), 30);
                    ((TextBox)control).TextAlign = HorizontalAlignment.Left;
                    ((TextBox)control).PlaceholderText = ctlDef["text"]; break;
                default: break;
            }
            if (ctlDef.ContainsKey("a"))
                switch (ctlDef["a"].ToLower())
                {
                    case "r": control.Anchor = AnchorStyles.Right; break;
                    default: control.Anchor = AnchorStyles.Left; break;
                }
            if (ctlDef.ContainsKey("f"))//  font
            {
                Font f = new Font(control.Font, FontStyle.Regular);
                string sw = ctlDef["f"].ToLower().Trim(' ')[0].ToString();
                switch (sw)
                {
                    case "b":
                        control.Font = new Font(control.Font, FontStyle.Bold);
                        break;
                    // MessageBox.Show(ctlDef["f"][0].ToString());
                    case "{":
                        /*
                         * 
                         *  {style=b,fcolor=red,size=20}
                         *  
                         *  
                         */
                        // Dictionary<string, string> fa = ctlDef["f"].Split(new char[] { '{', '}', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        //       .ToDictionary(str => str.Split(new char[] { '=', })[0], str => str.Split(new char[] { '=' })[1]);

                        Dictionary<string, string> fa = ctlDef["f"].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries).

                            ToDictionary(str => str.Split(new char[] { '=' })[0], str => str.Split(new char[] { '=' })[1]);



                        string s = control.Font.ToString();
                        foreach (KeyValuePair<string, string> kvp in fa)
                            switch (kvp.Key)
                            {
                                case "style" when kvp.Value == "b" || kvp.Value == "bold":
                                    var fontStyle = (FontStyle)Enum.Parse((typeof(FontStyle)), "Bold");
                                    control.Font = new Font(control.Font, fontStyle);

                                    break;
                                case "style" when kvp.Value == "italic":
                                    control.Font = new Font(control.Font, FontStyle.Italic);
                                    break;
                                case "fcolor" when kvp.Value != string.Empty:
                                    control.ForeColor = Color.FromName(kvp.Value);
                                    break;
                                case "size" when kvp.Value != string.Empty:
                                    control.Font = new Font(control.Font.Name, float.Parse(kvp.Value));
                                    break;
                            }
                        break;

                    default: break;
                }



            }
            if (ctlDef.ContainsKey("text"))
            {
                if (ctlDef["text"].Contains("${"))
                {
                    pnlFieldsVars.Add(ctlDef["text"].Split(new char[] { '$', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)[0], $"{ctlDef["r"]}:{ctlDef["c"]}");

                };
            }

            control.Text = ctlDef["text"];
            add_toContainer(container, col, row, control);
            container.ControlAdded -= dynaControlAdded;
        }
        private static void add_toContainer(TableLayoutPanel container, int col, int row, Control control)
        {
            container.SuspendLayout();
            container.AutoSize = true;
            container.Controls.Add(control, col, row);

            container.ResumeLayout();

        }
        private static void dynaControlAdded(object sender, ControlEventArgs e)
        {
            var x = (TableLayoutPanel)sender;
            e.Control.Visible = true;
            TableLayoutPanelCellPosition p = x.GetPositionFromControl(e.Control);
            Debug.WriteLine($"@dynC rcount= {x.RowCount}[{e.Control.GetType().Name}:text= {e.Control.Text} cCxR {p.Column},{p.Row}");

        }
        private void frmPartnership_Load(object sender, EventArgs e)
        {
            cmbPartnershipFlavor.SelectedIndex = 0;

            setupDynamicControls(sender, lblPartnership.Text);



        }
        private void setPartnershipLabel(string From, string To)
        {
            lblPartnership.Text = From + "-to-" + To;

        }
        private void cmbPartnershipSender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!uiShown) return;
            ComboBox x = (ComboBox)sender;
            if (x.SelectedItem != null)
            {
                if (cmbPartnershipReceiver.SelectedIndex == x.SelectedIndex)
                {
                    MessageBox.Show($"Sender and the receiver can not be the same..");
                    return;
                }
                if (pnlFieldsVars.ContainsKey(x.Name)) { setVariable(x); }
                setPartnershipLabel(x.Text, cmbPartnershipReceiver.Text);
            }
        }
        private static void setVariable(ComboBox x)
        {
            string[] xy = pnlFieldsVars[x.Name].Split(':', StringSplitOptions.RemoveEmptyEntries);
            container.GetControlFromPosition(int.Parse(xy[1]), int.Parse(xy[0])).Text = x.Text;
        }
        private void cmbPartnershipReceiver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!uiShown) return;
            ComboBox x = (ComboBox)sender;
            if (x.SelectedItem != null)
            {
                if (cmbPartnershipSender.SelectedIndex == x.SelectedIndex)
                {
                    MessageBox.Show($"Receiver and the Sender can not be the same..");
                    return;
                }
                if (pnlFieldsVars.ContainsKey(x.Name)) { setVariable(x); }
            }

        }
        private void frmPartnership_Shown(object sender, EventArgs e)
        {
            uiShown = true;
            setPartnershipLabel(cmbPartnershipSender.Text, cmbPartnershipReceiver.Text);
            cmbPartnershipSender_SelectedIndexChanged(cmbPartnershipSender, null);
            cmbPartnershipReceiver_SelectedIndexChanged(cmbPartnershipReceiver, null);

        }
        private bool isExistingPartnership(string partnership)
        {
            return partnerships.Contains<string>(partnership);
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (isExistingPartnership(lblPartnership.Text))
            {
                MessageBox.Show($"Can not add..partnership {lblPartnership.Text} exist", "Exisiting Partnership");
                return;
            }
;
        }
        private void chkPollerConfig_CheckedChanged(object sender, EventArgs e)
        {
            //  chkPollerConfig.Text = chkPollerConfig.Checked ? "Yes" : "No";
        }
        private XDocument getPartnershipTemplate()
        {
            XDocument doc = XDocument.Load("partnershipTemplate.xml");

            return doc;
        }
        private void CreatePartnership(string partnershipName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(partnership));
            partnership ps = new partnership();
            ps.name = partnershipName;
            var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
            TextWriter writer = new StreamWriter(partnershipName + ".xml");
            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using (var stringWriter = new StringWriter())
            {
                using (var xmlw = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(xmlw, ps, ns);

                    string s = stringWriter.ToString();
                    Debug.WriteLine($"xmlw.ToString():{s}");
                }
            }
            writer.Close();

            XDocument doc = getPartnershipTemplate();
            var xe = doc.XPathSelectElement("//partnership"); // the template has only one partnershio get that
            xe.SetAttributeValue("name", partnershipName);

            string[] partners = partnershipName.Split("-to-", StringSplitOptions.RemoveEmptyEntries);
            xe = doc.XPathSelectElement("//partnership/sender");
            xe.SetAttributeValue("name", partners[0]); //sender  (from)

            xe = doc.XPathSelectElement("//partnership/receiver");
            xe.SetAttributeValue("name", partners[1]); // 

        }
        private void setPartnerAttribute(string attributeName, string attrbuteValue, string partner)
        {
            string xp = $"//partner[@name='{partner}']";
            XElement xe = this.partnershipXDoc.XPathSelectElement(xp);
            xe.SetAttributeValue(attributeName, attrbuteValue);
        }
        private void removePartnershipAttribute(string attributeName, string partnership)
        {

            string xp = $"//partnership[@name='{partnership}']/attribute[@name='{attributeName}']";
            this.partnershipXDoc.XPathSelectElement(xp).Remove();
        }
        private void btnSavePartnership_Click(object sender, EventArgs e)
        {
            /*                             | Partner:          |Partner:               |
             *                             | prevent_          |remove_cms_            |
             *                             | canonicalization_ |algorithm_             |
             *                             | for_mic           |protection_attrib      |
             * ----------------------------+-------------------+-----------------------+                      
               (0) IBM Sterling            | x                 |                       |
            -------------------------------+-------------------+-----------------------+
               (1) IBM Datapower           | x                 |    
            -------------------------------+-------------------+---------------
               (2) Mendelson               | true              |
            -------------------------------+-------------------+---------------------------------------------------------------
               (3) SeeBurger(older Versions|                   | add partner attribue:
                                           |                   | <attribute name="rename_digest_to_old_name" value="true" />
            -------------------------------+-------------------+-----------------------------------------------------------
               (4) Oracle B2B              | false             | 
            */
            //  XElement xe = new XElement(this.partnershipXDoc);
            //XElement.Parse()

            string s = this.partnershipXDoc.ToString();
       //     webView21.AllowExternalDrop = true;

            Uri x = new Uri("file:///C:/Users/mapei/source/repos/As2Test/As2Test/bin/Debug/netcoreapp3.1/emptyPartnership.xml");


         //   webView21.Source = x;

            switch (cmbPartnershipFlavor.SelectedIndex)
            {

                case (int)implementaionFlavour.IBMDataPower:
                case (int)implementaionFlavour.IBMSterling:
                    setPartnerAttribute("remove_cms_algorithm_protection_attrib", "true", cmbPartnershipReceiver.Text);
                    break;
                case (int)implementaionFlavour.Mendelson:
                    setPartnerAttribute("prevent_canonicalization_for_mic", "true", cmbPartnershipReceiver.Text);
                    break;
                case (int)implementaionFlavour.Seeburger:
                    setPartnerAttribute("rename_digest_to_old_name", "true", cmbPartnershipReceiver.Text);
                    break;
                case (int)implementaionFlavour.OracleB2B:
                    setPartnerAttribute("prevent_canonicalization_for_mic", "false", cmbPartnershipReceiver.Text);
                    setPartnerAttribute("remove_cms_algorithm_protection_attrib", "false", cmbPartnershipReceiver.Text);
                    break;
                case (int)implementaionFlavour.Amazon:
                    removePartnershipAttribute("compression_type", cmbPartnershipReceiver.Text);
                    break;
                default:
                    break;
            }

            CreatePartnership(lblPartnership.Text);

        }

        private void btnTestJson_Click(object sender, EventArgs e)
        {
            JObject data = JObject.Parse(File.ReadAllText("containerControls.json"));
            List<JToken> cc = data.SelectTokens("controls").Children().ToList();
            Debug.WriteLine($"Count of Controls ={cc.Count()}");
            var control = new Control();
            var parentControl = new Control();
            Font font;
            TableLayoutPanel container = (TableLayoutPanel)this.Controls.Find("tlpDyna1", true).First();
           // DataGridView container = new DataGridView();
            container.Controls.Clear();

            var x = "";
            if (!string.IsNullOrEmpty((string)data.SelectToken("$.container.RowStyle.SizeType")))
            {
                SizeType st = (SizeType)Enum.Parse(typeof(SizeType), (string)data.SelectToken("$.container.RowStyle.SizeType"));
                int rh = int.Parse((string)data.SelectToken("$..RowStyle.Height"));
                TableLayoutRowStyleCollection rstyles = container.RowStyles;
                foreach (RowStyle style in rstyles)
                {
                    style.Height = rh;
                    style.SizeType = st;
                }
            }
            container.ColumnStyles.Clear();
            container.SetColumnSpan(container.Parent,3  );
            List<JToken> columns = data.SelectTokens("$.container.ColumnStyle").Children().ToList();
            int cs = 1;// int.Parse(data.SelectToken("$.container.ColumnSpan").ToString());
            Debug.WriteLine($"{cs} {columns.Count} parent name={container.Parent.Name}parent");
            container.SetColumnSpan(container, 3);
            TableLayoutColumnStyleCollection styles = container.ColumnStyles;
            foreach (JToken colo in columns)
            {
                ColumnStyle style = new ColumnStyle();

                
                styles.Add(new ColumnStyle((SizeType)Enum.Parse(typeof(SizeType), (string)colo.SelectToken("SizeType")), float.Parse((string)colo.SelectToken("Width"))));
                container.ColumnStyles.Add(style);
            }

            int row, col = 0;
            XElement xe = null;
            XDocument pdocTemplate = getPartnershipTemplate();
            foreach (JToken c in cc)
            {
                Debug.WriteLine($"{c.ToString()}\n");
                switch (c.SelectToken("..Type").ToString().ToLower())
                {
                    case "label":
                        control = new Label();
                        break;
                    case "textbox":
                        TextBox tcontrol = new TextBox();

                        if (!string.IsNullOrEmpty((string)c.SelectToken("..Multiline")))
                            tcontrol.Multiline = bool.Parse((string)c.SelectToken("..Multiline"));

                        if (!string.IsNullOrEmpty((string)c.SelectToken("..ScrollBars")))
                        {
                            tcontrol.ScrollBars = (ScrollBars)Enum.Parse(typeof(ScrollBars), (string)c.SelectToken("..ScrollBars"));
                        }
                        //  toolTip1.SetToolTip(tcontrol, null);

                                               
                        break;
                    case "groupbox":
                        parentControl = new GroupBox();
                        x = c.SelectToken("..XPath").ToString();
                        xe = pdocTemplate.XPathSelectElement(x);
                        parentControl.Name = xe.Name.LocalName;
                        break;
                    case "radiobutton":
                        break;
                    case "checkbox":
                        CheckBox ccontrol = new CheckBox();
                       // ccontrol.Text = c.SelectToken("..Text").ToString();
                        x = c.SelectToken("..XPath").ToString();
                       string sxe= utils.elementAxisOfXpath(x);
                        string attribute = x.Replace(sxe, "").TrimStart('/');
                    
                       // ccontrol.Checked = xe.XPathSelectAttribute("@enabled").Value == "true" ? true : false;
                        ccontrol.CheckedChanged += checkBox_CheckedChanged;
                        ccontrol.Tag = c.SelectToken("..StateText");
                        control = ccontrol;
                        checkBox_CheckedChanged(control, null);
                        break;

                    default:
                        break;
                }

                if (c.ToString().Contains("Font"))
                {
                    String? s = (string)c.SelectToken("..Font['Bold']").ToString().ToLower() == "true" ? "Bold" : "Regular";
                    FontStyle fs = (FontStyle)Enum.Parse(typeof(FontStyle), s);
                    font = new Font(c.SelectToken("..Font['Name']").ToString(), float.Parse((string)c.SelectToken("..Font['Size']")), fs);
                    control.Font = font;
                }
                if (!string.IsNullOrEmpty((string)c.SelectToken("..Text"))) control.Text = c.SelectToken("..Text").ToString();
                if (control.Text.Contains("${"))
                {
                    string[] ss = control.Text.Split(new char[] { '$', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                    var cx = this.Controls.Find(ss[0], true);
                    control.Text = cx[0].Text;

                }
                if (control.Text.Contains("xpath{"))
                {
                    string[] ss = control.Text.Split(new string?[] { "xpath{", "}" }, StringSplitOptions.RemoveEmptyEntries);
                    control.Text = ((IEnumerable<object>)pdocTemplate.XPathEvaluate(ss[0]))
                               .OfType<XAttribute>()
                               .Single()
                               .Value;

                }


                string dock = (string)c.SelectToken("..Dock");
                if (!string.IsNullOrEmpty(dock))
                    control.Dock = (DockStyle)Enum.Parse(typeof(DockStyle), dock);

                if (!string.IsNullOrEmpty((string)c.SelectToken("..Width"))) control.Width = (int)c.SelectToken("..Width");

                row = int.Parse(c.SelectToken("..Cell.Row").ToString());
                col = int.Parse(c.SelectToken("..Cell.Column").ToString());
                if (c.ToString().Contains("ToolTip"))
                {
                    if (!string.IsNullOrEmpty((string)c.SelectToken("..ToolTip")))
                    {
                        string xx = (string)c.SelectToken("..ToolTip").ToString();
                        if (xx.Contains("${"))
                        {
                            string ss = xx.Split(new char[] { '$', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower();
                            switch (ss)
                            {
                                case "text":
                                    toolTip1.SetToolTip(control, control.Text);
                                    break;
                            }
                            // toolTip1.SetToolTip(control, (stri
                        }
                    }
                }
                
                container.Controls.Add(control, col, row);
            }
        }

        private void btnGenerateSchema_Click(object sender, EventArgs e)
        {
            JObject data = JObject.Parse(File.ReadAllText("containerControls.json"));



        }


        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!uiShown) return;
            CheckBox c = (CheckBox)sender;
            string[] st = c.Tag.ToString().Split(new char[] { ':', ',' });
            c.Text = c.Checked ? st[0] : st[1];
            c.ForeColor = c.Checked ? Color.Green : Color.Brown;
            c.Refresh();
        }

    }
    [XmlRootAttribute("partnership", Namespace = null, IsNullable = false)]
    public class partnership
    {
        [XmlAttribute("name")]
        public string name;

    }
}
