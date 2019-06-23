using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETL.Common;
using ETL.BLL;
using ETL.Model;
using Model;
using CrystalDecisions.Windows.Forms;
using ETLPOS.Reports;
using BLL;

namespace ETLPOS
{
    public partial class CardSaleCashSaleReport : BaseForm
    {
        public CardSaleCashSaleReport()
        {
            InitializeComponent();
            LoadReportBranch();
        }
        private void LoadReportBranch()
        {
            CResult oResult = new CResult();
            CCompanyBranchBO oCompanyBranchBO = new CCompanyBranchBO();
            oResult = oCompanyBranchBO.ReadAll();

            if (oResult.IsSuccess)
            {
                ddlRptBranch.DataSource = oResult.Data as List<CCompanyBranch>;
                ddlRptBranch.DisplayMember = "CompBrn_Code";
                ddlRptBranch.ValueMember = "CompBrn_OId";
                ddlRptBranch.SelectedValue = currentBranch.CompBrn_OId.Trim();

                //ddlRptBranch3.DataSource = oResult.Data as List<CCompanyBranch>;
                //ddlRptBranch3.DisplayMember = "CompBrn_Code";
                //ddlRptBranch3.ValueMember = "CompBrn_OId";
                //ddlRptBranch3.SelectedValue = currentBranch.CompBrn_OId.Trim();


            }
            else
            {
                MessageBox.Show("Loading error...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            CCashCardBO bo = new CCashCardBO();


            DateTime date = dtpDate.Value.Date;
            DataTable result = bo.ReadAll(date,currentBranch.CompBrn_Code);
            dataGridView1.DataSource = result;

            DataRow[] cash = result.Select("PaymentType='Cash'");
            double amount = 0.0;
            foreach (var item in cash)
            {
                amount += Convert.ToDouble(item["TotalAmount"].ToString());
            }
            lblCash.Text = amount.ToString();

            DataRow[] card = result.Select("PaymentType='Card'");
            double Cardamount = 0.0;
            foreach (var item in card)
            {
                Cardamount += Convert.ToDouble(item["TotalAmount"].ToString());
            }
            lblCard.Text = Cardamount.ToString();
                        
        }
    }
}
