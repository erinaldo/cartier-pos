using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ETL.BLL;
using ETL.Common;
using ETL.Model;

namespace ETLPOS
{
    public partial class frmSearchGeneric<T> : BaseForm
    {

        #region "Declarations"

        List<T> list = new List<T>();
        string stDisplayMember = string.Empty;
        string stValueMember = string.Empty;

        public delegate void EventHandler(object sender, SearchEventArgs<T> e);

        public event EventHandler SelectedEvent;

        string stCond = string.Empty;

        #endregion

        #region "Methods"

        public frmSearchGeneric()
        {
            InitializeComponent();
        }

        public frmSearchGeneric(string stCond)
        {
            this.stCond = stCond;
            InitializeComponent();
        }
        
        private void PopulateTData()
        {
            lstSearcheResult.Items.Clear();
            lstSearcheResult.DisplayMember = stDisplayMember;
            lstSearcheResult.ValueMember = stValueMember;

            foreach (T t in list)
            {
                lstSearcheResult.Items.Add(t);
            }
        }

        private bool ValidateFormData()
        {
            if (rbtnDate.Checked)
            {
                if (dtpDateFrom.Value > dtpDateTo.Value)
                {
                    MessageBox.Show("Please check Date. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                if (txtRequisitionNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please give Requisition Number. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void GetOutput()
        {
            if (ValidateFormData())
            {
                if (typeof(T) == typeof(CMTMaster))
                {
                    list = new List<T>();

                    CMaterialTransferBO oMTBO = new CMaterialTransferBO();
                    CResult oResult = new CResult();
                    if (txtRequisitionNo.Text.Trim() == "")
                    {
                        DateTime dtFrom = CUtils.GetDate(dtpDateFrom.Value.ToString("dd-MM-yyyy"), EDateType.FROM);
                        DateTime dtTo = CUtils.GetDate(dtpDateTo.Value.ToString("dd-MM-yyyy"), EDateType.TO);

                        oResult = oMTBO.ReadByIDDate(dtFrom, dtTo, null);
                    }
                    else
                    {
                        oResult = oMTBO.ReadByIDDate(DateTime.Now, DateTime.Now, txtRequisitionNo.Text.Trim());
                    }

                    if (oResult.IsSuccess)
                    {
                        list = (List<T>)oResult.Data;

                        stDisplayMember = "MTMstr_OID";
                        stValueMember = "MTMstr_OID";
                        PopulateTData();
                    }
                    else
                    {
                        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        list = null;
                    }
                }
                else if (typeof(T) == typeof(CGRMaster))
                {
                    list = new List<T>();

                    CGRBO oGRBO = new CGRBO();
                    CResult oResult = new CResult();
                    if (txtRequisitionNo.Text.Trim() == "")
                    {
                        DateTime dtFrom = CUtils.GetDate(dtpDateFrom.Value.ToString("dd-MM-yyyy"), EDateType.FROM);
                        DateTime dtTo = CUtils.GetDate(dtpDateTo.Value.ToString("dd-MM-yyyy"), EDateType.TO);

                        oResult = oGRBO.ReadByIDDate(dtFrom, dtTo, null, stCond);
                    }
                    else
                    {
                        oResult = oGRBO.ReadByIDDate(DateTime.Now, DateTime.Now, txtRequisitionNo.Text.Trim(), stCond);
                    }

                    if (oResult.IsSuccess)
                    {
                        list = (List<T>)oResult.Data;

                        stDisplayMember = "GRMstr_OID";
                        stValueMember = "GRMstr_OID";
                        PopulateTData();
                    }
                    else
                    {
                        MessageBox.Show(oResult.ErrMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        list = null;
                    }
                }
            }
        }

        private void ClearFormData()
        {
            SetDate();
            dtpDateFrom.Value = DateTime.Now;
            dtpDateTo.Value = DateTime.Now;
            txtRequisitionNo.Text = "";
            lstSearcheResult.Items.Clear();
        }
        private void SetDate()
        {
            dtpDateFrom.Value = DateTime.Now.AddDays(-7.00);
        }

        #endregion

        #region "Events"

        private void rbtnDate_CheckedChanged(object sender, EventArgs e)
        {
            ClearFormData();
            if (rbtnDate.Checked)
            {
                pnlReqNo.Visible = false;
                pnlDate.Visible = true;
            }
            else
            {
                pnlReqNo.Visible = true;
                pnlDate.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetOutput();
            if(lstSearcheResult.Items.Count==0)
            {
                MessageBox.Show("No data has been found. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtRequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch.Focus();
            }
        }

        #endregion

        private void lstSearcheResult_DoubleClick(object sender, EventArgs e)
        {
            if (lstSearcheResult.SelectedItem != null)
            {
                T t = ((T)lstSearcheResult.SelectedItem);
                SearchEventArgs<T> oArgs = new SearchEventArgs<T>(t);
                OnSelectedEvent(oArgs);
                this.Dispose();
            }
        }

        private void frmSearchGeneric_Load(object sender, EventArgs e)
        {
            SetDate();
            GetOutput();
        }

        protected virtual void OnSelectedEvent(SearchEventArgs<T> e)
        {
            if (SelectedEvent != null)
            {
                SelectedEvent(this, e);
            }
        }
    }

    public class SearchEventArgs<T> : EventArgs
    {
        private  T m_t;

        public SearchEventArgs(T t)
        {
            this.m_t = t;
        }

        public T t
        {
            get { return m_t; }
        }
    }
}