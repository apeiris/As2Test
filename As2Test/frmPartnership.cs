using Org.BouncyCastle.Crmf;
using Org.BouncyCastle.Tls;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

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
        XDocument partnershipXDoc= null;
        public frmPartnership(ref XDocument partnershipsXDoc, ref List<string> partnerList, ref List<string> partnershipList, string nodeSelectorName)
        {
            InitializeComponent();
            this.partnershipXDoc= partnershipsXDoc;
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
        }
        private void setPartnership(string From, string To)
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
                setPartnership(x.Text, cmbPartnershipReceiver.Text);
            }
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

                setPartnership(cmbPartnershipSender.Text, x.Text);

            }

        }
        private void frmPartnership_Shown(object sender, EventArgs e)
        {
            uiShown = true;
            setPartnership(cmbPartnershipSender.Text, cmbPartnershipReceiver.Text);
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
        private void CreatePartnership(string name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(partnership));
            partnership ps = new partnership();
            ps.name = name;
            var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
            TextWriter writer = new StreamWriter(name + ".xml");
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
        }


        private void setPartnerAttribute(string attributeName,string attrbuteValue, string partner)
        {
            string xp = $"//partner[@name='{partner}']";
            XElement xe = this.partnershipXDoc.XPathSelectElement(xp);
            xe.SetAttributeValue(attributeName, attrbuteValue);
       }
        private void removePartnershipAttribute(string attributeName, string partnership) {

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
            webView21.AllowExternalDrop = true;
           
           Uri x = new Uri("file:///C:/Users/mapei/source/repos/As2Test/As2Test/bin/Debug/netcoreapp3.1/emptyPartnership.xml");
         //   webView21.NavigateToString(x);

            webView21.Source=x;

            switch (cmbPartnershipFlavor.SelectedIndex)
            {
                
                case (int)implementaionFlavour.IBMDataPower:
                case (int)implementaionFlavour.IBMSterling:
                    setPartnerAttribute("remove_cms_algorithm_protection_attrib","true", cmbPartnershipReceiver.Text);
                    break;
                case (int)implementaionFlavour.Mendelson:
                    setPartnerAttribute("prevent_canonicalization_for_mic","true", cmbPartnershipReceiver.Text);
                    break;
                case (int)implementaionFlavour.Seeburger:
                    setPartnerAttribute("rename_digest_to_old_name","true", cmbPartnershipReceiver.Text);
                    break;
                case (int)implementaionFlavour.OracleB2B:
                    setPartnerAttribute("prevent_canonicalization_for_mic", "false", cmbPartnershipReceiver.Text);
                    setPartnerAttribute("remove_cms_algorithm_protection_attrib", "false", cmbPartnershipReceiver.Text);
                    break;
                case (int)implementaionFlavour.Amazon:
                    removePartnershipAttribute("compression_type",cmbPartnershipReceiver.Text);
                    break;
                default:
                    break;
            }

            CreatePartnership(lblPartnership.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    [XmlRootAttribute("partnership", Namespace = null, IsNullable = false)]
    public class partnership
    {
        [XmlAttribute("name")]
        public string name;

    }
}
