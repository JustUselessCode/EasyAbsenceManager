using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using EasyAbsenceManager.Forms;
using EasyAbsenceManager.Helper;
using EasyAbsenceManager.Handler;
using Microsoft.Extensions.Logging;
using Ribbon = Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Core;

namespace EasyAbsenceManager
{
    public partial class ThisAddIn
    {
        private readonly string _ApplicationName = "EasyAbsenceManager";
        private readonly string _ApplicationLongName = "EasyAbsenceManager-OutlookAddIn";
        private bool _IsFirstStartup;

        public static readonly ILogger _Log;

        protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new EasyAbsenceManagerRibbon();
        }

        public void ThisAddIn_Startup(object sender, System.EventArgs e)
        {   

            //_Log.Source = _ApplicationName;
            //if (!EventLog.SourceExists(_ApplicationName))
            //{
            //    EventLog.CreateEventSource(_ApplicationName, _ApplicationLongName);   
            //}

            var resultFolderCreation = MailboxHandler.CreateCompletionFolder(Application);
            _IsFirstStartup = !resultFolderCreation;

            var SickNotes = MailboxHandler.FindAllSickNoteMailsInMailBox(Application);
            var SickNotesListDataSource = MailboxHandler.CreateDataSourceForListBox(SickNotes);

            if (_IsFirstStartup)
            {
                var FirstStartupForm = new StartupInfoForm();
                var DialogResult = FirstStartupForm.ShowDialog();

                var ManualForm = new ManuallyProcessedEmailsForm();
                ManualForm.SickNoteListBox.DataSource = SickNotesListDataSource;
                var ManualFormResult = ManualForm.ShowDialog();

                if (ManualFormResult is DialogResult.OK)
                {
                    MailboxHandler.MoveEmails(Application, SickNotes);
                }
            }



            if (SickNotes != null && SickNotes.Count > 0)
            {
                try
                {
                    //TODO: Implement functionality for first time startup (If the Mails are still in the inbox but have already been processed manually)
                    var form = new FoundNewSickNotesForm();
                    form.Name = "Easy-Absence-Manager";
                    form.SickNoteListBox.DataSource = SickNotesListDataSource;
                    form.ManagerInfoLabel.Text = $"Der EasyAbsenceManager hat {SickNotes.Count} Krankmeldungen gefunden. \nWollen sie den Prozess starten?";
                    form.ManagerInfoLabel.Font = new System.Drawing.Font("Arial", 9);
                    form.SickNoteListBox.Font = new System.Drawing.Font("Arial", 11);

                    DialogResult result = form.ShowDialog();

                    switch (result)
                    {
                        case DialogResult.OK:
                            AttachmentHandler.TryDownloadAndRenameAttachment(Application, SickNotes);
                            return;

                        case DialogResult.Cancel:
                            Application.Session.Logoff();
                            return;

                        default:
                            Application.Session.Logoff();
                            return;

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