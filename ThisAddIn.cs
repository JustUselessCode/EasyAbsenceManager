using System.Drawing;
using System.Windows.Forms;
using EasyAbsenceManager.Forms;
using EasyAbsenceManager.Handler;
using Microsoft.Extensions.Logging;

namespace EasyAbsenceManager
{
    public partial class ThisAddIn
    {
        private readonly string _ApplicationName = "EasyAbsenceManager";
        private readonly string _ApplicationLongName = "EasyAbsenceManager-OutlookAddIn";
        private bool _IsFirstStartup;
        private bool ManuallyProcessedEmails { get; set; } = false;

        public static readonly ILogger _Log;

        public void ThisAddIn_Startup(object sender, System.EventArgs e)
        {   
            var resultFolderCreation = MailboxHandler.CreateCompletionFolder(Application);
            _IsFirstStartup = !resultFolderCreation;

            var SickNotes = MailboxHandler.FindAllSickNoteMailsInMailBox(Application);
            var SickNotesListDataSource = MailboxHandler.CreateDataSourceForListBox(SickNotes);

            if (_IsFirstStartup)
            {
                var FirstStartupForm = new StartupInfoForm();
                var DialogResult = FirstStartupForm.ShowDialog();

                if (SickNotes.Count > 0)
                {
                    var ManualForm = new ManuallyProcessedEmailsForm();
                    ManualForm.SickNoteListBox.DataSource = SickNotesListDataSource;
                    ManualForm.ManagerInfoLabel.Font = new Font("Arial", 9);
                    ManualForm.SickNoteListBox.Font = new Font("Arial", 11);
                    var ManualFormResult = ManualForm.ShowDialog();

                    if (ManualFormResult == DialogResult.OK)
                    {
                        MailboxHandler.MoveEmails(Application, SickNotes);
                        ManuallyProcessedEmails = true;
                    }
                }
            }

            if (SickNotes != null && SickNotes.Count > 0)
            {
                try
                {
                    if (!ManuallyProcessedEmails)
                    {
                        var form = new FoundNewSickNotesForm();
                        form.Name = "Easy-Absence-Manager";
                        form.SickNoteListBox.DataSource = SickNotesListDataSource;
                        form.ManagerInfoLabel.Text = $"Der EasyAbsenceManager hat {SickNotes.Count} Krankmeldungen gefunden. \nWollen sie den Prozess starten?";
                        form.ManagerInfoLabel.Font = new Font("Arial", 9);
                        form.SickNoteListBox.Font = new Font("Arial", 11);

                        DialogResult result = form.ShowDialog();

                        switch (result)
                        {
                            case DialogResult.OK:
                                AttachmentHandler.TryDownloadAndRenameAttachment(Application, SickNotes);
                                var EndForm = new EndForm();
                                EndForm.EndFormLabel.Text = "Die Anhänge wurden erfolgreich verschoben.\nSie können dieses Fenster nun schließen.";
                                EndForm.ShowDialog();
                                return;

                            case DialogResult.Cancel:
                                Application.Session.Logoff();
                                return;

                            default:
                                Application.Session.Logoff();
                                return;

                        }
                    }
                  
                }
                catch (System.Exception ex)
                {
                    //_Log.WriteEntry(ex.StackTrace);
                }

            }
        }

        public Microsoft.Office.Interop.Outlook.Application GetInstance()
        {
            return Application;
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}