﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace As2Test
{
    public partial class frmdPartner : Form
    {
       public  Dictionary<string,string> ldic =null;
        
        public frmdPartner(ref Dictionary<string,string> dic,string nodeSelecterKey,string Caption)
        {
            InitializeComponent();
            ldic =new Dictionary<string, string>(dic);
            utils.setControl(txtdPartnerName, dic.SingleOrDefault(p => p.Key == "name"), nodeSelecterKey);
            utils.setControl(txtdPartnerAs2Id, dic.SingleOrDefault(p => p.Key == "as2_id"), nodeSelecterKey);
          
            utils.setControl(txtdPartnerX509Alias, dic.SingleOrDefault(p => p.Key == "x509_alias"), nodeSelecterKey);
            utils.setControl(txtdPartnerEmail, dic.SingleOrDefault(p => p.Key == "email"), nodeSelecterKey);
                        
            this.Text = Caption;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndOk_Click(object sender, EventArgs e)
        {

            ldic["name"]=txtdPartnerName.Text;
            ldic["as2_id"] = txtdPartnerAs2Id.Text;
            
            ldic["x509_alias"]=txtdPartnerX509Alias.Text;
            ldic["email"]=txtdPartnerEmail.Text;
          
            this.DialogResult=DialogResult.OK;  
            
        }

        private void btndCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;  
        }

        private void frmdPartner_Load(object sender, EventArgs e)
        {

        }
    }
}
