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
    public partial class frmCustomerList : BaseForm
    {
        public delegate void EEventhandler(object Sender, EEventArg e);
        public event EEventhandler EEvent;


        public virtual void ESelectedEvent(EEventArg arg)
        {
            if (EEvent != null)
                EEvent(this, arg);
        }

        ArrayList arrList = new ArrayList() ;
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }
        private void LoadCustomerData()
        {
            lvCustomerList.Items.Clear();
            CCustomerBO oCustomerBO = new CCustomerBO();
            CResult oResult = new CResult();
            CCustomer oCustomer = new CCustomer();

            oResult = oCustomerBO.ReadAll(oCustomer);
            if (oResult.IsSuccess)
            {
                foreach (CCustomer obj in oResult.Data as ArrayList)
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
                  
                    

                    lvCustomerList.Items.Add(oItem);
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

        private void lvCustomerList_DoubleClick(object sender, EventArgs e)
        {
            if (lvCustomerList.Items.Count > 0)
            {
                // ArrayList checkedpersnsrvclist = new ArrayList();
                ListViewItem oItem = (ListViewItem)lvCustomerList.SelectedItems[0];

             //   arrList = new ArrayList();
                foreach (CCustomer oCustomer in arrList as ArrayList)
                {
                    if (oCustomer.Cust_Id.Trim() == oItem.SubItems[2].Text.Trim())
                    {
                        EEventArg arg = new EEventArg(oCustomer);
                        ESelectedEvent(arg);
                        break;
                    }
                }

                this.Dispose();
            }



        }

        private void lvCustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class EEventArg : EventArgs
    {
        private CCustomer m_Customer;

        public EEventArg(CCustomer objE)
        {
            this.m_Customer = objE;
        }

        public CCustomer Customer
        {
            get { return this.m_Customer; }
        }

    }








}
