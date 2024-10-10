using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyAbsenceManager.Forms
{
    public partial class ManuallyProcessedEmailsForm : Form
    {
        public ManuallyProcessedEmailsForm()
        {
            InitializeComponent();
        }

        private void ManagerInfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void ManuallyProcessedEmailsForm_Load(object sender, EventArgs e)
        {
            ExecuteAddonButton.Text = "Verschieben";
            ManagerInfoLabel.Text = "Haben sie diese Krankmeldungen bereits händisch abgearbeitet?\n Dann werden sie zur Verhinderung von Dopplungen verschoben.";
        }

        private void GetHelpButton_Click(object sender, EventArgs e)
        {
            var helpDialog = new StartupInfoForm();
            var Result = helpDialog.ShowDialog();
        }

        private void CancelAddInExecutionButton_Click(object sender, EventArgs e)
        {

        }
    }
}
