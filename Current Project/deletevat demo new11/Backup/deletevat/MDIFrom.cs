using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace deletevat
{
    public partial class MDIFrom : Form
    {
        public MDIFrom()
        {
            InitializeComponent();
        }

        #region Private Methods

        private void CloseAllChild()
        {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                Form frm = (Form)this.MdiChildren[i];
                frm.Dispose();
            }
        }

        #endregion

        #region Button And Click Events

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salesMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            Sales oSales = new Sales();
            oSales.MdiParent = this;
            oSales.Show();
        }

        private void goodRcvMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            GoodsReceive oGoodRcv = new GoodsReceive();
            oGoodRcv.MdiParent = this;
            oGoodRcv.Show();
        }

        private void margeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChild();
            firmMerge oMarge = new firmMerge();
            oMarge.MdiParent = this;
            oMarge.Show();

        }

        #endregion

       
    }
}
