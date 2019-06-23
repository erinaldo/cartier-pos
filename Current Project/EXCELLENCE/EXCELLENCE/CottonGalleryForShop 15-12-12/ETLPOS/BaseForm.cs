using System.Windows.Forms;

using ETL.Model;

namespace ETLPOS
{
    public class BaseForm : Form
    {
        public static CUser currentUser;
        public static CCompanyBranch currentBranch;
        // Advance Start
        public static bool defaultUserMode = true;
        public static string VatClnNo = "00000001";
        // Advance End

        public BaseForm()
        {
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}
