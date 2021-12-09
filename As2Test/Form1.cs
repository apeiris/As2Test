using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;


namespace As2Test
{
    public partial class Form1 : Form
    {
        public static FileSystemWatcher fsw = null;
        const string signCert = @"C:\OpenAS2Server\config\as2_certs.p12";
       // const string receipientCertFile = @"C:\OpenAS2Server\config\partnera.cer";
        const string receipientCertFile = @"C:\OpenAS2Server\config\as2_certs_p12.cer";

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            lblSendFilePath.Text = Properties.Settings.Default.sendFilePath;
          //  if (!String.IsNullOrEmpty(fsw.Path)) fsw.EnableRaisingEvents = true;
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

        private static async void SendFileToAs2(string path)
        {
            string s = "";


            byte[] byteArray;

            try
            {
                using (FileStream ss = File.Open(path, FileMode.Open))
                {
                    ss.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"@openclose{ ex.Message}\n{ex.StackTrace}");
            }
        L1:
            try
            {
                using (FileStream SourceStream = File.Open(path, FileMode.Open))
                {
                    byteArray = new byte[SourceStream.Length];
                    await SourceStream.ReadAsync(byteArray, 0, (int)SourceStream.Length);
                }
            }
            catch (FileNotFoundException nf)
            {
                Debug.WriteLine($"******nf******\n{nf.Message}\n{nf.StackTrace}");
                goto L1;
            }
            catch (IOException io)
            {
                Debug.WriteLine($"******IOIOIO******\n{io.Message}\n{io.StackTrace}");
                goto L1;
            }
            s = System.Text.Encoding.ASCII.GetString(byteArray);
            Form1 form1 = new Form1();
            form1.setEDIText(s);




            Debug.WriteLine(s);

            Debug.Indent(); Debug.WriteLine(s); Debug.Unindent();

            ProxySettings proxy = new ProxySettings();
            Uri uri = new Uri("http://192.168.86.32:10080");

        
          


            AS2Helper.SendFile(uri, $"{path}", byteArray, "MyCompany_OID", "PartnerA_OID", proxy, 1000, signCert, "testas2", receipientCertFile);


        }
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(e.FullPath)) return;
            Debug.WriteLine($"Created: {e.FullPath}");

            SendFileToAs2(e.FullPath);

            File.Delete(e.FullPath);
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
        private void lblSendFilePath_Click(object sender, EventArgs e)
        {

            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.sendFilePath = dialog.FileName;
                    lblSendFilePath.Text = dialog.FileName;
              

             
                    Properties.Settings.Default.Save();


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtEDI.Text = "";

            byte[] byteArray;
         // string fname = @"C:\data\EDI\MyComapny_OID-PartnerA_OID-OrderID-745634.edi";
            string fname = lblSendFilePath.Text;
            using (FileStream SourceStream = File.Open(fname, FileMode.Open))
            {
                byteArray = new byte[SourceStream.Length];
                SourceStream.Read(byteArray, 0, (int)SourceStream.Length);
                //await SourceStream.ReadAsync(byteArray, 0, (int)SourceStream.Length);
            }


            ProxySettings proxy = new ProxySettings();
            Uri uri = new Uri("http://localhost:10080");


            string[] signCertFileName = { @"C:\OpenAS2Server\config\as2_certs.p12", @"C:\OpenAS2Server\config\companyA.jks" };

            string[] receipientCertFile = { @"C:\OpenAS2Server\config\companyb.cer", @"C:\OpenAS2Server\config\companyB.cer" };
            string [] fromId = { "companyb_OID","MyCompany_OID", "companyA_OID" };
            string [] toId = { "companya_OID","PartnerA_OID", "companyB_OID" };
     

            int ix = 0;
           

            System.Net.HttpStatusCode c = AS2Helper.SendFile(uri, fname, byteArray, fromId[ix], toId[ix], proxy, 10000
                      , signCertFileName[ix], "testas2", receipientCertFile[ix]);
            txtEDI.Text = c.ToString();
  
        }

       
    }
}
