
namespace As2Test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctxCertficate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addcertificate = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbpSendRcv = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEDIFilePath = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbxPartnerFrom = new System.Windows.Forms.ListBox();
            this.txtEDI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKeyStore = new System.Windows.Forms.Label();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnSendFile2 = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lbxPartnerTo = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpPartners = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPartnershipDelete = new System.Windows.Forms.Button();
            this.btnPartnershipModify = new System.Windows.Forms.Button();
            this.btnParnterShipAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lbxPartnerShips = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbxPartners = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPartnerEmail = new System.Windows.Forms.TextBox();
            this.txtPartnerX509Alias = new System.Windows.Forms.TextBox();
            this.txtPartnerAs2Id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPartnerName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPartnerDelete = new System.Windows.Forms.Button();
            this.btnPartnerAddNew = new System.Windows.Forms.Button();
            this.btnParnterToggleOp = new System.Windows.Forms.Button();
            this.btnPartnerUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbpLog = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbpSendRcv.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpPartners.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tbpLog.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxCertficate
            // 
            this.ctxCertficate.Name = "ctxCertficate";
            this.ctxCertficate.Size = new System.Drawing.Size(61, 4);
            // 
            // addcertificate
            // 
            this.addcertificate.Name = "addcertificate";
            this.addcertificate.Size = new System.Drawing.Size(153, 22);
            this.addcertificate.Text = "Add Certificate";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1341, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            // 
            // tbpSendRcv
            // 
            this.tbpSendRcv.Controls.Add(this.tableLayoutPanel3);
            this.tbpSendRcv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbpSendRcv.Location = new System.Drawing.Point(4, 24);
            this.tbpSendRcv.Name = "tbpSendRcv";
            this.tbpSendRcv.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSendRcv.Size = new System.Drawing.Size(1333, 529);
            this.tbpSendRcv.TabIndex = 1;
            this.tbpSendRcv.Text = "Send Receive";
            this.tbpSendRcv.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 11;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 387F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblEDIFilePath, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 7, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbxPartnerFrom, 7, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtEDI, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblKeyStore, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtEncrypted, 6, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 7, 5);
            this.tableLayoutPanel3.Controls.Add(this.lbxPartnerTo, 8, 2);
            this.tableLayoutPanel3.Controls.Add(this.label8, 8, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox1, 6, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.265774F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.73422F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1327, 523);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "X12 File-------->";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEDIFilePath
            // 
            this.lblEDIFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEDIFilePath.AutoSize = true;
            this.lblEDIFilePath.BackColor = System.Drawing.Color.LightYellow;
            this.tableLayoutPanel3.SetColumnSpan(this.lblEDIFilePath, 5);
            this.lblEDIFilePath.ForeColor = System.Drawing.Color.Brown;
            this.lblEDIFilePath.Location = new System.Drawing.Point(110, 0);
            this.lblEDIFilePath.Name = "lblEDIFilePath";
            this.lblEDIFilePath.Size = new System.Drawing.Size(252, 23);
            this.lblEDIFilePath.TabIndex = 4;
            this.lblEDIFilePath.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.lblEDIFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEDIFilePath.Click += new System.EventHandler(this.lblEDIFilePath_Click);
            this.lblEDIFilePath.MouseEnter += new System.EventHandler(this.lblEDIFilePath_MouseEnter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(783, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "From (Sender)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbxPartnerFrom
            // 
            this.lbxPartnerFrom.BackColor = System.Drawing.Color.LightYellow;
            this.lbxPartnerFrom.ForeColor = System.Drawing.Color.Brown;
            this.lbxPartnerFrom.FormattingEnabled = true;
            this.lbxPartnerFrom.ItemHeight = 15;
            this.lbxPartnerFrom.Location = new System.Drawing.Point(783, 58);
            this.lbxPartnerFrom.Name = "lbxPartnerFrom";
            this.tableLayoutPanel3.SetRowSpan(this.lbxPartnerFrom, 3);
            this.lbxPartnerFrom.Size = new System.Drawing.Size(140, 109);
            this.lbxPartnerFrom.TabIndex = 18;
            this.lbxPartnerFrom.SelectedIndexChanged += new System.EventHandler(this.lbxPartnerFrom_SelectedIndexChanged);
            // 
            // txtEDI
            // 
            this.txtEDI.BackColor = System.Drawing.Color.LightYellow;
            this.tableLayoutPanel3.SetColumnSpan(this.txtEDI, 6);
            this.txtEDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEDI.ForeColor = System.Drawing.Color.Brown;
            this.txtEDI.Location = new System.Drawing.Point(3, 58);
            this.txtEDI.Multiline = true;
            this.txtEDI.Name = "txtEDI";
            this.tableLayoutPanel3.SetRowSpan(this.txtEDI, 4);
            this.txtEDI.Size = new System.Drawing.Size(387, 414);
            this.txtEDI.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(5, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Key store file-->";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKeyStore
            // 
            this.lblKeyStore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKeyStore.AutoSize = true;
            this.lblKeyStore.BackColor = System.Drawing.Color.LightYellow;
            this.tableLayoutPanel3.SetColumnSpan(this.lblKeyStore, 5);
            this.lblKeyStore.ForeColor = System.Drawing.Color.Brown;
            this.lblKeyStore.Location = new System.Drawing.Point(110, 31);
            this.lblKeyStore.Name = "lblKeyStore";
            this.lblKeyStore.Size = new System.Drawing.Size(252, 15);
            this.lblKeyStore.TabIndex = 11;
            this.lblKeyStore.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.lblKeyStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKeyStore.Click += new System.EventHandler(this.lblKeystoreFile_click);
            this.lblKeyStore.MouseEnter += new System.EventHandler(this.lblCertificate_MouseEnter);
            // 
            // txtEncrypted
            // 
            this.txtEncrypted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEncrypted.Location = new System.Drawing.Point(396, 58);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.Name = "txtEncrypted";
            this.tableLayoutPanel3.SetRowSpan(this.txtEncrypted, 4);
            this.txtEncrypted.Size = new System.Drawing.Size(381, 414);
            this.txtEncrypted.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnDecrypt, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSendFile2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEncrypt, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(783, 175);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(137, 142);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(3, 115);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(62, 24);
            this.btnDecrypt.TabIndex = 2;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            // 
            // btnSendFile2
            // 
            this.btnSendFile2.Location = new System.Drawing.Point(3, 54);
            this.btnSendFile2.Name = "btnSendFile2";
            this.btnSendFile2.Size = new System.Drawing.Size(62, 23);
            this.btnSendFile2.TabIndex = 0;
            this.btnSendFile2.Text = "Send File";
            this.btnSendFile2.UseVisualStyleBackColor = true;
            this.btnSendFile2.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(3, 83);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(62, 26);
            this.btnEncrypt.TabIndex = 1;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lbxPartnerTo
            // 
            this.lbxPartnerTo.BackColor = System.Drawing.Color.LightYellow;
            this.lbxPartnerTo.ForeColor = System.Drawing.Color.Brown;
            this.lbxPartnerTo.FormattingEnabled = true;
            this.lbxPartnerTo.ItemHeight = 15;
            this.lbxPartnerTo.Location = new System.Drawing.Point(930, 58);
            this.lbxPartnerTo.Name = "lbxPartnerTo";
            this.tableLayoutPanel3.SetRowSpan(this.lbxPartnerTo, 3);
            this.lbxPartnerTo.Size = new System.Drawing.Size(120, 109);
            this.lbxPartnerTo.TabIndex = 19;
            this.lbxPartnerTo.SelectedIndexChanged += new System.EventHandler(this.lbxPartnerTo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightGray;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(930, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 32);
            this.label8.TabIndex = 17;
            this.label8.Text = "To (Receiver)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel3.SetColumnSpan(this.label4, 2);
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(783, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Partners";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpSendRcv);
            this.tabControl1.Controls.Add(this.tbpPartners);
            this.tabControl1.Controls.Add(this.tbpLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1341, 557);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tbpPartners
            // 
            this.tbpPartners.Controls.Add(this.tableLayoutPanel5);
            this.tbpPartners.Location = new System.Drawing.Point(4, 24);
            this.tbpPartners.Name = "tbpPartners";
            this.tbpPartners.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPartners.Size = new System.Drawing.Size(1333, 529);
            this.tbpPartners.TabIndex = 3;
            this.tbpPartners.Text = "Partner & Partnerships";
            this.tbpPartners.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.71816F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.28184F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.52773F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.47228F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1327, 523);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 593F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.13158F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(813, 456);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.8982F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.1018F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel7.Controls.Add(this.btnPartnershipDelete, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnPartnershipModify, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnParnterShipAdd, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 373);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.29578F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.70422F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(282, 80);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // btnPartnershipDelete
            // 
            this.btnPartnershipDelete.Location = new System.Drawing.Point(186, 3);
            this.btnPartnershipDelete.Name = "btnPartnershipDelete";
            this.btnPartnershipDelete.Size = new System.Drawing.Size(78, 33);
            this.btnPartnershipDelete.TabIndex = 5;
            this.btnPartnershipDelete.Text = "Delete";
            this.btnPartnershipDelete.UseVisualStyleBackColor = true;
            // 
            // btnPartnershipModify
            // 
            this.btnPartnershipModify.Location = new System.Drawing.Point(96, 3);
            this.btnPartnershipModify.Name = "btnPartnershipModify";
            this.btnPartnershipModify.Size = new System.Drawing.Size(78, 33);
            this.btnPartnershipModify.TabIndex = 4;
            this.btnPartnershipModify.Text = "Modify";
            this.btnPartnershipModify.UseVisualStyleBackColor = true;
            // 
            // btnParnterShipAdd
            // 
            this.btnParnterShipAdd.Location = new System.Drawing.Point(3, 3);
            this.btnParnterShipAdd.Name = "btnParnterShipAdd";
            this.btnParnterShipAdd.Size = new System.Drawing.Size(78, 33);
            this.btnParnterShipAdd.TabIndex = 3;
            this.btnParnterShipAdd.Text = "Add New";
            this.btnParnterShipAdd.UseVisualStyleBackColor = true;
            this.btnParnterShipAdd.Click += new System.EventHandler(this.btnParnterShipAdd_Click);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.lbxPartnerShips, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.lbxPartners, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 4;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(294, 364);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // lbxPartnerShips
            // 
            this.lbxPartnerShips.FormattingEnabled = true;
            this.lbxPartnerShips.ItemHeight = 15;
            this.lbxPartnerShips.Location = new System.Drawing.Point(3, 180);
            this.lbxPartnerShips.Name = "lbxPartnerShips";
            this.lbxPartnerShips.Size = new System.Drawing.Size(288, 169);
            this.lbxPartnerShips.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.tableLayoutPanel10.SetColumnSpan(this.label12, 2);
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(3, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(288, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Partnerships";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbxPartners
            // 
            this.lbxPartners.FormattingEnabled = true;
            this.lbxPartners.ItemHeight = 15;
            this.lbxPartners.Location = new System.Drawing.Point(3, 26);
            this.lbxPartners.Name = "lbxPartners";
            this.lbxPartners.Size = new System.Drawing.Size(288, 124);
            this.lbxPartners.TabIndex = 1;
            this.lbxPartners.SelectedIndexChanged += new System.EventHandler(this.lbxPartners_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.tableLayoutPanel10.SetColumnSpan(this.label11, 2);
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(3, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(288, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Partners";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel8.Controls.Add(this.txtPartnerEmail, 1, 4);
            this.tableLayoutPanel8.Controls.Add(this.txtPartnerX509Alias, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.txtPartnerAs2Id, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.txtPartnerName, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 1, 5);
            this.tableLayoutPanel8.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(303, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 6;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(486, 244);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // txtPartnerEmail
            // 
            this.txtPartnerEmail.Location = new System.Drawing.Point(84, 113);
            this.txtPartnerEmail.Name = "txtPartnerEmail";
            this.txtPartnerEmail.Size = new System.Drawing.Size(399, 23);
            this.txtPartnerEmail.TabIndex = 8;
            // 
            // txtPartnerX509Alias
            // 
            this.txtPartnerX509Alias.Location = new System.Drawing.Point(84, 83);
            this.txtPartnerX509Alias.Name = "txtPartnerX509Alias";
            this.txtPartnerX509Alias.Size = new System.Drawing.Size(399, 23);
            this.txtPartnerX509Alias.TabIndex = 7;
            // 
            // txtPartnerAs2Id
            // 
            this.txtPartnerAs2Id.Location = new System.Drawing.Point(84, 53);
            this.txtPartnerAs2Id.Name = "txtPartnerAs2Id";
            this.txtPartnerAs2Id.Size = new System.Drawing.Size(399, 23);
            this.txtPartnerAs2Id.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(39, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Location = new System.Drawing.Point(38, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 30);
            this.label7.TabIndex = 2;
            this.label7.Text = "AS2 Id";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Location = new System.Drawing.Point(18, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 30);
            this.label9.TabIndex = 3;
            this.label9.Text = "X509 Alias";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Right;
            this.label10.Location = new System.Drawing.Point(37, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 30);
            this.label10.TabIndex = 4;
            this.label10.Text = "E-Mail";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPartnerName
            // 
            this.txtPartnerName.Location = new System.Drawing.Point(84, 23);
            this.txtPartnerName.Name = "txtPartnerName";
            this.txtPartnerName.Size = new System.Drawing.Size(399, 23);
            this.txtPartnerName.TabIndex = 5;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 4;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.2994F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.7006F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel9.Controls.Add(this.btnPartnerDelete, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnPartnerAddNew, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnParnterToggleOp, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnPartnerUpdate, 1, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(84, 143);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(399, 98);
            this.tableLayoutPanel9.TabIndex = 9;
            // 
            // btnPartnerDelete
            // 
            this.btnPartnerDelete.Location = new System.Drawing.Point(170, 3);
            this.btnPartnerDelete.Name = "btnPartnerDelete";
            this.btnPartnerDelete.Size = new System.Drawing.Size(73, 42);
            this.btnPartnerDelete.TabIndex = 2;
            this.btnPartnerDelete.Text = "Delete";
            this.btnPartnerDelete.UseVisualStyleBackColor = true;
            this.btnPartnerDelete.Click += new System.EventHandler(this.btnPartnerDelete_Click);
            // 
            // btnPartnerAddNew
            // 
            this.btnPartnerAddNew.Location = new System.Drawing.Point(3, 3);
            this.btnPartnerAddNew.Name = "btnPartnerAddNew";
            this.btnPartnerAddNew.Size = new System.Drawing.Size(78, 42);
            this.btnPartnerAddNew.TabIndex = 0;
            this.btnPartnerAddNew.Text = "Add New";
            this.btnPartnerAddNew.UseVisualStyleBackColor = true;
            this.btnPartnerAddNew.Click += new System.EventHandler(this.btnPartnerAddNew_Click);
            // 
            // btnParnterToggleOp
            // 
            this.btnParnterToggleOp.Location = new System.Drawing.Point(249, 3);
            this.btnParnterToggleOp.Name = "btnParnterToggleOp";
            this.btnParnterToggleOp.Size = new System.Drawing.Size(73, 42);
            this.btnParnterToggleOp.TabIndex = 3;
            this.btnParnterToggleOp.UseVisualStyleBackColor = true;
            // 
            // btnPartnerUpdate
            // 
            this.btnPartnerUpdate.Location = new System.Drawing.Point(87, 3);
            this.btnPartnerUpdate.Name = "btnPartnerUpdate";
            this.btnPartnerUpdate.Size = new System.Drawing.Size(77, 42);
            this.btnPartnerUpdate.TabIndex = 1;
            this.btnPartnerUpdate.Text = "Modify";
            this.btnPartnerUpdate.UseVisualStyleBackColor = true;
            this.btnPartnerUpdate.Click += new System.EventHandler(this.btnPartnerUpdate_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.tableLayoutPanel8.SetColumnSpan(this.label5, 2);
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(480, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Partner details";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbpLog
            // 
            this.tbpLog.Controls.Add(this.tableLayoutPanel2);
            this.tbpLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbpLog.Location = new System.Drawing.Point(4, 24);
            this.tbpLog.Name = "tbpLog";
            this.tbpLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLog.Size = new System.Drawing.Size(1333, 529);
            this.tbpLog.TabIndex = 2;
            this.tbpLog.Text = "Log";
            this.tbpLog.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbxLog, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.33652F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.66348F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1327, 523);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnClearLog, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 465);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 55);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(3, 3);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(94, 37);
            this.btnClearLog.TabIndex = 0;
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lbxLog
            // 
            this.lbxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.ItemHeight = 15;
            this.lbxLog.Location = new System.Drawing.Point(3, 3);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(1321, 456);
            this.lbxLog.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(396, 478);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 557);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tbpSendRcv.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbpPartners.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tbpLog.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip ctxCertficate;
        private System.Windows.Forms.ToolStripMenuItem addcertificate;
        private System.Windows.Forms.TabPage tbpSendRcv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEDIFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKeyStore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbxPartnerFrom;
        private System.Windows.Forms.ListBox lbxPartnerTo;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtEDI;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSendFile2;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TabPage tbpLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tbpPartners;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.ListBox lbxPartners;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox txtPartnerEmail;
        private System.Windows.Forms.TextBox txtPartnerX509Alias;
        private System.Windows.Forms.TextBox txtPartnerAs2Id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPartnerName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button btnPartnerDelete;
        private System.Windows.Forms.Button btnPartnerUpdate;
        private System.Windows.Forms.Button btnPartnerAddNew;
        private System.Windows.Forms.Button btnParnterToggleOp;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lbxPartnerShips;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnPartnershipDelete;
        private System.Windows.Forms.Button btnPartnershipModify;
        private System.Windows.Forms.Button btnParnterShipAdd;
        private System.Windows.Forms.TextBox textBox1;
    }
}

