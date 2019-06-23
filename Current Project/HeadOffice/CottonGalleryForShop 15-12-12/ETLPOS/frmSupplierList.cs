using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETL.BLL;
using ETL.Model;
using ETL.Common;

namespace ETLPOS
{
    public partial class frmSupplierList : BaseForm
    {
        public frmSupplierList()
        {
            InitializeComponent();
        }

     public delegate void EEventhandler(object Sender, EEventArg2 e);
        public event EEventhandler EEvent;


        public virtual void ESelectedEvent2(EEventArg2 arg)
        {
            if (EEvent != null)
                EEvent(this, arg);
        }

        ArrayList arrList = new ArrayList() ;
      

        private void frmSupplierList_Load(object sender, EventArgs e)
        {
            LoadSupplierData();
        }
        private void LoadSupplierData()
        {
            lvSupplierList.Items.Clear();
            CSupplierBO oSupplierBO = new CSupplierBO();
            CResult oResult = new CResult();
            CSupplier oSupplier = new CSupplier();

            oResult = oSupplierBO.ReadAll(oSupplier);
            if (oResult.IsSuccess)
            {
                foreach (CSupplier obj in oResult.Data as ArrayList)
                {
                    ListViewItem oItem = new ListViewItem();
                    oItem.Text = obj.Cust_OId.ToString();                                   
                    oItem.SubItems.Add(obj.Cust_Branch).ToString();
                    oItem.SubItems.Add(obj.Cust_Id).ToString();
                    oItem.SubItems.Add(obj.Cust_Name).ToString();
                    oItem.SubItems.Add(obj.Cust_Address).ToString();
                  //  oItem.SubItems.Add(obj.Cust_DiscRate).ToString();
                    oItem.SubItems.Add(obj.Cust_Phone).ToString();
                    oItem.SubItems.Add(obj.Cust_Cell).ToString();
                    oItem.SubItems.Add(obj.Cust_ContactP).ToString();
                    oItem.SubItems.Add(obj.Cust_Fax).ToString();
                    oItem.SubItems.Add(obj.Cust_Web).ToString();
                    oItem.SubItems.Add(obj.Cust_Email).ToString();
                  
                    

                    lvSupplierList.Items.Add(oItem);
                    arrList.Add(obj);
                }
            }
            else
            {
                MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lvSupplierList_DoubleClick(object sender, EventArgs e)
        {
            if (lvSupplierList.Items.Count > 0)
            {
                // ArrayList checkedpersnsrvclist = new ArrayList();
                ListViewItem oItem = (ListViewItem)lvSupplierList.SelectedItems[0];

             //   arrList = new ArrayList();
                foreach (CSupplier oSupplier in arrList as ArrayList)
                {
                    if (oSupplier.Cust_Id.Trim()  == oItem.SubItems[2].Text.Trim())
                    {
                        EEventArg2 arg = new EEventArg2(oSupplier);
                        ESelectedEvent2(arg);
                        break;
                    }
                }

                this.Dispose();
            }



        }

        private void lvSupplierList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmSupplierList_Load_1(object sender, EventArgs e)
        {
            LoadSupplierData();
        }

        //private void lvSupplierList_DoubleClick_1(object sender, EventArgs e)
        //{

        //}
    }

    public class EEventArg2 : EventArgs
    {
        private CSupplier m_Supplier;

        public EEventArg2(CSupplier objE)
        {
            this.m_Supplier = objE;
        }

        public CSupplier Supplier
        {
            get { return this.m_Supplier; }
        }

    }




    }

