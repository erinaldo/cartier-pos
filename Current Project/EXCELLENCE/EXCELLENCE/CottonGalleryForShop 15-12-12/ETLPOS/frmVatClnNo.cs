using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ETLPOS
{
    public partial class frmVatClnNo : BaseForm
    {
        public frmVatClnNo()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            VatClnNo = ("00000001").Substring(0, 8-this.txtVatClnNo.Text.Trim().Length)+this.txtVatClnNo.Text;
            this.Close();
        }
        private void IsValidKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;

            Control txtB = (Control)sender;
           // if (e.KeyChar == 46) return;
            if (e.KeyChar < 48 || e.KeyChar > 57)
                e.Handled = true;
        }

      
    }
}
