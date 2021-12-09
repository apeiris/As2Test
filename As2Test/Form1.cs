using System;
using System.Diagnostics;
using System.IO;

using System.ServiceProcess;
using System.Windows.Forms;
using System.Management;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.XPath;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace As2Test
{
    public partial class Form1 : Form
    {
        IPAddress partner;
        public enum tabs
        {
            tbpSendRcv = 0,
            tbpPartners = 1,
            tbpLog = 2
        }
        public static FileSystemWatcher fsw = null;
        System.Threading.CancellationToken ct;
        RestClient rClient = new RestClient("http://localhost:8443")
        {
            Authenticator = new HttpBasicAuthenticator("userID", "pWd")
        };
        const string receipientCertFile = "";
        public static string AS2homePath = "";
        public static string AS2configPath = "";
        public static DataTable partnerFromTable = null;
        public static DataTable partnerToTable = null;
        private static bool uiShown = false;
        public static byte[] baEncrypted = null;
        static int logCounter = 0;
        Dictionary<string, string> partnerDic = null;
        List<string> partnershipsList = null;
        List<string> partnersList = null;
        XDocument partnshipXDocument = null;
        public Form1()
        {
            InitializeComponent();
        }
        enum logState
        {
            error,
            warn,
            debug,
            trace,
            info,
            verbose
        }
        private DataTable SelectFromDb(string stmt)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlSever);
            DataTable dt;
            using (SqlCommand cmd = con.CreateCommand())
            {
                if (con.State != System.Data.ConnectionState.Open) con.Open();
                cmd.CommandText = stmt;
                dt = cmd.ExecuteDataTable();


            }
            return dt;
        }
        private void setConfigPath()
        {
            ServiceController sc = new ServiceController(Properties.Settings.Default.ServiceName);
            using (ManagementObject wmiS = new ManagementObject("Win32_Service.Name='" + Properties.Settings.Default.ServiceName + "'"))
            {
                wmiS.Get();
                AS2homePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(wmiS["PathName"].ToString()))).Split("\\bin")[0];
                string configFileName = AS2homePath + "\\" + Properties.Settings.Default.configFilename;
                AS2configPath = AS2homePath + "\\config";

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {



            setConfigPath();
            lblKeyStore.Text = Properties.Settings.Default.keyStoreFile;
            lblEDIFilePath.Text = Properties.Settings.Default.x12FileName;
            if (File.Exists(lblEDIFilePath.Text)) txtEDI.Text = File.ReadAllText(lblEDIFilePath.Text);
            partnerFromTable = SelectFromDb("select * from dbo.ftPartners();");
            partnerToTable = SelectFromDb("select * from dbo.ftPartners();");
            string fName = getPartnershipFilename();
            partnshipXDocument = XDocument.Load(fName); 
            lbxPartnerFrom.DisplayMember = lbxPartnerTo.DisplayMember = "Name";
            lbxPartnerFrom.DataSource = partnerFromTable;
            lbxPartnerFrom.SetSelected(lbxPartnerFrom.FindString(Properties.Settings.Default.sender), true);
            lbxPartnerTo.DataSource = partnerToTable;
            lbxPartnerTo.SetSelected(lbxPartnerTo.FindString(Properties.Settings.Default.receiver), true);

            Debug.WriteLine($"properties.defaul Sender ={Properties.Settings.Default.sender} recever={Properties.Settings.Default.receiver}");
            tabControl1.SelectedIndex = (int)tabs.tbpPartners;
           
          


        }
        private string _editext;
        string editext { get { return _editext; } set { _editext = value; } }
        public virtual void setEDIText(String s)
        {

            if (txtEDI.InvokeRequired)
                txtEDI.Invoke(new Action(() => txtEDI.Text = s));
            else
            {
                txtEDI.Text = s;
            }
        }
        private static void OnError(object sender, ErrorEventArgs e) => PrintException(e.GetException());
        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Debug.WriteLine($"Message: {ex.Message} ");
                Debug.WriteLine("Stacktrace:");
                Debug.WriteLine(ex.StackTrace);

                PrintException(ex.InnerException);
            }
        }
        private void lblEDIFilePath_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Properties.Settings.Default.x12FileName;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.x12FileName = dialog.FileName;
                    lblEDIFilePath.Text = dialog.FileName;
                    txtEDI.Text = File.ReadAllText(lblEDIFilePath.Text);
                    Properties.Settings.Default.Save();
                }
            }
        }
        private void btnSendFile(object sender, EventArgs e)
        {
            txtEDI.Text = "";
            byte[] byteArray;
            // string fname = @"C:\data\EDI\MyComapny_OID-PartnerA_OID-OrderID-745634.edi";
            string fname = lblEDIFilePath.Text;
            using (FileStream SourceStream = File.Open(fname, FileMode.Open))
            {
                byteArray = new byte[SourceStream.Length];
                SourceStream.Read(byteArray, 0, (int)SourceStream.Length);
                //await SourceStream.ReadAsync(byteArray, 0, (int)SourceStream.Length);
            }


            ProxySettings proxy = new ProxySettings();
            Uri uri = new Uri("http://localhost:10080");



            AS2 as2 = new AS2(Properties.Settings.Default.keyStoreFile, Properties.Settings.Default.CertStorePassword);

        }
        private void lblEDIFilePath_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(lblEDIFilePath, "Click to change file..");
        }
        private string GetCertficateFilePathName()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = AS2configPath;
                dialog.Filter = "certificate files|*.pkcs;*.jks;*.cer;*.cert;*.p12;*.pub";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
                return null;
            }
        }
        private void lblCertificate_MouseEnter(object sender, EventArgs e)
        {

            toolTip1.SetToolTip(lblKeyStore, $"Select certificate from {AS2configPath} to sign the X12 payload..,Left click to add one..");

        }
        private void lblKeystoreFile_click(object sender, EventArgs e)
        {
            string keyStorefile = GetCertficateFilePathName();

            if (keyStorefile == null) return;
            lblKeyStore.Text = keyStorefile;



            Debug.WriteLine($"selected keystore={keyStorefile}");

            Properties.Settings.Default.keyStoreFile = keyStorefile;
            Properties.Settings.Default.Save();
            Debug.WriteLine($"selected keystore={keyStorefile}");

        }
        private void lbxPartnerFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!uiShown) return;
            Debug.WriteLine($"From and to {lbxPartnerFrom.Text}" + ":" + $"{lbxPartnerTo.Text}");
            if (lbxPartnerTo.Text == lbxPartnerFrom.Text)
            {
                MessageBox.Show("The Sender and the Receiver can not be same.. ");
                return;
            }
            Properties.Settings.Default.sender = lbxPartnerFrom.Text;
            Properties.Settings.Default.Save();
        }
        private void lbxPartnerTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!uiShown) return;
            Debug.WriteLine($"From and to {lbxPartnerFrom.Text}" + ":" + $"{lbxPartnerTo.Text}");
            if (lbxPartnerTo.Text == lbxPartnerFrom.Text)
            {
                MessageBox.Show("The Sender and the Receiver can not be same.. ");
                return;
            }

            Properties.Settings.Default.receiver = lbxPartnerTo.Text;
            Properties.Settings.Default.Save();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            uiShown = true;
        }
        private void Log(logState state, string msg)
        {
            logCounter++;
            string s = "";
            state.ToString();
            lbxLog.Items.Add($"{logCounter.ToString()}:{state.ToString()}:{msg}");
        }
        private void btnSendFile_Click(object sender, EventArgs e)
        {


            AS2 as2 = new AS2(Properties.Settings.Default.keyStoreFile, Properties.Settings.Default.CertStorePassword);

            byte[] baData = Encoding.ASCII.GetBytes(txtEDI.Text.ToCharArray());
            ProxySettings proxySettings = new ProxySettings();
            Uri uri = new Uri("http://localhost:10080");
            HttpStatusCode status = as2.SendFile(uri, lblEDIFilePath.Text, baData, lbxPartnerFrom.Text, lbxPartnerTo.Text, proxySettings, 200);
            if (status != HttpStatusCode.OK)
            {
                //throw new Exception($"could not send the file{lblEDIFilePath.Text}");
                Log(logState.error, $"Sending from {lbxPartnerFrom.Text} to {lbxPartnerTo.Text} could not be accomplished.. see the log.. {lblEDIFilePath.Text}");
                return;
            }
            Log(logState.info, $" {lbxPartnerFrom.Text}-{lbxPartnerTo.Text} was sent successfully..");

        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {

        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            /*
            string storefname = Properties.Settings.Default.keyStoreFile;
            string storePass = Properties.Settings.Default.CertStorePassword;
            X509Certificate2? cert = AS2MIMEUtilities.GetCertificateFromStore(storefname, storePass, lbxPartnerTo.Text.ToLower());
            // var x=cert.GetRSAPrivateKey();
            // RSAParameters rpr

            //txtEncrypted.Text = Encoding.Default.GetString(x.Decrypt(baEncrypted, RSAEncryptionPadding.OaepSHA256));


            EnvelopedCms cms = new EnvelopedCms();
            cms.Decode(baEncrypted);
            cms.Decrypt();

            byte[] ba = cms.Encode();

            Debug.WriteLine($"here={Encoding.UTF8.GetString(ba)}");
            */

        }
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lbxLog.Items.Clear();
        }
        private async Task getPartnerlistRest()
        {
            var request = new RestRequest("/api/partner/list");
            var response = await rClient.GetAsync(request, ct);
            Debug.WriteLine(response.Content.ToString());
            JObject jo = JObject.Parse(response.Content);
            JArray partners = (JArray)jo["results"];
            IList<string> PartnerList = partners.Select(c => (string)c).ToList();
            lbxPartners.DataSource = PartnerList;
            lbxPartners.DisplayMember = "String";
        }
        private IList<String> getPartnerListFile()
        {
            
         
            // string xp = $"//partner/@name";
            var childList =
                from el in partnshipXDocument.Root.Descendants("partner")
                select el.Attribute("name");
            partnersList= childList.Select(c => (string)c).ToList();
            return partnersList;
        }
        private List<string> getPartnerships(string partnerName, string nodeSelectorKey)
        {
            string xp = $"(//partnership/sender[@{nodeSelectorKey}='{partnerName}'] |//partnership/receiver[@{nodeSelectorKey}='{partnerName}'])//parent::partnership/@name";
          
            List<string> childList = ((IEnumerable<object>)partnshipXDocument.XPathEvaluate(xp))
                                .OfType<XAttribute>()
                                .Select(x => x.Value)
                                .ToList<string>();




            return childList;
        }
        private Dictionary<string, string> getPartnerDetails(string pName, string nodeSelectorkey)
        {
            string fName = getPartnershipFilename();
            XDocument doc = XDocument.Load(fName);
            string xp = $"//partner[@{nodeSelectorkey}='{pName}']";
            XElement xe = doc.XPathSelectElement(xp);
            Dictionary<string, string> plist = xe.Attributes().ToDictionary(k => k.Name.ToString(), v => v.Value);
            return plist;
        }
        private void btnGetPartners_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            lbxPartners.DataSource = getPartnerListFile(); ;
            Cursor = Cursors.Default;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tb = (TabControl)sender;

            Debug.WriteLine($"{tb.TabPages[tb.SelectedIndex].Name}");
            switch (tb.SelectedIndex)
            {
                case (int)tabs.tbpSendRcv:
                    break;

                case (int)tabs.tbpPartners:
                    btnGetPartners_Click(null, null);

                    break;
                case (int)tabs.tbpLog:
                    break;
            }
        }
        private void getPartnerData(string partner)
        {

            //var request = new RestRequest($"/api/partner/view/{partner}");
            ////var response = await rClient.GetAsync(request, ct);
            //var response = rClient.Get(request);
            //JObject jo = JObject.Parse(response.Content);

            //partnerDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(jo["results"][0].ToString());
            IList<string> l = getPartnerListFile();
        }
        private void lbxPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = (ListBox)sender;
            Cursor = Cursors.WaitCursor;
            if (x.SelectedItem != null)
            {
                string nodeSelectorKey = Properties.Settings.Default.partnerNodeSelecter;
                partnerDic = getPartnerDetails(x.SelectedItem.ToString(), nodeSelectorKey);
                utils.setControl(txtPartnerAs2Id, partnerDic.SingleOrDefault(p => p.Key == "as2_id"), nodeSelectorKey);
                utils.setControl(txtPartnerName, partnerDic.SingleOrDefault(p => p.Key == "name"), nodeSelectorKey);
                utils.setControl(txtPartnerX509Alias, partnerDic.SingleOrDefault(p => p.Key == "x509_alias"), nodeSelectorKey);
                utils.setControl(txtPartnerEmail, partnerDic.SingleOrDefault(p => p.Key == "email"), nodeSelectorKey);

                partnershipsList = getPartnerships(x.SelectedItem.ToString(), nodeSelectorKey);
                lbxPartnerShips.DataSource = partnershipsList;
            }
            Cursor = Cursors.Default;



        }
        private void clearPartnerfields()
        {
            txtPartnerAs2Id.Text = "";
            txtPartnerEmail.Text = "";
            txtPartnerName.Text = "";
            txtPartnerX509Alias.Text = "";

        }
        private XmlDocument getPartnerXmlDocument(ref string fName)
        {
            XmlDocument doc = new XmlDocument();
            fName = getPartnershipFilename();
            doc.Load(fName);
            return doc;
        }
        private string getPartnershipFilename()
        {
            return AS2configPath + "\\partnerships.xml";
        }
        private void updatePartnerXml(Dictionary<string, string> dic, string nodeSelecterKey)
        {
            string fName = "";
            XmlDocument doc = getPartnerXmlDocument(ref fName);
            string xp = $"//partner[@{nodeSelecterKey}='{dic[nodeSelecterKey]}']";
            XmlNode xe = doc.SelectSingleNode(xp);
            foreach (KeyValuePair<string, string> kvp in dic)
            {
                if (kvp.Key == nodeSelecterKey) continue;
                xe.Attributes[kvp.Key].Value = kvp.Value;
            }

            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            XmlWriter w = XmlWriter.Create(fName, ws);

            doc.Save(w);
            w.Close();
        }
        private void btnPartnerUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("name", txtPartnerName.Text);
            dic.Add("as2_id", txtPartnerAs2Id.Text);
            dic.Add("email", txtPartnerEmail.Text);
            dic.Add("x509_alias", txtPartnerX509Alias.Text);
            using (frmdPartner f = new frmdPartner(ref dic, Properties.Settings.Default.partnerNodeSelecter, "Update Partner"))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtPartnerAs2Id.Text = f.ldic["as2_id"];
                    txtPartnerName.Text = f.ldic["name"];
                    txtPartnerX509Alias.Text = f.ldic["x509_alias"];
                    txtPartnerEmail.Text = f.ldic["email"];
                    updatePartnerXml(f.ldic, Properties.Settings.Default.partnerNodeSelecter);
                }
            }
        }
        private void deletPartnerXml(string partnerName)
        {
            string fName = getPartnershipFilename();
            string xp = $"//partner[@name='{partnerName}']";
            XDocument doc = XDocument.Load(fName);
            var partner = (XElement)doc.XPathSelectElements(xp).First();
            partner.Remove();
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            XmlWriter w = XmlWriter.Create(fName, ws);

            doc.Save(w);
            w.Close();
        }
        private void btnPartnerDelete_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("name", txtPartnerName.Text);
            dic.Add("as2_id", txtPartnerAs2Id.Text);
            dic.Add("email", txtPartnerEmail.Text);
            dic.Add("x509_alias", txtPartnerX509Alias.Text);
            using (frmdPartner f = new frmdPartner(ref dic, Properties.Settings.Default.partnerNodeSelecter, "Delete Partner"))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {

                    deletPartnerXml(f.ldic["name"]);
                    btnGetPartners_Click(null, null);
                }
            }
        }
        private void addPartnerXml(Dictionary<string, string> dic, string nodeSelecterKey)
        {
            string fName = getPartnershipFilename();
            string xp = $"//partner[last()]";
            XDocument doc = XDocument.Load(fName);
            var partner = (XElement)doc.XPathSelectElements(xp).First();
            var newPartner = new XElement("partner");
            foreach (KeyValuePair<string, string> kvp in dic)
                newPartner.Add(new XAttribute(kvp.Key, kvp.Value));
            partner.AddAfterSelf(newPartner);
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            XmlWriter w = XmlWriter.Create(fName, ws);
            doc.Save(w);
            w.Close();
        }
        private void btnPartnerAddNew_Click(object sender, EventArgs e)
        {
            partnerDic.Clear();
            using (frmdPartner f = new frmdPartner(ref partnerDic, Properties.Settings.Default.partnerNodeSelecter, "Add Partner"))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtPartnerName.Text = f.ldic["name"];
                    txtPartnerAs2Id.Text = f.ldic["as2_id"];
                    txtPartnerX509Alias.Text = f.ldic["x509_alias"];
                    txtPartnerEmail.Text = f.ldic["email"];
                    addPartnerXml(f.ldic, "");
                    btnGetPartners_Click(null, null);
                };
            }
        }
        private void btnParnterShipAdd_Click(object sender, EventArgs e)
        {
            if(partnersList.Count < 2) { 
                MessageBox.Show("Minimum of 2 partners are required to define partnership..!"); 
                return;
            
            }
            using (frmPartnership f = new frmPartnership(ref partnshipXDocument,ref partnersList,ref partnershipsList, Properties.Settings.Default.parntershipNodeSelector))
            {
            if(f.ShowDialog()==DialogResult.OK)
                {

                }
            
            }
        }
    }
}

