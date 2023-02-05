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
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Net.NetworkInformation;
using As2Test.Properties;

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
        static JObject data = JObject.Parse(File.ReadAllText("containerControls.json"));
        string[] partners = null;
        string[] partnerships = null;
        static bool uiShown = false;
        XmlDocument partnershipXDoc = null;
        static Dictionary<string, Control> containerLinkedControls = new Dictionary<string, Control>();

        public frmPartnership(ref XmlDocument partnershipsXDoc, ref List<string> partnerList, ref List<string> partnershipList, string nodeSelectorName)
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
        private void frmPartnership_Load(object sender, EventArgs e)
        {
            cmbPartnershipFlavor.SelectedIndex = 0;       
            LoadJSON();
        }
        private void setPartnershipLabel(string From, string To)
        {
            lblPartnership.Text = From + "-to-" + To;

        }
        private void cmbPartnershipSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!uiShown) return;
            ComboBox x = (ComboBox)sender;
            if (x.SelectedItem != null)

            {
                if (containerLinkedControls.ContainsKey(x.Name))
                {
                    containerLinkedControls[x.Name].Text = x.Text;
                    setPartnershipLabel(cmbPartnershipSender.Text, cmbPartnershipReceiver.Text);
                }
            }
        }
        private void frmPartnership_Shown(object sender, EventArgs e)
        {
            uiShown = true;
            setPartnershipLabel(cmbPartnershipSender.Text, cmbPartnershipReceiver.Text);
            cmbPartnershipSelectedIndexChanged(cmbPartnershipSender, null);
            cmbPartnershipSelectedIndexChanged(cmbPartnershipReceiver, null);
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
        private XmlDocument getPartnershipTemplate()
        {
            XmlDocument doc = new XmlDocument(); doc.Load("partnershipTemplate.xml");
            return doc;
        }
        private void setPartnerAttribute(string attributeName, string attrbuteValue, string partner)
        {
            string xp = $"//partner[@name='{partner}']";

            XmlNode xn = this.partnershipXDoc.SelectSingleNode(xp);

            //xe.SetAttributeValue(attributeName, attrbuteValue);
        }
        private void removePartnershipAttribute(string attributeName, string partnership)
        {

            string xp = $"//partnership[@name='{partnership}']/attribute[@name='{attributeName}']";
            XmlNode xn = this.partnershipXDoc.SelectSingleNode(xp);
            xn.RemoveAll();

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
            // CreatePartnership(lblPartnership.Text);
        }
        private static List<JToken> ListJsonCControls()
        {
            return data.SelectTokens("controls").Children().ToList();
        }
        private void LoadJSON()
        {
            List<JToken> cc = ListJsonCControls();
            Debug.WriteLine($"Count of Controls ={cc.Count()}");
            var control = new Control();
            var parentControl = new Control();
            Font font;
            TableLayoutPanel container = (TableLayoutPanel)this.Controls.Find("tlpDyna1", true).First();
            container.SetColumnSpan(container.Parent, 3);
            container.Width = 900;
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
            container.SetColumnSpan(container.Parent, 3);
            List<JToken> columns = data.SelectTokens("$.container.ColumnStyle").Children().ToList();
            int cs = 1;// int.Parse(data.SelectToken("$.container.ColumnSpan").ToString());
                       //   Debug.WriteLine($"{cs} {columns.Count} parent name={container.Parent.Name}parent");
            container.SetColumnSpan(container, 3);
            TableLayoutColumnStyleCollection styles = container.ColumnStyles;
            foreach (JToken colo in columns)
            {
                ColumnStyle style = new ColumnStyle();
                styles.Add(new ColumnStyle((SizeType)Enum.Parse(typeof(SizeType), (string)colo.SelectToken("SizeType")), float.Parse((string)colo.SelectToken("Width"))));
                container.ColumnStyles.Add(style);
                // Debug.WriteLine($"Column type={style.SizeType.ToString()},width={style.Width}");
            }
            int row, col = 0;
            XmlElement xe = null;
            XmlDocument pdocTemplate = getPartnershipTemplate();
            foreach (JToken c in cc)
            {
                Debug.WriteLine($"{c.ToString()}\n");
                switch (c.SelectToken("..Type").ToString().ToLower())
                {
                    case "checkbox":
                        CheckBox ccontrol = new CheckBox();
                        // ccontrol.Text = c.SelectToken("..Text").ToString();
                        x = c.SelectToken("..XPath").ToString();
                        string sxe = utils.elementAxisOfXpath(x);
                        string attribute = x.Replace(sxe, "").TrimStart('/');

                        // ccontrol.Checked = xe.XPathSelectAttribute("@enabled").Value == "true" ? true : false;
                        ccontrol.CheckedChanged += checkBox_CheckedChanged;
                        ccontrol.Tag = c.SelectToken("..StateText");
                        control = ccontrol;
                        checkBox_CheckedChanged(control, null);
                        break;
                    case "combobox":
                        ComboBox cbx = new ComboBox();
                        object[] xx = c.SelectToken("..Items").ToString().Split(new char[] { '\"', ' ', ',', '\r', '\n', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                        cbx.Items.Clear();
                        cbx.Items.AddRange(xx);
                        cbx.Width = 100;
                        control = cbx;
                        break;
                    case "label":
                        control = new Label();
                        string xc = c.SelectToken("..Text").ToString();
                        if (xc.Contains("${"))
                        {
                            string[] ss = xc.Split(new char[] { '$', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                            if (!containerLinkedControls.ContainsKey(ss[0]))
                                containerLinkedControls.Add(ss[0], control);
                        }
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
                        control = tcontrol;

                        break;
                    case "groupbox":
                        parentControl = new GroupBox();
                        x = c.SelectToken("..XPath").ToString();
                        XmlNode xn = pdocTemplate.SelectSingleNode(x);
                        parentControl.Name = xn.LocalName;
                        break;
                    case "radiobutton":
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
                    //control.Text = ((IEnumerable<object>)pdocTemplate.XPathEvaluate(ss[0]))
                    //           .OfType<XAttribute>()
                    //           .Single()
                    //           .Value;
                    control.Text = pdocTemplate.SelectSingleNode(ss[0]).Value;

                }
                if (!string.IsNullOrEmpty((string)c.SelectToken("..control.Name"))) control.Name = (string)c.SelectToken("..control.Name");
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
                        }
                        else // tool tip is explicitly defined
                        {
                            toolTip1.SetToolTip(control, xx);
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
            //  if (!uiShown) return;
            CheckBox c = (CheckBox)sender;
            string[] st = c.Tag.ToString().Split(new char[] { ':', ',' });
            c.Text = c.Checked ? st[0] : st[1];
            c.ForeColor = c.Checked ? Color.Green : Color.Brown;
            c.Refresh();
        }
        private void lblPartnershipfile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = Properties.Settings.Default.configPath;
            fb.ShowDialog();
            string fn = "Partnerships.xml";
            string[] files = Directory.GetFiles(fb.SelectedPath, fn);
            if (files.Count() != 1)
            {
                DialogResult result = MessageBox.Show($"There is no {fn} in the selected directory\n There must be one file named {fn}", "", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Cancel) return;
                lblPartnershipfile_Click(null, null);
            }
            else
            {
                Properties.Settings.Default.Save();
            }
        }
        private void Log(string msg, [CallerLineNumber] int ln = 0, [CallerMemberName] string mn = "", [CallerFilePath] string fp = "")
        {
            var sf = new StackTrace().GetFrame(2);
            string[] fn=fp.Split("\\",StringSplitOptions.RemoveEmptyEntries);
            Debug.WriteLine($"{msg}:\t{ln}:{fn[fn.Length-1]}");
            Debug.WriteLine("-".PadRight(80, '='));
        }
        private string GetOuterXml(bool HasChildren,string xml)
        {
            if (HasChildren)
            {
                string[] x=xml.Split(new string[] {"<","/>\r\n",">"},StringSplitOptions.RemoveEmptyEntries);
                return $"<{x[0]}>";
            }
            return xml;
        }
        private void btnUpdatePartnership_Click(object sender, EventArgs e)
        {
            //copy the template as selected partnership 
            string fn = Properties.Settings.Default.configPath + "\\" + lblPartnership.Text + ".xml";
            File.Delete(fn);
            File.Copy("C:\\Users\\mapei\\source\\repos\\As2Test\\As2Test\\partnershipTemplate.xml", fn, true);
            XPNav xPartner = new XPNav(fn);
            xPartner.SetXpathContent("partnership/@name", lblPartnership.Text);
            // update the partner selections and save
            List<JToken> ccTokens = ListJsonCControls();
            int col, row = 0;
            foreach (JToken token in ccTokens)
            {
                if (token.SelectToken("..XPath") != null)
                {
                    col = int.Parse(token.SelectToken("..Cell.Column").ToString());
                    row = int.Parse(token.SelectToken("..Cell.Row").ToString());
                    Control c = tlpDyna1.GetControlFromPosition(col, row);
                    string xPath = token.SelectToken("..XPath").ToString();
                    xPartner.SetXpathContent(xPath, c.Text);

                    Log($"{c.GetType().Name}:R,C={row},{col} : text= {c.Text} : xpath={xPath} : {c.GetType().Name} ");
                }
            }
            xPartner.Save();
           string s1=xPartner.MergeToParentDocument(parentfilePath:Settings.Default.configPath+"//partnerships.xml",deleteIfExist: $"//partnerships/partnership[@name='{lblPartnership.Text}']",autoSave: true);
        }
    }

}
