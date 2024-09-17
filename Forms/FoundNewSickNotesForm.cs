using EasyAbsenceManager.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyAbsenceManager
{
    public partial class FoundNewSickNotesForm : Form
    {
        public FoundNewSickNotesForm()
        {
            InitializeComponent();
        }

        private void FoundNewSickNotesForm_Load(object sender, EventArgs e)
        {
        }

        private void SickNoteCountLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GetHelpButton_Click(object sender, EventArgs e)
        {
            var helpDialog = new StartupInfoForm();
            var Result = helpDialog.ShowDialog();
        }
    }
}
